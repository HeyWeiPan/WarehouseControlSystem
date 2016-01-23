using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.WebControlLib.Derived;
using EntpClass.BizLogic.HR.UserProfile;
using EntpClass.BizLogic.Security;

public partial class HR_UserProfile_UcUserJob : UserControlBase
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        SetUpDetailPageBase<HRUser> p = this.Page as SetUpDetailPageBase<HRUser>;

        p.PreSetControlValue += new EventHandler<SetControlValueEventArgs>(p_PreSetControlValue);
        p.PreSave += new CancelEventHandler(p_PreSave);
        //p.PageModeChanged += new EventHandler<PageModeChangedEventArgs>(p_PageModeChanged);
    }

    void p_PreSave(object sender, CancelEventArgs e)
    {
        TxtJobCode.Text = TxtJobCode.Text.ToUpper();

        if (!string.IsNullOrEmpty(TxtJobCode.Text))
        {
            if (!HRUser.CheckJobCode(TxtJobCode.Text))
            {
                PageBase p = this.Page as PageBase;
                RM rm = new RM(ResourceFile.Msg);
                RM rm1 = new RM(ResourceFile.Database);
                p.Alert(string.Format(rm["ValidateForeignKey"], rm1["job_code"]));
                e.Cancel = true;
            }

        }

    }

    //void p_PageModeChanged(object sender, PageModeChangedEventArgs e)
    //{
    //    if (e.NewPageMode == PageMode.Edit || e.NewPageMode == PageMode.Add)
    //    {
    //        WcbJobCode.Visible = true;
    //        TxtJobCode.Visible = false;
    //    }
    //    else
    //    {
    //        WcbJobCode.Visible = false;
    //        TxtJobCode.Visible = true;
    //    }
    //}

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

            b = RightHelper.CheckFuncRescRight(HRUser.USER_JOB, OperationCode.EDIT, HRUser.ResourceTypeID, userID);
        }

        if (!b)
        {
            SetControlsReadOnly(this.Controls, true);
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
