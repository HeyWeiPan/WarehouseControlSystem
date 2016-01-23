using System;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.Common;
using EntpClass.BizLogic.HR;
using EntpClass.BizLogic.Security;

public partial class HR_Base_GetCourseXMLDataSource : Page
{
    private int FunctionID
    {
        get { return Fn.ToInt(Request.QueryString["FunctionID"]); }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand("HR.GetTrainingCourseWebComboList");
        db.AddInParameter(cmd, "pCurUserID", DbType.Int32, CurrentUser.UserID);
        db.AddInParameter(cmd, "pFunctionID", DbType.Int32, FunctionID);
        DataSet ds = db.ExecuteDataSet(cmd);        

        Response.Clear();
        Response.Expires = 10;
        Response.Write(ds.GetXml());
        Response.End();
    }
}
