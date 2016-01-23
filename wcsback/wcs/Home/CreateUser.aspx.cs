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
using EntpClass.WebControlLib;

public partial class Home_CreateUser : PageBase
{       
    public override void SetPageInfo(ref EntpClass.Common.PageParameter p)
    {        
    }

    protected void ContinueButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("SignIn.aspx");
    }

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {

    }
    
    protected void CreateUserWizard1_CreatingUser(object sender, LoginCancelEventArgs e)
    {
        string errorMessage;
        Control requiredControl;
        
        bool b = CheckValid(out requiredControl, out errorMessage);
        if (!b)
        {
            Literal errorMessageLabel = (Literal)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("ErrorMessage");
            CreateUserWizard1.UnknownErrorMessage = errorMessage;            
            e.Cancel = true;
        }        
    }
}
