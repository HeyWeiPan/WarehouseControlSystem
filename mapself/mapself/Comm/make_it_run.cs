using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Web;
using WCSServer;


namespace Warehouse.Comm
{
    public class make_it_run//主运动函数
    {
        public static int OnMoveNum = 0;
        public static int c_time;

        const int timer_interval=500;

        public static int timer_flag=0;

        public static string sqlcmd_id=null ;
        public static void sqlcmdid(string cmdid)
        {
            sqlcmd_id = cmdid;
        }

        public static void set_up_timer()//用于更新小车状态的timer
        {
            Timer sqltimer = new Timer();
            sqltimer.Elapsed += new ElapsedEventHandler(theout);
            sqltimer.Interval = timer_interval;
            sqltimer.AutoReset = true;
            sqltimer.Enabled = true;
        }//endsetuptimer
        //public static void fortest()
        //{
        //    int i;
        //    for (i = 0; i < 1000; i++)
        //        theout();
        //}
         static public void theout(object source, ElapsedEventArgs e)
            //static public void theout()//调试用
        {
            int i;

            c_time++;

            for (i=0;i<asrvlist.asrv_num;i++) update_asrv(asrvlist.aslist[i].asrv_id); //触发事件为更新所有小车状态
            //for (i = 4; i < 5; i++) update_asrv(asrvlist.aslist[i].asrv_id); //调试用

        }//endtheout
        public static void main(byte[] taskbyte, int asrvid)//tstring为任务coderi
        {
            //分解任务code存到小车对象
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_x = asrvlist.aslist[asrvlist.basrv[asrvid]].pathx[0];
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_y = asrvlist.aslist[asrvlist.basrv[asrvid]].pathy[0];
 
            //分解任务code存到小车对象

            asrvlist.aslist[asrvlist.basrv[asrvid]].end_x = asrvlist.aslist[asrvlist.basrv[asrvid]].pathx[1];
            asrvlist.aslist[asrvlist.basrv[asrvid]].end_y = asrvlist.aslist[asrvlist.basrv[asrvid]].pathy[1];

            initasrv(asrvid);//使用前初始化小车对象

            asrvlist.aslist[asrvlist.basrv[asrvid]].task_string = taskbyte;

            //asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_flag = true;//onmove_flag代表小车是否在工作

            //以上是执行一条指令前对小车的一些初始化

            
              
        }//end main
        
        static void update_asrv(int asrvid) //该过程为更新特点小车状态的过程
        {
            double t;
            int whindex,floorindex;
            bool flag = false; //flag标记用于保证一次只进入一种阶段，见下
            double t3, t5,t7;

            //asrvlist.aslist[asrvlist.basrv[9]].pathlen = 8;//////////
            if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_flag == false) return; // 小车不在运行就退出

            asrvlist.aslist[asrvlist.basrv[asrvid]].cell_pass = GetCellPassNum(asrvid);
            if ((asrvlist.aslist[asrvlist.basrv[asrvid]].cubenum_token - asrvlist.aslist[asrvlist.basrv[asrvid]].cell_pass <= 3)&&(asrvlist.aslist[asrvlist.basrv[asrvid]].Statusflag==1))
                asrvlist.aslist[asrvlist.basrv[asrvid]].Statusflag = 2;

            
            t = (c_time - asrvlist.aslist[asrvlist.basrv[asrvid]].start_time+0.0) * timer_interval / 1000;

            if (asrvlist.aslist[asrvlist.basrv[asrvid]].stop_flag==true)//小车是否在停车5s
            {
                if (c_time - asrvlist.aslist[asrvlist.basrv[asrvid]].stop_start_time >= 5)//此处 25 应该为 5000/timer_interval
                {//停车结束时
                    asrvlist.aslist[asrvlist.basrv[asrvid]].stop_flag = false;//stop_flag代表小车是否在进行停车动作
                    asrvlist.aslist[asrvlist.basrv[asrvid]].stop_start_time = 0;
                    asrvlist.aslist[asrvlist.basrv[asrvid]].start_time = c_time;//start_time代表小车进行某段前进运动的开始时间
                    asrvlist.aslist[asrvlist.basrv[asrvid]].stop_flag = false;
                    if (asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag == 6)
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_flag = false;//任务结束，标记停车
                        asrvlist.aslist[asrvlist.basrv[asrvid]].Statusflag = 3;
                        ClearAsrvStatus(asrvid);                      

                        //////加入end_time
                        ////int idcmdid=Convert.ToInt32(asrvlist.aslist[asrvlist.basrv[asrvid]].cmd_id);
                        //string sql_endtime;
                        //sql_endtime = "update wcs.wcs.wcs_asrv_postback set end_date=getdate() where cmd_id=" + sqlcmd_id;
                        //SQLConnaction.ExecuteSQL(sql_endtime);

                        //string sql_worktime;
                        //sql_worktime = "update wcs.wcs.wcs_asrv_postback set worktime=datediff(second,start_date,end_date)  where cmd_id=" + sqlcmd_id;
                        //SQLConnaction.ExecuteSQL(sql_worktime);

                        sqlwatcher.OnMoveAsrvNum--;
                    }
                    return;
                }
                else return;
            }

            if ((flag==false)&&(asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag==1)) //state1，小车加速的情况
            {
                flag = true;

                asrvlist.aslist[asrvlist.basrv[asrvid]].velocity = t * asrv.acceleration; //更新小车当前速度

                if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_increase == true) //更新小车坐标
                    asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num = 0.5 * asrv.acceleration * t * t / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length + asrvlist.aslist[asrvlist.basrv[asrvid]].start_x;
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_decrease == true)
                    asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num = -0.5 * asrv.acceleration * t * t / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length + asrvlist.aslist[asrvlist.basrv[asrvid]].start_x;
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_increase == true)
                    asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num = 0.5 * asrv.acceleration * t * t / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length + asrvlist.aslist[asrvlist.basrv[asrvid]].start_y;
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_decrease == true)
                    asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num = -0.5 * asrv.acceleration * t * t / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length + asrvlist.aslist[asrvlist.basrv[asrvid]].start_y;

                asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination =//更新距离终点的距离
                    Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_x - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num) * asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length +
                     Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_y - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num) * asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;


                if (((Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination - 70) < asrvlist.aslist[asrvlist.basrv[asrvid]].max_velocity * timer_interval / 1000) || (asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination < 70)) && (asrvlist.aslist[asrvlist.basrv[asrvid]].velocity > 17))
                {//到了距离终点70r的位置 且速度大于17 进入state 3，跳过了state 2 此为特殊情况
                    if (asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag == 1)
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 3;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_velocity1 = asrvlist.aslist[asrvlist.basrv[asrvid]].velocity;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].de_start_time1 = c_time;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_xum1 = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_yum1 = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num;
                    }
                }
                if ((asrvlist.aslist[asrvlist.basrv[asrvid]].velocity >= asrvlist.aslist[asrvlist.basrv[asrvid]].max_velocity)&&(asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination >70))
                {//若达到最大速度则进入匀速阶段 进入state 2
                    if (asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag == 1)
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 2;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].velocity = asrvlist.aslist[asrvlist.basrv[asrvid]].max_velocity;
                    }
                }

                if (((17 - asrvlist.aslist[asrvlist.basrv[asrvid]].velocity < asrv.deceleration1*timer_interval/1000) || (asrvlist.aslist[asrvlist.basrv[asrvid]].velocity > 17)) && (asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination < 70))
                {//距离小于70的情况，当速度达到17rs 进入state 4
                    if (asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag == 1)
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 4;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].velocity = 17;
                    }
                }

                
                
            }//end state 1

            if ((flag==false)&&(asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag==2))//state 2,第一次匀速阶段
            {
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination<70) asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 3;
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag != 2) goto c3;
                //上两句为预防错误进入state 2 的处理
                flag = true;

                if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_increase==true) //更新小车坐标
                    asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num + asrvlist.aslist[asrvlist.basrv[asrvid]].max_velocity * timer_interval / 1000 / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_decrease == true)
                    asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num - asrvlist.aslist[asrvlist.basrv[asrvid]].max_velocity * timer_interval / 1000/asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_increase == true) 
                    asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num + asrvlist.aslist[asrvlist.basrv[asrvid]].max_velocity * timer_interval / 1000/asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_decrease == true)
                    asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num - asrvlist.aslist[asrvlist.basrv[asrvid]].max_velocity * timer_interval / 1000/asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                  
                asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination =//更新距离终点的距离
                   Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_x - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num) * asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length +
                    Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_y - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num) * asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;

                if ((Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination - 70) < asrvlist.aslist[asrvlist.basrv[asrvid]].max_velocity*timer_interval/1000) || (asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination < 70))
                {//判断是否从state 2进入state 3
                    asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 3;
                    asrvlist.aslist[asrvlist.basrv[asrvid]].start_velocity1 = asrvlist.aslist[asrvlist.basrv[asrvid]].velocity;
                    asrvlist.aslist[asrvlist.basrv[asrvid]].de_start_time1 = c_time;
                    asrvlist.aslist[asrvlist.basrv[asrvid]].start_xum1 = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num;
                    asrvlist.aslist[asrvlist.basrv[asrvid]].start_yum1 = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num;
                }
            }//end state2

 c3:           if ((flag==false)&&(asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag==3))//state 3,第一次减速阶段
            {
                flag = true;

                t3 = (c_time - asrvlist.aslist[asrvlist.basrv[asrvid]].de_start_time1 + 0.0) * timer_interval / 1000;

                asrvlist.aslist[asrvlist.basrv[asrvid]].velocity = 
                    asrvlist.aslist[asrvlist.basrv[asrvid]].velocity -timer_interval* asrv.deceleration1/1000; //更新小车当前速度

                if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_increase == true) //更新小车坐标
                    asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num = 
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_xum1 +
                        (asrvlist.aslist[asrvlist.basrv[asrvid]].start_velocity1 * t3 -
                        0.5 * asrv.deceleration1 * t3 * t3) / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_decrease == true) 
                    asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num =
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_xum1 -
                        (asrvlist.aslist[asrvlist.basrv[asrvid]].start_velocity1 * t3 -
                        0.5 * asrv.deceleration1 * t3 * t3)/asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_increase == true) 
                    asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num =
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_yum1 +
                        (asrvlist.aslist[asrvlist.basrv[asrvid]].start_velocity1 * t3 -
                        0.5 * asrv.deceleration1 * t3 * t3) / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_decrease == true)
                    asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num =
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_yum1 -
                        (asrvlist.aslist[asrvlist.basrv[asrvid]].start_velocity1 * t3 -
                        0.5 * asrv.deceleration1 * t3 * t3) / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                
               
                asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination =//更新距离终点的距离
                   Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_x - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num) * asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length +
                    Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_y - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num) * asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;

                if ((Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination) - 7 < 17.0 * timer_interval / 1000) || (asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination < 7))
                {//进入state 5 直接跳过state 4
                    if (asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag == 3)
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 5;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].de_start_time2 = c_time;
                    }
                }

                if ((asrvlist.aslist[asrvlist.basrv[asrvid]].velocity - 17 < asrv.deceleration1 * timer_interval / 1000) || (asrvlist.aslist[asrvlist.basrv[asrvid]].velocity < 17))
                {//进入state 4
                    if (asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag == 3)
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].velocity = 17;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 4;
                    }
                }
            }//end state 3

            if ((flag==false)&&(asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag==4))//state 4,第二次匀速阶段
            {
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination < 7) asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 5;
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag != 4) goto c5;
                //以上两句为防止错误进入state 4 的处理
                flag = true;

                 if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_increase==true) //更新小车坐标
                     asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num + 17.0 * timer_interval / 1000 / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                 if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_decrease == true)
                     asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num - 17.0 * timer_interval / 1000 / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                 if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_increase == true) 
                     asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num + 17.0 * timer_interval / 1000/asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                 if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_decrease == true) 
                     asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num - 17.0 * timer_interval / 1000/asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                

                 asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination =//更新距离终点的距离
                    Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_x - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num) * asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length +
                     Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_y - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num) * asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
               
                if ((Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination) - 7 < 17.0*timer_interval/1000) || (asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination < 7))
                {
                    asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 5;
                    asrvlist.aslist[asrvlist.basrv[asrvid]].de_start_time2 = c_time;
                    asrvlist.aslist[asrvlist.basrv[asrvid]].start_xum2 = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num;
                    asrvlist.aslist[asrvlist.basrv[asrvid]].start_yum2 = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num;
                }
            }//end state 4

c5:         if ((flag == false) && (asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag == 5))//state5,第二次减速阶段
            {
                flag = true;
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].velocity==0) goto v0;
                t5 = (c_time - asrvlist.aslist[asrvlist.basrv[asrvid]].de_start_time2 + 0.0) * timer_interval / 1000;

                asrvlist.aslist[asrvlist.basrv[asrvid]].velocity =
                   asrvlist.aslist[asrvlist.basrv[asrvid]].velocity - timer_interval * asrv.deceleration2 / 1000; //更新小车当前速度

                if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_increase == true) //更新小车坐标
                    asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num =
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_xum2 +
                        (17.0 * t5 -
                        0.5 * asrv.deceleration2 * t5 * t5) / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_decrease == true)
                    asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num =
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_xum2 -
                        (17.0 * t5 -
                        0.5 * asrv.deceleration2 * t5 * t5) / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_increase == true)
                    asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num =
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_yum2 +
                        (17.0 * t5 -
                        0.5 * asrv.deceleration2 * t5 * t5) / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_decrease == true)
                    asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num =
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_yum2 -
                        (17.0 * t5 -
                        0.5 * asrv.deceleration2 * t5 * t5) / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                
                
                asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination =//更新距离终点的距离
                    Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_x - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num) * asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length +
                     Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_y - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num) * asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
               
v0:                if ((asrvlist.aslist[asrvlist.basrv[asrvid]].velocity < 0.1) || (asrvlist.aslist[asrvlist.basrv[asrvid]].velocity < 0))
                {
                    asrvlist.aslist[asrvlist.basrv[asrvid]].velocity = 0;
                    if (asrvlist.aslist[asrvlist.basrv[asrvid]].tflag == 1) asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_flag = false;
                   
                    //////////////////
                    if (asrvlist.aslist[asrvlist.basrv[asrvid]].stepnum-asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum>=2)
                    {   
                        //修正位置
                        asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num=asrvlist.aslist[asrvlist.basrv[asrvid]].end_x;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num=asrvlist.aslist[asrvlist.basrv[asrvid]].end_y;
                        //重置startx，y
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_x = asrvlist.aslist[asrvlist.basrv[asrvid]].end_x;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_y = asrvlist.aslist[asrvlist.basrv[asrvid]].end_y;
                        //重置endx，y
                        if (asrvlist.aslist[asrvlist.basrv[asrvid]].tflag==2) asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum++;
                        if (asrvlist.aslist[asrvlist.basrv[asrvid]].cubenum_token >= asrvlist.aslist[asrvlist.basrv[asrvid]].taskstep[asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum + 1])
                        { //如果token步数大于下一截终点步数     
                            asrvlist.aslist[asrvlist.basrv[asrvid]].end_x = asrvlist.aslist[asrvlist.basrv[asrvid]].taskx[asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum + 1];
                            asrvlist.aslist[asrvlist.basrv[asrvid]].end_y = asrvlist.aslist[asrvlist.basrv[asrvid]].tasky[asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum + 1];
                         }
                        else
                        {
                            asrvlist.aslist[asrvlist.basrv[asrvid]].end_x = asrvlist.aslist[asrvlist.basrv[asrvid]].token_xnum;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].end_y = asrvlist.aslist[asrvlist.basrv[asrvid]].token_ynum;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].tflag =1;
                        }
                        


                        //如果到了最后的抬升下降指令
                        if ((asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num == asrvlist.aslist[asrvlist.basrv[asrvid]].taskx[asrvlist.aslist[asrvlist.basrv[asrvid]].stepnum-1]) &&
                            (asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num == asrvlist.aslist[asrvlist.basrv[asrvid]].tasky[asrvlist.aslist[asrvlist.basrv[asrvid]].stepnum-1]))
                        {
                            if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_flag == true) 
                                asrvlist.aslist[asrvlist.basrv[asrvid]].stop_flag = true;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].stop_start_time = c_time;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 6;
                        }
                        else
                        {
                            //停车，更新小车状态
                            refresh(asrvid);
                            //重置start time
                            initasrv(asrvid);
                            if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_flag==true) 
                                asrvlist.aslist[asrvlist.basrv[asrvid]].stop_flag = true;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].stop_start_time = c_time;
                        }//end else startx==endx starty==endy
                        
                    }//end if stepnum c_stepnum


                    updatestepnum(asrvid);
                    //if (asrvlist.aslist[asrvlist.basrv[asrvid]].tflag == 2) asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum++;
                }

            }//end state 5

            if ((flag == false) && (asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag == 7))//state7
            {
                flag = true;
                double s2;
                s2=(asrvlist.aslist[asrvlist.basrv[asrvid]].vmax4*asrvlist.aslist[asrvlist.basrv[asrvid]].vmax4-289)/2/asrv.deceleration1;

                t7 = (c_time - asrvlist.aslist[asrvlist.basrv[asrvid]].start_time3 + 0.0) * timer_interval / 1000;

                if (asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination>s2+7-0.1)//处于加速阶段
                {
                    asrvlist.aslist[asrvlist.basrv[asrvid]].velocity = asrvlist.aslist[asrvlist.basrv[asrvid]].velocity + timer_interval * asrv.acceleration / 1000;

                    if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_increase == true) //更新小车坐标
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num = asrvlist.aslist[asrvlist.basrv[asrvid]].start_xum3 + (asrvlist.aslist[asrvlist.basrv[asrvid]].start_velocity3 * t7 + 0.5 * asrv.acceleration * t7 * t7) / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                        if ((asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num >= asrvlist.aslist[asrvlist.basrv[asrvid]].end_x) || (Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_x - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num) < timer_interval / 1000 * asrvlist.aslist[asrvlist.basrv[asrvid]].velocity))
                        {
                            asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num = asrvlist.aslist[asrvlist.basrv[asrvid]].end_x;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].velocity = 0;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 5;
                        }
                    }
                    if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_decrease == true)
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num = asrvlist.aslist[asrvlist.basrv[asrvid]].start_xum3 - (asrvlist.aslist[asrvlist.basrv[asrvid]].start_velocity3 * t7 + 0.5 * asrv.acceleration * t7 * t7) / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;    
                        if ((asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num <= asrvlist.aslist[asrvlist.basrv[asrvid]].end_x) || (Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_x - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num) < timer_interval / 1000 * asrvlist.aslist[asrvlist.basrv[asrvid]].velocity))
                        {
                            asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num = asrvlist.aslist[asrvlist.basrv[asrvid]].end_x;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].velocity = 0;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 5;
                        }
                    }
                        
                    if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_increase == true)
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num = asrvlist.aslist[asrvlist.basrv[asrvid]].start_yum3 + (asrvlist.aslist[asrvlist.basrv[asrvid]].start_velocity3 * t7 + 0.5 * asrv.acceleration * t7 * t7) / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;   
                        if ((asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num >= asrvlist.aslist[asrvlist.basrv[asrvid]].end_y) || (Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_y - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num) < timer_interval / 1000 * asrvlist.aslist[asrvlist.basrv[asrvid]].velocity))
                        {
                            asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num = asrvlist.aslist[asrvlist.basrv[asrvid]].end_y;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].velocity = 0;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 5;
                        }
                    }
                        
                    if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_decrease == true)
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num = asrvlist.aslist[asrvlist.basrv[asrvid]].start_yum3 - (asrvlist.aslist[asrvlist.basrv[asrvid]].start_velocity3 * t7 + 0.5 * asrv.acceleration * t7 * t7) / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                        if ((asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num <= asrvlist.aslist[asrvlist.basrv[asrvid]].end_y) || (Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_y - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num) < timer_interval / 1000 * asrvlist.aslist[asrvlist.basrv[asrvid]].velocity))
                        {
                            asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num = asrvlist.aslist[asrvlist.basrv[asrvid]].end_y;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].velocity = 0;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 5;
                        }
                    }
                       
                    asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination =//更新距离终点的距离
                   Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_x - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num) * asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length +
                    Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_y - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num) * asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;

                    if ((Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination - s2 - 7) < asrvlist.aslist[asrvlist.basrv[asrvid]].vmax4 * timer_interval / 1000)||(asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination - s2 - 7<0))
                        asrvlist.aslist[asrvlist.basrv[asrvid]].tmax = c_time;
                }
                else//处于减速状态
                {
                    double t4;
                    t4 = (c_time - asrvlist.aslist[asrvlist.basrv[asrvid]].tmax)  * timer_interval / 1000;
                    asrvlist.aslist[asrvlist.basrv[asrvid]].velocity = asrvlist.aslist[asrvlist.basrv[asrvid]].vmax4 - t4 * asrv.deceleration1;

                    if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_increase == true) //更新小车坐标
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num = (s2 + 7 + asrvlist.aslist[asrvlist.basrv[asrvid]].vmax4 * t4 - 0.5 * asrv.deceleration1 * t4 * t4) / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                        if ((asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num >= asrvlist.aslist[asrvlist.basrv[asrvid]].end_x) || (Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_x - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num) < timer_interval / 1000 * asrvlist.aslist[asrvlist.basrv[asrvid]].velocity))
                        {
                            asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num = asrvlist.aslist[asrvlist.basrv[asrvid]].end_x;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].velocity = 0;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 5;
                        }
                    }
                       
                    if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_decrease == true)
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num = (s2 + 7 - asrvlist.aslist[asrvlist.basrv[asrvid]].start_velocity3 * t4 - 0.5 * asrv.deceleration1 * t4 * t4) / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                        if ((asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num <= asrvlist.aslist[asrvlist.basrv[asrvid]].end_x) || (Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_x - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num) < timer_interval / 1000 * asrvlist.aslist[asrvlist.basrv[asrvid]].velocity))
                        {
                            asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num = asrvlist.aslist[asrvlist.basrv[asrvid]].end_x;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].velocity = 0;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 5;
                        }
                    }
                        
                    if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_increase == true)
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num = (s2 + 7 + asrvlist.aslist[asrvlist.basrv[asrvid]].start_velocity3 * t4 - 0.5 * asrv.deceleration1 * t4 * t4) / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                        if ((asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num >= asrvlist.aslist[asrvlist.basrv[asrvid]].end_y) || (Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_y - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num) < timer_interval / 1000 * asrvlist.aslist[asrvlist.basrv[asrvid]].velocity))
                        {
                            asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num = asrvlist.aslist[asrvlist.basrv[asrvid]].end_y;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].velocity = 0;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 5;
                        }
                    }
                        
                    if (asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_decrease == true)
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num = (s2 + 7 - asrvlist.aslist[asrvlist.basrv[asrvid]].start_velocity3 * t4 - 0.5 * asrv.deceleration1 * t4 * t4) / asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
                        if ((asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num <= asrvlist.aslist[asrvlist.basrv[asrvid]].end_y) || (Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_y - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num) < timer_interval / 1000 * asrvlist.aslist[asrvlist.basrv[asrvid]].velocity))
                        {
                            asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num = asrvlist.aslist[asrvlist.basrv[asrvid]].end_y;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].velocity = 0;
                            asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 5;
                        }
                    }
                        

                    asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination =//更新距离终点的距离
                  Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_x - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num) * asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length +
                   Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].end_y - asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num) * asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;

                    if ((Math.Abs(asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination - 7) < 17.0 * timer_interval / 1000) || (asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination < 7))
                    {
                        asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 5;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].de_start_time2 = c_time;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_xum2 = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num;
                        asrvlist.aslist[asrvlist.basrv[asrvid]].start_yum2 = asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num;
                    }
                }

            }//end state 7

            whindex=warehouselist.bwh[asrvlist.aslist[asrvlist.basrv[asrvid]].asrvwh_num];
            floorindex=warehouselist.bwh[asrvlist.aslist[asrvlist.basrv[asrvid]].asrvfloor_num];
            
           SendAsrvStatus(asrvid);

        }//end update_asrv
       
        static void updatestepnum(int asrvid)
        {
            int i;
            for (i=0;i<asrvlist.aslist[asrvlist.basrv[asrvid]].stepnum-2;i++)
            {
                if ((asrvlist.aslist[asrvlist.basrv[asrvid]].taskx[i] == asrvlist.aslist[asrvlist.basrv[asrvid]].taskx[i + 1])
                    && (asrvlist.aslist[asrvlist.basrv[asrvid]].taskx[i] == asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num))
                    asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum = i;
                if ((asrvlist.aslist[asrvlist.basrv[asrvid]].tasky[i] == asrvlist.aslist[asrvlist.basrv[asrvid]].tasky[i + 1])
                    && (asrvlist.aslist[asrvlist.basrv[asrvid]].tasky[i] == asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num))
                    asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum = i;
            }
        }
        static int GetCellPassNum(int asrvid)
        {
            int ans=0;
            ans = ans + asrvlist.aslist[asrvlist.basrv[asrvid]].taskstep[asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum];

            int xnum=Convert.ToInt32(asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num);
            int ynum = Convert.ToInt32(asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num);
           
            ans = ans + Math.Abs(xnum - asrvlist.aslist[asrvlist.basrv[asrvid]].taskx[asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum]);
            ans = ans + Math.Abs(ynum - asrvlist.aslist[asrvlist.basrv[asrvid]].tasky[asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum]);
            
            return ans;
        }
        public static double get_distance(int asrvid)//获取小车当前任务的距离终点的距离
        {
            double xend,yend;
            double xstart, ystart;

            xstart = asrvlist.aslist[asrvlist.basrv[asrvid]].start_x;
            ystart = asrvlist.aslist[asrvlist.basrv[asrvid]].start_y;
            xend = asrvlist.aslist[asrvlist.basrv[asrvid]].end_x;
            yend = asrvlist.aslist[asrvlist.basrv[asrvid]].end_y;
            return (Math.Abs(ystart - yend) + Math.Abs(xstart - xend)) * asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length;
            
        }//end get_distance

        //static void transfer16to10(string ss, ref int xnum, ref int ynum)//16进制与十进制的转换
        //{
        //    int x1, x2, y1, y2;

        //    if ((ss[0] >= '0') && (ss[0] <= '9')) x1 = ss[0] - '0';
        //    else x1 = (ss[0] - 'A') + 10;

        //    if ((ss[1] >= '0') && (ss[1] <= '9')) x2 = ss[1] - '0';
        //    else x2 = (ss[1] - 'A') + 10;

        //    if ((ss[2] >= '0') && (ss[2] <= '9')) y1 = ss[2] - '0';
        //    else y1 = (ss[2] - 'A') + 10;

        //    if ((ss[3] >= '0') && (ss[3] <= '9')) y2 = ss[3] - '0';
        //    else y2 = (ss[3] - 'A') + 10;

        //    xnum = x1 * 16 + x2;
        //    ynum = y1 * 16 + y2;
        //}//end transfer16to10

        public static void refresh(int asrvid)
        {
            asrvlist.aslist[asrvlist.basrv[asrvid]].de_start_time1 = 0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].de_start_time2 = 0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].stop_start_time = 0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination = 0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_increase = false;
            asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_decrease = false;
            asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_increase = false;
            asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_decrease = false;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_time = -1;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_velocity1 = 0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_xum1 = 0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_yum1 = 0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_xum2 = 0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_yum2 = 0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_time3 = 0;  
        }//end refresh

        public static void initasrv(int asrvid)
        {
            asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum = 0;

            updateasrvdirection(asrvid);
            //asrvlist.aslist[asrvlist.basrv[asrvid]].start_time = c_time;
            //asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination = get_distance(asrvid);
            asrvlist.aslist[asrvlist.basrv[asrvid]].state_flag = 1;
            
        }//end initasrv

        public static void updateasrvdirection(int asrvid)
        {
            if (asrvlist.aslist[asrvlist.basrv[asrvid]].end_x == asrvlist.aslist[asrvlist.basrv[asrvid]].start_x)
            {
                asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_increase = false;//小车运动方向为x增大方向
                asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_decrease = false;//小车运动方向为x减小方向
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].end_y > asrvlist.aslist[asrvlist.basrv[asrvid]].start_y)
                {
                    asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_increase = true;//小车运动方向为y增大方向
                    asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_decrease = false;//小车运动方向为y减小方向
                }
                else
                {
                    asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_increase = false;
                    asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_decrease = true;
                }
            }
            else
            {
                asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_increase = false;
                asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_decrease = false;
                if (asrvlist.aslist[asrvlist.basrv[asrvid]].end_x > asrvlist.aslist[asrvlist.basrv[asrvid]].start_x)
                {
                    asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_increase = true;
                    asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_decrease = false;
                }
                else
                {
                    asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_increase = false;
                    asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_decrease = true;
                }
            }
        }

        static void checkcrash()//以小车两两判断是否有碰撞
        {
            int i, j;
            double xi1, xi2, yi1, yi2, xj1, xj2, yj1, yj2; //小车同时会占着两个格子，所以两辆小车需四个坐标
            for (i = 0; i < asrvlist.asrv_num - 1; i++)
            {
                if (asrvlist.aslist[i].onmove_flag == false) continue;
                for (j = i + 1; j < asrvlist.asrv_num; j++)
                {
                    if (asrvlist.aslist[j].onmove_flag == false) continue;
                    if (asrvlist.aslist[i].asrvwh_num != asrvlist.aslist[j].asrvwh_num) continue;
                    if (asrvlist.aslist[i].asrvfloor_num != asrvlist.aslist[j].asrvfloor_num) continue;

                    xi1 = Math.Ceiling(asrvlist.aslist[i].asrvx_num);
                    yi1 = Math.Ceiling(asrvlist.aslist[i].asrvy_num);
                    xi2 = Math.Floor(asrvlist.aslist[i].asrvx_num);
                    yi2 = Math.Floor(asrvlist.aslist[i].asrvy_num);
                    xj1 = Math.Ceiling(asrvlist.aslist[j].asrvx_num);
                    yj1 = Math.Ceiling(asrvlist.aslist[j].asrvy_num);
                    xj2 = Math.Floor(asrvlist.aslist[j].asrvx_num);
                    yj2 = Math.Floor(asrvlist.aslist[j].asrvy_num);

                    if (((xi1 == xj1) && (yi1 == yj1)) || ((xi1 == xj2) && (yi1 == yj2)) || ((xi2 == xj2) && (yi2 == yj2)) || ((xi2 == xj1) && (yi2 == yj1)))
                    { //发生了碰撞 }
                    }
                }
            }
        }//end checkcrash


        public static void SendAsrvStatus(int asrvid)
        {
            byte[] data = GetTaskCmd(GetActionBytes(asrvid));
            byte[] mac = GetMacAddress(asrvid);

            Asrv a = new Asrv();
            a.Data=GetSendData(data,mac);
            a.Address = mac;
            a.UpdateAsrvStatus();
        }
        public static byte[] GetMacAddress(int asrvid)
        {            
            return asrvlist.aslist[asrvlist.basrv[asrvid]].macAddress_cmd;
        }
        public static byte[] GetActionBytes(int asrvid)
        {
            byte[] status_cmd = new byte[10];
            status_cmd[0] = (byte)asrvlist.aslist[asrvlist.basrv[asrvid]].asrvwh_num;
            status_cmd[1] = (byte)asrvlist.aslist[asrvlist.basrv[asrvid]].asrvfloor_num;
            status_cmd[2] = (byte)Convert.ToInt32(asrvlist.aslist[asrvlist.basrv[asrvid]].asrvx_num);
            status_cmd[3] = (byte)Convert.ToInt32(asrvlist.aslist[asrvlist.basrv[asrvid]].asrvy_num);
            
            //int cmdid1;
            //int.TryParse(asrvlist.aslist[asrvlist.basrv[asrvid]].cmd_id, out cmdid1);
            //status_cmd[4] = (byte)cmdid1;//当前任务ID
            status_cmd[4] = asrvlist.aslist[asrvlist.basrv[asrvid]].task_id;
            status_cmd[5] = 0x56;//当前电量百分比
            status_cmd[6] = 0xFF;
            if (asrvlist.aslist[asrvlist.basrv[asrvid]].Statusflag==1) status_cmd[6] &= 0xF5;
            else if (asrvlist.aslist[asrvlist.basrv[asrvid]].Statusflag==2) status_cmd[6] &= 0xF6;
            else if (asrvlist.aslist[asrvlist.basrv[asrvid]].Statusflag == 3) status_cmd[6] &= 0xF7;
            //else if
            //if(正常)
            status_cmd[6] &= 0xCF;
            //if(aisle)
            status_cmd[6] &= 0xFF;
            //if(高位)
            status_cmd[6] &= 0xFF;
            //if(通信状态正常)--默认bit8-15为0
            status_cmd[7] = 0x00;
            //if(正常)
            status_cmd[8] = 0x00;
            status_cmd[9] = 0x00;
            return status_cmd;
        }
        public static byte[] GetTaskCmd(byte[] actions)
        {
            byte[] b = null;
            List<byte> list = new List<byte>();
            //帧头
            list.Add(0x5A);
            
            //帧长度
            int length = 2+ actions.Length;
            list.Add((byte)length);

            //指令类型
            list.Add(0x08);

            //帧载荷

            list.AddRange(actions);
            //异或校验

            byte check = (byte)0;


            for (int i = 2; i < list.Count; i++)
            {
                check ^= list[i];
            }
            list.Add((byte)check);


            b = list.ToArray();

            return b;
        }
        public static byte[] GetSendData(byte[] data, byte[] mac)
        {
            byte[] b = null;
            List<byte> list = new List<byte>();

            //帧头
            list.Add(0x7e);

            //长度
            byte[] length = BitConverter.GetBytes(14 + data.Length);

            list.Add(length[1]);
            list.Add(length[0]);

            list.Add(0x10);
            list.Add(0x00);

            list.AddRange(mac);//64bit adress

            list.Add(0xff);
            list.Add(0xfe);//16bit adress

            list.Add(0x00);//Broadcast Radius
            list.Add(0x00);//Options

            list.AddRange(data);//data

            //校验

            int sum = 0;

            byte check;
            for (int i = 3; i < list.Count; i++)
            {
                sum += list[i];
            }

            if (sum <= 255)
                list.Add((byte)sum);
            else
            {
                check = (byte)sum;
                list.Add((byte)(~check));
            }

            b = list.ToArray();
            return b;
        }
        public static void ClearAsrvStatus(int asrvid)
        {
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_time=-1;
            asrvlist.aslist[asrvlist.basrv[asrvid]].de_start_time1=-1;
            asrvlist.aslist[asrvlist.basrv[asrvid]].de_start_time2=-1;
            asrvlist.aslist[asrvlist.basrv[asrvid]].stop_start_time=-1;
            asrvlist.aslist[asrvlist.basrv[asrvid]].distance_to_destination=0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].velocity=0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].max_velocity=0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_velocity1=0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_xum1=-1;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_xum2=-1;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_yum1=-1;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_yum2=-1;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_x = -1;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_y = -1;
            asrvlist.aslist[asrvlist.basrv[asrvid]].end_x = -1;
            asrvlist.aslist[asrvlist.basrv[asrvid]].end_y = -1;
            Array.Clear(asrvlist.aslist[asrvlist.basrv[asrvid]].task_string, 0, asrvlist.aslist[asrvlist.basrv[asrvid]].task_string.Length);
            asrvlist.aslist[asrvlist.basrv[asrvid]].cmd_id = null;
            asrvlist.aslist[asrvlist.basrv[asrvid]].xstring = null;
            asrvlist.aslist[asrvlist.basrv[asrvid]].ystring = null;
            asrvlist.aslist[asrvlist.basrv[asrvid]].load_flag = false;
            asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_flag = false;
            asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_decrease = false;
            asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_x_flag_increase = false;
            asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_decrease = false;
            asrvlist.aslist[asrvlist.basrv[asrvid]].onmove_y_flag_increase = false;
            asrvlist.aslist[asrvlist.basrv[asrvid]].stop_flag = false;
            Array.Clear(asrvlist.aslist[asrvlist.basrv[asrvid]].pathx, 0, asrvlist.aslist[asrvlist.basrv[asrvid]].pathx.Length);
            Array.Clear(asrvlist.aslist[asrvlist.basrv[asrvid]].pathy, 0, asrvlist.aslist[asrvlist.basrv[asrvid]].pathy.Length);
            Array.Clear(asrvlist.aslist[asrvlist.basrv[asrvid]].macAddress_cmd, 0x00, asrvlist.aslist[asrvlist.basrv[asrvid]].macAddress_cmd.Length);
            asrvlist.aslist[asrvlist.basrv[asrvid]].pathlen = 0;
            Array.Clear(asrvlist.aslist[asrvlist.basrv[asrvid]].taskx, 0, asrvlist.aslist[asrvlist.basrv[asrvid]].taskx.Length);
            Array.Clear(asrvlist.aslist[asrvlist.basrv[asrvid]].tasky, 0, asrvlist.aslist[asrvlist.basrv[asrvid]].tasky.Length);
            Array.Clear(asrvlist.aslist[asrvlist.basrv[asrvid]].taskstep, 0, asrvlist.aslist[asrvlist.basrv[asrvid]].taskstep.Length);
            asrvlist.aslist[asrvlist.basrv[asrvid]].stepnum = 0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].c_stepnum = 0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].cubenum_token=-2;
            asrvlist.aslist[asrvlist.basrv[asrvid]].cubenum_token_old = -2;
            asrvlist.aslist[asrvlist.basrv[asrvid]].cell_length = 0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].vmax4 = 0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_xum3 = -1;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_yum3 = -1;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_velocity3 = -1;
            asrvlist.aslist[asrvlist.basrv[asrvid]].tmax = 0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].tflag = 0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].token_xnum = 0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].token_ynum = 0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].Statusflag = 3;
            asrvlist.aslist[asrvlist.basrv[asrvid]].cell_pass = 0;
            asrvlist.aslist[asrvlist.basrv[asrvid]].start_time3 = 0;

        }
    }//end make_it_run

    
}