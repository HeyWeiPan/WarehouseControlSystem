using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using EntpClass.WebUI;
using EntpClass.Common;

public partial class CommonUI_WebForm_GetReport : PageBase
{
    private int RenderType
    {
        get
        {
            return Fn.ToInt(this.Request.QueryString["RenderType"]);
        }
    }

    public override void InitializeEvents()
    {
        PageBase page = (PageBase)this.Page;
        page.Load += new EventHandler(Page_Load);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ReportScopePageBase reportScopePage = this.PreviousPage as ReportScopePageBase;
        this.Title = reportScopePage.ReportSetting.ReportPageTitle;
        this.LblTitle.Text = reportScopePage.ReportSetting.ReportPageTitle;

        Control requiredControl = null;
        string errorMsg = string.Empty;
        if (!reportScopePage.OnCheckRequired(false, out requiredControl, out errorMsg))
        {
            Alert(errorMsg);
            this.CloseWithResponse();
            return;
        }

        //string reportUrl = reportScopePage.GetReportUrl();
        //reportUrl = HttpUtility.HtmlDecode(reportUrl);
        //IfraSubWindow.Attributes.Add("src", reportUrl);
        RadioButton RbtIE = reportScopePage.Form.FindControl("RbtIE") as RadioButton;
        RadioButton RbtExcel = reportScopePage.Form.FindControl("RbtExcel") as RadioButton;
        RadioButton RbtPDF = reportScopePage.Form.FindControl("RbtPDF") as RadioButton;

        if (RbtIE != null && RbtIE.Checked)
        {
            form1.Visible = false;
            reportScopePage.RenderHTML();            
        }
        if (RbtExcel != null && RbtExcel.Checked)
        {
            form1.Visible = false;
            reportScopePage.RenderExcel();
        }
        if (RbtPDF != null && RbtPDF.Checked)
        {
            form1.Visible = false;
            reportScopePage.RenderPDF();
        }      
    }

    public override void SetPageInfo(ref EntpClass.Common.PageParameter p)
    {
        p.FunctionID = (this.PreviousPage as ReportScopePageBase).PageSetting.FunctionID;
    }
}
