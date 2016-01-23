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

public partial class Home_EmpAccount : PageBase
{
    public override void InitializeEvents()
    {
        PageBase page = (PageBase)this.Page;
        page.Load += new EventHandler(Page_Load);       
    }

    private void SetResource()
    {
        RM rm = new RM(ResourceFile.Database);        
        LabAccountOfEmployee.InnerText = rm["Account_of_Employee"];
      
        rm = new RM(ResourceFile.Msg);
        errorMsg.InnerText = rm["Password_Same"];
    }

    private void RegeditWebcomboChange()
    {
        if (!this.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegeditWebcomboChange"))
        {
            StringBuilder s = new StringBuilder();

            s.Append("function onWebcomboChange(webCombo)");
            s.Append("{");
            s.AppendFormat("document.getElementById('{0}').value='';", TxtAccountName.ClientID);
            s.AppendFormat("document.getElementById('{0}').value='';", TxtEmailAddress.ClientID);
            s.Append("if(webCombo.value==''){return;}");
            s.Append("WsHome.GetUserInfoXML(webCombo.value, onSetUserInfo,f_wserror);");
            s.Append("};");

            s.Append("function onSetUserInfo(xmlDoc)");
            s.Append("{");
            s.Append("var oXML = f_loadXML(xmlDoc);");
            s.AppendFormat("document.getElementById('{0}').value=f_getXMLNodeValue(oXML,'{1}');\n", TxtAccountName.ClientID, "LOWERCASE_LOGIN_NAME");
            s.AppendFormat("document.getElementById('{0}').value=f_getXMLNodeValue(oXML,'{1}');\n", TxtEmailAddress.ClientID, "EMAIL");
            s.Append("}");

            ComboUser.OnClientChange += "onWebcomboChange(this);";

            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegeditWebcomboChange", s.ToString(), true);
        }
    }

    public override void SetPageInfo(ref PageParameter p)
    {
        p.FunctionID = Fn.ToInt(ScrFunction.AccountofEmployeeMenuID);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ComboUser.SetReadOnly(true);
            ComboUser.SetValue(Fn.ToString(CurrentUser.UserID));

            TxtAccountName.Text = CurrentUser.LoginName;
            TxtEmailAddress.Text = CurrentUser.EmailAddress;

            //权限的控制
            //如果有 ReadRight,可以修改自己的信息
            if (PageRight.ReadRight)
            {
                BtnSave.Enabled = true;
            }

            //如果有 EditRight,可以修改别人的信息            
            if (PageRight.EditRight)
            {
                BtnSave.Enabled = true;
                ComboUser.SetReadOnly(false);
            }
        }

        SetResource();
    }

    protected override void Render(HtmlTextWriter writer)
    {
        RegeditWebcomboChange();

        base.Render(writer);
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        RM rm = new RM(ResourceFile.Msg);

        if (String.IsNullOrEmpty(ComboUser.GetValue()))
        {
            errorMsg.InnerText = rm["Employee_incorrect"];
            return;
        }

        if (String.IsNullOrEmpty(TxtAccountName.Text))
        {
            errorMsg.InnerText = rm["Account_incorrect"];
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

        if (TxtConfirmPassword.Text != TxtPassword.Text)
        {
            errorMsg.InnerText = rm["Password_match"];
            return;
        }

        EntpClass.Common.SqlMembershipProvider memberShip = new EntpClass.Common.SqlMembershipProvider();
        int rowsAffected = memberShip.UpdateUser(ComboUser.GetValue(), TxtAccountName.Text, TxtPassword.Text, TxtEmailAddress.Text);

        //rowsAffected
        //      0:密码长度或缺少特殊字符
        //      1:用户只读
        //      2:用户名重复
        //      -1:修改成功
        if (rowsAffected == -1)
        {
            if (Fn.ToInt(ComboUser.Value) == CurrentUser.UserID)                
                Response.Redirect("Logout.aspx");            
            else
                errorMsg.InnerText = rm["SaveSuccess"];
        }
        else if (rowsAffected == 0)
        {
            errorMsg.InnerText = rm["Passwod_Format"];
        }
        else if (rowsAffected == 1)
        {
            errorMsg.InnerText = rm["User_ReadOnly"];
        }
        else if (rowsAffected == 2)
        {
            errorMsg.InnerText = rm["User_Repeat"];
        }
        else
        {
            errorMsg.InnerText = rm["Update_User_Failed"];
        }
    }
}
