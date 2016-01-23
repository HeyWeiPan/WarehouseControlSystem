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
using EntpClass.WebControlLib.Derived.HR;
using EntpClass.BizLogic.Security;

public partial class HR_UserProfile_UcUserPositionTransferList : GridControlBase<HRUserPositionTransfer>
{
    private string UserId
    {
        get{ return Fn.ToString(Request.QueryString["UserId"]);}
    }
    
    protected override GridView GetGridViewControl()
    {
        return GrdPosTranList;
    }

    protected override DataSet GetGridDataSet()
    {
        string proc = "HR.GetUserPositionTransferHistory";
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
        parmeter.FunctionID = HRUser.USER_WORK_AFTER;

        PageRights right = new PageRights(parmeter);

        p.AddRight = right.AddRight;
        p.DeleteRight = right.DeleteRight;
        p.EditRight = right.EditRight;
    }

    protected override bool OnPreSave(PageBase page, GridViewRow row, bool isInsert, string keyValue)
    {
        Hashtable dataControlCollection = page.DataControlCollection;

        if (isInsert)
        {
            UcHiddenField HidUserId = new UcHiddenField();
            HidUserId.ID = "HidUserId";
            HidUserId.ColumnName = "user_id";
            HidUserId.RequiredField = true;
            HidUserId.Value = UserId;

            page.AddControl(HidUserId);
        }
        
        UcDropDownList DrpCompanyId = (UcDropDownList)Fn.GetControlByColumnName(dataControlCollection, "company_id");
        IWebDataControl TxtStartDate = Fn.GetControlByColumnName(dataControlCollection, "start_date");//结束日期
        IWebDataControl TxtEndDate = Fn.GetControlByColumnName(dataControlCollection, "end_date");//结束日期
        IWebDataControl TxtServiceMonth = Fn.GetControlByColumnName(dataControlCollection, "service_month");//司龄(月)

        UcHiddenField HidCompany = new UcHiddenField();
        HidCompany.ID = "HidCompany";
        HidCompany.ColumnName = "company_name";
        HidCompany.Value = DrpCompanyId.SelectedItem.Text;

        string a = string.Format("dbo.GetDatediffMonth('{0}','{1}')", TxtStartDate.GetValue(), TxtEndDate.GetValue());

        TxtServiceMonth.InsertExpression = a;
        TxtServiceMonth.UpdateExpression = a;

        page.AddControl(HidCompany);

        return base.OnPreSave(page, row, isInsert, keyValue);
    }    
}

