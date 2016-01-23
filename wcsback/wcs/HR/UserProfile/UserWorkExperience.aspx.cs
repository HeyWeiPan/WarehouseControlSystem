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

public partial class HR_UserProfile_UserWorkExperience : PageBase
{
    private string UserId
    {
        get
        {
            return Fn.ToString(Request.QueryString["UserId"]);
        }
    }

    public override void SetPageInfo(ref PageParameter p)
    {
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        if (!Page.IsPostBack)
        {
            bool b = RightHelper.CheckFuncRescRight(HRUser.USER_WORK_BEFORE, OperationCode.READ, ScrUser.ResourceTypeID, UserId);
            if (!b)
            {
                UcUserWorkExperienceList1.Visible = false;
                UcUserWorkExperienceList1.GridDataLoaded = true;
            }

            //入职后的工作经历
            b = RightHelper.CheckFuncRescRight(HRUser.USER_WORK_AFTER, OperationCode.READ, ScrUser.ResourceTypeID, UserId);
            if (!b)
            {
                UcUserPositionTransferList1.Visible = false;
                UcUserPositionTransferList1.GridDataLoaded = true;
            }
        }
    }
}
