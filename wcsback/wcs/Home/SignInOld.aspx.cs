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

public partial class Home_SignIn : System.Web.UI.Page
{
    private UcValidateNum _validateNumControl;

    private UcValidateNum ValidateNumControl
    {
        get
        {
            if (this._validateNumControl == null)
            {
                this._validateNumControl = ((UcValidateNum)this.L1.FindControl("UcValidateNum1"));
            }

            return this._validateNumControl;
        }
    }

    private void ShowValidateControl()
    {
        ValidateNumControl.Visible = true;
        this.L1.FindControl("ValidateNum").Visible = true;
        this.L1.FindControl("RequiredFieldValidator1").Visible = true;
        this.L1.FindControl("ValidateNumLbl").Visible = true;

        this.L1.FindControl("trBlank").Visible = false;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        TextBox UserName = (TextBox)L1.FindControl("UserName");

        if (!IsPostBack)
        {
            Response.Expires = 0;

            if (CurrentUser.UseLanguage == Language.English)
                ((RadioButton)this.L1.FindControl("RadEnglish")).Checked = true;
            else
                ((RadioButton)this.L1.FindControl("RadChinese")).Checked = true;

            ValidateNumControl.CreateValidateNum();

            UserName.Text = CurrentUser.LastSucceededLoginUser;

            CurrentUser.LoginErrorCount = 0;
        }


        UserName.Focus();
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        ImageButton imgLogin = (ImageButton)L1.FindControl("LoginButton");
        imgLogin.ToolTip = (new RM(ResourceFile.UI))["Login"];

        if (CurrentUser.UseLanguage == Language.Chinese)
            imgLogin.ImageUrl = "Images/login_btn1.cn.gif";
        else
            imgLogin.ImageUrl = "Images/login_btn1.gif";

        TextBox UserName = (TextBox)L1.FindControl("UserName");
        UserName.Focus();

        //用户点击验证控件时，刷新验证控件
        if (IsPostBack)
        {
            ValidateNumControl.CreateValidateNum();

            TextBox txt = ((TextBox)this.L1.FindControl("ValidateNum"));
            txt.Text = string.Empty;
        }
    }

    protected void L1_LoggingIn(object sender, LoginCancelEventArgs e)
    {
        if (((RadioButton)this.L1.FindControl("RadEnglish")).Checked)
            CurrentUser.UseLanguage = Language.English;
        else
            CurrentUser.UseLanguage = Language.Chinese;
    }

    protected void L1_ValidateNumAuthenticate(object sender, AuthenticateEventArgs e)
    {
        TextBox txt = this.L1.FindControl("ValidateNum") as TextBox;

        //如果用户名密码验证成功
        if (e.Authenticated)
        {
            //如果验证码控件可见，进行验证码验证
            if (ValidateNumControl.Visible)
            {
                //如果验证码验证失败
                if (!ValidateNumControl.CheckValidateNum(Fn.ToString(txt.Text)))
                {
                    e.Authenticated = false;
                    this.L1.FailureText = new RM(ResourceFile.Msg)["ValidateNumError"];
                }
            }
        }
        else
        {
            //用户名密码验证失败
            this.L1.FailureText = new RM(ResourceFile.Msg)["LogError"];

            if (CurrentUser.LoginErrorCount == 3)
            {
                ShowValidateControl();
            }
        }

        if (txt != null)
        {
            //清除验证码
            txt.Text = string.Empty;
        }
    }
}
