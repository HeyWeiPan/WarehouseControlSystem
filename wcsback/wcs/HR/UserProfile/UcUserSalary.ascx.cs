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

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.WebControlLib.Derived;
using EntpClass.BizLogic.HR.UserProfile;
using EntpClass.BizLogic.Security;

public partial class HR_UserProfile_UcUserSalary : System.Web.UI.UserControl
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        SetUpDetailPageBase<HRUser> p = this.Page as SetUpDetailPageBase<HRUser>;


        p.PageModeChanged += new EventHandler<PageModeChangedEventArgs>(p_PageModeChanged);
        p.PreSetControlValue += new EventHandler<SetControlValueEventArgs>(p_PreSetControlValue);
        p.PreSave += new System.ComponentModel.CancelEventHandler(p_PreSave);
    }

    void p_PageModeChanged(object sender, PageModeChangedEventArgs e)
    {
        if (e.NewPageMode == PageMode.Add || e.NewPageMode == PageMode.Edit)
        {
            WcbSocialInsuranceGeoID.Visible = true;
            WcbHousingFundGeoID.Visible = true;

            TxtSocialInsuranceGeoName.Visible = false;
            TxtHousingFundGeoName.Visible = false;
        }
        else
        {
            WcbSocialInsuranceGeoID.Visible = false;
            WcbHousingFundGeoID.Visible = false;

            TxtSocialInsuranceGeoName.Visible = true;
            TxtHousingFundGeoName.Visible = true;
        }
    }

    void p_PreSave(object sender, System.ComponentModel.CancelEventArgs e)
    {
        string siGeoID = WcbSocialInsuranceGeoID.Value;
        string hfGeoID = WcbHousingFundGeoID.Value;

        if (string.IsNullOrEmpty(siGeoID))
        {
            siGeoID = "null";
        }

        if (string.IsNullOrEmpty(hfGeoID))
        {
            hfGeoID = "null";
        }


        TxtSocialInsuranceGeoName.InsertExpression = string.Format("dbo.GetGeographyFullName({0})", siGeoID);
        TxtSocialInsuranceGeoName.UpdateExpression = string.Format("dbo.GetGeographyFullName({0})", siGeoID);

        TxtHousingFundGeoName.InsertExpression = string.Format("dbo.GetGeographyFullName({0})", hfGeoID);
        TxtHousingFundGeoName.UpdateExpression = string.Format("dbo.GetGeographyFullName({0})", hfGeoID);
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
            b = RightHelper.CheckFuncRescRight(HRUser.USER_SALARY, OperationCode.EDIT, HRUser.ResourceTypeID, userID);
        }

        if (!b)
        {
            SetControlsReadOnly(this.Controls, true);
        }
        else
        {

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
