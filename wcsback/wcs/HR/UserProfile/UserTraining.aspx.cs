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

public partial class HR_UserProfile_UserTraining : PageBase
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
            //培训信息
            //入职前
            bool b = RightHelper.CheckFuncRescRight(HRUser.USER_TRAINING_BEFORE, OperationCode.READ, ScrUser.ResourceTypeID, UserId);
            if (!b)
            {
                UcUserTraining2.Visible = false;
                UcUserTraining2.GridDataLoaded = true;
            }

            //入职后
            b = RightHelper.CheckFuncRescRight(HRUser.USER_TRAINING_AFTER, OperationCode.READ, ScrUser.ResourceTypeID, UserId);
            if (!b)
            {
                UcUserTraining1.Visible = false;
                UcUserTraining1.GridDataLoaded = true;
            }
        }
    }
}
