using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using EntpClass.BizLogic.Security;
using EntpClass.Common;
using System.Text;

public partial class Public_UcSysMessageList : UserControlBase
{
    private DataSet GetUnReadMessageList()
    {
        string proc = "msg.GetUnReadMessageList";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);      
        //db.AddInParameter(cmd, "pUserId", DbType.Int32, CurrentUser.UserID); //ajax后台请求时，Session无效，需要通过Querystring来取
        db.AddInParameter(cmd, "pUserId", DbType.Int32, UserID);
        db.AddInParameter(cmd, "pSysLinkFlag", DbType.Int32, -1);
        DataSet ds = db.ExecuteDataSet(cmd);
        return ds;
    }


    [UserControlPartialRender(Key = "UserID", Source = UserControlPartialRenderSource.QueryString)]
    public string UserID
    {
        get;
        set;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!IsPostBack)
        {
            DataSet ds = GetUnReadMessageList();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["page_url"] = "javascript:ShowDjLinkDetail('" + UrlHelper.UrlBase + "/CommonUI/WebForm/DialogFrame.aspx?DialogUrl="+ UrlHelper.UrlBase + ds.Tables[0].Rows[i]["page_url"] + "')";
            }

            RptRemindList.Visible = true;
            RptRemindList.DataSource = ds;          
            RptRemindList.DataBind();
        }
    }


   
}