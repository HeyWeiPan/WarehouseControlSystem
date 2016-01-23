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
using EntpClass.WebControlLib;

public partial class HomeV2_SignIn : System.Web.UI.Page
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        TextBox UserName = (TextBox)L1.FindControl("UserName");
        CheckBox Cb = (CheckBox)L1.FindControl("Cb1");
        if (!IsPostBack)
        {
            Response.Expires = 0;
            if (Request.Cookies["shinan_login_info"] != null)
            {
                UserName.Text = Request.Cookies["shinan_login_info"]["user_name"];
                Cb.Checked = true;
            }

            CurrentUser.LoginErrorCount = 0;
        }


        UserName.Focus();
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        Button imgLogin = (Button)L1.FindControl("LoginButton");
        imgLogin.ToolTip = (new RM(ResourceFile.UI))["Login"];



        TextBox UserName = (TextBox)L1.FindControl("UserName");
        UserName.Focus();


    }

    protected void L1_LoggingIn(object sender, LoginCancelEventArgs e)
    {
        //if (((RadioButton)this.L1.FindControl("RadEnglish")).Checked)
        //    CurrentUser.UseLanguage = Language.English;
        //else
        //    CurrentUser.UseLanguage = Language.Chinese;

        CheckBox Cb = (CheckBox)L1.FindControl("Cb1");
        TextBox UserName = (TextBox)L1.FindControl("UserName");
        if (Cb.Checked)
        {
            if (HttpContext.Current.Request.Cookies["shinan_login_info"] == null)
            {

                HttpCookie newcookie = new HttpCookie("shinan_login_info");
                newcookie["user_name"] = UserName.Text;
                newcookie.Path = "/";
                HttpContext.Current.Response.AppendCookie(newcookie);
            }
            else
            {
                HttpContext.Current.Response.Cookies["shinan_login_info"]["user_name"] = UserName.Text;
                HttpContext.Current.Request.Cookies["shinan_login_info"]["user_name"] = UserName.Text;

            }

            HttpContext.Current.Response.Cookies["shinan_login_info"].Expires = DateTime.Now.AddDays(30);

        }
    }

    protected void L1_ValidateNumAuthenticate(object sender, AuthenticateEventArgs e)
    {
        TextBox txt = this.L1.FindControl("ValidateNum") as TextBox;

        //用户名密码验证失败
        if (!e.Authenticated)
        {

            this.L1.FailureText = new RM(ResourceFile.Msg)["LogError"];

        }
        //else
        //{

        //    if (CurrentUser.LoginErrorCount == 3)
        //    {
        //        ShowValidateControl();
        //    }
        //}


    }
}