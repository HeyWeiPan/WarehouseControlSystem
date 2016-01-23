using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.BizLogic.HR;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.HR.Setup;

public partial class HR_Setup_UcJDResponsibilityList : GridControlBase<JDResponsibility>
{
    private string JobCode
    {
        get { return Fn.ToString(Request.QueryString["JobCode"]); }
    }    

    protected override GridView GetGridViewControl()
    {
        return GrdList;
    }

    protected override DataSet GetGridDataSet()
    {
        string proc = "HR.GetJDResponsibilityList";
        Database db = DatabaseFactory.CreateDatabase(HRConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);        
        db.AddInParameter(cmd, "pJobCode", DbType.String, JobCode);
        DataSet ds = db.ExecuteDataSet(cmd);
        return ds;   
    }

    protected override bool OnInsert(PageBase page, Database db, DbTransaction transaction)
    {
        Hashtable dataControls = page.DataControlCollection;

        UcHiddenField HidJobCode = new UcHiddenField();
        HidJobCode.ID = "HidJobCode";
        HidJobCode.ColumnName = "job_code";
        HidJobCode.RequiredField = true;
        HidJobCode.Value = JobCode;

        page.AddControl(HidJobCode);

        return base.OnInsert(page, db, transaction);
    }
}
