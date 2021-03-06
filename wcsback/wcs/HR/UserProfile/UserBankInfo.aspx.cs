﻿using System;
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

public partial class HR_UserProfile_UserBankInfo : PageBase
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
        return;
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        if (!Page.IsPostBack)
        {
            bool b = RightHelper.CheckFuncRescRight(HRUser.USER_BANKINFO, OperationCode.READ, ScrUser.ResourceTypeID, UserId);
            if (!b)
            {
                Response.End();
            }
        }
    }
}
