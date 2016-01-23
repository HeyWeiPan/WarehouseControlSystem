using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using EntpClass.WebControlLib;
using EntpClass.WebControlLib.Derived;
using EntpClass.Common;
using EntpClass.BizLogic;
using EntpClass.WebUI;
using EntpClass.BizLogic.Security;
using EntpClass.BizLogic.WorkFlow;

using System.Text;

public partial class UcDSSWflProcess : WorkflowUserControlBase
{
    public class RedefineSubmitEventArgs : EventArgs
    {
        public string OperationName;
        public RedefineSubmitEventArgs(string operationName)
        {
            this.OperationName = operationName;
        }
    }
    public delegate void AfterRedefineProcessSubmit(object sender, RedefineSubmitEventArgs e);
    public event AfterRedefineProcessSubmit OnAfterRedefineProcessSubmit;

    public delegate void BeforeSubmit(object sender, EventArgs e);
    public event BeforeSubmit OnBeforeProcessSubmit;

    public event InstanceProcessTemplate.AfterWorkFlowTransit OnAfterworkFlowTransit;

    public delegate void SubmitSuccess(object sender, EventArgs e);
    public event SubmitSuccess OnSubmitSuccess;

    /// <summary>
    /// 执行了重定义操作后，是否处理设置流程步骤的页面
    /// </summary>
    public bool IsAdminPage
    {
        get
        {
            return Fn.ToBoolean(ViewState["IsAdminPage"]);
        }
        set
        {
            ViewState["IsAdminPage"] = value;
        }
    }

    /// <summary>
    /// 页面的模式，如果页面模式不是处在View时，提交按钮不可用
    /// </summary>
    public PageMode mode
    {
        get
        {
            PageBase p = this.Page as PageBase;
            return p.CurrentPageMode;
        }
        //set
        //{
        //    ViewState["ParentPageMode"] = value;
        //}
    }

    /// <summary>
    /// Submit之前的检查结果，由外面页面执行OnBeforeSubmit事件时设置
    /// </summary>
    public string CheckSubmitReturnMessage
    {
        get
        {
            return Fn.ToString(ViewState["CheckSubmitReturnMessage"]);
        }
        set
        {
            ViewState["CheckSubmitReturnMessage"] = value;
        }
    }

    private bool _CheckSubmitResult = true;
    public bool CheckSubmitResult
    {
        get
        {
            return _CheckSubmitResult;
        }
        set
        {
            _CheckSubmitResult = value;
        }
    }
    /// <summary>
    /// 指示是否是用户自定义流程
    /// </summary>
    public bool IsUserDefineProcess
    {
        get
        {
            return Fn.ToBoolean(ViewState["IsUserDefineProcess"]);
        }
        set
        {
            ViewState["IsUserDefineProcess"] = value;
        }
    }

    public string GetOperationCode()
    {
        RadioButtonList rblOperation = (RadioButtonList)GrdActivity.Rows[GrdActivity.EditIndex].FindControl("RblOperation");
        return rblOperation.SelectedValue;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (ViewState["IsUserDefineProcess"] == null)
            {
                IsUserDefineProcess = false;
            }
            SetInstanceActivityGrid();
        }
    }
    private void SetOperationRadioList()
    {

        InstanceProcess instprocess = new InstanceProcess(ApplicationID, ProcessID, InstanceID);

        RadioButtonList RblOperation = (RadioButtonList)GrdActivity.Rows[GrdActivity.EditIndex].FindControl("RblOperation");

        DataSet ds = instprocess.GetOperationScope(CurrentUser.UserID, CurrentStateID);
        if (ds.Tables[0].Rows.Count > 4)
        {
            RblOperation.RepeatLayout = RepeatLayout.Table;
            RblOperation.RepeatColumns = 2;
            RblOperation.RepeatDirection = RepeatDirection.Horizontal;
        }
        RblOperation.DataSource = ds;
        RblOperation.DataTextField = "operation_name_" + DBSetting.MultiLanguageSuffix;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (Fn.ToInt(dr["operation_id"]) == InstanceProcessTemplate.HoldOperationId)
            {
                dr["operation_name_" + DBSetting.MultiLanguageSuffix] = InstanceProcessTemplate.HoldName;
            }
        }
        RblOperation.DataBind();
    }

    public void SetInstanceActivityGrid()
    {
        GrdActivity.EditIndex = -1;
        bool isPrint = false;
        if (Page.Request.Path.IndexOf("Print", StringComparison.CurrentCultureIgnoreCase) > 0)
        {
            //print mode
            isPrint = true;
        }


        InstanceProcessTemplate instanceTemplate = new InstanceProcessTemplate();
        DataSet ds = instanceTemplate.GetInstanceProcess(ApplicationID,
            ProcessID, InstanceID, DBSetting.MultiLanguageSuffix);

        InstanceProcess instprocess = new InstanceProcess(ApplicationID, ProcessID, InstanceID);
        CurrentStateID = instprocess.GetCurrentStateID();

        InstanceState ins = new InstanceState(ApplicationID, InstanceID);

        RM rm = new RM(ResourceFile.Msg);

        //int EditIndex = -1;
        int assignTo = instanceTemplate.GetAssignTo(ApplicationID, InstanceID);

        GrdActivity.DataSource = ds;
        if (!isPrint)
        {
            //以下部分需要判断是否是处在用户自定义流程状态，如果是，则只允许在未定义流程管理页面进行操作
            //但需要注意，如果当前状态是用户自定义流程状态，有可能被Hold了，此时在未定义流程管理页面也不允许进行流程操作，
            //也不需要添加指示未定义流程操作的行
            if (instprocess.CheckActionPermission(CurrentUser.UserID))
            {
                DataRow[] drs = ds.Tables[0].Select("P_Level=1");

                if (drs.Length > 0)
                {
                    if (Fn.ToInt(drs[0]["from_state_id"]) != CurrentStateID)
                    {
                        throw new Exception("State error. Please contact with administrator.");
                    }
                    GrdActivity.EditIndex = ds.Tables[0].Rows.IndexOf(drs[0]);
                    //if (CurrentStateID == State.GetStateID(UserDefineProcess.RedefineStateCode))
                    //{
                    //    drs[0]["Operator_name"] = rm["ToBeRedefine"];
                    //    EditIndex = GrdActivity.EditIndex;
                    //    GrdActivity.EditIndex = -1;
                    //}
                }

            }
            //if (CurrentStateID == State.GetStateID(UserDefineProcess.RedefineStateCode))
            //{
            //    if (assignTo == 0)      //刚执行了用户重定义流程操作
            //    {
            //        DataRow dr = ds.Tables[0].NewRow();
            //        dr["Operator_name"] = rm["ToBeRedefine"];
            //        ds.Tables[0].Rows.Add(dr);
            //        if (IsAdminPage)
            //        {
            //            GrdActivity.EditIndex = ds.Tables[0].Rows.Count - 1;
            //        }
            //    }
            //    else if (assignTo > 0)
            //    {
            //        if (EditIndex != -1)
            //        {
            //            if (IsAdminPage)
            //            {
            //                GrdActivity.EditIndex = EditIndex;
            //            }
            //        }
            //        else
            //        {
            //            ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["Operator_name"] = rm["ToBeRedefine"];
            //        }
            //    }
            //}
        }

        GrdActivity.DataBind();
        if (GrdActivity.EditIndex > -1)
        {
            SetOperationRadioList();
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        if (GrdActivity.EditIndex > -1)
        {
            RenderClientScript();
        }

        base.OnPreRender(e);
    }

    void RenderClientScript()
    {

        RM rm = new RM(ResourceFile.Msg);

        RadioButtonList RblOperation = (RadioButtonList)GrdActivity.Rows[GrdActivity.EditIndex].FindControl("RblOperation");
        UcButton BtnSubmit = (UcButton)GrdActivity.Rows[GrdActivity.EditIndex].FindControl("BtnSubmit");
        BtnSubmit.OnClientClick = string.Format("if(!window.confirm('{0}')) return false;", rm["ConfirmSubmitForm"]);

        StringBuilder s = new StringBuilder(200);
        s.Append("function OnClientSubmit()");
        s.Append("{");

        s.Append("var selectedVal='';");
        s.Append("var grd;");
        s.Append("var grds =document.getElementsByTagName('TABLE');");
        s.AppendFormat("for(var i=0;i<grds.length;i++){{if(grds[i].getAttribute('id')=='{0}'){{grd=grds[i];break;}}}}", RblOperation.ClientID);//定位gridview
        s.Append("var a =grd.getElementsByTagName(\"input\");");
        s.Append("for (var i=0;i<a.length;i++){if (a[i].type == 'radio'){if (a[i].checked){selectedVal=a[i].value;break;}}}");

        foreach (ListItem item in RblOperation.Items)
        {
            if (item.Value.ToUpper() == "FORWARD")
            {
                DialogWindow w = new DialogWindow();
                w.Url = UrlHelper.UrlBase + "/DSS/IDMP/GetForwardPerson.aspx";

                w.Width = 400;
                w.Height = 280;
                s.Append("if(selectedVal=='FORWARD')");
                s.Append("{");
                s.Append("var returnValue = '';");
                s.Append(w.GetShowModalDialogScript("returnValue"));
                s.Append("if(returnValue == null || returnValue == ''){ return false;}");
                s.AppendFormat("document.all('{0}').value = returnValue;", HidForwardPerson.ClientID);
                s.Append("}");
            }
        }
        s.AppendFormat("if (selectedVal==''){{alert('{0}');return false;}}", rm["PleaseSelectOperation"]);

        s.AppendFormat("if(!window.confirm('{0}')) return false;", rm["ConfirmSubmitForm"]);
        s.Append("return true;");
        s.Append("}\n");

        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clientscript", s.ToString(), true);

        BtnSubmit.OnClientClick = "if(!OnClientSubmit()){return false;} window.returnValue='REFRESH';";

        if (mode != PageMode.View)
        {
            BtnSubmit.Enabled = false;
        }
        else
        {
            BtnSubmit.Enabled = true;
        }
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        PageBase page = (PageBase)this.Page;
        RM rm = new RM(ResourceFile.Msg);

        if (mode != PageMode.View)
        {
            page.Alert(rm["SAVEFIRST"]);
            return;
        }

        CheckSubmitReturnMessage = "";

        if (OnBeforeProcessSubmit != null)
        {
            OnBeforeProcessSubmit(this, EventArgs.Empty);
        }

        if (CheckSubmitReturnMessage.Length != 0)
        {
            page.Alert(CheckSubmitReturnMessage);
            return;
        }

        if (!CheckSubmitResult)
        {
            return;
        }


        //if (AppSetting.HttpsEnabled)
        //{
        //    HttpClientCertificate cert = Request.ClientCertificate;
        //    if (!Certificate.CheckClientCertificate(cert))
        //    {
        //        page.Alert("Your client certificate has problem, please contact helpdesk!");
        //        return;
        //    }
        //}

        if (GrdActivity.EditIndex > -1)
        {
            InstanceProcess instprocess = new InstanceProcess(ApplicationID, ProcessID, InstanceID);
            GridViewRow editRow = GrdActivity.Rows[GrdActivity.EditIndex];
            RadioButtonList rblOperation = (RadioButtonList)editRow.FindControl("RblOperation");
            UcTextBox txtRemark = (UcTextBox)editRow.FindControl("TxtRemark");


            if (rblOperation.SelectedItem == null)
            {
                page.Alert(rm["PleaseSelectOperation"]);
                return;
            }
            string operationCode = rblOperation.SelectedValue;

            int assignTo = 0;
            int userID = CurrentUser.UserID;

            int redefineStateId = State.GetStateID(UserDefineProcess.RedefineStateCode);
            int userdefineStateId = State.GetStateID(UserDefineProcess.UserDefineStateCode);

            if (operationCode.ToUpper() == "FORWARD")
            {
                assignTo = Fn.ToInt(HidForwardPerson.Value);
                if (assignTo == 0)
                {
                    page.Alert(rm["Notsetforward"]);
                    return;
                }
            }

            if (operationCode.ToUpper() == "HOLD")
            {
                InstanceProcessTemplate instanceTemplate = new InstanceProcessTemplate();
                assignTo = instanceTemplate.GetApplicantId(ApplicationID, InstanceID);
            }

            if (operationCode.ToUpper() == "APPROVE" && CurrentStateID == State.GetStateID(UserDefineProcess.RedefineStateCode))
            {
                int c = UserDefineProcess.GetItemsCount(ApplicationID, InstanceID);
                if (c == 0)
                {
                    page.Alert(rm["PROCESS_NOT_DEFINED"]);
                    return;
                }
                string errorMessageDefine;
                if (!UserDefineProcess.SetUserDefineProcessStep(
                    ApplicationID, ProcessID, InstanceID, txtRemark.Text, out errorMessageDefine))
                {
                    page.Alert(rm["SubmitFailed"] + errorMessageDefine);
                    return;
                }
                else
                {
                    if (OnAfterRedefineProcessSubmit != null)
                    {
                        RM rm2 = new RM(ResourceFile.Msg);
                        OnAfterRedefineProcessSubmit(this, new RedefineSubmitEventArgs(rm2["RedefineFlowStep"]));
                    }
                }
            }
            else
            {
                string errorMessage;
                InstanceProcessTemplate instanceTemplate = new InstanceProcessTemplate(OnAfterworkFlowTransit);
                if (!instanceTemplate.TransitProcess(ApplicationID, ProcessID, InstanceID, IsUserDefineProcess, CurrentStateID, operationCode, txtRemark.Text, assignTo, out errorMessage))
                {
                    page.Alert(rm["SubmitFailed"] + errorMessage);
                    return;
                }
                else
                {
                    if (CurrentStateID == redefineStateId || CurrentStateID == userdefineStateId)
                    {
                        if (OnAfterRedefineProcessSubmit != null)
                        {
                            OnAfterRedefineProcessSubmit(this, new RedefineSubmitEventArgs(UserDefineProcess.GetOperationNameByCode(operationCode)));
                        }
                    }
                }

                if (OnSubmitSuccess != null)
                {
                    OnSubmitSuccess(this, new EventArgs());
                }
            }
            SetInstanceActivityGrid();
        }
    }

    public override void Refresh()
    {
        SetInstanceActivityGrid();
    }
}