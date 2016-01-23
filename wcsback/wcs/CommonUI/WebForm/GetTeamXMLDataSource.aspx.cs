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
using EntpClass.WebControlLib.Derived;
using EntpClass.BizLogic.HR.OrgChart;

public partial class CommonUI_WebForm_GetTeamXMLDataSource : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int functionID = Fn.ToInt(Request.QueryString["FunctionID"]);
        DataSet ds = Team.GetTeamList(functionID);

        Response.Clear();
        Response.Expires = 300;
        Response.Write(ds.GetXml());
        Response.End();
    }    
}
