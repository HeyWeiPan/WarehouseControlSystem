using mapself;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Timers;
using System.Web;

namespace Warehouse.Comm
{
      public class sqlwatcher  // 该函数待完善，考虑到模拟器具体需要什么功能而定
    {
          public static string sqlcmd_b_id, new_sqlcmd_b_id;
        static string sql,sqltoken;
        static DataTable dt, dtnew,dttoken;
        public static string Show_name = "??";
        public static byte[] cmd_byte_list = null;
        public static int asrvid,ctime=0;
        public static bool cmd_new_flag;
        public static int OnMoveAsrvNum = 0;
        private static string cmdid;
        private static int ii;
        public static void main()
        {
            cmd_new_flag = false;

            sql = "select top 1 * from wcs.wcs.wcs_cmd_Breakdown order by cmd_b_id desc";
            dt = SQLConnaction.QuerySQL(sql).Tables[0];
            if (dt.Rows.Count != 0) sqlcmd_b_id = dt.Rows[0]["cmd_b_id"].ToString();
            else sqlcmd_b_id = "0";


            Timer sqltimer1 = new Timer();
            sqltimer1.Elapsed += new ElapsedEventHandler(theout1);
            sqltimer1.Interval = 300;
            sqltimer1.AutoReset = true;
            sqltimer1.Enabled = true;
            
            //for (ii=0;ii<1000;ii++)theout1();//test用
                
        }

       static public void theout1(object source, ElapsedEventArgs e)
       //static public void theout1()
        {

            ctime++;

            int i,j,h;

            dt = SQLConnaction.QuerySQL(sql).Tables[0];
            if (dt.Rows.Count != 0) new_sqlcmd_b_id = dt.Rows[0]["cmd_b_id"].ToString();
            else new_sqlcmd_b_id = "0";

            
            cmd_new_flag = false;
            
            if (sqlcmd_b_id != new_sqlcmd_b_id) 
            {
                cmd_new_flag = true;

                string sql1 = "select * from wcs.wcs.wcs_cmd_Breakdown where cmd_b_id<=" + new_sqlcmd_b_id + " and cmd_b_id>" + sqlcmd_b_id;
                dtnew = SQLConnaction.QuerySQL(sql1).Tables[0];
                    
                int asrvid;
                
                //string temp,taskstring,cmdstring;                
                string temp;
                for (i = 0; i < dtnew.Rows.Count; i++) 
                {
                    h = 0;
                    if (dtnew.Rows[i]["cmd_type"].ToString() == "TASK")//如果指令类型是TASK
                    {
                        Show_name = "new!";

                        cmd_byte_list = (byte[])dtnew.Rows[i]["cmd_b_code"];

                        byte[] cmd_task_list = GetCmdTask(cmd_byte_list);//5A之后TASK指令部分
                        byte[] taskstring = gettask(cmd_task_list);//只包含坐标点，最后终点坐标再重复一次

                        cmdid = dtnew.Rows[i]["cmd_id"].ToString();

                        temp = dtnew.Rows[i]["asrv_id"].ToString();
                        int.TryParse(temp, out asrvid);

                        make_it_run.refresh(asrvid);//使用前刷新小车对象的一些属性

                        asrvlist.aslist[asrvlist.basrv[asrvid]].cmd_id = cmdid;

                        asrvlist.aslist[asrvlist.basrv[asrvid]].load_flag = get_task_type(cmd_task_list);

                        if (asrvlist.aslist[asrvlist.basrv[asrvid]].load_flag == true) asrvlist.aslist[asrvlist.basrv[asrvid]].max_velocity = asrv.max_velocity_unloaded;
                        else asrvlist.aslist[asrvlist.basrv[asrvid]].max_velocity = asrv.max_velocity_loaded;
                        OnMoveAsrvNum++;
                        //////////
                        asrvlist.aslist[asrvlist.basrv[asrvid]].task_id = cmd_task_list[2];
                        for (int ii = 0; ii < 8; ii++)
                        {
                            asrvlist.aslist[asrvlist.basrv[asrvid]].macAddress_cmd[ii] = cmd_byte_list[ii + 5];
                        }

                        once_ylx.main(asrvid, cmdid,cmd_byte_list);
                        make_it_run.main(taskstring, asrvid);
                    }//end if TASK
                    
                 }//end for i
                sqlcmd_b_id = new_sqlcmd_b_id;
             }//end if !=  
            

            ////////////////////////////////////////////////////////////////定时读TOKEN    
            for (j = 0; j < asrvlist.asrv_num; j++)
            //for (j = 4; j < 5; j++)//tiaoshi
            {
                if ((asrvlist.aslist[j].cmd_id!=null)&&(asrvlist.aslist[j].stop_flag==false))
                {
                    //asrvlist.aslist[asrvlist.basrv[9]].pathlen = 8;//////
                    sqltoken = "select * from wcs.wcs.wcs_cmd_Breakdown where cmd_id =" + asrvlist.aslist[j].cmd_id+" and cmd_type='TOKEN'";
                    dttoken = SQLConnaction.QuerySQL(sqltoken).Tables[0];
                    if (dttoken.Rows.Count == 0) continue;
                    byte[] sqlcmd_token_bytelist = new byte[100];
                    sqlcmd_token_bytelist = (byte[])dttoken.Rows[0]["cmd_b_code"];

                    //找到5A,取出TOKEN值赋值给cubenum_token
                    for (int k = 0; k< sqlcmd_token_bytelist.Length; k++)
                    {
                        if (sqlcmd_token_bytelist[k] == 0x5A)
                        {
                            asrvlist.aslist[j].cubenum_token = (int)sqlcmd_token_bytelist[k + 3];
                            asrvlist.aslist[j].cubenum_token--;
                            if (asrvlist.aslist[j].cubenum_token < 0) asrvlist.aslist[j].cubenum_token = 0;
                            if (asrvlist.aslist[j].cubenum_token > asrvlist.aslist[j].pathlen)
                                asrvlist.aslist[j].cubenum_token = asrvlist.aslist[j].pathlen;
                            break;
                        }
                    }
                    //////////
                    //判断是不是新token
                    //if (asrvlist.aslist[j].cubenum_token_old == -1) asrvlist.aslist[j].cubenum_token_old = asrvlist.aslist[j].cubenum_token;
                    if (asrvlist.aslist[j].cubenum_token_old != asrvlist.aslist[j].cubenum_token)
                    {
                        int xnum_token = 0, ynum_token = 0;
                        Getxy(asrvlist.aslist[j].asrv_id, asrvlist.aslist[j].cubenum_token, ref xnum_token, ref ynum_token);
                        asrvlist.aslist[j].token_xnum = xnum_token;
                        asrvlist.aslist[j].token_ynum = ynum_token;
                        Updateasrv(asrvlist.aslist[j].asrv_id);
                    }
                    asrvlist.aslist[j].cubenum_token_old = asrvlist.aslist[j].cubenum_token;
                    
                }//end if asrv onmove
            }// end for j

        }//end the out
        public static double Getcelllength(int asrvid)
        {
            int whindex, floorindex,xmid,ymid,xstart,ystart,xend,yend;
            whindex = warehouselist.bwh[asrvlist.aslist[asrvlist.basrv[asrvid]].asrvwh_num];
            floorindex = warehouselist.bwh[asrvlist.aslist[asrvlist.basrv[asrvid]].asrvfloor_num];

            xstart = asrvlist.aslist[asrvlist.basrv[asrvid]].taskx[asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum];
            ystart = asrvlist.aslist[asrvlist.basrv[asrvid]].tasky[asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum];
            xend = asrvlist.aslist[asrvlist.basrv[asrvid]].taskx[asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum+1];
            yend = asrvlist.aslist[asrvlist.basrv[asrvid]].tasky[asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum+1];
            xmid = (xstart + xend) / 2;
            ymid = (ystart + yend) / 2;

            if (warehouselist.whlist[whindex].floorlist[floorindex].celllist[xmid-1][ymid-1].celltype_code == 0)
                return 61.9693;
            if (warehouselist.whlist[whindex].floorlist[floorindex].celllist[xmid-1][ymid-1].celltype_code == 3)
                return 38.1972;
            return 0;
        }
        static void Updateasrv(int asrvid)
        {
           

            asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length=Getcelllength(asrvid);

            int p;
            p = asrvlist.aslist[asrvlist.basrv[asrvid]].taskstep[asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum + 1];
            if (asrvlist.aslist[asrvlist.basrv[asrvid]].cubenum_token<p)//如果token小于转折点
            {
                asrvlist.aslist[asrvlist.basrv[asrvid]].tflag = 1;
                asrvlist.aslist[asrvlist.basrv[asrvid]].start_x=asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num;
                asrvlist.aslist[asrvlist.basrv[asrvid]].start_y = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num;
                asrvlist.aslist[asrvlist.basrv[asrvid]].end_x = asrvlist.aslist[asrvlist.basrv[asrvid]].token_xnum;
                asrvlist.aslist[asrvlist.basrv[asrvid]].end_y = asrvlist.aslist[asrvlist.basrv[asrvid]].token_ynum;
                asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination = make_it_run.get_distance(asrvid);
                
            }
            else//依旧以转折点为小车当前终点
            {
                asrvlist.aslist[asrvlist.basrv[asrvid]].tflag = 2;
                asrvlist.aslist[asrvlist.basrv[asrvid]].start_x = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num;
                asrvlist.aslist[asrvlist.basrv[asrvid]].start_y = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num;
                asrvlist.aslist[asrvlist.basrv[asrvid]].end_x = asrvlist.aslist[asrvlist.basrv[asrvid]].taskx[asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum + 1];
                asrvlist.aslist[asrvlist.basrv[asrvid]].end_y = asrvlist.aslist[asrvlist.basrv[asrvid]].tasky[asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum + 1];
                asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination = make_it_run.get_distance(asrvid);

            }
            make_it_run.updateasrvdirection(asrvid);
            /////更改小车状态
            if (asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag == 3)//当小车当前在状态3时
            {
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination > 69.5)//距离大于70r
                    asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 1;
            }
            else if (asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag == 4)//当小车当前在状态4时
            {
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination > 69.5)//距离大于70r
                    asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 1;
                else//距离小于70r
                {
                    double v;
                    v = System.Math.Sqrt((asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination - 7) * 2 * asrv.acceleration * asrv.deceleration1 / (asrv.acceleration + asrv.deceleration1) + 289);
                    if (v > asrvlist.aslist[asrvlist.basrv[asrvid]].max_velocity - 0.5)//最高速度大于小车最大速度
                        asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 1;
                    else//最高速度小于小车最大速度
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].vmax4 = v;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_xum3 = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_yum3 = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_velocity3 = asrvlist.aslist[asrvlist.basrv[asrvid]].velocity;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_time3 = make_it_run.c_time;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 7;
                    }
                }
            }//end else state 4

            else if (asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag == 5)//当小车当前在状态5时
            {
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination > 69.5)//距离大于70r
                    asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 1;
                else//距离小于70r
                {
                    double v;
                    v = System.Math.Sqrt((asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination - 7 + asrvlist.aslist[asrvlist.basrv[asrvid]].velocity * asrvlist.aslist[asrvlist.basrv[asrvid]].velocity / 2 / asrv.acceleration + 289 / 2 / asrv.deceleration1) * 2 * asrv.acceleration * asrv.deceleration1 / (asrv.acceleration + asrv.deceleration1));
                    if (v > asrvlist.aslist[asrvlist.basrv[asrvid]].max_velocity - 0.5)//最高速度大于小车最大速度
                        asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 1;
                    else//最高速度小于小车最大速度
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].vmax4 = v;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_xum3 = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_yum3 = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_velocity3 = asrvlist.aslist[asrvlist.basrv[asrvid]].velocity;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_time3 = make_it_run.c_time;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 7;
                    }
                }
            }
            
            asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_flag = true;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_time = make_it_run.c_time;
            asrvlist.aslist[asrvlist.basrv[asrvid]].Statusflag = 1;
            if (make_it_run.timer_flag == 0)//timer_flag判断timer是否已经启动
            {
                make_it_run.c_time = 0;
                make_it_run.set_up_timer();
                make_it_run.timer_flag = 1;
            }
            ii = 999;
           //make_it_run.fortest();
        }
        public static void Getxy(int asrvid, int token_num, ref int xnum, ref int ynum)
        {
            xnum = asrvlist.aslist[asrvlist.basrv[asrvid]].pathx[token_num];
            ynum = asrvlist.aslist[asrvlist.basrv[asrvid]].pathy[token_num];

        }

         public static byte[] GetCmdTask(byte[] cmd_byte)//得到帧长度到异或校验（不包括）的字节数组
        {
            int startNum = 0;
            int cmd_byte_task_length;
            for (int j = 0; j < cmd_byte.Length; j++)
            {
                if (cmd_byte[j] == 0x5A)
                {
                    startNum = j + 1;
                    break;
                }               
            }
            cmd_byte_task_length = cmd_byte[startNum]+1;
            byte[] b = new byte[cmd_byte_task_length];
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = cmd_byte[startNum + i];
            }
            return b;
        }
        //static bool get_task_type(string tstring)
        //{
        //    int i=0;
        //    while (i < tstring.Length)
        //    {
        //        if ((tstring[i] == '6') && (tstring[i + 1] == 'A') && (tstring[i + 2] == 'A') && (tstring[i + 3] == '6')) break;
        //        i++;
        //    }
        //    i = i - 10;
        //    if (tstring[i] == 'C') return true;
        //    else return false;

        //}//end get_task_type
         public static bool get_task_type(byte[] cmd_byte)
        {
            byte b = cmd_byte[cmd_byte.Length - 5];
            int bit2 = GetbitValue(b, 2);
            int bit3 = GetbitValue(b, 3);

            if (bit2 == 0 && bit3 == 1) return true;//下降，说明载货
            else if (bit2 == 1 && bit3 == 1) return false;//抬升，说明空载
            else return false;
        }
          private static int GetbitValue(byte input,int index)//获取数据中某一位的值，index为要获取的第几位序号，从0开始
          {
              if(index>sizeof(byte))
              {
                  return -1;
              }
              int value = input << (sizeof(byte) - 1 - index);
              value = value >> (sizeof(byte) - 1);
              return value;
          }
        //static private string gettask(string tstring) 
        //{
        //    bool flag, st_flag = false; ;
        //    string ss="";
        //    int i;

        //    i=0;
            
        //    while (i<tstring.Length)
        //    {
        //        flag = false;
        //        if ((i+3<tstring.Length)&&(tstring[i]=='5')&&(tstring[i+1]=='A')&&(tstring[i+2]=='A')&&(tstring[i+3]=='5'))
        //        {
        //            i=i+8;
        //            flag=true;
        //            st_flag = true;
        //        }
        //        if ((st_flag==true)&&(i+7<tstring.Length)&&(tstring[i]=='4')&&(tstring[i+1] =='9'))
        //        {
        //            ss=ss + tstring[i+4] + tstring[i+5] + tstring[i+6] + tstring[i+7];
        //            i=i+8;
        //            flag=true;
        //        }
        //        if ((st_flag == true)&&(i + 7 < tstring.Length) && (tstring[i] == '4') && (tstring[i + 1] == '3'))
        //        {
        //            ss=ss+tstring[i+4]+tstring[i+5]+tstring[i+6]+tstring[i+7];
        //            i=i+8;
        //            flag=true;
        //        }
        //        if ((st_flag == true) && (i + 7 < tstring.Length) && (tstring[i] == '4') && (tstring[i + 1] == '6'))
        //        {
        //            ss=ss+tstring[i+4]+tstring[i+5]+tstring[i+6]+tstring[i+7];
        //            i=i+8;
        //            flag=true;
        //        }
        //        if ((st_flag == true) && (i + 7 < tstring.Length) && (tstring[i] == '4') && (tstring[i + 1] == 'C'))
        //        {
        //            ss = ss + tstring[i+4]+tstring[i+5]+tstring[i+6]+tstring[i+7];
        //            i = i+8;
        //            flag = true;
        //        }
        //        if ((st_flag == true) && (i + 7 < tstring.Length) && (tstring[i] == 'C') && (tstring[i + 1] == '0'))
        //        {
        //            ss = ss+tstring[i+4]+tstring[i+5]+tstring[i+6]+tstring[i+7];
        //            i = i+8;
        //            flag = true;
        //        }
        //        if ((st_flag == true) && (i + 7 < tstring.Length) && (tstring[i] == 'E') && (tstring[i + 1] == '0'))
        //        {
        //            ss = ss + tstring[i + 4] + tstring[i + 5] + tstring[i + 6] + tstring[i + 7];
        //            i = i + 8;
        //            flag = true;
        //        }

        //        if (flag == false) i++;
        //    }
        //return ss;
        //}//end gettask
          static public byte[] gettask(byte[] cmd_byte)//得到每个转折点坐标组成的字符数组
          {
              byte[] b = new byte[(cmd_byte.Length - 3) / 2+2];
              int xy_start=5;
              for(int i=0;i<b.Length-2;i=i+2)
              {
                  b[i] = cmd_byte[xy_start];
                  b[i + 1] = cmd_byte[xy_start + 1];
                  xy_start = xy_start + 4;
              }
              b[b.Length - 2] = cmd_byte[cmd_byte.Length - 2];
              b[b.Length - 1] = cmd_byte[cmd_byte.Length - 1];
              return b;
          }

        //public static string aaa(byte[] bbb)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (byte b in bbb)
        //    {
        //        sb.Append(b > 15 ? Convert.ToString(b, 16) : '0' + Convert.ToString(b, 16));
        //    }
        //    return sb.ToString();
        //}//end aaa
        
     }//endclass

    
}//endnamespace