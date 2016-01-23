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
using System.Text;

using EntpClass.Common;
using EntpClass.WebUI;
using EntpClass.WebControlLib.Derived;
using EntpClass.BizLogic.HR.Setup;

public partial class HR_Setup_UcJobStructureScope : ScopeControlBase
{    
    private void RegisterSetSkillListScript()
    {        
        StringBuilder s = new StringBuilder(500);

        s.Append("function onSetWorkSkillList(result)");
        s.Append("{");
        s.AppendFormat("f_bindXML(document.getElementById('{0}'),result,'WORKSKILL_NAME','WORKSKILL_ID',null,true);", DdlWorkSkill.ClientID);
        s.Append("}");

        Page.ClientScript.RegisterClientScriptBlock(GetType(), "onSetWorkSkillList", s.ToString(), true);
    }

    protected override DbRowParameter GetParameter()
    {
        JobStructure job = new JobStructure();
        return job.Parameter;
    }

    protected override string JoinTable(JoinTableParameters p)
    {
        return "";
    }
        
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!IsPostBack)
        {            
            object obj = Session[ListPageId + DdlWsCode.ID];
            string workSkillCategoryCode = obj == null ? DdlWsCode.Text : Fn.ToString(obj);
            DdlWsCode.Text = workSkillCategoryCode;
            
            if (!string.IsNullOrEmpty(workSkillCategoryCode))
            {
                DdlWorkSkill.SelectedValue = null;
                DdlWorkSkill.SqlText = WorkSkill.GetWorkSkillSql(workSkillCategoryCode);
                DdlWorkSkill.DataBind();
            }
        }
        else
        {
            string workSkillCategoryCode = Request.Params[DdlWsCode.UniqueID];
            string workSkillId = Request.Params[DdlWorkSkill.UniqueID];
            DdlWorkSkill.SqlText = WorkSkill.GetWorkSkillSql(workSkillCategoryCode);
            DdlWorkSkill.DataBind();
            DdlWorkSkill.Text = workSkillId;
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        RegisterSetSkillListScript();
    }    
}
