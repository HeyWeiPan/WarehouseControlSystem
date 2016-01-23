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

public partial class HR_UserProfile_UcUserFamilyInfo : UserControlBase
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        SetUpDetailPageBase<HRUser> p = this.Page as SetUpDetailPageBase<HRUser>;

        p.PreSetControlValue += new EventHandler<SetControlValueEventArgs>(p_PreSetControlValue);
    }

    void p_PreSetControlValue(object sender, SetControlValueEventArgs e)
    {
        if (!this.Visible)
        {
            return;
        }

        SetUpDetailPageBase<HRUser> page = (SetUpDetailPageBase<HRUser>)this.Page;

        string userID = Fn.ToString(page.RowData["user_id"]);

        bool b = false;

        if (userID == "")
        {
            b = true;
        }
        else
        {
            b = RightHelper.CheckFuncRescRight(HRUser.USER_FAMILY, OperationCode.EDIT, HRUser.ResourceTypeID, userID);
        }

        if (!b)
        {
            SetControlsReadOnly(this.Controls, true);
        }
        else
        {
            if (CurrentUser.UserID.ToString() == Fn.ToString(page.RowData["user_id"]))
            {
                TxtResidenceAddress.RequiredField = true;
                TxtEmergencyContactName.RequiredField = true;
                TxtEmergencyPhone.RequiredField = true;
            }
        }
    }

    private void SetControlsReadOnly(ControlCollection cl, bool b)
    {
        foreach (Control c in cl)
        {
            if (c is IWebDataControl)
            {
                IWebDataControl dc = (IWebDataControl)c;
                dc.RequiredField = false;
                dc.ReadOnlyWhenInsert = true;
                dc.ReadOnlyWhenUpdate = true;
                dc.AllowUpdate = false;
                dc.AllowInsert = false;
            }
        }
    }
}
