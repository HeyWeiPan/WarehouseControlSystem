using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.BizLogic.WCS;
using EntpClass.Common;
using EntpClass.WebUI;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Drawing;

public partial class WCS_map_AsrvStatus : PageBase
{

    public string AsrvId
    {
        get
        {
            return Fn.ToString(Request.QueryString["AsrvId"]);
        }
    }

    public string AsrvCode
    {
        get
        {
            return Fn.ToString(Request.QueryString["AsrvCode"]);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public override void SetPageInfo(ref EntpClass.Common.PageParameter p)
    {

    }

    public DataTable GetAsrvStatus()//根据仓库编号和楼层编号提取数据库中信息
    {
        string proc = "WCS.GetAsrvStatus";
        Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pAsrvId", DbType.Int32, AsrvId);

        return db.ExecuteDataSet(cmd).Tables[0];

    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        SetAsrvStatus(GetAsrvStatus());
    }


    public void SetAsrvStatus(DataTable dt)
    {
        char[] statusbits = GetStatusBits((byte[])dt.Rows[0]["current_status"]);

        L1.Text = statusbits[15] == '0' ? "1.停车等待" : "1.执行任务";
        L2.Text = statusbits[14] == '0' ? "2.手动模式" : "2.自动模式";
        L3.Text = statusbits[13] == '0' ? "3.正常行进" : "3.紧急停车";
        L4.Text = statusbits[12] == '0' ? "4.没有充电" : "4.充电中";
        L5.Text = statusbits[11] == '0' ? "5.充电结束" : "6.正在充电";
        L6.Text = statusbits[10] == '0' ? "6.Zigbee通信正常" : "6.Zigbee通信暂时中断";
        L7.Text = statusbits[9] == '0' ? "7.上方无货物" : "7.上方有货物";
        L8.Text = statusbits[8] == '0' ? "8.前方无货物" : "8.前方无货物";
        L9.Text = statusbits[7] == '0' ? "9.防撞检测无异物" : "9.防撞检测有异物";
        L10.Text = statusbits[6] == '0' ? "10.托盘落下" : "10.托盘抬升";
        L11.Text = statusbits[5] == '0' ? "11.车轮位于巷道方向" : "11.车轮位于货道方向";
        L12.Text = "12.电量：" + Fn.ToString(dt.Rows[0]["current_power"]) + "%";

        char[] errorbits = GetStatusBits((byte[])dt.Rows[0]["error_status"]);

        E1.Text = errorbits[7] == '0' ? "1.电量正常" : "1.电量低报警";
        if (errorbits[7] == '1')
            E1.ForeColor = Color.Red;


        E2.Text = errorbits[6] == '0' ? "2.Zigbee通信正常" : "2.Zigbee通信故障";
        E3.Text = errorbits[5] == '0' ? "3.RFID通信正常" : "3.RFID通信故障";
        E4.Text = errorbits[4] == '0' ? "4.伺服通信正常" : "4.伺服通信故障";

        if (errorbits[7] == '1')
            E1.ForeColor = Color.Red;

        if (errorbits[6] == '1')
            E2.ForeColor = Color.Red;

        if (errorbits[5] == '1')
            E3.ForeColor = Color.Red;

        if (errorbits[4] == '1')
            E4.ForeColor = Color.Red;


        string m = errorbits[3].ToString() + errorbits[2].ToString() + errorbits[1].ToString();


        E5.ForeColor = Color.Red;
        if (m == "000")
        {
            E5.Text = "5.伺服电机正常";
            E5.ForeColor = Color.Black;
        }
        else if (m == "100")
            E5.Text = "5.#1电机故障";
        else if (m == "010")
            E5.Text = "5.#2电机故障";
        else if (m == "110")
            E5.Text = "5.#3电机故障";
        else if (m == "001")
            E5.Text = "5.#4电机故障";
        else if (m == "101")
            E5.Text = "5.#5电机故障";
        else if (m == "011")
            E5.Text = "5.#6电机故障";
    }


    public char[] GetStatusBits(byte[] status)
    {
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
        return bit;
    }


    protected override string GetPageTitle()
    {
        return "小车" + AsrvCode + "状态";
    }
}