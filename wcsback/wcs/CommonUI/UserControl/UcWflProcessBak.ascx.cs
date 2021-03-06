﻿using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Text;
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
using EntpClass.WebControlLib.Derived;
using EntpClass.BizLogic.WorkFlow;
using EntpClass.BizLogic.Security;

public partial class CommonUI_UserControl_UcWflProcessBak : UserControlBase
{
    InstanceProcess _CurrentInstanceProcess = null;

    public InstanceProcess CurrentInstanceProcess
    {
        get
        {
            if (_CurrentInstanceProcess == null)
            {
                _CurrentInstanceProcess = new InstanceProcess(ApplicationID, ProcessID, InstanceID);
            }
            return _CurrentInstanceProcess;
        }
    }

    /// <summary>
    /// ApplicationID
    /// </summary>
    public int ApplicationID
    {
        get
        {
            return Fn.ToInt(ViewState["ApplicationID"]);
        }
        set
        {
            if (Fn.ToInt(ViewState["ApplicationID"]) != value)
            {
                _CurrentInstanceProcess = null;
            }
            ViewState["ApplicationID"] = value;

        }
    }

    /// <summary>
    /// ProcessID
    /// </summary>
    public int ProcessID
    {
        get
        {
            return Fn.ToInt(ViewState["ProcessID"]);
        }
        set
        {
            if (Fn.ToInt(ViewState["ProcessID"]) != value)
            {
                _CurrentInstanceProcess = null;
            }
            ViewState["ProcessID"] = value;
        }
    }

    /// <summary>
    /// 实例Id
    /// </summary>
    public int InstanceID
    {
        get
        {
            return Fn.ToInt(ViewState["InstanceID"]);
        }
        set
        {
            if (Fn.ToInt(ViewState["InstanceID"]) != value)
            {
                _CurrentInstanceProcess = null;
            }
            ViewState["InstanceID"] = value;
        }
    }

    /// <summary>
    /// 流程的所有者
    /// </summary>    
    public int ProcessOwnerId
    {
        get { return Fn.ToInt(ViewState["ProcessOwnerId"]); }
        set { ViewState["ProcessOwnerId"] = value; }
    }

    /// <summary>
    /// 流程的创建者
    /// </summary>    
    public int ProcessCreateId
    {
        get { return Fn.ToInt(ViewState["ProcessCreateId"]); }
        set { ViewState["ProcessCreateId"] = value; }
    }

    /// <summary>
    /// 首次提交验证使用的FunctionID
    /// </summary>
    private int _RightFunctionID = 0;
    public int RightFunctionID
    {
        get
        {
            return _RightFunctionID;
        }
        set
        {
            _RightFunctionID = value;
        }
    }

    /// <summary>
    /// 权限验证的Operation_Code
    /// </summary>
    private string _RightOperationCode = "SUBMIT";
    public string RightOperationCode
    {
        get
        {
            return _RightOperationCode;
        }
        set
        {
            _RightOperationCode = value;
        }
    }

    /// <summary>
    /// 是否现在状态列
    /// </summary>
    private bool _ShowStatus = false;
    public bool ShowStatus
    {
        get
        {
            return _ShowStatus;
        }
        set
        {
            _ShowStatus = value;
        }
    }

    /// <summary>
    /// 是否只是使用提交权限来验证
    /// </summary>
    private bool _SingleSubmitRight = false;
    public bool SingleSubmitRight
    {
        get { return _SingleSubmitRight; }
        set { _SingleSubmitRight = value; }
    }

    /// <summary>
    /// 使用的资源的Id
    /// </summary>
    private int _ResourceTypeID = 0;
    public int ResourceTypeID
    {
        get { return _ResourceTypeID; }
        set { _ResourceTypeID = value; }
    }

    /// <summary>
    /// 使用的资源的值,有可能和InstanceID是用一个值。
    /// </summary>
    private string _ResourceValue = "";
    public string ResourceValue
    {
        get { return _ResourceValue; }
        set { _ResourceValue = value; }
    }

    /// <summary>
    /// 得到工作流程数据的存储过程的名字
    /// 工作流的显示数据和具体的业务关联,不能走通用的取数据的存储过程
    /// 关联到版本的数据
    /// </summary>
    private string _ProcessDataProcName = "";
    public string ProcessDataProcName
    {
        get { return _ProcessDataProcName; }
        set { _ProcessDataProcName = value; }
    }

    /// <summary>
    /// 备份页面的路径
    /// </summary>
    private string _BakFormPath = "";
    public string BakFormPath
    {
        get { return _BakFormPath; }
        set { _BakFormPath = value; }
    }

    /// <summary>
    /// 版本比较页面的路径
    /// </summary>
    private string _VersionCompareFormPath = "";
    public string VersionCompareFormPath
    {
        get { return _VersionCompareFormPath; }
        set { _VersionCompareFormPath = value; }
    }

    /// <summary>
    /// 得到当前版本比较的存储过程的名称
    /// 在版本比较控件中使用
    /// </summary>
    private string _VersionCompareProcName = "";
    public string VersionCompareProcName
    {
        get { return _VersionCompareProcName; }
        set { _VersionCompareProcName = value; }
    }

    /// <summary>
    /// 得到所有版本比较的存储过程的名称
    /// 在版本比较控件中使用
    /// </summary>
    private string _VersionCompareAllProcName = "";
    public string VersionCompareAllProcName
    {
        get { return _VersionCompareAllProcName; }
        set { _VersionCompareAllProcName = value; }
    }

    /// <summary>
    /// 是否允许工作流上的提交
    /// </summary>
    private bool _AllowSubmit = true;
    public bool AllowSubmit
    {
        get { return _AllowSubmit; }
        set { _AllowSubmit = value; }
    }

    /// <summary>
    /// 最多显示的审批记录数
    /// </summary>
    private int _ShowMaxRows = 99;
    public int ShowMaxRows
    {
        get { return _ShowMaxRows; }
        set { _ShowMaxRows = value; }
    }

    /// <summary>
    /// 显示最后3条审批记录
    /// </summary>
    private int _ShowLastRows = 3;
    public int ShowLastRows
    {
        get { return _ShowLastRows; }
        set { _ShowLastRows = value; }
    }

    private void BindEmptyGrid()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Operation_Name", typeof(string));
        dt.Columns.Add("Operator_Name", typeof(string));
        dt.Columns.Add("from_state_name", typeof(string));
        dt.Columns.Add("Remark", typeof(string));
        dt.Columns.Add("SDate", typeof(DateTime));
        dt.Columns.Add("version", typeof(string));
        dt.Columns.Add("bak_id", typeof(int));

        GrdProcess.DataSource = dt;
        GrdProcess.DataBind();
    }

    private DataSet GetProcessData()
    {        
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(ProcessDataProcName);
        db.AddInParameter(cmd, "pApplicationid", DbType.Int32, ApplicationID);
        db.AddInParameter(cmd, "pProcessid", DbType.String, ProcessID);
        db.AddInParameter(cmd, "pInstanceid", DbType.String, InstanceID);
        db.AddInParameter(cmd, "pUserId", DbType.Int32, CurrentUser.UserID);        
        db.AddInParameter(cmd, "pLanguageFlag", DbType.String, DBSetting.MultiLanguageSuffix);

        return db.ExecuteDataSet(cmd);
    }  

    public int CurrentStateID
    {
        get
        {
            if (Fn.ToInt(ViewState["CurrentStateID"]) == 0)
            {
                ViewState["CurrentStateID"] = CurrentInstanceProcess.GetCurrentStateID();
            }

            return Fn.ToInt(ViewState["CurrentStateID"]);
        }
        private set
        {
            ViewState["CurrentStateID"] = value;
        }
    }    

    private void RenderEditClientScript()
    {
        GridViewRow editRow = GrdProcess.Rows[GrdProcess.EditIndex];
        UcButton BtnSubmit = (UcButton)editRow.FindControl("BtnSubmit");

        if (!Parent.Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "JsUcAppFormProcessListEdit"))
        {
            RM rmMs = new RM(ResourceFile.Msg);

            RadioButtonList RblOperation = (RadioButtonList)editRow.FindControl("RblOperation");

            StringBuilder s = new StringBuilder(1000);
            s.Append("function OnClientSubmit(instanceId)");
            s.Append("{");
            s.Append("var j=0;");
            s.Append("var grd;");

            s.AppendFormat("var grds =document.getElementsByTagName('TABLE');");
            s.Append("for(var i=0;i<grds.length;i++){if(grds[i].getAttribute('a')==instanceId){grd=grds[i];break;}}");//定位gridview

            s.Append("if(grd==undefined){return false;}");

            s.AppendFormat("var a =grd.getElementsByTagName(\"input\");", RblOperation.ClientID);
            s.Append("for (var i=0;i<a.length;i++){if (a[i].type == 'radio'){if (a[i].checked){j=1;break;}}}");

            s.AppendFormat("if (j==0){{alert('{0}');return false;}}", rmMs["PleaseSelectOperation"]);
            s.AppendFormat("if(!window.confirm('{0}')) return false;", rmMs["ConfirmSubmitForm"]);

            s.Append("return true;");
            s.Append("}");

            Parent.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "JsUcAppFormProcessListEdit", s.ToString().Trim(), true);
        }

        BtnSubmit.OnClientClick = string.Format("if(!OnClientSubmit('{0}')){{window.event.cancelBubble = true;return false;}};", InstanceID);
    }

    private void RenderViewClientScript()
    {
        if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "JsProcessListView"))
        {
            DialogWindow dw = new DialogWindow();
            dw.Url = UrlHelper.UrlBase + VersionCompareFormPath;           
            dw.AddUrlClientObjectParameter("CurBakID", "bakId");
            dw.AddUrlClientObjectParameter("CurVersion", "version");
            dw.AddUrlParameter("FunctionID", RightFunctionID.ToString());
            dw.AddUrlParameter("BakFormPath", BakFormPath);
            dw.AddUrlParameter("VersionCompareProcName", VersionCompareProcName);
            dw.AddUrlParameter("VersionCompareAllProcName", VersionCompareAllProcName);
            dw.Width = 1000;
            dw.Height = 700;

            StringBuilder s = new StringBuilder(300);                       

            s.Append("function ShowVersionCompare(bakId,version)");
            s.Append("{");            
            s.Append(dw.GetShowModalDialogScript());
            s.Append("}");

            dw = new DialogWindow();
            dw.Url = UrlHelper.UrlBase + BakFormPath;
            dw.AddUrlClientObjectParameter("Mode", "mode");
            dw.AddUrlClientObjectParameter("KeyValue", "keyvalue");
            dw.AddUrlClientObjectParameter("Version", "version");
            dw.AddUrlParameter("FunctionID", RightFunctionID.ToString());            
            dw.Width = 1000;
            dw.Height = 700;

            s.Append("function ShowBakForm(mode,keyvalue,version)");
            s.Append("{");            
            s.Append(dw.GetShowModalDialogScript());
            s.Append("}");

            Parent.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "JsProcessListView", s.ToString().Trim(), true);
        }
    }

    private void SetOperationRadioList()
    {
        RadioButtonList RblOperation = (RadioButtonList)GrdProcess.Rows[GrdProcess.EditIndex].FindControl("RblOperation");

        DataSet ds = CurrentInstanceProcess.GetOperationScope(CurrentUser.UserID, CurrentStateID);

        RblOperation.DataSource = ds;
        RblOperation.DataTextField = "operation_name_" + DBSetting.MultiLanguageSuffix;
        RblOperation.DataBind();
    }

    private bool SubmitValidate(string operationCode, string remark, GridViewRow editRow)
    {
        RM rm = new RM(ResourceFile.Msg);
        PageBase page = (PageBase)this.Page;
        
        //服务器端再次检查是否有 operationCode
        if (string.IsNullOrEmpty(operationCode))
        {
            page.Alert(rm["PleaseSelectOperation"]);
            return false;
        }

        //处理超长备注        
        if (remark.Length > 2000)
        {
            page.Alert(rm["ExceedMaxLength"]);
            return false;
        }      

        return true;
    }

    private bool GetHasRight(DataTable dt)
    {
        //判断当前用户是不是可以处理当前流程的用户
        //第一次提交的时候,判断有没有RightFunctionID的SUBMIT的权限
        //进入工作流以后,判断是否有assgin_to的权限
        bool hasRight = false;
        DataRow[] drs0 = dt.Select("P_Level=0");
        DataRow[] drs1 = dt.Select("P_Level=1");        

        if (drs1.Length == 0 || !AllowSubmit)
        {
            hasRight = false;
        }
        else
        {
            int toStateId = Fn.ToInt(drs1[0]["to_state_id"]);                 

            if (SingleSubmitRight)
            {                
                //具体到实例流程
                //只能创建者才可以第一次提交
                if (toStateId == 1 && ProcessCreateId != 0)
                {
                    if (CurrentUser.UserID != ProcessCreateId)
                    {
                        return false;
                    }
                }
                //是否只是有提交权限来验证
                //单一提交权限的验证,不适应assign_to
                if (ResourceTypeID != 0 && !string.IsNullOrEmpty(ResourceValue))
                {
                    hasRight = RightHelper.CheckFuncRescRight(RightFunctionID, RightOperationCode, ApplicationID,ResourceTypeID, ResourceValue);
                }
                else
                {
                    hasRight = RightHelper.CheckFuncRightCached(RightFunctionID, RightOperationCode);
                }
            }
            else
            {                                
                //具体到实例流程
                //只能创建者才可以第一次提交
                if (toStateId == 1 && ProcessCreateId != 0)
                {
                    if (CurrentUser.UserID != ProcessCreateId)
                    {
                        return false;
                    }
                }

                //说明工作流是重新修改的,或者因为其他原因,流程需要重新提交的
                //权限的验证需要重新开始  
                //1:开始状态        
                //2:重新提交状态
                //3:重新编辑状态
                if (dt.Rows.Count == 1 || toStateId == InstanceState.BeginningStateID || toStateId == InstanceState.ReSubmitStateID || toStateId == InstanceState.ReModifyStateID)
                {
                    //第一次使用提交权限来验证                    
                    if (ResourceTypeID != 0 && !string.IsNullOrEmpty(ResourceValue))
                    {
                        hasRight = RightHelper.CheckFuncRescRight(RightFunctionID, RightOperationCode, ApplicationID,ResourceTypeID, ResourceValue);
                    }
                    else
                    {
                        hasRight = RightHelper.CheckFuncRightCached(RightFunctionID, RightOperationCode);
                    }
                }
                else
                {
                    //使用assign_to权限来验证
                    hasRight = CurrentInstanceProcess.CheckActionPermission(CurrentUser.UserID);
                }
            }
        }

        return hasRight;
    }

    public string GetNavigateUrl(object bakID, object version)
    {
        string currentBakID = Fn.ToString(bakID);
        string currentVersion = Fn.ToString(version);

        if (Fn.ToLength(currentBakID) == 0)
            return string.Empty;

        if (Fn.ToLength(currentVersion) == 0)
            return string.Empty;

        if (currentVersion.ToUpper() == "V1")
            return string.Format("javascript:ShowBakForm('VIEW','{0}','{1}')", bakID, currentVersion.Substring(1));
        else
            return string.Format("javascript:ShowVersionCompare('{0}','{1}');", currentBakID, currentVersion);
    }

    public void ProcessData()
    {
        //返回工作流处理情况列表
        //如果返回null,绑定空表
        if (string.IsNullOrEmpty(ProcessDataProcName))
            return;

        DataSet ds = GetProcessData();
        DataTable dt = ds == null ? null : ds.Tables[0];

        if (dt == null)
        {
            this.BindEmptyGrid();
        }
        else
        {
            //工作流程显示有点长, 比较占地方. 默认情况就显示最后3条记录
            int totalRows = dt.Rows.Count;
            if (totalRows > ShowMaxRows)
            {
                string rowFilter = string.Format("id > {0} and id <= {1}", totalRows - ShowLastRows, totalRows);
                dt.DefaultView.RowFilter = rowFilter;
            }

            GrdProcess.Columns[0].Visible = ShowStatus;            
            GrdProcess.DataSource = dt.DefaultView;
            GrdProcess.EditIndex = -1;

            DataRow[] drs0 = dt.Select("P_Level=0");
            DataRow[] drs1 = dt.Select("P_Level=1");

            bool hasRight = GetHasRight(dt);

            if (hasRight)
            {
                if (drs1.Length > 0)
                {
                    //正常情况下,P_Level=1的from_state_id和to_state_id,都是 wfl_instance_state表的state_id
                    if (Fn.ToInt(drs1[0]["to_state_id"]) != CurrentStateID)
                    {                        
                        //流程在审批的过程中,由于某种原因,process_id发生了变化。
                        //新的process会从旧的process的状态开始执行
                        if (drs0.Length > 0)
                        {
                            int count = drs0.Length - 1;
                            int oldProcessId = Fn.ToInt(dt.Rows[count]["process_id"]);
                            int newProcessId = Fn.ToInt(drs1[0]["process_id"]);

                            if (oldProcessId == newProcessId)
                            {
                                throw new Exception("State error. Please contact with administrator.");
                            }
                            else
                            {
                                CurrentStateID = Fn.ToInt(drs1[0]["to_state_id"]);                                
                            }
                        }
                        else
                        {
                            throw new Exception("State error. Please contact with administrator.");
                        }
                    }

                    //如果有权限则允许修改当前状态的行.
                    int editIndex = dt.Rows.IndexOf(drs1[0]);
                    if (AllowSubmit && editIndex >= 0)
                    {
                        GrdProcess.EditIndex = dt.DefaultView.Count - 1;
                    }               
                }
            }
            else
            {
                //如果没有提交权限,且工作流还没有提交,不显示数据
                if (dt.Rows.Count == 1 && drs0.Length == 0)
                {
                    dt.Rows.RemoveAt(0);
                }
            }

            GrdProcess.DataBind();
        }

        //设置操作动作
        if (GrdProcess.EditIndex > -1)
        {
            SetOperationRadioList();
        }
    }    

    protected override bool SupportAutoEvents
    {
        get
        {
            return false;
        }
    }    

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        PageBase page = (PageBase)this.Page;

        if (GrdProcess.EditIndex > -1)
        {
            GridViewRow editRow = GrdProcess.Rows[GrdProcess.EditIndex];
            RadioButtonList RblOperation = (RadioButtonList)editRow.FindControl("RblOperation");
            UcTextBox TxtRemark = (UcTextBox)editRow.FindControl("TxtRemarkEdit");

            string operationCode = RblOperation.SelectedValue;
            string remark = TxtRemark.Text.Trim();
            int currentStateId = CurrentStateID;

            bool b = SubmitValidate(operationCode, remark, editRow);
            if (!b) return;            

            Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    CurrentInstanceProcess.Transit(db, transaction, currentStateId, CurrentUser.UserID, remark, operationCode);

                    transaction.Commit();
                }
                catch (SqlException err)
                {
                    transaction.Rollback();

                    //触发ProcessError事件
                    page.Alert(err.Message);

                    return;
                }
                finally
                {
                    connection.Close();
                }
            }

            string rawUrl = Request.RawUrl;
            if (rawUrl.Contains("?"))
                Response.Redirect(Request.RawUrl + "&REFRESH=-1");
            else
                Response.Redirect(Request.RawUrl + "?REFRESH=-1");
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        PageBase page = (PageBase)this.Page;

        if (GrdProcess.EditIndex > -1)
        {
            RenderEditClientScript();

            //如果流程处理组件在页面上有多个的话,加上一个属性a
            //在客户端验证的时候,判断传递的InstanceID是否和a的值一致,来得到GridView
            //从而定位RblOperation
            GrdProcess.Attributes["a"] = Fn.ToString(InstanceID);
        }

        if (Fn.ToBoolean(Request.QueryString["REFRESH"]))        
            page.RegisterRefreshScript();        

        if (GrdProcess.Rows.Count >= 1 && GrdProcess.Rows[0].Visible == true)
            RenderViewClientScript();
    }
}