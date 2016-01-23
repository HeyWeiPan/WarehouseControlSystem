using System;
using System.Data;
using System.Data.Common;
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
using EntpClass.WebControlLib;
using EntpClass.BizLogic.HR;
using EntpClass.BizLogic.HR.Setup;
using EntpClass.WebControlLib.Derived;
using EntpClass.BizLogic.HR.UserProfile;

public partial class HR_Setup_UcJobStructureUserList : GridControlBase<JobStructure>
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
        Database db = DatabaseFactory.CreateDatabase(HRConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand("HR.GetJobStructureUserList");
        db.AddInParameter(cmd, "pJobCode", DbType.String, JobCode);
        DataSet ds = db.ExecuteDataSet(cmd);
        return ds;        
    }

    protected override void InitNewRow(GridViewRow r, Hashtable rowCtrlCollection)
    {
        base.InitNewRow(r, rowCtrlCollection);

        r.Cells[0].ColumnSpan = 3;
        r.Cells.RemoveAt(1);
        r.Cells.RemoveAt(1);
    }

    protected override bool OnInsert(PageBase page, Database db, DbTransaction transaction)
    {
        Hashtable dataControls = page.DataControlCollection;
        IWebDataControl WcbUser = Fn.GetControlByColumnName(dataControls, "user_id");
        int userId = Fn.ToInt(WcbUser.GetValue());

        bool b = HRUser.UpdateUserJobCode(userId, JobCode, db, transaction);
        return b;
    }

    protected override bool OnDelete(string id)
    {
        bool b = HRUser.UpdateUserJobCode(id,string.Empty);
        return b;
    }

    protected override void SetParameter(GridControlParameter p)
    {
        PageParameter pageSetting = new PageParameter();
        pageSetting.FunctionID = JobStructure.UserFunctionID;
        PageRights right = new PageRights(pageSetting);
        p.AddRight = right.AddRight;
        p.DeleteRight = right.DeleteRight;

        base.SetParameter(p);

        p.DialogMode = false;
        p.EditRight = false;
    }

}
