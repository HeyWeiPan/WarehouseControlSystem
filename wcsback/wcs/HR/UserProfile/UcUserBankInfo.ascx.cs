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
using EntpClass.WebControlLib.Derived;
using EntpClass.BizLogic.Security;

public partial class HR_UserProfile_UcUserBankInfo : GridControlBase<HRUserBankInfo>
{
    private string UserId
    {
        get
        {
            return Fn.ToString(Request.QueryString["UserId"]);
        }
    }

    protected override bool SupportAutoEvents
    {
        get
        {
            return false;
        }
    }

    protected override GridView GetGridViewControl()
    {
        return GrdBankInfoList;
    }

    protected override DataSet GetGridDataSet()
    {
        string proc = "HR.GetUserBankInfoList";

        Database db = DatabaseFactory.CreateDatabase(HRConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pUserId", DbType.Int32, Fn.ToInt(UserId));

        DataSet ds = db.ExecuteDataSet(cmd);

        return ds;
    }

    protected override void SetParameter(GridControlParameter p)
    {
        base.SetParameter(p);

        PageParameter parmeter = new PageParameter();
        parmeter.ResourceTypeIDs = new int[] { ScrUser.ResourceTypeID };
        parmeter.ResourceValues = new string[] { UserId };
        parmeter.FunctionID = HRUser.USER_BANKINFO;

        PageRights right = new PageRights(parmeter);

        p.DialogMode = false;
        p.FreeFormMode = true;
        p.AutoBindControl = true;
        p.AddRight = right.AddRight;
        p.DeleteRight = right.DeleteRight;
        p.EditRight = right.EditRight;

    }



    protected override bool OnPreSave(PageBase page, GridViewRow row, bool isInsert, string keyValue)
    {
        Hashtable dataControlCollection = page.DataControlCollection;

        if (isInsert)
        {
            IWebDataControl HidUserId = Fn.GetControlByColumnName(dataControlCollection, "user_id");
            HidUserId.RequiredField = true;
            HidUserId.SetValue(UserId);
        }

        return base.OnPreSave(page, row, isInsert, keyValue);
    }
}
