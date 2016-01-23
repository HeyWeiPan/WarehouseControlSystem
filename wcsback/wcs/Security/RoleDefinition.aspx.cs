using System;
using System.Text;
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
using EntpClass.BizLogic.Security;
using EntpClass.WebControlLib.Derived;

public partial class RoleDefinition : SetUpListPageBase<Role>
{    
    protected override DataSet GetDataSet(ScopeSqlParameters p)
    {
        StringBuilder s = new StringBuilder(200);
    
        s.Append("select role_name, description, system_role_flag, role_id  ");
        s.AppendFormat("from scr_role ,{0} ", p.TableSql);            
        s.AppendFormat(" where role_id = {0}.id", p.TableAlias);
        s.AppendFormat(" order by {0}.show_order", p.TableAlias);
        
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetSqlStringCommand(s.ToString());
        DataSet ds = db.ExecuteDataSet(cmd);

        return ds;
    }

    protected override void SetScopeParameter(ref ScopeWindowParameters p)
    {
        p.Width = 600;
        p.Height = 450;
        p.UserControlPath = "~/Security/UcRoleDefinitionScope.ascx";
    }
}

