using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.Common;
using EntpClass.WebUI;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.HR;
using EntpClass.BizLogic.HR.Setup;

public partial class HR_Setup_WorkSkillList : SetUpListPageBase<WorkSkill>
{
    protected override void SetScopeParameter(ref ScopeWindowParameters p)
    {
        p.Width = 350;
        p.Height = 200;
        p.UserControlPath = "~/HR/Setup/UcWorkSkilScope.ascx";
    }

    protected override DataSet GetDataSet(ScopeSqlParameters p)
    {
        string proc = "HR.GetWorkSkillList";
        Database db = DatabaseFactory.CreateDatabase(HRConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pTableSql", DbType.String, p.TableSql);
        db.AddInParameter(cmd, "pTableAlias", DbType.String, p.TableAlias);
        db.AddInParameter(cmd, "pLanguage", DbType.String, DBSetting.MultiLanguageSuffix);
        DataSet ds = db.ExecuteDataSet(cmd);
        return ds;
    }

    protected override DataControlField OnGridColumnCreating(string colName)
    {
        switch (colName.ToUpper())
        {           
            case "WORKSKILL_CATEGORY_CODE":
                DataControlField f1 = base.OnGridColumnCreating(colName);
                f1.ItemStyle.Width = Unit.Parse("12%");
                return f1;
            case "WORKSKILL_NUMBER":
                DataControlField f2 = base.OnGridColumnCreating(colName);
                f2.ItemStyle.Width = Unit.Parse("12%");
                return f2;
            case "WORKSKILL_NAME":                
                DataControlField f3 = base.OnGridColumnCreating(colName);
                f3.ItemStyle.Width = Unit.Parse("12%");
                return f3;            
        }

        return base.OnGridColumnCreating(colName);
    }

}
