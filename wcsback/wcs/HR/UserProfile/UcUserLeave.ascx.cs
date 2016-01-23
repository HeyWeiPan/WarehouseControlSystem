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
using EntpClass.BizLogic.HR.Leave;

public partial class HR_UserProfile_UcUserLeave : GridControlBase<LeaveForm>
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

    protected override bool SupportAutoEvents
    {
        get
        {
            return false;
        }
    }

    protected override GridView GetGridViewControl()
    {
        return GrdLeaveList;
    }

    protected override DataSet GetGridDataSet()
    {
        DataSet ds = LeaveForm.GetUserLeaveList(Fn.ToInt(PeriodId), Fn.ToInt(UserId));                

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
        p.FreeFormMode = true;
        p.AutoBindControl = true;
        p.AddRight = false;
        p.DeleteRight = false;
        p.EditRight = false;
    }
}
