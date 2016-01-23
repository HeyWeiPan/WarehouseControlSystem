using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.WebUI;
using EntpClass.BizLogic.WCS;
using System.Data;
using System.Data.Common;

public partial class WCS_wh_EquipmentList : SetUpListPageBase<Equipment>
{
    protected override void SetScopeParameter(ref ScopeWindowParameters p)
    {
        p.UserControlPath = "~/WCS/WH/UcEquipmentScope.ascx";
        p.Width = 500;
        p.Height = 300;
    }

    protected override DataSet GetDataSet(ScopeSqlParameters p)
    {
        string proc = "WCS.GetEquipmentList";
        Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pTableSql", DbType.String, p.TableSql);
        db.AddInParameter(cmd, "pTableAlias", DbType.String, p.TableAlias);
        db.AddInParameter(cmd, "pLanguage", DbType.String, DBSetting.MultiLanguageSuffix);
        DataSet ds = db.ExecuteDataSet(cmd);
        return ds;

    }

    protected override DataControlField OnGridColumnCreating(string colName)
    {
        DataControlField f = base.OnGridColumnCreating(colName);

        switch (colName.ToLower())
        {

            case "equipment_type_name":
                f.SortExpression = "equipment_type_id";
                break;
            case "wh_code":
                f.SortExpression = "wh_id";
                break;
        }

        return f;
    }
}