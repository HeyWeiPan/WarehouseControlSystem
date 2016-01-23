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

public partial class CommonUI_WebForm_GetUserXMLDataSource : Page
{
    private string IncludeInactiveUser
    {
        get
        {
            return Request.QueryString["includeInactiveUser"];
        }
    }

    private bool ShowTeamLeaderOnly
    {
        get
        {
            return Fn.ToBoolean(Request.QueryString["ShowTeamLeaderOnly"]);
        }
    }

    private string FunctionID
    {
        get
        {
            return Request.QueryString["FunctionID"];
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int functionID = Fn.ToInt(FunctionID);
        bool includeInactiveUser = Fn.ToBoolean(IncludeInactiveUser, false);

        DataSet ds;
        if (ShowTeamLeaderOnly)
        {
            ds = ScrUser.GetTeamLeaderList(functionID);
        }
        else
        {
            ds = ScrUser.GetUserList(includeInactiveUser, functionID);
        }
        Response.Clear();
        Response.Expires = 60 * 10;
        Response.Write(ds.GetXml());
        Response.End();
    }
}
