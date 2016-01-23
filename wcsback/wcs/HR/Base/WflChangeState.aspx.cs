using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.WorkFlow;
using EntpClass.BizLogic.HR.HRApplication;
using EntpClass.BizLogic.HR.PA;

public partial class HR_Base_WflChangeState : PageBase
{
    private const int LeaveFormApplicationID = 3100000;
    private int ApplicationId
    {
        get { return Fn.ToInt(Request.QueryString["ApplicationId"]); }
    }

    private int ProcessId
    {
        get { return Fn.ToInt(Request.QueryString["ProcessId"]); }
    }

    private int InstanceId
    {
        get { return Fn.ToInt(Request.QueryString["InstanceId"]); }
    }

    private string DBAction
    {
        get
        {
            switch (ApplicationId)
            {
                case AppProcessType.ApplicationID:
                    return "HR.AppDBAction";
                case PAImprove.ApplicationID:
                    return "HR.PAImproveDBAction";
                case LeaveFormApplicationID:
                    return "HR.LeaveDBAction";
                default:
                    return "";
            }
        }
    }

    private string GetStatusSql()
    {
        switch (ApplicationId)
        {
            case AppProcessType.ApplicationID:
            case PAImprove.ApplicationID:
                string sql1
                     = "select value, text,show_order "
                     + "from "
                     + "("
                     + string.Format(" select value=state_id,text=function_name_{0},show_order=show_order*100 from scr_function ", CurrentUser.UseLanguage == Language.English ? "en" : "cn")
                     + string.Format(" where delete_flag = 0 and enable_flag = -1 and function_pid = {0} and state_id > 100 ", ProcessId.ToString())
                     + string.Format(" union select value=state_id,text=state_name_{0},show_order=state_id*10 from wfl_state", CurrentUser.UseLanguage == Language.English ? "en" : "cn")
                     + string.Format(" where enable_flag = -1 and state_id in({0},{1},{2},{3})", InstanceState.ReSubmitStateID, InstanceState.CancelledStateID, InstanceState.ApprovedStateID, InstanceState.DisapprovedStateID)
                     + " ) t order by show_order";
                return sql1;
            case LeaveFormApplicationID:
                string sql2
                   = "select value, text "
                   + "from "
                   + "("
                   + string.Format(" select distinct to_state_id value,wfl.f_GetStateName(to_state_id,'{0}') text,to_state_id show_order", CurrentUser.UseLanguage == Language.English ? "en" : "cn")
                   + string.Format(" from wfl_transit where enable_flag = -1 and to_state_id != 1 and process_id = {0} ", ProcessId)
                   + string.Format(" and to_state_id not in({0},{1},{2},{3},{4})",
                        InstanceState.ReSubmitStateID, InstanceState.ReModifyStateID, InstanceState.CancelledStateID,
                        InstanceState.ApprovedStateID, InstanceState.DisapprovedStateID)
                   + " union "
                   + string.Format(" select state_id as value, state_name_{0} as text,state_id show_order from wfl_state", CurrentUser.UseLanguage == Language.English ? "en" : "cn")
                   + string.Format(" where enable_flag = -1 and state_id in({0},{1},{2},{3},{4})",
                         InstanceState.ReSubmitStateID, InstanceState.ReModifyStateID, InstanceState.CancelledStateID,
                         InstanceState.ApprovedStateID, InstanceState.DisapprovedStateID)
                   + " ) t order by show_order desc";
                return sql2;
            default:
                string sql = "select value, text,show_order "
                + "from "
                + "("
                + string.Format(" select value=state_id,text=function_name_{0},show_order=show_order*100 from scr_function ", CurrentUser.UseLanguage == Language.English ? "en" : "cn")
                + string.Format(" where delete_flag = 0 and enable_flag = -1 and function_pid = {0} and state_id > 100 ", ProcessId.ToString())
                + string.Format(" union select value=state_id,text=state_name_{0},show_order=state_id*10 from wfl_state", CurrentUser.UseLanguage == Language.English ? "en" : "cn")
                + string.Format(" where enable_flag = -1 and state_id in({0},{1},{2},{3})", InstanceState.ReSubmitStateID, InstanceState.CancelledStateID, InstanceState.ApprovedStateID, InstanceState.DisapprovedStateID)
                + " ) t order by show_order";

                return sql;

        }

    }

    public override void SetPageInfo(ref PageParameter p)
    {
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (!IsPostBack)
        {
            DdlStatus.SqlText = GetStatusSql();
            DdlStatus.DataBind();

            DdlStatus.ColumnName = "Status";
            DdlStatus.RequiredField = true;
        }
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        string message;
        Control control;
        RM rmMs = new RM(ResourceFile.Msg);

        if (string.IsNullOrEmpty(DdlStatus.SelectedValue))
            return;

        bool b = CheckValid(out control, out message);
        if (!b)
        {
            Alert(message);
            return;
        }

        InstanceProcess process = new InstanceProcess(ApplicationId, ProcessId, InstanceId);

        int toStateId = Fn.ToInt(DdlStatus.SelectedValue);
        string remark = TxtWfRemark.Text;
        string operationCode = InstanceProcess.ADMINAPPROVE;
        int currentStateId = process.GetCurrentStateID();

        //if (toStateId == currentStateId)
        //{
        //    Alert(rmMs["CheckWflState"]);
        //    return;
        //}

        if (toStateId == InstanceState.CancelledStateID)
            b = process.ChangeProcessState(toStateId, operationCode, false, DBAction, remark, out message);
        else
            b = process.ChangeProcessState(toStateId, operationCode, true, DBAction, remark, out message);

        if (!b)
            Alert(message);
        else
        {
            string str = "window.returnValue='REFRESH';";
            AttachClientEvent("SetOnLoad", "window", "onload", str);

            Alert(rmMs["SubmitSuccess"]);

            DdlStatus.Enabled = false;
            TxtWfRemark.ReadOnly = true;
            BtnSubmit.Visible = false;
        }
    }
}
