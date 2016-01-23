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
using EntpClass.WebControlLib;
using EntpClass.BizLogic.Security;
/// <summary>
/// 部门考核评分结果报表
/// </summary>
public partial class HR_UserProfile_Report_UserInsuranceList : ReportScopePageBase
{
    public override void SetPageInfo(ref PageParameter p)
    {
       // p.FunctionID = 5010370;
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }


    protected override void SetReportScopeParameter(ref ReportScopeParameter p)
    {
        p.ReportPath = "/HRReport/hr_user_insurance_list";
    }

    protected override void PreGetReport(ReportHelper report)
    {
      //  report.AddReportParameter("pCurUserId", CurrentUser.UserID.ToString());


        base.PreGetReport(report);
    }
}
