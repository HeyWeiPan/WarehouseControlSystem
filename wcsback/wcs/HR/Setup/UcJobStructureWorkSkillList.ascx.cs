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

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.HR;
using EntpClass.BizLogic.HR.Setup;

public partial class HR_Setup_UcJobStructureWorkSkillList : GridControlBase<JobStructureWorkSkill>
{
    private string WorkSkillCategoryCode
    {
        get { return Fn.ToString(Request.QueryString["Category"]); }
    }

    private string JobCode
    {
        get { return Fn.ToString(Request.QueryString["JobCode"]); }
    }    

    public string GetWorkSkillSql()
    {
        string sql = WorkSkill.GetWorkSkillSql(WorkSkillCategoryCode);          
        return sql;
    }

    private string GetWorkSkillLevelSql(int workSkillId)
    {
        string sql
            = "SELECT workskill_level_id,workskill_level_description = '(' + workskill_level_number + ')'+ workskill_level_description FROM hr_workskill_level a,hr_workskill b"
            + string.Format(" WHERE b.workskill_category_code = '{0}' and b.workskill_id = {1} ", WorkSkillCategoryCode, workSkillId)
            + " AND a.workskill_id = b.workskill_id ORDER BY workskill_level_number";
        return sql;
    }

    private void SetColumnSpan(GridViewRow r)
    {
        r.Cells[2].ColumnSpan = 2;
        r.Cells[2].Width = Unit.Parse("48%");
        r.Cells.RemoveAt(3);          
    }

    protected override GridView GetGridViewControl()
    {
        switch (WorkSkillCategoryCode)
        {
            case "A":
                GrdProfessinal.Visible = true;
                return GrdProfessinal;                
            case "B":
                GrdKnowledge.Visible = true;
                return GrdKnowledge;                
            case "C":
                GrdSkill.Visible = true;
                return GrdSkill;                
            default:
                GrdProfessinal.Visible = true;
                return GrdProfessinal;                
        }                    
    }    

    protected override DataSet GetGridDataSet()
    {
        string proc = "HR.GetJobStructureWorkSkillList";
        Database db = DatabaseFactory.CreateDatabase(HRConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pWorkSkillCategoryCode", DbType.String, WorkSkillCategoryCode);
        db.AddInParameter(cmd, "pJobCode", DbType.String, JobCode);
        DataSet ds = db.ExecuteDataSet(cmd);
        return ds;   
    }

    protected override void SetParameter(GridControlParameter p)
    {
        PageParameter pageSetting = new PageParameter();

        switch (WorkSkillCategoryCode)
        {
            case "A":
                pageSetting.FunctionID = JobStructure.QualityFuncID;
                break;
            case "B":
                pageSetting.FunctionID = JobStructure.KnowledgeFuncID;
                break;
            case "C":
                pageSetting.FunctionID = JobStructure.SkillsFuncID;
                break;
        }

        PageRights right = new PageRights(pageSetting);
        p.AddRight = right.AddRight;
        p.DeleteRight = right.DeleteRight;
        p.EditRight = right.EditRight;

        base.SetParameter(p);
    }

    protected override void InitNewRow(GridViewRow r, Hashtable rowCtrlCollection)
    {
        base.InitNewRow(r, rowCtrlCollection);

        SetColumnSpan(r);        
    }

    protected override void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        base.OnRowEditing(sender, e);

        int editIndex = e.NewEditIndex;

        GridView gv = GetGridViewControl();
        DataSet ds = (DataSet)GetGridViewControl().DataSource;

        GridViewRow r = gv.Rows[editIndex];
        SetColumnSpan(r);

        PageBase page = this.Page as PageBase;
        page.ClearDataControlCollection();
        page.SetDataControlCollection(r.Controls);

        int workSkillId = Fn.ToInt(ds.Tables[0].Rows[editIndex]["workskill_id"]);

        Hashtable dataControlCollection = page.DataControlCollection;
        UcDropDownList DdlWorkSkill = (UcDropDownList)Fn.GetControlByColumnName(dataControlCollection, "workskill_id");
        DdlWorkSkill.Text = Fn.ToString(workSkillId);        

        UcDropDownList DdlWorkSkillLevel = (UcDropDownList)Fn.GetControlByColumnName(dataControlCollection, "workskill_level_id");                
        DdlWorkSkillLevel.SqlText = GetWorkSkillLevelSql(workSkillId);
        DdlWorkSkillLevel.DataBind();
        DdlWorkSkillLevel.Text = Fn.ToString(ds.Tables[0].Rows[editIndex]["workskill_level_id"]);
    }

    protected override bool OnInsert(PageBase page, Database db, DbTransaction transaction)
    {        
        Hashtable dataControls = page.DataControlCollection;

        UcHiddenField HidJobCode = new UcHiddenField();
        HidJobCode.ID = "HidJobCode";
        HidJobCode.ColumnName = "job_code";
        HidJobCode.RequiredField = true;
        HidJobCode.Value = JobCode;

        page.AddControl(HidJobCode);

        return base.OnInsert(page, db, transaction);        
    }

    protected override bool Save(GridViewRow row, Database db, DbTransaction transaction)
    {
        GridView gv = GetGridViewControl();
        bool b = base.Save(row, db, transaction);
        if (!b) { SetColumnSpan(row); }
        return b;
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        PageBase page = this.Page as PageBase;
        if (!page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegeditLinkScript"))
        {
            StringBuilder s = new StringBuilder(500);

            WorkSkill skill = new WorkSkill();
            DialogWindow dw = skill.DetailDialogWindow;
            s.Append(PageBase.GetShowDialogWindowClientFunction(dw, "ShowWorkSkill"));           

            page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegeditLinkScript", s.ToString(), true);
        }
    }

    protected void DdlWorkSkill_SelectedIndexChanged(object sender, EventArgs e)
    {
        UcDropDownList DdlWorkSkill = (UcDropDownList)sender;
        GridViewRow r = (GridViewRow)DdlWorkSkill.Parent.Parent;
        SetColumnSpan(r);

        PageBase page = this.Page as PageBase;
        page.ClearDataControlCollection();
        page.SetDataControlCollection(r.Controls);

        int workSkillId = Fn.ToInt(DdlWorkSkill.Text);

        Hashtable dataControlCollection = page.DataControlCollection;        
        UcDropDownList DdlWorkSkillLevel = (UcDropDownList)Fn.GetControlByColumnName(dataControlCollection, "workskill_level_id");                
        DdlWorkSkillLevel.SqlText = GetWorkSkillLevelSql(workSkillId);
        DdlWorkSkillLevel.DataBind();
    }
}