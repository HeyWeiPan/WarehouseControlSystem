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

public partial class HR_Setup_JobStructureList : SetUpListPageBase<JobStructure>
{
    private UcButton BtnImport;

    private void RegeditDetailScript()
    {
        if (!ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegeditDetail"))
        {
            StringBuilder s = new StringBuilder(500);           
            DialogWindow dw = new DialogWindow();
            dw.Url = UrlHelper.UrlBase + "/HR/Setup/JobStructureImport.aspx";
            dw.Width = 1000;
            dw.Height = 700;            

            s.Append("function ShowImport()");
            s.Append("{");
            s.Append("var returnValue = '';" + dw.GetShowModalDialogScript("returnValue"));
            s.Append("if(returnValue =='REFRESH'){return true;}return false;");
            s.Append("}");

            ClientScript.RegisterClientScriptBlock(this.GetType(), "RegeditDetail", s.ToString(), true);
        }
    }
    
    protected override void SetScopeParameter(ref ScopeWindowParameters p)
    {
        p.Width = 500;
        p.Height = 400;
        p.UserControlPath = "~/HR/Setup/UcJobStructureScope.ascx";
    }

    protected override DataSet GetDataSet(ScopeSqlParameters p)
    {
        string proc = "HR.GetJobStructureList_Scope";
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
            case "JOB_CODE":
                UCDialogHyperLinkField f1 = new UCDialogHyperLinkField();
                f1.DataTextField = "job_code";
                f1.DataLinkFiled = "job_structure_id";
                f1.DataLinkClientScriptFunction = "ShowDetail('VIEW',linkParam)";
                f1.HeaderText = "job_code";
                f1.SortExpression = "job_code";            
                return f1;         
            case "JOB_USERS":
                BoundField b = new BoundField();
                b.DataField = "job_users";
                b.HeaderText = "job_users";
                b.SortExpression = "hr.GetJobUsers(job_code)";
                b.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                return b;
            case "JOB_SUMMARY":
                return null;
        }

        return base.OnGridColumnCreating(colName);
    }

    protected override void OnInit(EventArgs e)
    {
        BtnImport = new UcButton();
        BtnImport.ID = "BtnImport";
        BtnImport.ColumnName = "Import";
        BtnImport.Visible = false;
        BtnImport.Click += new EventHandler(BtnImport_Click);
        BtnImport.OnClientClick = "if(!ShowImport()){window.event.cancelBubble = true;return false;};";
        BtnImport.Width = Unit.Parse("70px"); 

        UcButton BtnExport = ((UcButton)this.GetMasterPageControl("BtnExport"));
        BtnExport.ColumnName = "Export";
        BtnExport.Width = Unit.Parse("70px"); 

        this.AddLeftButtonBarControl(BtnImport);
                
        base.OnInit(e);
    }

    protected override void OnExport()
    {        
        string errorMesage;
        string filePath = Request.PhysicalApplicationPath + @"Export\JobStructure.xls";
        ScopeSqlParameters p = new ScopeSqlParameters();
        p.TableSql = string.Format("({0}) {1}", GetExportSql(), p.TableAlias);
        DataTable dt = GetDataSet(p).Tables[0];

        bool b = ExcelHelper.WriteExcelFile(filePath, dt, "JobStructure", out errorMesage);
        if (b)
            ExcelHelper.ExportToExcel(filePath);
        else
            Alert(errorMesage);      
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        RegeditDetailScript();
        BtnImport.Visible = RightHelper.CheckFuncRightCached(JobStructure.FUNCTIONID, "IMPORT");
    }
    
    void BtnImport_Click(object sender, EventArgs e)
    { 
    
    }
}
