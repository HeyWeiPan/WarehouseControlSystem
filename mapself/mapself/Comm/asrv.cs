using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.Comm
{
    public class asrv
    {
        public static double max_velocity_loaded=31.5, max_velocity_unloaded=50;//空载时最大速度50，载货时最大速度31.5
        public static double raise_time=5000, laydown_time=5000, direction_turning_time=5000;//抬升下降转弯速度
        public static double acceleration=20.0, deceleration1=18.0, deceleration2=20.643;
        

        public double asrvx_num, asrvy_num;//小车当前坐标
        public int asrvwh_num, asrvfloor_num, asrv_id, state_flag=0;//state_flag 1表示处于加速，2表示在最高速度匀速，3表示第一次减速，4表示第二次匀速，5表示第二次减速
        
        public int start_time=-1, de_start_time1, de_start_time2,stop_start_time,start_time3;
        public double distance_to_destination, velocity, max_velocity;
        public double start_velocity1, start_xum1, start_yum1,start_xum2, start_yum2;
        public double start_x=-1, start_y=-1, end_x=-1, end_y=1;

        public byte[] task_string=null;//存放小车任务信息
        public string cmd_id=null;

        public bool onmove_flag, onmove_x_flag_increase, onmove_x_flag_decrease, onmove_y_flag_increase, onmove_y_flag_decrease, stop_flag, load_flag;//load_flag true表示unloaded false表示loaded

        public string xstring, ystring;

        public int[] pathx = new int[200]; //显示小车路径
        public int[] pathy = new int[200];
        public int pathlen = 0;

        public byte[] macAddress_cmd = new byte[8];

        public int[] taskx = new int[10];//每个转折点x坐标
        public int[] tasky = new int[10];//每个转折点y坐标
        public int[] taskstep = new int[10]; //小车当前任务的转折点数，包括起点和终点
        public int stepnum,c_stepnum;//规定c_stepnum=x为小车在从第x转折点到第x+1转折点之间，起始x为0

        public int cubenum_token=-2,cubenum_token_old=-2;//TOKEN指令中步数

        public double cell_length,vmax4;
        public double start_xum3, start_yum3, start_velocity3,tmax;

        public int tflag=0; //1表示当前段没到转折点 2表示当前只走到转折点

        public int token_xnum, token_ynum;

        public int Statusflag=3;//运行过程状态信息 1表示执行任务 2表示等待令牌 3表示等待任务
        public int cell_pass;//记录下车走了多少格

        public byte task_id = 0x01;
     }
}