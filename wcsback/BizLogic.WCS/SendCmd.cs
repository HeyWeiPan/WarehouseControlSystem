using EntpClass.BizLogic.WCS;
using EntpClass.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WCSServer
{
    public class SendCmd
    {

        private string HOST = "";
        private int PORT = 0;
        public IPAddress IP;

        /// <summary>
        /// 获取仓库代码
        /// </summary>
        public string WHCode
        {
            get
            {

                return Fn.ToString(System.Configuration.ConfigurationSettings.AppSettings["WHCode"]);

            }
        }


        /// <summary>
        /// 获取发送时间间隔
        /// </summary>
        public int SendPeriod
        {
            get
            {

                return Fn.ToInt(System.Configuration.ConfigurationSettings.AppSettings["SendPeriod"]);

            }
        }

        /// <summary>
        ///任务最大发送次数
        /// </summary>
        public int MaxSendCnt
        {
            get
            {

                return Fn.ToInt(System.Configuration.ConfigurationSettings.AppSettings["MaxSendCnt"]);

            }
        }

        private TcpClient tcp = null;
        private NetworkStream workStream = null;
        public Timer t;
        public void Start()
        {
            SetWhIpAndPort();//初始化参数
            if (HOST == "" || PORT == 0)
                return;



            //建立定时器，发送命令
            t = new Timer(new TimerCallback(timer_Elapsed), null, 0, SendPeriod);


        }

        /// <summary>
        /// 定时器回调函数
        /// </summary>
        /// <param name="sender"></param>

        void timer_Elapsed(object sender)
        {
            //if (tcp != null && tcp.Connected)
            //{
            //    DataSet ds = GetTaskCmd();//获取发送命令

            //    string cmdId = "";
            //    int cnt = 0;
            //    byte[] buffer = null;
            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        if (CanSendCmd((byte[])ds.Tables[0].Rows[i]["status"]))//判断小车状态是否能接收命令
            //        {
            //            buffer = (byte[])ds.Tables[0].Rows[i]["cmd"];
            //            workStream.Write(buffer, 0, buffer.Length);

            //            cmdId = Fn.ToString(ds.Tables[0].Rows[i]["cmd_id"]);
            //            cnt = Fn.ToInt(ds.Tables[0].Rows[i]["send_cnt"]) + 1;

            //            UpdateCmdSendCnt(cmdId, cnt); //更新命令的发送次数
            //        }
            //    }


            //    //发送路权令牌
            //    DataSet dsToken = GetRoadRightCMD();
            //    byte[] bufferRight = null;
            //    for (int j = 0; j < dsToken.Tables[0].Rows.Count; j++)
            //    {
            //        bufferRight = Asrv.GetSendData(Asrv.GetTokenCmd(Fn.ToInt(dsToken.Tables[0].Rows[j]["step"])), (byte[])(dsToken.Tables[0].Rows[j]["address"]));
            //        cmdId = Fn.ToString(dsToken.Tables[0].Rows[j]["cmd_id"]);

            //        if (CheckTokenSendCnt(cmdId, bufferRight)) //如果相同的令牌发送次数没有超过最大发送次数则发送路权令牌
            //        {

            //            workStream.Write(bufferRight, 0, bufferRight.Length);


            //            InsertCmdBreakdown(cmdId, bufferRight);
            //        }
            //    }

            //}
            //else
            //{
            //    Connect();//连接HOST并等待接收数据
            //}

            
            string cmdId = GetCmdId();

            //如果没有未分配的任务，只计算路权
            if (cmdId == "0")
            {
                SetRoadRight();
                UpdateCmd();
                return;
            }

            Route r = new Route();
            r.CalcRoute(cmdId);
            SetRoadRight();
            UpdateCmd();
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

        /// <summary>
        /// 检查同样的令牌的发送次数是否超过最大发送次数
        /// </summary>
        /// <param name="cmdId"></param>
        /// <param name="rightData"></param>
        /// <returns></returns>

        public bool CheckTokenSendCnt(string cmdId, byte[] rightData)
        {
            string sql = "select WCS.GetTokenCmdSendCnt(@pCmdId,@pData)";
            Database db = DatabaseFactory.CreateDatabase("ConWCS");
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "pCmdId", DbType.Int32, cmdId);
            db.AddInParameter(cmd, "pData", DbType.Binary, rightData);
            int cnt = Fn.ToInt(db.ExecuteScalar(cmd));

            if (cnt >= MaxSendCnt)
                return false;
            else
                return true;

        }

        public void InsertCmdBreakdown(string cmdId, byte[] rightData)
        {
            string proc = "WCS.InsertCmdBreakdown";
            Database db = DatabaseFactory.CreateDatabase("ConWCS");
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pCmdId", DbType.Int32, cmdId);
            db.AddInParameter(cmd, "pData", DbType.Binary, rightData);
            db.AddInParameter(cmd, "pType", DbType.String, "TOKEN");
            db.ExecuteNonQuery(cmd);
        }

        private void UpdateCmdSendCnt(string cmdId, int cnt)
        {
            string proc = "WCS.UpdateCmdSendCnt";
            Database db = DatabaseFactory.CreateDatabase("ConWCS");
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pCmdId", DbType.Int32, cmdId);
            db.AddInParameter(cmd, "pCnt", DbType.Int32, cnt);
            db.AddInParameter(cmd, "pMaxSendCnt", DbType.Int32, MaxSendCnt);
            db.ExecuteNonQuery(cmd);
        }


        private DataSet GetTaskCmd()
        {
            string proc = "WCS.GetTaskCmdByWhCode";
            Database db = DatabaseFactory.CreateDatabase("ConWCS");
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pWhCode", DbType.String, WHCode);
            return db.ExecuteDataSet(cmd);
        }

        public DataSet GetRoadRightCMD()
        {
            string proc = "WCS.GetRoadRightCMD";
            Database db = DatabaseFactory.CreateDatabase("ConWCS");
            DbCommand cmd = db.GetStoredProcCommand(proc);
            return db.ExecuteDataSet(cmd);
        }

        private void SetWhIpAndPort()
        {
            try
            {
                string proc = "WCS.GetWhSetup";
                Database db = DatabaseFactory.CreateDatabase("ConWCS");
                DbCommand cmd = db.GetStoredProcCommand(proc);
                db.AddInParameter(cmd, "pWhCode", DbType.String, WHCode);
                DataSet ds = db.ExecuteDataSet(cmd);
                DataRow dr = ds.Tables[0].Rows[0];

                HOST = Fn.ToString(dr["host"]);
                PORT = Fn.ToInt(dr["port"]);

            }
            catch (SqlException ex)
            {
                WriteLog.WriteServerLogs(ex.Message);
            }
        }


        public static ManualResetEvent connectDone = new ManualResetEvent(false);

        /// <summary>

        /// 异步连接的回调函数

        /// </summary>

        /// <param name="ar"></param>

        private static void ConnectCallback(IAsyncResult ar)
        {
            connectDone.Set();
            TcpClient t = (TcpClient)ar.AsyncState;
            try
            {
                if (t.Connected)
                {
                    t.EndConnect(ar);

                }
                else
                {

                    t.EndConnect(ar);

                }

            }
            catch (SocketException se)
            {
                Console.WriteLine(se.Message);
            }
        }



        private void Connect()
        {
            if ((tcp == null) || (!tcp.Connected))
            {
                try
                {
                    tcp = new TcpClient();
                    tcp.ReceiveTimeout = 10;


                    connectDone.Reset();

                    WriteLog.WriteServerLogs("开始连接...");


                    tcp.BeginConnect(HOST, PORT,
                        new AsyncCallback(ConnectCallback), tcp);

                    connectDone.WaitOne();

                    if ((tcp != null) && (tcp.Connected))
                    {
                        workStream = tcp.GetStream();

                        WriteLog.WriteServerLogs("连接已确立");

                        asyncread(tcp);
                    }
                }
                catch (Exception se)
                {
                    WriteLog.WriteServerLogs(se.Message + " Conn......." + Environment.NewLine);
                }
            }
        }
        /// <summary>

        /// 断开连接

        /// </summary>

        private void DisConnect()
        {
            if ((tcp != null) && (tcp.Connected))
            {
                workStream.Close();
                tcp.Close();
                WriteLog.WriteServerLogs("断开连接....");
            }
        }

        private void asyncread(TcpClient sock)
        {

            NetworkStream stream = sock.GetStream();
            StateObject state = new StateObject();
            state.client = sock;
            if (stream.CanRead)
            {
                try
                {
                    IAsyncResult ar = stream.BeginRead(state.buffer, 0, StateObject.BufferSize,
                            new AsyncCallback(TCPReadCallBack), state);
                }
                catch (Exception e)
                {
                    WriteLog.WriteServerLogs("Receive Error..");
                }
            }
        }

        public List<byte[]> list = new List<byte[]>();
        private void TCPReadCallBack(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            //主动断开时

            if ((state.client == null) || (!state.client.Connected))
                return;
            int numberOfBytesRead;
            NetworkStream mas = state.client.GetStream();

            numberOfBytesRead = mas.EndRead(ar);
            state.totalBytesRead += numberOfBytesRead;


            if (numberOfBytesRead > 0)
            {
                byte[] dd = new byte[numberOfBytesRead];
                Array.Copy(state.buffer, 0, dd, 0, numberOfBytesRead);

                state.list.Add(dd);
                SaveData(dd, state);
                mas.BeginRead(state.buffer, 0, StateObject.BufferSize,
                        new AsyncCallback(TCPReadCallBack), state);

            }
            else
            {
                //被动断开时 

                mas.Close();
                state.client.Close();

                mas = null;
                state = null;
                WriteLog.WriteServerLogs("连接异常中断");

            }

        }

        private void SaveData(byte[] bs, StateObject state)
        {

            if (bs == null || bs.Length == 0)//数据长度为0则返回
                return;

            byte[] buffer = null;
            List<byte> l = new List<byte>();
            if (bs[0] == 0x7E)
            {
                if (CheckBufferComplete(bs))
                {
                    buffer = bs;
                    ResetList(state);
                }
                else
                    return;
            }
            else
            {
                buffer = ConnectBuffer(state);

                if (CheckBufferComplete(buffer))
                {
                    ResetList(state);
                }
                else
                    return;
            }

            //处理小车反馈的数据
            Asrv a = new Asrv();
            a.Address = GetAsrvAddress(buffer);
            a.Data = GetAsrvFeedbackData(buffer);

            a.ProcessData();


        }
        /// <summary>
        /// 获取小车地址
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private byte[] GetAsrvAddress(byte[] buffer)
        {
            List<byte> list = new List<byte>();
            //根据协议小车地址为第5~12个字节
            for (int i = 4; i < 12; i++)
            {
                list.Add(buffer[i]);
            }

            return list.ToArray();

        }


        private byte[] GetAsrvFeedbackData(byte[] buffer)
        {
            List<byte> list = new List<byte>();
            //根据协议小车发送的数据为第16个至最后一个字节（既校验和）之前
            for (int i = 15; i < buffer.Length - 1; i++)
            {
                list.Add(buffer[i]);
            }

            return list.ToArray();
        }

        /// <summary>
        /// 清空数据数组
        /// </summary>
        /// <param name="state"></param>
        private void ResetList(StateObject state)
        {
            state.list.Clear();
        }

        /// <summary>
        /// 连接数据包
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private byte[] ConnectBuffer(StateObject state)
        {
            List<byte> list = new List<byte>();
            byte[] b = null;
            for (int i = 0; i < state.list.Count; i++)
            {
                b = state.list[i];
                for (int j = 0; j < b.Length; j++)
                {
                    list.Add(b[j]);
                }
            }


            return list.ToArray();

        }

        /// <summary>
        /// 验证数据包是否正确
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        private bool CheckBufferComplete(byte[] bs)
        {
            int length = 0;
            int cnt = bs.Length;

            if (cnt >= 3)
            {
                length = Convert.ToInt32(bs[1].ToString() + bs[2].ToString(), 10);
            }


            if (length == cnt - 4) //判断数据包长度是否正确
            {
                //判断校验和是否正确 根据协议校验和为最后一个字节
                int sum = 0;

                byte check;
                for (int i = 3; i < cnt - 1; i++)
                {
                    sum += bs[i];
                }

                if (sum <= 255)
                    check = (byte)sum;
                else
                {
                    check = (byte)sum;
                    check = (byte)(~check);
                }

                if (check == bs[cnt - 1])

                    return true;
                else
                    return false;
            }
            else
                return false;

        }


        /// <summary>
        /// 判断小车当前是否为待命状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool CanSendCmd(byte[] status)
        {
            if (status == null || status.Length == 0)
                return false;


            string s = "";
            string bits = "";
            int length = 0;



            for (int i = 0; i < status.Length; i++)
            {
                bits = Convert.ToString(status[i], 2);
                length = bits.Length;
                if (length < 8)
                {
                    for (int j = 0; j < 8 - length; j++)
                    {
                        bits = "0" + bits;
                    }
                }


                s = s + bits;
            }

            char[] bit = s.ToCharArray();

            if (bit[4] == '0' && bit[7] == '0' && bit[12] == '0' && bit[13] == '0' && bit[14] == '1' && bit[15] == '0')
                return true;

            return false;
        }


    }

    class StateObject
    {
        public List<byte[]> list = new List<byte[]>();
        public Timer tmr;
        public Socket sk;
        public TcpClient client;
        public int totalBytesRead = 0;
        public int i = 0;
        public const int BufferSize = 1024;
        public byte[] buffer = new byte[BufferSize];


    }
}
