using System;
using System.Text;
using System.Data;
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
using EntpClass.WebControlLib.Derived;
using EntpClass.BizLogic.Security;

public partial class Security_RoleFunctionOperation : PageBase
{
    private void RenderMenuScript()
    {
        ClientPopupMenu menu = new ClientPopupMenu("mMain", "createMenu");

        RM rm = new RM(ResourceFile.UI);

        menu.AddMenuItem("mAdd", rm["Menu_Add"], "addMenu", ResourceHelper.GetImageUrl(this.Page, "add.png"));
        menu.AddMenuItem("mEdit", rm["Menu_Edit"], "editMenu", ResourceHelper.GetImageUrl(this.Page, "edit.png"));
        menu.AddMenuSeparator("mSep1");
        menu.AddMenuItem("mDelete", rm["Menu_Delete"], "deleteMenu", ResourceHelper.GetImageUrl(this.Page, "delete.small.png"));
        menu.AddMenuItem("mRefresh", rm["Menu_Refresh"], "refreshSelectedNode", ResourceHelper.GetImageUrl(this.Page, "refresh.png"));
        menu.RenderScript(Page);
    }

    private void RenderClientScript()
    {
        if (!this.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "JsRoleFunctionOperationScript"))
        {
            StringBuilder s = new StringBuilder("");
            RM rm = new RM(ResourceFile.Msg);

            hRoleID.Value = Fn.ToString(Request.QueryString["RoleID"]);

            s.AppendFormat("{0}.treeNodeSrc='RoleFunctionOperationGetTreeNodes.aspx?RoleID={1}';", Trv1.ClientID, hRoleID.Value);
            s.AppendFormat("{0}.databind();", Trv1.ClientID);
            this.ClientScript.RegisterStartupScript(this.GetType(), "settreesrc", s.ToString(), true);

            DialogWindow detailWindow = new DialogWindow();
            detailWindow.Width = 600;
            detailWindow.Height = 650;
            detailWindow.DisplayScrollBar = false;
            detailWindow.Url = UrlHelper.UrlBase + "/Security/RoleFunctionOperationDetail.aspx";
            detailWindow.AddUrlClientObjectParameter("Mode", "mode");
            detailWindow.AddUrlParameter("RoleID", Fn.ToString(Request.QueryString["RoleID"]));
            detailWindow.AddUrlClientObjectParameter("FunctionID", String.Format("f_getSelectedNodeID({0})", this.Trv1.ClientID));

            StringBuilder sWin = new StringBuilder(500);
            sWin.AppendFormat("var userId = {0};", CurrentUser.UserID);
            sWin.Append("function CheckDelete()");
            sWin.Append("{");
            sWin.Append("if(!CheckSelected()) {alert('").Append(rm["PleaseSelectRow"]).Append("');return false;}");
            sWin.Append("if(!window.confirm('").Append(rm["ConfirmDeleteNode"]).Append("')){return false;}");
            sWin.Append("return true;");
            sWin.Append("}\n");

            sWin.Append("function CheckSelected()");
            sWin.Append("{");
            sWin.AppendFormat(@"if({0}.selectedNodeIndex == ''){{return false;}} else {{return true;}}", this.Trv1.ClientID);
            sWin.Append("}\n");

            sWin.Append("function ShowDetail(mode)");
            sWin.Append("{");
            sWin.Append("if(mode != 'ADD' && !CheckSelected()) {alert('").Append(rm["PleaseSelectNode"]).Append("');return;}");
            sWin.Append("var returnValue = '';");
            sWin.Append(detailWindow.GetShowModalDialogScript("returnValue"));
            sWin.Append("if(returnValue=='refresh'){refreshSelectedNode();}");
            sWin.Append("}\n");

            sWin.AppendFormat("var pageAddRight='{0}';", PageRight.AddRight);
            sWin.AppendFormat("var pageEditRight ='{0}';", PageRight.EditRight);
            sWin.AppendFormat("var pageDeleteRight ='{0}';", PageRight.DeleteRight);

            detailWindow = null;

            this.ClientScript.RegisterStartupScript(this.GetType(), "JsRoleFunctionOperationScript", sWin.ToString(), true);
        }
    }

    public override void SetPageInfo(ref PageParameter p)
    {
        p.FunctionID = RoleFunctionOperation.FunctionID;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        BtnTreeAdd.Visible = PageRight.AddRight;
        BtnTreeDelete.Visible = PageRight.DeleteRight;
        BtnTreeEdit.Visible = PageRight.EditRight;

        BtnTreeAdd.OnClientClick = "addMenu();return false;";
        BtnTreeDelete.OnClientClick = "deleteMenu();return false;";
        BtnTreeEdit.OnClientClick = "editMenu();return false;";
        BtnTreeRefresh.OnClientClick = "refreshSelectedNode();return false;";
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
    
        RenderMenuScript();
        RenderClientScript();        
    }           
}