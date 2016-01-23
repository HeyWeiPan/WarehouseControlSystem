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
using EntpClass.BizLogic.HR.UserProfile;
using EntpClass.BizLogic.Security;
using EntpClass.BizLogic.HR.Leave;

public partial class HR_UserProfile_UcUserLeaveResidualList : GridControlBase<LeaveInit>
{
    private string _PeriodId;
    public string PeriodId
    {
        get { return _PeriodId; }
        set { _PeriodId = value; }
    }

    private string UserId
    {
        get
        {
            return Fn.ToString(Request.QueryString["UserId"]);
        }
    }

    //private string _TotalResidualDays;
    //public string TotalResidualDays
    //{
    //    get { return _TotalResidualDays; }
    //    set { _TotalResidualDays = value; }
    //}

    protected override GridView GetGridViewControl()
    {
        return GrdUserLeaveList;
    }

    protected override DataSet GetGridDataSet()
    {
        DataSet ds = LeaveInit.GetUserLeaveResidualList(Fn.ToInt(PeriodId), Fn.ToInt(UserId));

        //if (ds != null && ds.Tables.Count != 0 && ds.Tables[0].Rows.Count > 0)
        //    TotalResidualDays = Fn.ToString(ds.Tables[0].Rows[0]["total_residual_days"]);

        return ds;
    }

    protected override void OnLoad(EventArgs e)
    {
        GridDataLoaded = true;

        base.OnLoad(e);
    }

    protected override void SetParameter(GridControlParameter p)
    {
        base.SetParameter(p);
       
        p.DialogMode = false;
        p.AddRight = false;
        p.DeleteRight = false;
        p.EditRight = false;
    }
}
