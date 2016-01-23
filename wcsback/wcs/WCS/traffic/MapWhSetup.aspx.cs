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
public partial class WCS_map_MapWhSetup : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public override void SetPageInfo(ref EntpClass.Common.PageParameter p)
    {

    }

    public string WhId
    {
        get
        {
            return Fn.ToString(Request.QueryString["WhId"]);
        }
    }
    public string WhModeId 
    {
        get { return Fn.ToString(Request.QueryString["WhModeId"]); }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);


        PH1.Controls.Add(new LiteralControl(GetTableHtml()));

    

    }

   

    public string GetTableHtml()//同MapWh.aspx.cs
    {

        if (WhId == "")
            return "";

        string proc = "WCS.GetWhTrafficHtml";
        Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pWhId", DbType.Int32, WhId);
        db.AddOutParameter(cmd, "pOut", DbType.String, 100000000);
        db.ExecuteNonQuery(cmd);
        return Fn.ToString(db.GetParameterValue(cmd, "pOut"));
    }


  
   
}