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

using EntpClass.Common;
using EntpClass.BizLogic.Security;

public partial class CommonUI_WebForm_GetRoleXMLDataSource : Page
{
    private int FunctionID
    {
        get
        {
            return Fn.ToInt(Request.QueryString["FunctionID"]);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = Role.GetAuthorizedRole(FunctionID);

        Response.Clear();
        Response.Expires = 10;
        Response.Write(ds.GetXml());
        Response.End();
    }
}
