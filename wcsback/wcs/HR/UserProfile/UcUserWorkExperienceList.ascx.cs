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

using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.WebUI;
using EntpClass.BizLogic;
using EntpClass.BizLogic.HR;
using EntpClass.BizLogic.HR.UserProfile;
using EntpClass.BizLogic.Security;

public partial class HR_UserProfile_UcUserWorkExperienceList : GridControlBase<HRUserWorkExperience>
{
    private string UserId
    {
        get { return Fn.ToString(Request.QueryString["UserId"]); }
    }

    //private bool ValidateData(PageBase page)
    //{
    //    RM rmMs = new RM(ResourceFile.Msg);
    //    RM rmDb = new RM(ResourceFile.Database);
    //    Hashtable dataControlCollection = page.DataControlCollection;
    //    IWebDataControl TxtStartDate = Fn.GetControlByColumnName(dataControlCollection, "start_date");
    //    IWebDataControl TxtEndDate = Fn.GetControlByColumnName(dataControlCollection, "end_date");
    //    IWebDataControl TxtSocialServiceMonth = Fn.GetControlByColumnName(dataControlCollection, "social_service_month");
    //    //不能超过结束日期与开始日期的差值.
    //    DateTime startDate = (DateTime)TxtStartDate.DbValue;
    //    DateTime endDate = (DateTime)TxtEndDate.DbValue;
    //    int startYear = startDate.Year;
    //    int startMonth = startDate.Month;
    //    int endYear = endDate.Year;
    //    int endMonth = endDate.Month;
    //    int serviceMonth = (endYear - startYear) * 12 + (endMonth - startMonth);
    //    int socialMonth = Fn.ToInt(TxtSocialServiceMonth.GetValue());
    //    if (socialMonth > serviceMonth)
    //    {
    //        page.Alert(rmDb["social_service_month"] + "," + rmMs["DataError"]);
    //        return false;
    //    }
    //    return true;
    //}

    protected override GridView GetGridViewControl()
    {
        return GrdWorkList;
    }

    protected override DataSet GetGridDataSet()
    {
        string proc = "HR.GetUserWorkExperienceList";
        Database db = DatabaseFactory.CreateDatabase(HRConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pUserId", DbType.Int32, Fn.ToInt(UserId));
        DataSet ds = db.ExecuteDataSet(cmd);
        return ds;
    }

    protected override void SetParameter(GridControlParameter p)
    {
        base.SetParameter(p);

        p.DialogMode = false;
        p.FreeFormMode = true;
        p.AutoBindControl = true;

        PageParameter parmeter = new PageParameter();
        parmeter.ResourceTypeIDs = new int[] { ScrUser.ResourceTypeID };
        parmeter.ResourceValues = new string[] { UserId };
        parmeter.FunctionID = HRUser.USER_WORK_BEFORE;

        PageRights right = new PageRights(parmeter);

        p.AddRight = right.AddRight;
        p.DeleteRight = right.DeleteRight;
        p.EditRight = right.EditRight;
    }

    protected override bool OnPreSave(PageBase page, GridViewRow row, bool isInsert, string keyValue)
    {
        Hashtable dataControlCollection = page.DataControlCollection;


        UcHiddenField HidUserId = new UcHiddenField();
        HidUserId.ID = "HidUserId";
        HidUserId.ColumnName = "user_id";
        HidUserId.RequiredField = true;
        HidUserId.AllowUpdate = false;
        HidUserId.Value = UserId;

        page.AddControl(HidUserId);


        return base.OnPreSave(page, row, isInsert, keyValue);
    }

    //protected override bool OnInsert(PageBase page, Database db, DbTransaction transaction)
    //{
    //    //bool b = ValidateData(page);
    //    //if (!b) return false;
    //    return base.OnInsert(page, db, transaction);
    //}

    //protected override bool OnUpdate(PageBase page, string id, Database db, DbTransaction transaction)
    //{
    //    //bool b = ValidateData(page);
    //    //if (!b) return false;
    //    return base.OnUpdate(page, id, db, transaction);
    //}
}
