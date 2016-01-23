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

public partial class HR_UserProfile_UcUserContractInfo : UserControlBase
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
            b = RightHelper.CheckFuncRescRight(HRUser.USER_CONTRACT, OperationCode.EDIT, HRUser.ResourceTypeID, userID);
        }

        if (!b)
        {
            SetControlsReadOnly(this.Controls, true);
        }

    }

    //private void SetControlsReadOnly(ControlCollection cl, bool b)
    //{
    //    foreach (Control c in cl)
    //    {
    //        if (c is IWebDataControl)
    //        {
    //            IWebDataControl dc = (IWebDataControl)c;
    //            dc.RequiredField = false;
    //            dc.ReadOnlyWhenInsert = true;
    //            dc.ReadOnlyWhenUpdate = true;
    //            dc.AllowUpdate = false;
    //            dc.AllowInsert = false;
    //        }
    //    }
    //}

    public override void InitializeEvents()
    {
        base.InitializeEvents();
        PageBase page = this.Page as PageBase;
        page.PageModeChanged += new EventHandler<PageModeChangedEventArgs>(page_PageModeChanged);
        page.PreSetControlValue += new EventHandler<SetControlValueEventArgs>(page_PreSetControlValue);

    }

    void page_PreSetControlValue(object sender, SetControlValueEventArgs e)
    {
        if (!this.Visible)
        {
            SetControlsReadOnly(this.Controls, true);
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
            b = RightHelper.CheckFuncRescRight(HRUser.USER_CONTRACT, OperationCode.EDIT, HRUser.ResourceTypeID, userID);
        }

        if (!b)
        {
            SetControlsReadOnly(this.Controls, true);
        }
    }

    void page_PageModeChanged(object sender, PageModeChangedEventArgs e)
    {

        if (e.NewPageMode == PageMode.Add || e.NewPageMode == PageMode.Edit)
        {

            TxtReplaceUserName.Visible = false;
            WcbReplaceUserID.Visible = true;
        }
        else
        {

            TxtReplaceUserName.Visible = true;
            WcbReplaceUserID.Visible = false;
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
