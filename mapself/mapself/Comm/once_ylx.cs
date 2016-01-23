using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Warehouse.Comm;

namespace mapself
{
    public class once_ylx
    {
        static byte[] cmd_byte_list_ylx = new byte[100];

        public static void main(int asrvid, string cmdid, byte[] cmd_byte)
        {
            make_it_run.sqlcmdid(cmdid);

            int i = 0;
            cmd_byte_list_ylx = cmd_byte;
            /// <summary>
            /// 写入数据库，作业编号，小车编号，开始时间(默认写入）
            /// </summary>
            //string sql33;
            //sql33 = "select * from wcs.wcs.wcs_asrv_postback where cmd_id="+cmdid;
            //DataTable dt33 = SQLConnaction.QuerySQL(sql33).Tables[0];
            //if(dt33.Rows.Count==0)
            //{
            //    string sql9;
            //    sql9 = "insert into wcs.wcs.wcs_asrv_postback(cmd_id,asrv_id) values(" + cmdid + "," + asrvid + ")";
            //    SQLConnaction.ExecuteSQL(sql9);
            //}
            

            //StringBuilder sb = new StringBuilder();
            //sb.AppendFormat("insert wcs.wcs.wcs_asrv_postback set cmd_id={0},asrv_id={1}", cmdid, asrvid);
            //SQLConnaction.ExecuteSQL(sb.ToString());

            /// <summary>
            /// 得到WCS_ASRV_TASK_COMMAND
            /// cmd_byte_task：字节数组，保存5AA5与 6AA6之间的命令
            /// </summary>
            int startNum = 0;
            int cmd_byte_task_length;
            for (int j = 0; j < cmd_byte_list_ylx.Length; j++)
            {
                if (cmd_byte_list_ylx[j] == 0x5A)
                {
                    startNum = j + 1;
                    break;
                }
                
            }
            cmd_byte_task_length = cmd_byte_list_ylx[startNum]+1;
            byte[] cmd_byte_task = new byte[cmd_byte_task_length];
            for (i = 0; i < cmd_byte_task.Length; i++)
            {
                cmd_byte_task[i] = cmd_byte_list_ylx[startNum + i];
            }
            /// <summary>
            /// 得到指令中每个阶段动作的起始坐标，也就是转折点
            /// int cmd_length：将命令分为四个字节一组，每组表示一个阶段动作
            /// int[] cmd_x，int[] cmd_y：字节数组，每个阶段动作的起始坐标
            /// </summary>
            int cmd_length = (cmd_byte_task.Length - 3) / 4;
            asrvlist.aslist[asrvlist.basrv[asrvid]].stepnum = cmd_length+1;
            int[] cmd_x = new int[cmd_length];
            int[] cmd_y = new int[cmd_length];
            int task_i = 5;
            
            for (i = 0; i < cmd_length; i++)
            {
                cmd_x[i] = cmd_byte_task[task_i];
                cmd_y[i] = cmd_byte_task[task_i + 1];
                asrvlist.aslist[asrvlist.basrv[asrvid]].taskx[i] = cmd_byte_task[task_i];
                asrvlist.aslist[asrvlist.basrv[asrvid]].tasky[i] = cmd_byte_task[task_i+1];
                if (i != 0) asrvlist.aslist[asrvlist.basrv[asrvid]].taskstep[i] =
                      asrvlist.aslist[asrvlist.basrv[asrvid]].taskstep[i - 1] + Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].taskx[i] - asrvlist.aslist[asrvlist.basrv[asrvid]].taskx[i - 1])
                      + Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].tasky[i] - asrvlist.aslist[asrvlist.basrv[asrvid]].tasky[i - 1]);
                task_i = task_i + 4;
            }
            asrvlist.aslist[asrvlist.basrv[asrvid]].taskstep[asrvlist.aslist[asrvlist.basrv[asrvid]].stepnum-1] = asrvlist.aslist[asrvlist.basrv[asrvid]].taskstep[asrvlist.aslist[asrvlist.basrv[asrvid]].stepnum - 2];
            asrvlist.aslist[asrvlist.basrv[asrvid]].taskx[cmd_length] = asrvlist.aslist[asrvlist.basrv[asrvid]].taskx[cmd_length - 1];
            asrvlist.aslist[asrvlist.basrv[asrvid]].tasky[cmd_length] = asrvlist.aslist[asrvlist.basrv[asrvid]].tasky[cmd_length - 1];
            /// <summary>
            /// 写入数据库,起始坐标，做数据统计用
            /// </summary>
            //string sql19;
            //sql19 = "update wcs.dbo.wcs_asrv_statistics set start_x=" + cmd_x[0] + ",start_y=" + cmd_y[0] + ",end_x=" + cmd_x[cmd_length - 1] + ",end_y=" + cmd_y[cmd_length - 1] + " where cmd_id=" + cmdid;
            //SQLConnaction.ExecuteSQL(sql19);
            for (i = 0; i < cmd_length - 1; i++)
            {
                if (cmd_x[i] == cmd_x[i + 1])
                {
                    if (cmd_y[i] > cmd_y[i + 1])
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].pathlen += cmd_y[i] - cmd_y[i + 1];
                    }
                    else if (cmd_y[i] < cmd_y[i + 1])
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].pathlen += cmd_y[i + 1] - cmd_y[i];
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (cmd_y[i] == cmd_y[i + 1])
                {
                    if (cmd_x[i] > cmd_x[i + 1])
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].pathlen += cmd_x[i] - cmd_x[i + 1];
                    }
                    else
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].pathlen += cmd_x[i + 1] - cmd_x[i];
                    }
                }
            }
            //加1：包括起点位置
            asrvlist.aslist[asrvlist.basrv[asrvid]].pathx[0] = cmd_x[0];
            asrvlist.aslist[asrvlist.basrv[asrvid]].pathy[0] = cmd_y[0];
            int road_length_buffer = 0;
            int road_length = 0;
            for (i = 0; i < cmd_length - 1; i++)
            {
                if (cmd_x[i] == cmd_x[i + 1])
                {
                    if (cmd_y[i] > cmd_y[i + 1])
                    {
                        road_length += cmd_y[i] - cmd_y[i + 1];
                        int t = 1;
                        for (int y = road_length_buffer; y < road_length; y++)
                        {
                            asrvlist.aslist[asrvlist.basrv[asrvid]].pathx[y + 1] = cmd_x[i];
                            asrvlist.aslist[asrvlist.basrv[asrvid]].pathy[y + 1] = cmd_y[i] - t;
                            t++;
                        }
                        road_length_buffer += cmd_y[i] - cmd_y[i + 1];

                    }
                    else if (cmd_y[i] < cmd_y[i + 1])
                    {
                        road_length = road_length + cmd_y[i + 1] - cmd_y[i];
                        int t = 1;
                        for (int y = road_length_buffer; y < road_length; y++)
                        {
                            asrvlist.aslist[asrvlist.basrv[asrvid]].pathx[y + 1] = cmd_x[i];
                            asrvlist.aslist[asrvlist.basrv[asrvid]].pathy[y + 1] = cmd_y[i] + t;
                            t++;
                        }
                        road_length_buffer += cmd_y[i + 1] - cmd_y[i];
                    }
                    else
                    {
                        continue;
                    }
                }//end if
                else if (cmd_y[i] == cmd_y[i + 1])
                {
                    if (cmd_x[i] > cmd_x[i + 1])
                    {
                        road_length += cmd_x[i] - cmd_x[i + 1];
                        int t = 1;
                        for (int y = road_length_buffer; y < road_length; y++)
                        {
                            asrvlist.aslist[asrvlist.basrv[asrvid]].pathx[y + 1] = cmd_x[i] - t;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].pathy[y + 1] = cmd_y[i];
                            t++;
                        }
                        road_length_buffer += cmd_x[i] - cmd_x[i + 1];

                    }
                    else
                    {
                        road_length += cmd_x[i + 1] - cmd_x[i];
                        int t = 1;
                        for (int y = road_length_buffer; y < road_length; y++)
                        {
                            asrvlist.aslist[asrvlist.basrv[asrvid]].pathx[y + 1] = cmd_x[i] + t;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].pathy[y + 1] = cmd_y[i];
                            t++;
                        }
                        road_length_buffer += cmd_x[i + 1] - cmd_x[i];
                    }
                }//end else if
            }
            asrvlist.aslist[asrvlist.basrv[asrvid]].pathx[asrvlist.aslist[asrvlist.basrv[asrvid]].pathlen] = cmd_x[cmd_length-1];
            asrvlist.aslist[asrvlist.basrv[asrvid]].pathy[asrvlist.aslist[asrvlist.basrv[asrvid]].pathlen] = cmd_y[cmd_length-1];

        }//end main
    }//end class
}//end namespace