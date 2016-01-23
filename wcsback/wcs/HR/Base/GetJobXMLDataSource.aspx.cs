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
using EntpClass.BizLogic.HR.Setup;

public partial class HR_Base_GetJobXMLDataSource : Page
{
    private int FunctionID
    {
        get { return Fn.ToInt(Request.QueryString["FunctionID"]);}
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        DataSet ds = JobStructure.GetJobStructureWebComboList(FunctionID);

        Response.Clear();
        Response.Expires = 10;
        Response.Write(ds.GetXml());
        Response.End();
    }
}
