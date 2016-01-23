using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Web.UI.WebControls;
using EntpClass.BizLogic.HR;
using EntpClass.BizLogic.HR.Public;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.WebUI;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EntpClass.BizLogic.Security;

public partial class Home_Notification_NotificationList : SetUpListPageBase<Notification>
{
    protected override void SetScopeParameter(ref ScopeWindowParameters p)
    {
    }

    protected override DataSet GetDataSet(ScopeSqlParameters p)
    {        
        StringBuilder s = new StringBuilder(300);
        s.Append("SELECT notify_id,'(' + cast(month(issue_date) as nvarchar(10)) +  '.' + cast(day(issue_date) as nvarchar(10)) + ') ' + title title,");
        s.Append(" issue_by = dbo.getUserName(create_by,''),issue_Date,pause_date,attachment_notify_flag,set_top_flag");
        s.Append(" From def_notification n");
        s.Append(" INNER JOIN ");
        s.Append(p.TableSql);
        s.AppendFormat(" ON n.notify_id = {0}.id", p.TableAlias);        
        s.AppendFormat(" order by {0}.show_order", p.TableAlias);

        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetSqlStringCommand(s.ToString());
        DataSet ds = db.ExecuteDataSet(cmd);
        return ds;
    }

    protected override DataControlField OnGridColumnCreating(string colName)
    {
        DataControlField f = null;

        switch (colName.ToUpper())
        {
            case "TITLE":
                UCDialogHyperLinkField f1 = new UCDialogHyperLinkField();
                f1.DataTextField = "title";
                f1.DataLinkFiled = "notify_id";
                f1.DataLinkClientScriptFunction = "ShowNotification('VIEW',linkParam)";
                f1.HeaderText = "title";
                f1.SortExpression = "title";
                return f1;
            case "ISSUE_BY":
                f = base.OnGridColumnCreating(colName);
                f.SortExpression = "create_by";
                return f;
            case "ISSUE_TEAM":
                f = base.OnGridColumnCreating(colName);
                f.SortExpression = "issue_team_id";
                return f;
        }

        return base.OnGridColumnCreating(colName);
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        if (!this.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegeditNotification"))
        {
            Notification notification = new Notification();
            DialogWindow dw = notification.DetailDialogWindow;

            StringBuilder s = new StringBuilder(200);
            s.Append(PageBase.GetShowDialogWindowClientFunction(dw, "ShowNotification"));

            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegeditNotification", s.ToString(), true);
        }
    }
}
