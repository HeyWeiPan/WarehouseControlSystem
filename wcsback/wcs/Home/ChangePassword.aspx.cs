using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Security;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.BizLogic.Security;

public partial class Home_ChangePassword : PageBase
{
    public override void InitializeEvents()
    {
        PageBase page = (PageBase)this.Page;
        page.Load += new EventHandler(Page_Load);
    }

    private void SetResource()
    {
        RM rm = new RM(ResourceFile.Database);

        LabChangePassword.InnerText = rm["Change_Password"];

        rm = new RM(ResourceFile.Msg);
        errorMsg.InnerText = "";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TxtUserName.Text = CurrentUser.FullName;

            //权限的控制
            //如果有 ReadRight,可以修改自己的密码
            if (PageRight.ReadRight)
            {
                BtnSave.Enabled = true;
            }
        }

        SetResource();
    }

    public override void SetPageInfo(ref PageParameter p)
    {
        p.FunctionID = Fn.ToInt(ScrFunction.ChangePasswordMenuID);
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        RM rm = new RM(ResourceFile.Msg);
        if (String.IsNullOrEmpty(TxtOldPassword.Text))
        {
            errorMsg.InnerText = rm["password_incorrect"];
            return;
        }
        if (String.IsNullOrEmpty(TxtPassword.Text))
        {
            errorMsg.InnerText = rm["password_input"];
            return;
        }

        if (TxtPassword.Text.Length < EntpClass.Common.SqlMembershipProvider.pMinRequiredPasswordLength)
        {
            errorMsg.InnerText = string.Format(rm["Password_Length"], EntpClass.Common.SqlMembershipProvider.pMinRequiredPasswordLength);
            return;
        }
        if (!String.Equals(TxtConfirmPassword.Text, TxtPassword.Text))
        {
            errorMsg.InnerText = rm["Password_match"];
            return;
        }

        EntpClass.Common.SqlMembershipProvider memberShip = new EntpClass.Common.SqlMembershipProvider();
        int rowsAffected = memberShip.ChangePassword(CurrentUser.LoginName, TxtOldPassword.Text, TxtPassword.Text);

        //rowsAffected
        //      0:密码长度或者是格式不正确
        //      1:用户只读
        //      2:密码错误
        //      -1:修改成功
        if (rowsAffected == -1)
            Response.Redirect("Logout.aspx");            
        else if (rowsAffected == 0)
            errorMsg.InnerText = rm["Passwod_Format"];
        else if (rowsAffected == 1)
            errorMsg.InnerText = rm["User_ReadOnly"];
        else if (rowsAffected == 2)
            errorMsg.InnerText = rm["Passwod_Error"];
        else
            errorMsg.InnerText = rm["Change_Passwod_Failed"];
    }
}