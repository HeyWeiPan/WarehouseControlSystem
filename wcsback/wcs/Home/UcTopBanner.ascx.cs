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

public partial class Home_UcTopBanner : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!_AllowLogout)
        {
            BtnLogout.Visible = false;
        }

        BtnLogout.ToolTip = (new RM(ResourceFile.UI))["Logout"];
        if (CurrentUser.UseLanguage == Language.Chinese)
            BtnLogout.ImageUrl = "images/button5.cn.gif";
        else
            BtnLogout.ImageUrl = "images/button5.gif";
    }

    private bool _AllowLogout = true;

    public bool AllowLogout
    {
        get
        {
            return _AllowLogout;
        }
        set
        {
            _AllowLogout = value;
        }
    }

    protected void BtnLogout_Click(object sender, ImageClickEventArgs e)
    {
        //Response.Redirect("Logout.aspx");
        Parent.Page.Response.Redirect("Logout.aspx");
    }
}
