using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.Common;
using EntpClass.WebUI;
using EntpClass.WebControlLib;
using EntpClass.WebControlLib.Derived;
using EntpClass.BizLogic.HR.UserProfile;

public partial class HR_UserProfile_UcUserScope : ScopeControlBase
{
    protected override DbRowParameter GetParameter()
    {
        HRUser user = new HRUser();

        return user.Parameter;
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        WcbUser.FunctionID = HRUser.FUNCTIONID;
        WcbUser.IncludeInactiveUser = true;

        TVListTeam.FunctionID = HRUser.FUNCTIONID;

        if (!Page.IsPostBack)
        {
            DrpEnableFlag.SelectedValue = "-1";
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

    }

    protected override string JoinTable(JoinTableParameters p)
    {
        return string.Empty;
    }
}
