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

public partial class HR_UserProfile_UcUserRewardPunish : GridControlBase<HRUserRewardPunish>
{
    private string UserId
    {
        get
        {
            return Fn.ToString(Request.QueryString["UserId"]);
        }
    }  

    private int _CurrentCompanyFlag = -1;
    public int CurrentCompanyFlag
    {
        get { return _CurrentCompanyFlag; }
        set { _CurrentCompanyFlag = value; }
    }

   

    protected override bool SupportAutoEvents
    {
        get
        {
            return false;
        }
    }


    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (CurrentCompanyFlag == 0)
        {
            GrdList.Columns[0].HeaderText = "CURRENT_COMPANY_BEFORE";
           
        }
        else
        {
            GrdList.Columns[0].HeaderText = "CURRENT_COMPANY_AFTER";
        }


    }


    protected override GridView GetGridViewControl()
    {
        return GrdList;
    }

    protected override DataSet GetGridDataSet()
    {
        string proc = "HR.GetUserRewardPunishList";

        Database db = DatabaseFactory.CreateDatabase(HRConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pUserId", DbType.Int32, Fn.ToInt(UserId));
        db.AddInParameter(cmd, "pCurrentCompanyFlag", DbType.Int32, CurrentCompanyFlag);

        DataSet ds = db.ExecuteDataSet(cmd);

        return ds;
    }

    protected override void SetParameter(GridControlParameter p)
    {
        
        base.SetParameter(p);

        int functionId = 0;

        if (CurrentCompanyFlag == 0)
            functionId = HRUser.USER_REWARD_BEFORE;//入职前的权限
        else
            functionId = HRUser.USER_REWARD_AFTER;//入职后的权限

        PageParameter parmeter = new PageParameter();
        parmeter.ResourceTypeIDs = new int[] { ScrUser.ResourceTypeID };
        parmeter.ResourceValues = new string[] { UserId };
        parmeter.FunctionID = functionId;
        
        PageRights right = new PageRights(parmeter);

        p.DialogMode = false;
        p.FreeFormMode = true;
        p.AutoBindControl = true;
        p.AddRight = right.AddRight;
        p.DeleteRight = right.DeleteRight;
        p.EditRight = right.EditRight;

        //bool b = RightHelper.CheckFuncRescRight(functionId, OperationCode.EDIT, ScrUser.ResourceTypeID, UserId);

        //p.AddRight = p.AddRight == true ? b : p.AddRight;
        //p.EditRight = p.EditRight == true ? b : p.EditRight;
        //p.DeleteRight = p.DeleteRight == true ? b : p.DeleteRight;
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

            UcHiddenField HidCurrentCompanyFlag = new UcHiddenField();
            HidCurrentCompanyFlag.ID = "HidCurrentCompanyFlag";
            HidCurrentCompanyFlag.ColumnName = "current_company_flag";
            HidCurrentCompanyFlag.RequiredField = true;
            HidCurrentCompanyFlag.Value = CurrentCompanyFlag.ToString();

            page.AddControl(HidUserId);
            page.AddControl(HidCurrentCompanyFlag);
        }

        return base.OnPreSave(page, row, isInsert, keyValue);
    }    
}



