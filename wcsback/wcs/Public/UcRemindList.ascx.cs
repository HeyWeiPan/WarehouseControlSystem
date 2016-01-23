using System;
using System.Data;
using System.Data.Common;
//using EntpClass.BizLogic.JXC;
//using EntpClass.BizLogic.JXC.Setup;
using EntpClass.BizLogic.Security;
using EntpClass.Common;
using EntpClass.WebUI;
using EntpClass.WebControlLib;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Web.UI.WebControls;

public partial class Public_UcRemindList : UserControlBase
{
    private DataSet GetRemindList()
    {
        string proc = "dbo.GetRemindList";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pLanguage", DbType.String, DBSetting.MultiLanguageSuffix);
        //db.AddInParameter(cmd, "pUserId", DbType.Int32, CurrentUser.UserID); //ajax后台请求时，Session无效，需要通过Querystring来取
        db.AddInParameter(cmd, "pUserId", DbType.Int32, UserID);
        DataSet ds = db.ExecuteDataSet(cmd);
        return ds;
    }


    [UserControlPartialRender(Key = "UserID", Source = UserControlPartialRenderSource.QueryString)]
    public string UserID
    {
        get;
        set;
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        this.RptRemindList.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(RptRemindList_ItemDataBound);
    }

    void RptRemindList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == System.Web.UI.WebControls.ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HyperLink l = e.Item.FindControl("Lnk") as HyperLink;
            DataRowView drv =  e.Item.DataItem as DataRowView;
            if (drv != null)
            {

                l.NavigateUrl = string.Format("javascript:PageTrans('{0}','{1}');", drv["page_url"], drv["page_function_id"]);
            }
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!IsPostBack)
        {
            DataSet ds = GetRemindList();
            RptRemindList.Visible = true;
            RptRemindList.DataSource = ds;
            int i = 0;

            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["page_url"] = UrlHelper.UrlBase + ds.Tables[0].Rows[i]["page_url"];
            }
            RptRemindList.DataBind();
        }
    }


}
