using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.BizLogic.HR.Setup;
using EntpClass.BizLogic.Security;
using EntpClass.WebControlLib;

public partial class HR_Setup_JobStructureDetail : SetUpDetailPageBase<JobStructure>
{
    private void RegditLnkScript()
    {
        if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegditLnkScript"))
        {
            StringBuilder s = new StringBuilder(1000);

            s.Append("function switchTab(oSelectedTab,columnName,HidSelectedTab)");
            s.Append("{");
            s.Append("document.getElementById(HidSelectedTab).value=oSelectedTab.id;");//保存客户端每次点击TabId

            if (TabJobPay.Visible)
            {
                s.AppendFormat("var TabJobPay = document.getElementById('{0}');", TabJobPay.ClientID);
                s.Append("TabJobPay.style.display='none';");
            }

            if (TabResponsibility.Visible)
            {
                s.AppendFormat("var TabResponsibility = document.getElementById('{0}');", TabResponsibility.ClientID);
                s.Append("TabResponsibility.style.display='none';");
            }

            s.AppendFormat("var TabIfra = document.getElementById('{0}');", TabIfra.ClientID);
            s.Append("TabIfra.style.display='none';");

            s.Append("switch(columnName.toLowerCase())");
            s.Append("{");
            s.Append("case 'tabuser':");
            s.Append("case 'tabquality':");
            s.Append("case 'tabknowledge':");
            s.Append("case 'tabskill':");
            s.Append("TabIfra.style.display='inline';");
            s.Append("break;");

            s.Append("case 'tabjobpay':");
            s.Append("TabJobPay.style.display='inline';");
            s.Append("break;");

            s.Append("case 'tabresponsibility':");
            s.Append("TabIfra.style.display='inline';");
            s.Append("TabResponsibility.style.display='inline';");
            s.Append("break;");
            s.Append("}");

            s.Append("}");

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegditLnkScript", s.ToString(), true);
        }
    }

    private string DefaultTabColumnName
    {
        get { return Fn.ToString(Request.QueryString["DefaultTab"]); }
    }

    public UcHyperLink GetFirstTab()
    {
        if (LnkUser.Visible)
            return LnkUser;
        else if (LnkResponsibility.Visible)
            return LnkResponsibility; 
        else if (LnkQuality.Visible)
            return LnkQuality;
        else if (LnkKnowledge.Visible)
            return LnkKnowledge;
        else if (LnkSkill.Visible)
            return LnkSkill;
        else if (LnkJobPay.Visible)
            return LnkJobPay;              
        else
            return null;
    }

    private UcHyperLink GetCurrentTab()
    {
        string defaultTabColumnName = string.Empty;

        if (!string.IsNullOrEmpty(HidSelectedTab.Value))
        {
            defaultTabColumnName = HidSelectedTab.Value;
        }
        else
        {
            defaultTabColumnName = DefaultTabColumnName;
        }

        if (!string.IsNullOrEmpty(defaultTabColumnName))
        {
            UcHyperLink lnk = null;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is UcHyperLink)
                {
                    lnk = ctrl as UcHyperLink;

                    if (lnk.ColumnName == defaultTabColumnName || lnk.ClientID == defaultTabColumnName)
                    {
                        if (lnk.Visible)
                        {
                            return lnk;
                        }
                        else
                        {
                            return GetFirstTab();
                        }
                    }
                }
            }
        }

        return GetFirstTab();
    }

    protected override PageRights GetPageRight()
    {
        PageRights p = base.GetPageRight();
        p.EditRight = true;
        p.HasEditOperation = true;

        bool jobRight = RightHelper.CheckFuncRightCached(JobStructure.FUNCTIONID, OperationCode.EDIT);
        bool payRight = RightHelper.CheckFuncRightCached(JobStructure.PayFuncID, OperationCode.EDIT);
        bool responsibilityRight = RightHelper.CheckFuncRightCached(JobStructure.ResponsibilityFuncID, OperationCode.EDIT);
        if (!jobRight && !payRight && !responsibilityRight)
        {
            p.EditRight = false;
            p.HasEditOperation = false;
        }        
        return p;
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (!IsPostBack)
        {
            bool userRight = false;
            bool qualityRight = false;
            bool knowledgeRight = false;
            bool skillsRight = false;
            bool payRight = false;
            bool responsibilityRight = false;

            if (this.KeyValue != string.Empty)
            {
                userRight = RightHelper.CheckFuncRight(JobStructure.UserFunctionID, OperationCode.READ);
                qualityRight = RightHelper.CheckFuncRightCached(JobStructure.QualityFuncID, OperationCode.READ);
                knowledgeRight = RightHelper.CheckFuncRightCached(JobStructure.KnowledgeFuncID, OperationCode.READ);
                skillsRight = RightHelper.CheckFuncRightCached(JobStructure.SkillsFuncID, OperationCode.READ);
                payRight = RightHelper.CheckFuncRightCached(JobStructure.PayFuncID, OperationCode.READ);
                responsibilityRight = RightHelper.CheckFuncRightCached(JobStructure.ResponsibilityFuncID, OperationCode.READ);
            }

            if (!userRight) { LnkUser.Visible = false; }
            if (!qualityRight) { LnkQuality.Visible = false; }
            if (!knowledgeRight) { LnkKnowledge.Visible = false; }
            if (!skillsRight) { LnkSkill.Visible = false; }

            if (!payRight)
            {
                TabJobPay.Visible = false;
                LnkJobPay.Visible = false;
                this.UcJobStructurePay1.Visible = false;
                this.Controls.Remove(this.UcJobStructurePay1);
            }

            if (!responsibilityRight)
            {
                TabResponsibility.Visible = false;
                LnkResponsibility.Visible = false;
                this.UcJDSummary1.Visible = false;
                this.Controls.Remove(this.UcJDSummary1);
            }
        }

        LnkUser.Attributes.Add("onclick", string.Format("setSelectedTab(this);switchTab(this,'{0}','{1}');", LnkUser.ColumnName, HidSelectedTab.ClientID));
        LnkQuality.Attributes.Add("onclick", string.Format("setSelectedTab(this);switchTab(this,'{0}','{1}');", LnkQuality.ColumnName, HidSelectedTab.ClientID));
        LnkKnowledge.Attributes.Add("onclick", string.Format("setSelectedTab(this);switchTab(this,'{0}','{1}');", LnkKnowledge.ColumnName, HidSelectedTab.ClientID));
        LnkSkill.Attributes.Add("onclick", string.Format("setSelectedTab(this);switchTab(this,'{0}','{1}');", LnkSkill.ColumnName, HidSelectedTab.ClientID));
        LnkJobPay.Attributes.Add("onclick", string.Format("setSelectedTab(this);switchTab(this,'{0}','{1}');", LnkJobPay.ColumnName, HidSelectedTab.ClientID));
        LnkResponsibility.Attributes.Add("onclick", string.Format("setSelectedTab(this);switchTab(this,'{0}','{1}');", LnkResponsibility.ColumnName, HidSelectedTab.ClientID));
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        LnkUser.NavigateUrl = "";
        LnkQuality.NavigateUrl = "";
        LnkKnowledge.NavigateUrl = "";
        LnkSkill.NavigateUrl = "";
        LnkResponsibility.NavigateUrl = "";        
        IfraSubWindow.Visible = true;

        if (CurrentPageMode == PageMode.View)
        {
            string jobCode = Fn.ToString(RowData["job_code"]);
            string urlUser = string.Format("JobStructureUser.aspx?JobCode={0}", jobCode);
            string urlQuality = string.Format("JobStructureWorkSkill.aspx?Category={0}&JobCode={1}", "A", jobCode);
            string urlKnowledge = string.Format("JobStructureWorkSkill.aspx?Category={0}&JobCode={1}", "B", jobCode);
            string urlSkill = string.Format("JobStructureWorkSkill.aspx?Category={0}&JobCode={1}", "C", jobCode);
            string urlResponsibility = string.Format("JDList.aspx?JobCode={0}", jobCode);

            LnkUser.NavigateUrl = urlUser;
            LnkQuality.NavigateUrl = urlQuality;
            LnkKnowledge.NavigateUrl = urlKnowledge;
            LnkSkill.NavigateUrl = urlSkill;
            LnkResponsibility.NavigateUrl = urlResponsibility;            
        }
        else
        {
            LnkQuality.Visible = false;
            LnkKnowledge.Visible = false;
            LnkSkill.Visible = false;
            LnkUser.Visible = false;            
            IfraSubWindow.Visible = false;
            IfraSubWindow.Attributes.Add("src", "");           
        }

        UcHyperLink LnkCurrent = GetCurrentTab();
        if (LnkCurrent == null) { IfraSubWindow.Visible = false; return; }        
        AttachClientEvent("windowonload", "window", "onload", string.Format("document.getElementById('{0}').click();", LnkCurrent.ClientID));        
        RegditLnkScript();
    }

    protected override bool OnSave()
    {
        bool b = base.OnSave();
        if (b) { KeyValue = RowData.KeyValue; }
        return b;
    }
}
