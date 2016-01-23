using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.Security;

public partial class Home_MenuWindow : PageBase
{
    public override void InitializeEvents()
    {
        PageBase page = (PageBase)this.Page;
        page.Load += new EventHandler(Page_Load);      
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            UcTreeMenuList.NodeBinding += new EventHandler<TreeNodeBindingEventArgs>(UcTreeMenuList_NodeBinding);
            UcTreeMenuList.BindData(GetDataSource(), "FUNCTION_ID", "FUNCTION_PID", "Show_Order asc");
            UcTreeMenuList.Target = "MainWindow";
        }
    }

    public override void SetPageInfo(ref PageParameter pageSetting)
    {
        return ;
    }

    void UcTreeMenuList_NodeBinding(object sender, TreeNodeBindingEventArgs e)
    {
        e.Node.Text = Fn.ToString(e.Row["FUNCTION_name_" + DBSetting.MultiLanguageSuffix]);
        string pageUrl = Fn.ToString(e.Row["page_url"]);
        if (pageUrl != string.Empty)
        {
            if (pageUrl[0] == '/')
            {
                e.Node.NavigateUrl = UrlHelper.UrlBase + pageUrl;
            }
            else
            {
                e.Node.NavigateUrl = pageUrl;
            }
        }

        string target = Fn.ToString(e.Row["target"]);
        if (target != string.Empty)
        {
            e.Node.Target = target;
        }
    }

    private DataTable GetDataSource()
    {
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);

        DbCommand cmd = db.GetSqlStringCommand("select * from scr_function");

        return db.ExecuteDataSet(cmd).Tables[0];
    }
}
