using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Security;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.BizLogic.Security;

public partial class Home_Navigate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string funcID = Request.QueryString["FuncID"];

        if (funcID != string.Empty)
        {
            if (!CurrentUser.IsLogin)
            {
                Session["redirect_func_id"] = funcID;
                Response.Redirect(UrlHelper.UrlBase + "/home/signin.aspx",false);
                return;
            }

            Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
            DbCommand cmd = db.GetStoredProcCommand("security.SetClickHistory");
            db.AddInParameter(cmd, "pUserID", DbType.Int32, Fn.ToInt(CurrentUser.UserID));
            db.AddInParameter(cmd, "pFunctionID", DbType.Int32, Fn.ToInt(funcID));
            db.AddOutParameter(cmd, "pOut", DbType.String, 2000);

            db.ExecuteNonQuery(cmd);

            //object obj=db.GetParameterValue("@pOut");

            string pageUrl = Fn.ToString(db.GetParameterValue(cmd,"pOut"));

            if (pageUrl != string.Empty)
            {
                if (pageUrl[0] == '/')
                {
                   pageUrl = UrlHelper.UrlBase + pageUrl;                 
                }

                if (pageUrl.IndexOf('?') == -1)
                {
                    pageUrl = pageUrl + "?";
                }

                pageUrl = pageUrl + Request.QueryString.ToString();
   
                Response.Redirect(pageUrl);
            }
        }
    }
}
