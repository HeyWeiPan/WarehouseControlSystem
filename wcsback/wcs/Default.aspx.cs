using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using EntpClass.Common;
using EntpClass.WebUI;

public partial class _Default : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Fn.ToString(Session["ID"]) == "")
        {
            int intUID = CurrentUser.UserID;
            string strAspUserName = CurrentUser.LoginName;
            string strAspAppConn = System.Configuration.ConfigurationManager.AppSettings["ConAspApp"];

            Session["ID"] = intUID.ToString();

            //Response.Redirect("AspSesionStart.asp?AspAppConn=" + strAspAppConn + "&AspUserName=" + strAspUserName + "&AspUserID=" + intUID.ToString());
        }
    }

    public override void SetPageInfo(ref PageParameter pageSetting)
    {
        return;
    }
}
