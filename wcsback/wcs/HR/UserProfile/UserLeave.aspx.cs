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
using EntpClass.BizLogic.HR.UserProfile;
using EntpClass.BizLogic.Security;
using EntpClass.BizLogic.HR.Leave;

public partial class HR_UserProfile_UserLeave : PageBase
{
    public override void SetPageInfo(ref PageParameter p)
    {
    }

    private string UserId
    {
        get
        {
            return Fn.ToString(Request.QueryString["UserId"]);
        }
    }

    protected override void OnLoadComplete(EventArgs e)
    {
        base.OnLoadComplete(e);

        if (!IsPostBack)
            DrpLeavePeriod.SelectedIndex = 0;

        UcUserLeaveResidualList1.GridDataLoaded = false;
        UcUserLeaveResidualList1.PeriodId = DrpLeavePeriod.Text;
        UcUserLeaveResidualList1.SetGridData();

        UcUserLeave1.GridDataLoaded = false;
        UcUserLeave1.PeriodId = DrpLeavePeriod.Text;
        UcUserLeave1.SetGridData();

        TxtTotalResidualDays.Text = LeaveInit.GetLeftLeaveDayDescription(Fn.ToInt(DrpLeavePeriod.Text), Fn.ToInt(UserId)); ;
    }
}
