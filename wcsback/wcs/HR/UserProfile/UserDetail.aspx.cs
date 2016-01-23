using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using EntpClass.Common;
using EntpClass.WebUI;
using EntpClass.WebControlLib;
using EntpClass.WebControlLib.Derived;
using EntpClass.BizLogic.HR.UserProfile;
using System.Collections.Generic;

public partial class HR_UserProfile_UserDetail : SetUpDetailPageBase<HRUser>
{

    public override void ReloadPage(string keyValue, PageMode mode, string appendQueryString)
    {
        UcHiddenField HidSelectedTab = Fn.FindControlWithLoop("HidSelectedTab", this.Page.Controls) as UcHiddenField;

        if (!string.IsNullOrEmpty(HidSelectedTab.Value))
        {
            if (!string.IsNullOrEmpty(appendQueryString))
            {
                appendQueryString = appendQueryString + "&";
            }

            appendQueryString = appendQueryString + string.Format("defaultTab={0}", HidSelectedTab.Value);
        }
        base.ReloadPage(keyValue, mode, appendQueryString);
    }

}
