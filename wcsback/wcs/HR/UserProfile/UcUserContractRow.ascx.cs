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

public partial class HR_UserProfile_UcUserContractRow : UserControlBase
{
    protected void UcDdlYesNo1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Fn.ToBoolean(DrpNoEndDateFlag.Text) == true)
        {
            //无固定期限劳动合同
            DtpContractEndDate.Text = string.Empty;
            TxtContractMonth.ReadOnly = true;
            TxtContractMonth.RequiredField = false;
            TxtContractMonth.Text = string.Empty;
        }
        else
        {
            TxtContractMonth.ReadOnly = false;
            TxtContractMonth.RequiredField = true;
        }
    }

}

