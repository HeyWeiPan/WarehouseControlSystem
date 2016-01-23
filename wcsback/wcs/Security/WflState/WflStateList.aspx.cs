using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.BizLogic.Security;
using EntpClass.BizLogic.Workflow;
using System.Text;
using System.Data.Common;

public partial class Security_WflState_WflStateList : SetUpListPageBase<WflState>
{
    protected override DataSet GetDataSet(ScopeSqlParameters p)
    {
        string proc = "security.GetWflStateList";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pTableSql", DbType.String, p.TableSql);
        db.AddInParameter(cmd, "pTableAlias", DbType.String, p.TableAlias);
        db.AddInParameter(cmd, "pLanguage", DbType.String, DBSetting.MultiLanguageSuffix);
        DataSet ds = db.ExecuteDataSet(cmd);
        return ds;
    }

    protected override void SetScopeParameter(ref ScopeWindowParameters p)
    {
        p.Width = 520;
        p.Height = 300;
        p.UserControlPath = "~/Security/WflState/WflStateScope.ascx";
    }

    
}