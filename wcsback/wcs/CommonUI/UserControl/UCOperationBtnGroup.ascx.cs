using System;
using System.Data;
using System.Text;
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

public partial class CommonUI_UserControl_UCOperationBtnGroup : UserControlBase
{
    protected override bool SupportAutoEvents
    {
        get
        {
            return false;
        }
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
    }
}
