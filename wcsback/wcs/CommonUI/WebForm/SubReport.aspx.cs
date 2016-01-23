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

public partial class Jxc_Report_SubReport : PageBase
{
    ReportHelper report = null;

    protected override void OnPreRenderComplete(EventArgs e)
    {
        base.OnPreRenderComplete(e);
        report = new ReportHelper(Fn.ToString(Request["url"]));
        report.Format = ReportHelper.HTMLFORMAT;
        report.AddReportParameter("IsHTMLFormat", report.IsHTMLFormat());

        for (int i = 0; i < Request.QueryString.Count; i++)
        {
            if (Fn.ToString(Request.QueryString.Keys[i]) != "url")
            {
                if (Server.UrlDecode(Fn.ToString(Request.QueryString[i])) != "")
                {
                    if (Fn.ToString(Request.QueryString.Keys[i]).Substring(0, 3) == "INT")
                    {
                        report.AddReportParameter(Fn.ToString(Request.QueryString.Keys[i]).Substring(4), Fn.ToInt(Request.QueryString[i]));
                    }
                    else if (Fn.ToString(Request.QueryString.Keys[i]).Substring(0, 3) == "CHA")
                    {
                        report.AddReportParameter(Fn.ToString(Request.QueryString.Keys[i]).Substring(4), Fn.ToString(Request.QueryString[i]));
                    }
                    else if (Fn.ToString(Request.QueryString.Keys[i]).Substring(0, 3) == "BOL")
                    {
                        report.AddReportParameter(Fn.ToString(Request.QueryString.Keys[i]).Substring(4), Fn.ToBoolean(Request.QueryString[i]));
                    }
                }
            }
        }

        report.RenderHTML();
    }

    public override void SetPageInfo(ref PageParameter p)
    {
        return;
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (DdlExportType.SelectedValue != "")
        {
            if (DdlExportType.SelectedValue == "EXCEL")
            {
                report.RenderExcel();
            }
            else if (DdlExportType.SelectedValue == "WORD")
            {
                //report.Format = "WORD";
                //report.Render();
            }
            else if (DdlExportType.SelectedValue == "PDF")
            {
                report.RenderPDF();
            }
        }
    }
}