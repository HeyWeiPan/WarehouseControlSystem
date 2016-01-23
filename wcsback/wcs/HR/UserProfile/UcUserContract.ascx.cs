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

public partial class HR_UserProfile_UcUserContract : GridControlBase<HRUserContract>
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
        return GrdContractList;
    }

    protected override DataSet GetGridDataSet()
    {
        string proc = "HR.GetUserContractList";

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
        parmeter.FunctionID = HRUser.USER_CONTRACT;

        PageRights right = new PageRights(parmeter);

        p.DialogMode = false;
        p.FreeFormMode = true;
        p.AutoBindControl = true;
        p.AddRight = right.AddRight;
        p.DeleteRight = right.DeleteRight;
        p.EditRight = right.EditRight;

    }

    protected override void SetRowControlValue(GridViewRowEventArgs e, Hashtable rowCtrlCollection, DataRowView r, PageMode m)
    {
        base.SetRowControlValue(e, rowCtrlCollection, r, m);

        UcDdlYesNo DrpNoEndDateFlag = Fn.GetControlByColumnName(rowCtrlCollection, "CONTRACT_NOENDDATE_FLAG") as UcDdlYesNo;
        UcDatePicker DtpContractEndDate = Fn.GetControlByColumnName(rowCtrlCollection, "CONTRACT_end_date") as UcDatePicker;
        UcTextBox TxtContractMonth = Fn.GetControlByColumnName(rowCtrlCollection, "contract_month") as UcTextBox;

        if (Fn.ToBoolean(DrpNoEndDateFlag.Text) == true)
        {
            //无固定期限劳动合同
            DtpContractEndDate.Text = string.Empty;
            TxtContractMonth.ReadOnlyWhenInsert = true;
            TxtContractMonth.ReadOnlyWhenUpdate = true;
            TxtContractMonth.RequiredField = false;
            TxtContractMonth.Text = string.Empty;
        }
        else
        {
            TxtContractMonth.ReadOnlyWhenInsert = false;
            TxtContractMonth.ReadOnlyWhenUpdate = false;

            TxtContractMonth.ReadOnly = false;
            TxtContractMonth.RequiredField = true;
        }


        UcDropDownList DrpCompanyID = Fn.GetControlByColumnName(rowCtrlCollection, "contract_company_id") as UcDropDownList;
        UcTextBox TxtCompanyName = Fn.GetControlByColumnName(rowCtrlCollection, "contract_company_name") as UcTextBox;

        if (m == PageMode.Add || m == PageMode.Edit)
        {
            DrpCompanyID.Visible = true;
            TxtCompanyName.Visible = false;
        }
        else
        {
            DrpCompanyID.Visible = false;
            TxtCompanyName.Visible = true;
        }

        if (m == PageMode.Add)
        {
            DataSet ds = HRUser.GetUserBasicInfo(Fn.ToInt(UserId));

            IWebDataControl statusCode = Fn.GetControlByColumnName(rowCtrlCollection, "user_status_code") as IWebDataControl;
            IWebDataControl userType = Fn.GetControlByColumnName(rowCtrlCollection, "user_type_id") as IWebDataControl;

            statusCode.BindData(ds.Tables[0].DefaultView[0]);
            userType.BindData(ds.Tables[0].DefaultView[0]);
            DrpCompanyID.BindData(ds.Tables[0].DefaultView[0]);
        }
    }

    protected override void InitNewRow(GridViewRow r, Hashtable rowCtrlCollection)
    {
        base.InitNewRow(r, rowCtrlCollection);

        //IWebDataControl DdlCurrentContractFlag = Fn.GetControlByColumnName(rowCtrlCollection, "last_contract_flag");
        //DdlCurrentContractFlag.SetValue("-1");
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

        UcDropDownList DrpCompanyID = Fn.GetControlByColumnName(dataControlCollection, "contract_company_id") as UcDropDownList;
        UcTextBox TxtCompanyName = Fn.GetControlByColumnName(dataControlCollection, "contract_company_name") as UcTextBox;

        TxtCompanyName.Text = DrpCompanyID.SelectedItem.Text;

        return base.OnPreSave(page, row, isInsert, keyValue);
    }
}
