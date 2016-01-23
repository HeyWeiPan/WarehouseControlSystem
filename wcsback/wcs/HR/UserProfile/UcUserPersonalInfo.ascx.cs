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

public partial class HR_UserProfile_UcUserPersonalInfo : UserControlBase
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        SetUpDetailPageBase<HRUser> p = this.Page as SetUpDetailPageBase<HRUser>;


        p.PageModeChanged += new EventHandler<PageModeChangedEventArgs>(p_PageModeChanged);

        p.PreSetControlValue += new EventHandler<SetControlValueEventArgs>(p_PreSetControlValue);
        p.PreSave += new System.ComponentModel.CancelEventHandler(p_PreSave);
    }

    void p_PreSave(object sender, System.ComponentModel.CancelEventArgs e)
    {
        string hukouGeoID = WcbHukouGeoID.Value;
        string personalFileGeoID = WcbPersonalFileGeoID.Value;
        string birthPlaceGeoID = WcbBirthPlaceGeoID.Value;
        string nativePlaceGeoID = WcbNativePlaceGeoID.Value;

        if (string.IsNullOrEmpty(hukouGeoID))
        {
            hukouGeoID = "null";
        }

        if (string.IsNullOrEmpty(personalFileGeoID))
        {
            personalFileGeoID = "null";
        }

        if (string.IsNullOrEmpty(birthPlaceGeoID))
        {
            birthPlaceGeoID = "null";
        }

        if (string.IsNullOrEmpty(nativePlaceGeoID))
        {
            nativePlaceGeoID = "null";
        }


        TxtHuKouGeoName.InsertExpression = string.Format("dbo.GetGeographyFullName({0})", hukouGeoID);
        TxtHuKouGeoName.UpdateExpression = string.Format("dbo.GetGeographyFullName({0})", hukouGeoID);

        TxtPersonalFileGeoName.InsertExpression = string.Format("dbo.GetGeographyFullName({0})", personalFileGeoID);
        TxtPersonalFileGeoName.UpdateExpression = string.Format("dbo.GetGeographyFullName({0})", personalFileGeoID);

        TxtBirthPlaceGeoName.InsertExpression = string.Format("dbo.GetGeographyFullName({0})", birthPlaceGeoID);
        TxtBirthPlaceGeoName.UpdateExpression = string.Format("dbo.GetGeographyFullName({0})", birthPlaceGeoID);

        TxtNativePlaceGeoName.InsertExpression = string.Format("dbo.GetGeographyFullName({0})", nativePlaceGeoID);
        TxtNativePlaceGeoName.UpdateExpression = string.Format("dbo.GetGeographyFullName({0})", nativePlaceGeoID);
    }

    void p_PageModeChanged(object sender, PageModeChangedEventArgs e)
    {
        if (e.NewPageMode == PageMode.Add || e.NewPageMode == PageMode.Edit)
        {
            WcbNativePlaceGeoID.Visible = true;
            WcbPersonalFileGeoID.Visible = true;
            WcbHukouGeoID.Visible = true;
            WcbBirthPlaceGeoID.Visible = true;

            TxtNativePlaceGeoName.Visible = false;
            TxtPersonalFileGeoName.Visible = false;
            TxtHuKouGeoName.Visible = false;
            TxtBirthPlaceGeoName.Visible = false;
        }
        else
        {
            WcbNativePlaceGeoID.Visible = false;
            WcbPersonalFileGeoID.Visible = false;
            WcbHukouGeoID.Visible = false;
            WcbBirthPlaceGeoID.Visible = false;

            TxtNativePlaceGeoName.Visible = true;
            TxtPersonalFileGeoName.Visible = true;
            TxtHuKouGeoName.Visible = true;
            TxtBirthPlaceGeoName.Visible = true;
        }
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
            b = RightHelper.CheckFuncRescRight(HRUser.USER_PERSONAL, OperationCode.EDIT, HRUser.ResourceTypeID, userID);
        }

        if (!b)
        {
            SetControlsReadOnly(this.Controls, true);
        }
        else
        {
            if (CurrentUser.UserID.ToString() == Fn.ToString(page.RowData["user_id"]))
            {
                DpkBirthday.RequiredField = true;
                DrpNationality.RequiredField = true;
                UcDdlfolkishness.RequiredField = true;
                WcbHukouGeoID.RequiredField = true;
                TxtHuKouPlace.RequiredField = true;
                // WcbPersonalFileGeoID.RequiredField = true;
                TxtIdCardNum.RequiredField = true;
                DrpMarryType.RequiredField = true;
                DrpPolitical.RequiredField = true;
                DrpEducationalBackground.RequiredField = true;
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
