using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Security;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.Security;

public partial class Security_FavorateDefinitionGetChildNodes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UcTreeMenuList.NodeBinding += new EventHandler<TreeNodeBindingEventArgs>(UcTreeMenuList_NodeBinding);
        UcTreeMenuList.BindData(GetDataSource(), "favorate_ID", "favorate_PID", "create_date asc");
        UcTreeMenuList.Target = "MainWindow";

        Response.Write(HttpUtility.UrlDecode(UcTreeMenuList.ToXML()));
        Response.End();
    }

    void UcTreeMenuList_NodeBinding(object sender, TreeNodeBindingEventArgs e)
    {
        e.Node.Text = Fn.ToString(e.Row["menu_name_" + DBSetting.MultiLanguageSuffix]);
        string pageUrl = Fn.ToString(e.Row["page_url"]);

        if (pageUrl != string.Empty)
        {
            e.Node.NavigateUrl = "Navigate.aspx?FuncID=" + Fn.ToString(e.Row["function_id"]);
            
            #region
            //if (pageUrl[0] == '/')
            //{
            //    e.Node.NavigateUrl = UrlHelper.UrlBase + pageUrl;
            //}
            //else
            //{
            //    e.Node.NavigateUrl = pageUrl;
            //}
            #endregion
        }

        //string target = Fn.ToString(e.Row["target"]);
        //if (target != string.Empty)
        //{
        //    e.Node.Target = target;
        //}
    }

    private DataTable GetDataSource()
    {
        string str = string.Format("select * from scr_favorate where user_id = {0}",CurrentUser.UserID);

        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetSqlStringCommand(str);

        return db.ExecuteDataSet(cmd).Tables[0];
    }
}
