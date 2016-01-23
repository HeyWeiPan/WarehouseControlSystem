using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntpClass.Common;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using System.Collections;

namespace EntpClass.BizLogic.WCS
{
    public class CmdBreak
    {

        private int XNUM, YNUM, FLOORNUM, TASKTYPE;
        public int XF, XB, YF, YB;
        private string CMDID;
        private string RACK;
        private string CELLNUM;
        private Hashtable CELLS;
        private char SPLIT = '.';
        public string MACADRESS;
        public string CmdId
        {
            get
            {
                return CMDID;
            }
            set
            {
                CMDID = value;
            }
        }
        public int Xnum
        {
            get
            {
                return XNUM;
            }
            set
            {
                XNUM = value;
            }
        }

        public int Ynum
        {
            get
            {
                return YNUM;
            }
            set
            {
                YNUM = value;
            }
        }

        public string CellNum
        {

            get
            {
                return CELLNUM;
            }
            set
            {
                CELLNUM = value;
            }
        }


        public int FloorNum
        {

            get
            {
                return FLOORNUM;
            }
            set
            {
                FLOORNUM = value;
            }
        }


        public int TaskType
        {

            get
            {
                return TASKTYPE;
            }
            set
            {
                TASKTYPE = value;
            }
        }


        public string Rack
        {

            get
            {
                return RACK;
            }
            set
            {
                RACK = value;
            }
        }


        public Hashtable Cells
        {

            get
            {
                return CELLS;
            }
            set
            {
                CELLS = value;
            }
        }


        public bool RouteBreak()
        {
            DataSet ds = GetTask();
            //没有路径则返回
            if (ds == null || ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0)
                return false;


            ArrayList points = BuildRouteBreak(ds);

            byte[] data = GetTaskCmd(GetActionBytes(points));
            byte[] mac = GetMacAdress();

            ZIGBEE z = new ZIGBEE();

            byte[] buffer = z.GetSendData(data, mac);


            try
            {
                InsertCmdBreakdown(buffer, "TASK");
                return true;
            }
            catch
            {
                return false;
            }




        }
        /// <summary>
        /// 获取需要改变指令的坐标
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public ArrayList BuildRouteBreak(DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            ArrayList points = new ArrayList();

            points.Add(CellNum);


            int step = dt.Rows.Count;


            int x1, x2, y1, y2;




            if (step >1)
            {
                x1 = Fn.ToInt(dt.Rows[1]["x_num"]);
                y1 = Fn.ToInt(dt.Rows[1]["y_num"]);
                x2 = Xnum;
                y2 = Ynum;

                if (x1 != x2 && y1 != y2)
                {
                    points.Add(dt.Rows[0]["cell_num"].ToString()); //存入拐弯点
                }

            
       
                for (int i = 2; i < step; i++)
                {



                    //存入拐弯点
                    x1 = Fn.ToInt(dt.Rows[i]["x_num"]);
                    y1 = Fn.ToInt(dt.Rows[i]["y_num"]);

                    x2 = Fn.ToInt(dt.Rows[i - 2]["x_num"]);
                    y2 = Fn.ToInt(dt.Rows[i - 2]["y_num"]);


                    if (x1 != x2 && y1 != y2)
                    {
                        points.Add(dt.Rows[i - 1]["cell_num"].ToString()); //存入拐弯点
                    }

                }
            }


            points.Add(dt.Rows[step - 1]["cell_num"].ToString()); //存入终点



            return points;
        }




        /// <summary>
        /// 获取动作指令帧载荷
        /// </summary>
        /// <param name="points">需要改变指令的坐标</param>
        /// <returns></returns>

        private byte[] GetActionBytes(ArrayList points)
        {
            byte[] b = null;
            List<byte> list = new List<byte>();
            int x1, x2, y1, y2;
            byte bit5;

            list.Add((byte)int.Parse(CmdId));

            for (int i = 1; i < points.Count; i++)
            {
                x1 = Fn.ToInt(Fn.ToString(points[i]).Split(SPLIT)[0]);
                y1 = Fn.ToInt(Fn.ToString(points[i]).Split(SPLIT)[1]);
                x2 = Fn.ToInt(Fn.ToString(points[i - 1]).Split(SPLIT)[0]);
                y2 = Fn.ToInt(Fn.ToString(points[i - 1]).Split(SPLIT)[1]);

                int target = GetChannelDirection(x2, y2, x1, y1);
                int actiontype = GetActionType(x2, y2, x1, y1);
                int celltype = GetStartSite(x1, y1);

                //如果是巷道，bit5为1
                if (celltype == 0)
                {
                    bit5 = 1;
                }
                else
                {
                    bit5 = 0;
                }

                list.Add(GetActionCmd(x1, y1, x2, y2));
                list.Add(GetActionStep(x1, y1, x2, y2));
                list.Add((byte)x2);
                list.Add((byte)y2);

                if (i == points.Count - 1)
                {
                    list.Add(BitToHex(0, (byte)actiontype, (byte)target, bit5));

                    list.Add(0);
                    list.Add((byte)x1);
                    list.Add((byte)y1);

                }

            }
            b = list.ToArray();

            return b;
        }

       

//        byte bit_to_hex（byte bit01，byte bit23，byte bit4，byte bit5）
//{
//    Byte temp；
//temp= ((bit5<<5)&0x20) |((bit4<<4)&0x10)| ((bit23<<2)&0x0c)| (bit01&0x03);
//    return temp;
//} 

//void hex_to_bit（byte bit03,byte bit45,byte bit6,byte bit7,byte bit8,byte byte0,byte byte1）
//{
//    Bit03 = (byte0&0x0f) ;
//    Bit45 = ((byte0>>4)&0x03);
//Bit6 = ((byte0>>6)&0x01);
//Bit7 = ((byte0>>7)&0x01);
//Bit8 =(byte1&0x01);
//}
        /// <summary>
        /// 获取动作指令
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>

        public byte GetActionCmd(int x1, int y1, int x2, int y2)
        {
            byte rnt;
            byte bit5;

            int target = GetChannelDirection(x2,y2,x1,y1);

            int celltype = GetStartSite(x2, y2);

            int actiontype = GetActionType(x2, y2, x1, y1);

            //如果是巷道，bit5为1
            if (celltype == 0)
            {
                bit5 = 1;
            }
            else 
            {
                bit5 = 0;
            }

            if (x1 == x2)
            {
                //rnt = y1 - y2 > 0 ? 10 : 11;
                if (y1 - y2 > 0)
                {
                    rnt = BitToHex(2, 0, (byte)target, bit5);
                }
                else 
                {
                    rnt = BitToHex(3, 0, (byte)target, bit5);
                }
            }
            else if (y1 == y2)
            {
                if (x1 - x2 > 0)
                {
                    rnt = BitToHex(0, 0, (byte)target, bit5);
                }
                else
                {
                    rnt = BitToHex(1, 0, (byte)target, bit5);
                }
                //rnt = x1 - x2 > 0 ? 00 : 01;
            }
            else 
            {
                rnt = 0;
            }

            return rnt;
        }

        /// <summary>
        /// 二进制转十六进制
        /// </summary>
        /// <param name="bit01"></param>
        /// <param name="bit23"></param>
        /// <param name="bit4"></param>
        /// <param name="bit5"></param>
        /// <returns></returns>
        public byte BitToHex(byte bit01, byte bit23, byte bit4, byte bit5)
        {
            int temp;
            temp = ((bit5 << 5) & 0x20) | ((bit4 << 4) & 0x10) | ((bit23 << 2) & 0x0c) | (bit01 & 0x03);
            return (byte)temp;
        }

        

        /// <summary>
        /// 获取指令执行步数
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>

        public byte GetActionStep(int x1, int y1, int x2, int y2)
        {
            int rnt;

            if (x1 == x2)
            {
                rnt = Math.Abs(y1 - y2);
            }
            else
            {
                rnt = Math.Abs(x1 - x2);
            }

            return (byte)rnt;
        }

        /// <summary>
        /// 获取动作指令集
        /// </summary>
        /// <param name="actions"></param>
        /// <returns></returns>

        public byte[] GetTaskCmd(byte[] actions)
        {
            byte[] b = null;
            List<byte> list = new List<byte>();
            //帧头
            list.Add(0x5A);
            
            //帧长度
            int length = 1 + actions.Length;
            list.Add((byte)length);

            //指令类型
            list.Add(0x02);

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

        /// <summary>
        /// 解析MAC地址
        /// </summary>
        /// <param name="mac"></param>
        /// <returns></returns>
        public byte[] GetMacAdress()
        {
            string[] s = MACADRESS.Split(':');


            byte[] buffer = new byte[8];

            for (int i = 0; i < s.Length; i++)
            {
                buffer[i] = (byte)int.Parse(s[i], System.Globalization.NumberStyles.HexNumber);
            }

            return buffer;


        }

        public void InsertCmdBreakdown(byte[] buffer, string cmdType)
        {
            string proc = "WCS.InsertCmdBreakdown";
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pCmdId", DbType.Int32, CmdId);
            db.AddInParameter(cmd, "pData", DbType.Binary, buffer);
            db.AddInParameter(cmd, "pType", DbType.String, cmdType);
            db.ExecuteNonQuery(cmd);
        }



        /// <summary>
        /// 获取路径
        /// </summary>
        /// <param name="cmdId">任务ID</param>
        /// <returns></returns>
        public DataSet GetTask()
        {
            string proc = "WCS.GetAsrvRoute";
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pCmdId", DbType.Int32, CmdId);

            return db.ExecuteDataSet(cmd);
        }

        /// <summary>
        /// 获取货道方向
        /// </summary>
        /// <returns></returns>
        public int GetChannelDirection(int start_x,int start_y,int end_x,int end_y) 
        {
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd = db.GetStoredProcCommand("WCS.IsChannel");
            db.AddInParameter(cmd, "pCmdId", DbType.Int32, CmdId);
            db.AddInParameter(cmd, "start_x", DbType.Int32, start_x);
            db.AddInParameter(cmd, "start_y", DbType.Int32, start_y);
            db.AddInParameter(cmd, "end_x", DbType.Int32, end_x);
            db.AddInParameter(cmd, "end_y", DbType.Int32, end_y);
            db.AddOutParameter(cmd, "result", DbType.Int32, 1000);
            db.ExecuteDataSet(cmd);

            return int.Parse(db.GetParameterValue(cmd, "result").ToString());
        }

        /// <summary>
        /// 判断起点位置
        /// </summary>
        /// <returns></returns>
        public int GetStartSite(int x,int y)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select celltype_code from wcs_cell where wh_id = (select wh_id from wcs_asrv_cmd where cmd_id = {0}) and x_num = {1} and y_num = {2}", CmdId,x,y);
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd = db.GetSqlStringCommand(sb.ToString());

            return int.Parse(db.ExecuteScalar(cmd).ToString());
        }

        /// <summary>
        /// 获取动作类型
        /// </summary>
        /// <param name="start_x"></param>
        /// <param name="start_y"></param>
        /// <param name="end_x"></param>
        /// <param name="end_y"></param>
        /// <returns></returns>
        public int GetActionType(int start_x, int start_y, int end_x, int end_y) 
        {
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd = db.GetStoredProcCommand("WCS.GetActionType");
            db.AddInParameter(cmd, "pCmdId", DbType.Int32, CmdId);
            db.AddInParameter(cmd, "start_x", DbType.Int32, start_x);
            db.AddInParameter(cmd, "start_y", DbType.Int32, start_y);
            db.AddInParameter(cmd, "end_x", DbType.Int32, end_x);
            db.AddInParameter(cmd, "end_y", DbType.Int32, end_y);
            db.AddOutParameter(cmd, "result", DbType.Int32, 1000);
            db.ExecuteDataSet(cmd);

            return int.Parse(db.GetParameterValue(cmd, "result").ToString());
        }
    }
}
