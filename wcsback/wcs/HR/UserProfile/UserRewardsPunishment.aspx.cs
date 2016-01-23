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

public partial class HR_UserProfile_UserRewardsPunishment : PageBase
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
            //奖惩信息
            //入职前
            bool b = RightHelper.CheckFuncRescRight(HRUser.USER_REWARD_BEFORE, OperationCode.READ, ScrUser.ResourceTypeID, UserId);
            if (!b)
            {
                UcUserRewardPunish2.Visible = false;
                UcUserRewardPunish2.GridDataLoaded = true;
            }

            //入职前
            b = RightHelper.CheckFuncRescRight(HRUser.USER_REWARD_AFTER, OperationCode.READ, ScrUser.ResourceTypeID, UserId);
            if (!b)
            {
                UcUserRewardPunish1.Visible = false;
                UcUserRewardPunish1.GridDataLoaded = true;
            }
        }
    }
}
