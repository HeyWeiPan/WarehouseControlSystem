using EntpClass.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCSServer
{
    public class Asrv
    {
        private byte[] _address;
        private byte[] _data;

        public int Bit03, Bit45, Bit6, Bit7, Bit8;


        /// <summary>
        /// 设置或获取小车MAC地址
        /// </summary>
        public byte[] Address
        {
            get { return _address; }
            set { _address = value; }
        }

        /// <summary>
        /// 获取或设置小车返回的数据
        /// </summary>
        public byte[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        /// <summary>
        /// 异或校验数据
        /// </summary>
        /// <returns></returns>
        private bool CheckDataComplete()
        {
            byte check = (byte)0;


            for (int i = 2; i < Data.Length - 3; i++)
            {
                check ^= Data[i];
            }
            if (check == Data[Data.Length - 3])
                return true;
            else
                return false;


        }
        /// <summary>
        /// 获取指令类型,根据协议为第四个字节
        /// </summary>
        /// <returns></returns>
        private byte GetCmdType()
        {
            return Data[3];
        }

        /// <summary>
        /// 设置该小车命令队列中第一条为已完成发送,小车已接收
        /// </summary>
        private void UpdateCmdStatus()
        {
            string proc = "WCS.UpdateCmdStatus";
            Database db = DatabaseFactory.CreateDatabase("ConWCS");
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pAdress", DbType.Binary, Address);
            db.ExecuteNonQuery(cmd);
        }


        /// <summary>
        /// 更新小车状态
        /// </summary>
        private void UpdateAsrvStatus()
        {

            byte[] buffer = GetAsrvStatus();


            int area = (int)buffer[0];
            int floor = (int)buffer[1];
            int x = (int)buffer[2];
            int y = (int)buffer[3];
            int taskId = (int)buffer[4];
            //int cells = (int)buffer[4];
            int power = (int)buffer[5];

            byte[] status = new byte[2];
            status[0] = buffer[6];
            status[1] = buffer[7];

            byte[] error = new byte[2];
            error[0] = buffer[8];
            error[1] = buffer[9];


            string proc = "WCS.UpdateAsrvStatus";
            Database db = DatabaseFactory.CreateDatabase("ConWCS");

            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pArea", DbType.Int32, area);
            db.AddInParameter(cmd, "pAdress", DbType.Binary, Address);
            db.AddInParameter(cmd, "pFloor", DbType.Int32, floor);
            db.AddInParameter(cmd, "pX", DbType.Int32, x);
            db.AddInParameter(cmd, "pY", DbType.Int32, y);
            db.AddInParameter(cmd, "pTaskId", DbType.Int32, taskId);
            db.AddInParameter(cmd, "pPower", DbType.Int32, power);
            db.AddInParameter(cmd, "pStatus", DbType.Binary, status);
            db.AddInParameter(cmd, "pError", DbType.Binary, error);
            db.ExecuteNonQuery(cmd);


            HexToBit(buffer[6], buffer[7]);

            SendCmdCondition();
        }

        /// <summary>
        /// 十六进制转二进制
        /// </summary>
        /// <param name="bit03"></param>
        /// <param name="bit45"></param>
        /// <param name="bit6"></param>
        /// <param name="bit7"></param>
        /// <param name="bit8"></param>
        /// <param name="byte0"></param>
        /// <param name="byte1"></param>
        public void HexToBit(byte byte0, byte byte1)
        {
            Bit03 = (byte0 & 0x0f);
            Bit45 = ((byte0 >> 4) & 0x03);
            Bit6 = ((byte0 >> 6) & 0x01);
            Bit7 = ((byte0 >> 7) & 0x01);
            Bit8 = (byte1 & 0x01);
        }

        public void SendCmdCondition()
        {
            Database db = DatabaseFactory.CreateDatabase("ConWCS");

            if (Bit03 == 6) //等待令牌
            {
                SetRoadRight();
                UpdateCmd();
            }
            else if (Bit03 == 7) //等待任务
            {
                DbCommand cmd = db.GetStoredProcCommand("WCS.SendNextCmd");
                db.AddInParameter(cmd, "address", DbType.String, Address);
                db.AddOutParameter(cmd, "pCmdId", DbType.Int32, 1000000);
                db.ExecuteNonQuery(cmd);
                string cmdId = Fn.ToString(db.GetParameterValue(cmd, "pCmdId"));

                //cmdId不等于0，即任务还未完成
                if (cmdId != "0")
                {
                    EntpClass.BizLogic.WCS.Route r = new EntpClass.BizLogic.WCS.Route();
                    r.CalcRoute(cmdId);
                    SetRoadRight();
                    UpdateCmd();
                }

            }

            //if (Bit45 == )
            //{

            //}
        }


        /// <summary>
        /// 获取未完成的任务命令
        /// </summary>
        /// <returns></returns>
        public string GetCmdId()
        {
            Database db = DatabaseFactory.CreateDatabase("ConWCS");
            DbCommand cmd = db.GetStoredProcCommand("wcs.GetCmdId");
            db.AddOutParameter(cmd, "pCmdId", DbType.Int32, 10000);
            db.ExecuteDataSet(cmd);
            return Fn.ToString(db.GetParameterValue(cmd, "pCmdId"));
        }


        /// <summary>
        /// 设置路权
        /// </summary>
        public void SetRoadRight()
        {
            Database db = DatabaseFactory.CreateDatabase("ConWCS");
            DbCommand cmd = db.GetStoredProcCommand("wcs.SetRoadRight");
            db.ExecuteNonQuery(cmd);
        }


        /// <summary>
        /// 更新路权命令
        /// </summary>
        public void UpdateCmd()
        {
            SendCmd sc = new SendCmd();
            //发送路权令牌
            DataSet dsToken = sc.GetRoadRightCMD();
            byte[] bufferRight = null;
            for (int j = 0; j < dsToken.Tables[0].Rows.Count; j++)
            {
                bufferRight = Asrv.GetSendData(Asrv.GetTokenCmd(int.Parse(dsToken.Tables[0].Rows[j]["step_num"].ToString())), (byte[])(dsToken.Tables[0].Rows[j]["address"]));
                string cmdId = dsToken.Tables[0].Rows[j]["cmd_id"].ToString();
                sc.InsertCmdBreakdown(cmdId, bufferRight);
                //if (sc.checktokensendcnt(cmdid, bufferright)) //如果相同的令牌发送次数没有超过最大发送次数则发送路权令牌
                //{

                //    workstream.write(bufferright, 0, bufferright.length);


                //    sc.insertcmdbreakdown(cmdid, bufferright);
                //}
            }
        }

        private byte[] GetAsrvStatus()
        {
            List<byte> list = new List<byte>();
            //根据协议小车发送的状态数据为第4~13个字节
            for (int i = 20; i < 30; i++)
            {
                list.Add(Data[i]);
            }

            return list.ToArray();
        }



        /// <summary>
        /// 处理小车发回的数据
        /// </summary>
        public void ProcessData()
        {
            bool b = CheckDataComplete();//验证数据完整性

            if (!b)
                return;

            byte cmdType = GetCmdType();//获取发回的指令类型

            if (cmdType == 0x02)//表示小车已收到任务
            {
                UpdateCmdStatus();
            }



            if (cmdType == 0x08)//小车反馈的状态
            {
                UpdateAsrvStatus();
            }
        }

        /// <summary>
        /// 获取路权令牌命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="cells"></param>
        /// <returns></returns>

        public static byte[] GetTokenCmd(int steps)
        {
            byte[] b = null;
            List<byte> list = new List<byte>();
            //帧头
            list.Add(0x5A);

            //帧长度
            list.Add((byte)3);

            //指令类型
            list.Add(0x04);

            //帧载荷


            list.AddRange(GetTokenData(steps));
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


        public static byte[] GetTokenData(int step)
        {


            byte[] buffer = new byte[2];

            byte[] b = BitConverter.GetBytes(step);
            buffer[0] = b[0];

            buffer[1] = b[1];

            return buffer;
        }

        /// <summary>
        /// ZIGBEE打包发送数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mac"></param>
        /// <returns></returns>
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




        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }


    }
}
