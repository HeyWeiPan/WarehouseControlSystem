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

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.Security;

public partial class Home_GetHistroyChildNodes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UcTreeList.NodeBinding += new EventHandler<TreeNodeBindingEventArgs>(UcTreeList_NodeBinding);
        UcTreeList.BindData(GetHistoryDataSource(), "FUNCTION_ID", "FUNCTION_PID", "");
        UcTreeList.Target = "MainWindow";

        Response.Write(HttpUtility.UrlDecode(UcTreeList.ToXML()));
        Response.End();
    }

    void UcTreeList_NodeBinding(object sender, TreeNodeBindingEventArgs e)
    {
        e.Node.Text = Fn.ToString(e.Row["function_name_" + DBSetting.MultiLanguageSuffix]);
        string pageUrl = Fn.ToString(e.Row["page_url"]);
        if (pageUrl != string.Empty)
        {
            e.Node.NavigateUrl = "Navigate.aspx?FuncID=" + Fn.ToString(e.Row["function_id"]);
        }

        //string target = Fn.ToString(e.Row["target"]);
        //if (target != string.Empty)
        //{
        //    e.Node.Target = target;
        //}
    }

    private DataTable GetHistoryDataSource()
    {
        string s = "";
        DbCommand cmd = null;
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);

        if (DBSetting.UseDatabaseType == DatabaseType.Oracle)
        {
            s = "select -2 function_id,null function_pid,'最近访问的10个页面' function_name_cn,'Latest 10 Visited Pages' function_name_en,null page_url,null target from dual union all ";
            s = s + "select -1 function_id,null function_pid,'本月访问次数最多的10个页面' function_name_cn,'Top 10 Visited Pages' function_name_en,null page_url,null target from dual union all ";
            s = s + "select * from (select a.function_id,-2 function_pid,b.function_name_cn,b.function_name_en,b.page_url,b.target ";
            s = s + "from (select function_id,max(click_date) from scr_click_history  h where h.user_id = " + CurrentUser.UserID.ToString() + " group by function_id order by max(click_date) desc) a,scr_function b ";
            s = s + "where a.function_id=b.function_id(+)) where rownum<=10 union all ";
            s = s + "select * from (select a.function_id,-1 function_pid,b.function_name_cn,b.function_name_en,b.page_url,b.target ";
            s = s + "from (select function_id,count(*) from scr_click_history h where h.user_id = " + CurrentUser.UserID.ToString() + " and click_date > sysdate - 30 group by function_id order by count(*) desc) a,scr_function b ";
            s = s + "where a.function_id=b.function_id(+)) where rownum<=10";

            cmd = db.GetSqlStringCommand(s);
        }
        else if(DBSetting.UseDatabaseType == DatabaseType.SqlServer)
        {
            cmd = db.GetStoredProcCommand("GetHistroyBrowse");
            db.AddInParameter(cmd, "pUserID", DbType.Int32, CurrentUser.UserID);
        }

        DataSet ds = db.ExecuteDataSet(cmd);

        return ds.Tables[0];
    }
}