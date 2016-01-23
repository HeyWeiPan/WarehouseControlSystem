using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using System.Timers;
using WCSServer;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using EntpClass.Common;
using EntpClass.BizLogic.WCS;

public partial class WCS_map_MapTaskTop : PageBase
{
    static System.Timers.Timer timer  = new System.Timers.Timer();

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        
        timer.Elapsed += new ElapsedEventHandler(theout);
        timer.Interval = 1000;
        timer.AutoReset = true;
        timer.Enabled = false;
    }

    public override void SetPageInfo(ref EntpClass.Common.PageParameter p)
    {
       
    }

    public void theout(object source, ElapsedEventArgs e)
    {
        string cmdId = GetCmdId();

        //如果没有未分配的任务，只计算路权
        if (cmdId == "0")
        {
            SetRoadRight();
            //UpdateCmd();
            return;
        }

        Route r = new Route();
        r.CalcRoute(cmdId);
        SetRoadRight();
        //UpdateCmd();

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
        UpdateCmd();
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
    protected void BtnStart_Click(object sender, EventArgs e)
    {
        timer.Start();
        timer.Enabled = true;
    }
    protected void BtnStop_Click(object sender, EventArgs e)
    {
        timer.Stop();
        timer.Enabled = false;
    }
}