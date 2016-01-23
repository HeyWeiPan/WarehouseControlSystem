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
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.Security;

public partial class Security_FunctionDefinition : PageBase 
{    
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (PageRight.ReadRight) { BtnView.Enabled = true; }
        if (PageRight.DeleteRight) { BtnDelete.Enabled = true; }
        if (PageRight.AddRight) { BtnAdd.Enabled = true; }

        if (PageRight.EditRight)
        {
            BtnCut.Enabled = true;
            BtnCopy.Enabled = true;
            BtnPaste.Enabled = true;
            BtnEdit.Enabled = true;
        }                      
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
    
        RenderMenuScript();
        RenderClientScript();
    }

    public override void SetPageInfo(ref PageParameter pageSetting)
    {
        pageSetting.FunctionID = ScrFunction.FunctionID;
    }

    private void RenderMenuScript()
    {
        RM rm = new RM(ResourceFile.UI);
        ClientPopupMenu menu = new ClientPopupMenu("mMain", "createMenu");

        menu.AddMenuItem("mView", rm["Menu_View"], "viewMenu", ResourceHelper.GetImageUrl(this.Page, "view.small.png"));
        menu.AddMenuItem("mAdd", rm["Menu_Add"], "addMenu", ResourceHelper.GetImageUrl(this.Page, "add.png"));
        menu.AddMenuItem("mEdit", rm["Menu_Edit"], "editMenu", ResourceHelper.GetImageUrl(this.Page, "edit.png"));
        menu.AddMenuSeparator("mSep1");
        menu.AddMenuItem("mCopy", rm["Menu_Copy"], "copyMenu", ResourceHelper.GetImageUrl(this.Page, "copy.small.png"));
        menu.AddMenuItem("mCut", rm["Menu_Cut"], "cutMenu", ResourceHelper.GetImageUrl(this.Page, "cut.small.png"));
        menu.AddMenuItem("mPaste", rm["Menu_Paste"], "pasteMenu", ResourceHelper.GetImageUrl(this.Page, "paste.small.png"));
        menu.AddMenuItem("mDelete", rm["Menu_Delete"], "deleteMenu", ResourceHelper.GetImageUrl(this.Page, "delete.small.png"));
        menu.AddMenuSeparator("mSep2");
        menu.AddMenuItem("mRefresh", rm["Menu_Refresh"], "refreshSelectedNode", ResourceHelper.GetImageUrl(this.Page, "refresh.png"));
        menu.RenderScript(Page);        
    }
    
    protected virtual void RenderClientScript()
    {
        if (!this.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "JsFDefinition"))
        {
            RM rm = new RM(ResourceFile.Msg);

            DialogWindow detailWindow = new DialogWindow();
            detailWindow.Width = 700;
            detailWindow.Height = 520;
            detailWindow.DisplayScrollBar = true;
            detailWindow.Url = UrlHelper.UrlBase + "/Security/FunctionDefinitionDetail.aspx";
            detailWindow.AddUrlClientObjectParameter("Mode", "mode");
            detailWindow.AddUrlClientObjectParameter("KeyValue", String.Format("f_getSelectedNodeID({0})", UcTreeMenuList.ClientID));
            detailWindow.AddUrlClientObjectParameter("Version", String.Format("f_getSelectedNodeType({0})", UcTreeMenuList.ClientID));
            StringBuilder s = new StringBuilder(500);
            s.AppendFormat("var userId = {0};", CurrentUser.UserID); 

            //check if there is a selected node.
            s.Append("function CheckSelected()");
            s.Append("{");
            s.AppendFormat(@"if({0}.selectedNodeIndex == ''){{return false;}} else {{return true;}}", UcTreeMenuList.ClientID);
            s.Append("}\n");

            //view details.
            s.Append("function ShowDetail(mode)");
            s.Append("{");
            s.Append("if(mode != 'ADD' && !CheckSelected()) {alert('").Append(rm ["PleaseSelectNode"]).Append("');return;}");
            s.Append("var returnValue = '';");
            s.Append(detailWindow.GetShowModalDialogScript("returnValue"));
            s.Append("if(returnValue=='REFRESH'){refreshParentNode(mode);}");
            s.Append("}\n");
            detailWindow = null;

            //delete selected row
            s.Append("function CheckDelete()");
            s.Append("{");
            s.Append("if(!CheckSelected()) {alert('").Append(rm ["PleaseSelectRow"]).Append("');return false;}");
            s.Append("if(!window.confirm('").Append(rm ["ConfirmDeleteNode"]).Append("')){return false;}");
            s.Append("return true;");
            s.Append("}\n");

            //copy selected row
            s.Append("function CheckCut()");
            s.Append("{");
            s.Append("if(!CheckSelected()) {alert('").Append(rm ["PleaseSelectRow"]).Append("');return false;}");
            s.Append("if(!window.confirm('").Append(rm ["ConfirmCutNode"]).Append("')){return false;}");
            s.Append("return true;");
            s.Append("}\n");

            //cut selected row
            s.Append("function CheckCopy()");
            s.Append("{");
            s.Append("if(!CheckSelected()) {alert('").Append(rm ["PleaseSelectRow"]).Append("');return false;}");
            s.Append("if(!window.confirm('").Append(rm ["ConfirmCopyNode"]).Append("')){return false;}");
            s.Append("return true;");
            s.Append("}\n");

            s.Append("var pageAddRight='" + PageRight.AddRight + "';");
            s.Append("var pageEditRight ='" + PageRight.EditRight + "';");
            s.Append("var pageDeleteRight ='" + PageRight.DeleteRight + "';");
            s.Append("var pageReadRight ='" + PageRight.ReadRight + "';");

            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "JsFDefinition", s.ToString(), true);
        }
        
        if (!this.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "JsStartTree"))
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}.treeNodeSrc='FunctionDefinitionGetChildNodes.aspx?parentNodeID={1}';", this.UcTreeMenuList.ClientID, 0);
            sb.AppendFormat("{0}.databind();", UcTreeMenuList.ClientID);
            sb.AppendFormat(";var TVOrg =document.getElementById('{0}');", this.UcTreeMenuList.ClientID);
            this.ClientScript.RegisterStartupScript(this.GetType(), "JsStartTree", sb.ToString(), true);
        }
    }
}
