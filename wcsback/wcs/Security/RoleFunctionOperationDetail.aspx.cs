using System;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Security;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.BizLogic.Security;

public partial class Security_RoleFunctionOperationDetail : SetUpDetailPageBase<ScrFunction>
{
    public override void InitializeEvents()
    {
        PageBase page = (PageBase)this.Page;
        page.PreRender += new EventHandler(page_PreRender);
    }

    void page_PreRender(object sender, EventArgs e)
    {
        RegeditNodeScript();
    }

    private string RoleId
    {
        get
        {
            return Fn.ToString(Request["RoleID"]);
        }       
    }

    private string FunctionId
    {
        get
        {
            return Fn.ToString(Request["FunctionID"]);
        }    
    }

    private void RegeditNodeScript()
    {
        if (!this.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegeditNodeScript"))
        {
            StringBuilder s = new StringBuilder("");
            
            s.AppendFormat("var hidMode='{0}';", CurrentPageMode);
            s.AppendFormat("var roleId='{0}';", RoleId);
            s.AppendFormat("var link='{0}';", this.LinkFunction.ClientID);

            s.AppendFormat("function getTreeView(){{return {0};}}", Trv.ClientID);         

            //tree node click
            s.Append("function onNodeclick()");
            s.Append("{");
            s.Append("var index = getTreeView().clickedNodeIndex;");
            s.Append("if (index != null && index != '')");
            s.Append("{");
            s.Append("var oCurrNode =getTreeView().getTreeNode(index);var a = document.all(link);");
            s.Append("a.setAttribute('href','RoleFunctionOperationCheckBox.aspx?FunctionID='+oCurrNode.getAttribute('NodeData')+'&mode='+hidMode+'&RoleID='+roleId);");
            s.Append("a.click();");
            s.Append("}");
            s.Append("}");

            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegeditNodeScript", s.ToString(), true);
        }
    }

    protected override void OnPageModeChanged(PageModeChangedEventArgs arg)
    {
        base.OnPageModeChanged(arg);

        switch (CurrentPageMode)
        { 
            case PageMode.Add:
                StringBuilder s = new StringBuilder("");
                s.AppendFormat("{0}.treeNodeSrc='FunctionDefinitionGetChildNodes.aspx?parentNodeID={1}';", Trv.ClientID, 0);
                s.AppendFormat("{0}.databind();", Trv.ClientID);
                this.ClientScript.RegisterStartupScript(this.GetType(), "settreesrc", s.ToString(), true);
                break;
            case PageMode.Edit:
                this.Trv.Visible = false;
                this.LinkFunction.NavigateUrl = string.Format("RoleFunctionOperationCheckBox.aspx?FunctionID={0}&mode={1}&RoleID={2}", FunctionId, Fn.ToString(CurrentPageMode), RoleId);

                string strScript = "document.all('" + LinkFunction.ClientID + "').click();";
                this.ClientScript.RegisterStartupScript(this.GetType(), "LinkClick", strScript, true);
                break;
        }       
    }   
}
