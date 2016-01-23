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

public partial class WCS_map_MapWh : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public override void SetPageInfo(ref EntpClass.Common.PageParameter p)
    {

    }


    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        //PH1为右下方仿真仓库的整片方块，将所有信息添加进去
        PH1.Controls.Add(new LiteralControl(GetTableHtml()));//填充到留空的位置

 

    }


    public string WhId
    {
        get
        {
            return Fn.ToString(Request.QueryString["WhId"]);
        }
    }

    public string FloorNum
    {
        get
        {
            return Fn.ToString(Request.QueryString["FloorNum"]);
        }
    }



    public string GetTableHtml()//根据仓库编号和楼层编号提取数据库中信息
    {

        if (WhId == "" || FloorNum == "")
            return "";
        if (WhId == "undefined" || FloorNum == "undefined")
            return "";


        string proc = "WCS.GetWhMapHtml";
        Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pWhId", DbType.Int32, WhId);
        db.AddInParameter(cmd, "pFloorNum", DbType.Int32, FloorNum);
        db.AddOutParameter(cmd, "pOut", DbType.String, 100000000);
        db.ExecuteNonQuery(cmd);
        return Fn.ToString(db.GetParameterValue(cmd, "pOut"));
    }

  
    

   
}