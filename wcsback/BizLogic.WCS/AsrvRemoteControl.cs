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
using System.Net.Sockets;

namespace EntpClass.BizLogic.WCS
{
    public class AsrvRemoteControl
    {
        private string IPADRESS = "";
        private int PORT = 0;
        private byte[] MACADDRESS = null;


        public void SendCmd(string asrvId, string cmdType)
        {
            InitParameter(asrvId);

            ZIGBEE z=new ZIGBEE();
            byte[] sendBuffer = z.GetSendData(GetCmdAllData(cmdType),MACADDRESS);

            TcpClient tcp = new TcpClient();

            tcp.Connect(IPADRESS,PORT);

            if (tcp.Connected)
            {
                NetworkStream ns = tcp.GetStream();
                ns.Write(sendBuffer,0,sendBuffer.Length);

                ns.Close();
                tcp.Close();
            }



        }

        public byte[] GetCmdAllData(string cmdType)
        {
            byte[] b = null;
            List<byte> list = new List<byte>();
            //帧头
            list.Add(0x5A);

            //帧长度
    
            list.Add(0x02);

            //指令类型
            list.Add(0x10);

            //帧载荷

            list.Add(GetCmdData(cmdType));
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

        public byte GetCmdData(string cmdType)
        {
            switch (cmdType.ToLower())
            {
                case "unauto":
                    return 0x4d;
                case "auto":
                    return 0x41;
                case "forward":
                    return 0x46;
                case "back":
                    return 0x42;
                case "up":
                    return 0x55;
                case "down":
                    return 0x44;
                case "faster":
                    return 0x2b;
                case "slow":
                    return 0x2d;
                case "stop":
                    return 0x53;
                case "faststop":
                    return 0x45;
                case "turn":
                    return 0x54;
                default:
                    return 0;
            }
        }

        public void InitParameter(string asrvId)
        {
            string proc = "WCS.GetAsrvParameter";
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pAsrvId", DbType.Int32, asrvId);
            DataSet ds = db.ExecuteDataSet(cmd);
            IPADRESS = Fn.ToString(ds.Tables[0].Rows[0]["ip"]);
            PORT = Fn.ToInt(ds.Tables[0].Rows[0]["port"]);
            MACADDRESS = (byte[])ds.Tables[0].Rows[0]["mac_address"];

        }



    }
}
