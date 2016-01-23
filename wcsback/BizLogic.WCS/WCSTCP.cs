using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace EntpClass.BizLogic.WCS
{
    public class WCSTCP
    {
        public string SendCmd()
        {

            try
            {
                int port = 2101;
                string host = "192.168.0.8";
                IPAddress ip = IPAddress.Parse(host);
                IPEndPoint ipe = new IPEndPoint(ip, port);//把ip和端口转化为IPEndPoint实例
                Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建一个Socket

                c.Connect(ipe);//连接到服务器
                string sendStr = "hello!This is a socket test";
                byte[] bs = new byte[64];
                
                bs[0] = 0x7e;
                bs[1] = 0x00;
                bs[2] = 0x0f;
                bs[3] = 0x10;
                bs[4] = 0x01;
                bs[5] = 0x00;
                bs[6] = 0x13;
                bs[7] = 0xa2;
                bs[8] = 0x00;
                bs[9] = 0x40;
                bs[10] = 0xa8;
                bs[11] = 0x99;
                bs[12] = 0x59;
                bs[13] = 0xff;
                bs[14] = 0xfe;
                bs[15] = 0x00;
                bs[16] = 0x00;
                bs[17] = 0x34;
                bs[18] = 0x2e;
                


                c.Send(bs, 19, 0);//发送测试信息
                string recvStr = "";
                byte[] recvBytes = new byte[1024];
                int bytes;
                bytes = c.Receive(recvBytes, recvBytes.Length, 0);//从服务器端接受返回信息
                recvStr += Encoding.ASCII.GetString(recvBytes, 0, bytes);

                c.Close();

                return recvStr;
            }
            catch (ArgumentNullException e)
            {
                throw e;
            }
            catch (SocketException e)
            {
                throw e;
            }

        }
    }
}
