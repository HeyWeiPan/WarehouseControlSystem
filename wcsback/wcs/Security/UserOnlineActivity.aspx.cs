using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using EntpClass.BizLogic.Security;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

public partial class Security_UserOnlineActivity : SetUpListPageBase<UserOnlineActivity>
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void SetScopeParameter(ref ScopeWindowParameters p)
    {
       
    }

    protected override System.Data.DataSet GetDataSet(ScopeSqlParameters p)
    {
        StringBuilder s = new StringBuilder(200);

        s.Append("select user_activity_id,u.user_number,u.login_name,u.native_name, ip,login_time, last_action_function_id, last_action_time  ");
        s.AppendFormat("from def_user_online_activity ua ,def_user u,{0} ", p.TableSql);
        s.AppendFormat(" where user_activity_id = {0}.id", p.TableAlias);
        s.Append(" and ua.user_id = u.user_id");

        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetSqlStringCommand(s.ToString());
        DataSet ds = db.ExecuteDataSet(cmd);

        return ds;
    }
}