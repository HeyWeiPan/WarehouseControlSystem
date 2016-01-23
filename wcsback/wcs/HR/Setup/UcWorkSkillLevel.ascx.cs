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
using EntpClass.BizLogic.HR;
using EntpClass.BizLogic.HR.Setup;

public partial class HR_Setup_UcWorkSkillLevel : GridControlBase<WorkSkillLevel>
{
    private int _WorkSkillId = 0;
    public int WorkSkillId
    {
        get { return _WorkSkillId; }
        set { _WorkSkillId = value;}
    }

    protected override GridView GetGridViewControl()
    {
        return GrdList;
    }

    protected override DataSet GetGridDataSet()
    {
        string proc = "HR.GetWorkSkillLevelList";
        Database db = DatabaseFactory.CreateDatabase(HRConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pWorkSkillId", DbType.Int32, WorkSkillId);
        DataSet ds = db.ExecuteDataSet(cmd);
        return ds;    
    }

    protected override bool OnInsert(PageBase page, Database db, DbTransaction transaction)
    {
        Hashtable dataControls = page.DataControlCollection;

        UcHiddenField HidWorkSkillId = new UcHiddenField();
        HidWorkSkillId.ID = "HidWorkSkillId";
        HidWorkSkillId.ColumnName = "workskill_id";
        HidWorkSkillId.RequiredField = true;
        HidWorkSkillId.Value = Fn.ToString(WorkSkillId);

        page.AddControl(HidWorkSkillId);

        return base.OnInsert(page, db, transaction);
    }
}
