///----------------------------------------------------------------'
///Author:LZJ
///Date: 2011-5--21
///Comments:App_Parameter Config
///Version History: (Add most recent change to top of list)
///Date：
///Name:
///Description:        
///----------------------------------------------------------------

using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EntpClass.WebUI;
using EntpClass.BizLogic;
using EntpClass.BizLogic.Setup;
using System.Text;
using EntpClass.BizLogic.Security;

public partial class Setup_AppParameter_AppParameterList : SetUpListPageBase<AppParameter>
{
    protected override void SetScopeParameter(ref ScopeWindowParameters p)
    {
        p.Width = 520;
        p.Height = 250;
        p.UserControlPath = "~/Setup/AppParameter/UcAppParameterScope.ascx";
    }

    protected override DataSet GetDataSet(ScopeSqlParameters p)
    {

        //从<app_parameter>取数据
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);

        StringBuilder sql = new StringBuilder(500);
        sql.Append("select code, description, module_name, data_type, data_text, enable_flag ");
        sql.AppendFormat(" from app_parameter t ");
        sql.AppendFormat(" join {0} on t.code = {1}.id ", p.TableSql, p.TableAlias);
        sql.AppendFormat(" order by {0}.show_order", p.TableAlias);
        DbCommand cmd = db.GetSqlStringCommand(sql.ToString());

        DataSet ds = db.ExecuteDataSet(cmd);

        return ds;
    }

}
