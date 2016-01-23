using EntpClass.BizLogic.WCS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCSServer;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Label1.Text = GetBitToHex(0, 0, 1, 0).ToString();
        //SendCmd sc = new SendCmd();
        ////发送路权令牌
        //DataSet dsToken = sc.GetRoadRightCMD();
        //byte[] bufferRight = null;
        //for (int j = 0; j < dsToken.Tables[0].Rows.Count; j++)
        //{
        //    bufferRight = Asrv.GetSendData(Asrv.GetTokenCmd(int.Parse(dsToken.Tables[0].Rows[j]["step_num"].ToString())), (byte[])(dsToken.Tables[0].Rows[j]["address"]));
        //    string cmdId = dsToken.Tables[0].Rows[j]["cmd_id"].ToString();
        //    sc.InsertCmdBreakdown(cmdId, bufferRight);
        //    //if (sc.checktokensendcnt(cmdid, bufferright)) //如果相同的令牌发送次数没有超过最大发送次数则发送路权令牌
        //    //{

        //    //    workstream.write(bufferright, 0, bufferright.length);


        //    //    sc.insertcmdbreakdown(cmdid, bufferright);
        //    //}
        //}

        
    }

    public byte GetBitToHex(byte bit01, byte bit23, byte bit4, byte bit5)
    {
        int temp;
        temp = ((bit5 << 5) & 0x20) | ((bit4 << 4) & 0x10) | ((bit23 << 2) & 0x0c) | (bit01 & 0x03);
        return (byte)temp;
    }
}