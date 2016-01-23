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

using EntpClass.Common;
using EntpClass.WebUI;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.HR.OrgChart;

public partial class HR_OrgChart_TeamTree : PageBase
{
    public override void SetPageInfo(ref PageParameter p)
    {
        p.FunctionID = Team.FUNCTIONID;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    }

    private void RegeditMenuScript()
    {
        RM rm = new RM(ResourceFile.UI);

        ClientPopupMenu menu = new ClientPopupMenu("mMain", "createMenu");

        menu.AddMenuItem("mView", rm["Menu_View"], "viewMenu", ResourceHelper.GetImageUrl(this.Page, "view.small.png"));
        menu.AddMenuItem("mAdd", rm["Menu_Add"], "addMenu", ResourceHelper.GetImageUrl(this.Page, "add.png"));
        menu.AddMenuItem("mEdit", rm["Menu_Edit"], "editMenu", ResourceHelper.GetImageUrl(this.Page, "edit.png"));
        menu.AddMenuSeparator("mSep1");
        //menu.AddMenuItem("mCopy", rm["Menu_Copy"], "copyMenu", ResourceHelper.GetImageUrl(this.Page, "copy.small.png"));
        menu.AddMenuItem("mCut", rm["Menu_Cut"], "cutMenu", ResourceHelper.GetImageUrl(this.Page, "cut.small.png"));
        menu.AddMenuItem("mPaste", rm["Menu_Paste"], "pasteMenu", ResourceHelper.GetImageUrl(this.Page, "paste.small.png"));
        menu.AddMenuItem("mDelete", rm["Menu_Delete"], "deleteMenu", ResourceHelper.GetImageUrl(this.Page, "delete.small.png"));
        menu.AddMenuSeparator("mSep2");
        menu.AddMenuItem("mRefresh", rm["Menu_Refresh"], "refreshSelectedNode", ResourceHelper.GetImageUrl(this.Page, "refresh.png"));

        menu.RenderScript(Page);
    }

    private void RegditDetailScript()
    {
        if (!ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegditDetailScript"))
        {
            RM rm = new RM(ResourceFile.Msg);

            Team team = new Team();
            DialogWindow dw = team.DetailDialogWindow;

            //主键由 tem_id 改变成 team_guid
            //dw.AddUrlClientObjectParameter("KeyValue", "f_getSelectedNodeID(TVOrg)");
            dw.AddUrlClientObjectParameter("KeyValue", "getTeamGuid(TVOrg)");
            dw.AddUrlClientObjectParameter("Mode", "mode");            
            dw.AddUrlClientObjectParameter("TeamId", "f_getSelectedNodeID(TVOrg)");//team_id
            dw.AddUrlClientObjectParameter("TeamName", "f_getSelectedNodeText(TVOrg)");
            dw.AddUrlClientObjectParameter("TeamTypeId", "getTeamTypeId(TVOrg)");            

            StringBuilder s = new StringBuilder();

            s.Append("function ShowDetail(mode,type)");
            s.Append("{");
            s.AppendFormat("if(mode != 'ADD' && !CheckSelected()) {{alert('{0}');return;}}", rm["PleaseSelectNode"]);
            s.Append("var returnValue = '';" + dw.GetShowModalDialogScript("returnValue"));
            s.Append("if(returnValue=='REFRESH'){refreshParentNode(mode,type);}");
            s.Append("}\n");

            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegditDetailScript", s.ToString(), true);
        }
    }

    private void RegeditMenuOperationScript()
    {
        if (!ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegeditMenuOperationScript"))
        {
            RM rm = new RM(ResourceFile.Msg);
            RM rmd = new RM(ResourceFile.Database);
            StringBuilder s = new StringBuilder();

            s.AppendFormat("var TVOrg= {0};", TVOrg.ClientID);//TVOrg   
            s.AppendFormat("var A1 = '{0}';", A1.ClientID);
            s.AppendFormat("var pageAddRight = '{0}';", PageRight.AddRight);
            s.AppendFormat("var pageEditRight = '{0}';", PageRight.EditRight);
            s.AppendFormat("var pageDeleteRight = '{0}';", PageRight.DeleteRight);
            s.AppendFormat("var pageReadRight = '{0}';", PageRight.ReadRight);

            s.AppendFormat("var pleaseSelectNode = '{0}';", rm["PleaseSelectNode"]);
            s.AppendFormat("var pleaseCopyOrCut = '{0}';", rm["PleaseCopyOrCut"]);

            s.AppendFormat("var confirmDeleteNode = '{0}';", rm["ConfirmDeleteNode"]);
            s.AppendFormat("var confirmCutNode = '{0}';", rm["ConfirmCutNode"]);
            s.AppendFormat("var confirmCopyNode = '{0}';", rm["ConfirmCopyNode"]);

            s.AppendFormat("var to = '{0}';", rmd["to"]);
            s.AppendFormat("var cut = '{0}';", rmd["cut"]);
            s.AppendFormat("var copy = '{0}';", rmd["copy"]);

            s.AppendFormat("var notPasteSelf = '{0}';", rm["NotPasteSelf"]);
            s.AppendFormat("var notPasteParent = '{0}';", rm["NotPasteParent"]);
            s.AppendFormat("var notCutParent = '{0}';", rm["NotCutParent"]);
            s.AppendFormat("var notCopyOnlyLeaf = '{0}';", rm["NotCopyOnlyLeaf"]);

            //parentNodeID = -1;
            //在数据库中并不存在根节点为 -1 的数据,是指请求包括根节点(ID = 0)在内的所有的数据            
            s.AppendFormat("{0}.treeNodeSrc='TeamTreeGetChildNode.aspx?parentNodeID={1}';", TVOrg.ClientID, Team.VirtualRootID);
            s.AppendFormat("{0}.databind();", TVOrg.ClientID);
            s.AppendFormat("{0}.expandLevel=1;", TVOrg.ClientID);            

            this.ClientScript.RegisterStartupScript(this.GetType(), "RegeditMenuOperationScript", s.ToString(), true);
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        RegeditMenuScript();

        RegditDetailScript();

        RegeditMenuOperationScript();        
    }
}
