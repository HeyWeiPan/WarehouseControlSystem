using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntpClass.BizLogic.WCS
{
    public class ZIGBEE
    {
        public byte[] GetSendData(byte[] data, byte[] mac)
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




    }
}
