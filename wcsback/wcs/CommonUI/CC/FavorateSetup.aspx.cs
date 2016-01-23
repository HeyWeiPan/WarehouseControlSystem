using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using EntpClass.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

using System.Data;
using EntpClass.BizLogic.Security;

public partial class CC_FavorateSetup : PageBase
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
        LB.SqlText = string.Format("select menu_name_cn function_name,function_id from scr_favorate where user_id={0} order by show_order", CurrentUser.UserID);
        LB.DataValueField = "function_id";
        LB.DataTextField = "function_name";
        LB.DataSource = null;
        LB.DataBind();


    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        SaveOtherBudget(HidXml.Value);
        Response.Redirect("FavorateSetup.aspx");
    }


    public void SaveOtherBudget(string xmlVal)
    {
        string proc = "PA.UpdateUserFavorateFunc";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pXml", DbType.Xml, HttpUtility.UrlDecode(xmlVal));
        db.AddInParameter(cmd, "pUserId", DbType.Int32, CurrentUser.UserID);
        db.ExecuteNonQuery(cmd);
    }
}