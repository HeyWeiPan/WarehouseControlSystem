using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using EntpClass.Common;
using System.Text;
using EntpClass.BizLogic.Setup;

public partial class Setup_FileFolder : PageBase
{
    public override void InitializeEvents()
    {
        PageBase page = (PageBase)this.Page;
        page.Load += new EventHandler(Page_Load);
        page.PreRender += new EventHandler(Page_PreRender);
    }

    private void RegeditMenuScript()
    {
        RM rm = new RM(ResourceFile.UI);

        ClientPopupMenu menu = new ClientPopupMenu("mMain", "createMenu");

        menu.AddMenuItem("mView", rm["Menu_View"], "viewMenu", ResourceHelper.GetImageUrl(this.Page, "view.small.png"));
        menu.AddMenuItem("mAdd", rm["Menu_Add"], "addMenu", ResourceHelper.GetImageUrl(this.Page, "add.png"));
        menu.AddMenuItem("mEdit", rm["Menu_Edit"], "editMenu", ResourceHelper.GetImageUrl(this.Page, "edit.png"));
        menu.AddMenuSeparator("mSep1");     
        menu.AddMenuItem("mDelete", rm["Menu_Delete"], "deleteMenu", ResourceHelper.GetImageUrl(this.Page, "delete.small.png"));
        menu.AddMenuSeparator("mSep2");
        menu.AddMenuItem("mRefresh", rm["Menu_Refresh"], "refreshSelectedNode", ResourceHelper.GetImageUrl(this.Page, "refresh.png"));

        menu.RenderScript(Page);
    }

    private void RegeditMenuOperationScript()
    {
        if (!this.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegeditMenuOperationScript"))
        {
            RM rm = new RM(ResourceFile.Msg);
            RM rmd = new RM(ResourceFile.Database);
            StringBuilder s = new StringBuilder(700);

            s.AppendFormat("var TVOrg= {0};", TVOrg.ClientID);//TVOrg            

            s.Append("var pageAddRight='" + PageRight.AddRight + "';");
            s.Append("var pageEditRight ='" + PageRight.EditRight + "';");
            s.Append("var pageDeleteRight ='" + PageRight.DeleteRight + "';");
            s.Append("var pageReadRight ='" + PageRight.ReadRight + "';");

            s.AppendFormat("var pleaseSelectNode = '{0}';", rm["PleaseSelectNode"]);
            s.AppendFormat("var pleaseCopyOrCut = '{0}';", rm["PleaseCopyOrCut"]);

            s.AppendFormat("var confirmDeleteNode = '{0}';", rm["ConfirmDeleteNode"]);
            //s.AppendFormat("var confirmCutNode = '{0}';", rm["ConfirmCutNode"]);
            //s.AppendFormat("var confirmCopyNode = '{0}';", rm["ConfirmCopyNode"]);

            s.AppendFormat("var to = '{0}';", rmd["to"]);
            s.AppendFormat("var cut = '{0}';", rmd["cut"]);
            s.AppendFormat("var copy = '{0}';", rmd["copy"]);

            s.AppendFormat("var notPasteSelf = '{0}';", rm["NotPasteSelf"]);
            s.AppendFormat("var notPasteParent = '{0}';", rm["NotPasteParent"]);
            s.AppendFormat("var notCutParent = '{0}';", rm["NotCutParent"]);
            s.AppendFormat("var notCopyOnlyLeaf = '{0}';", rm["NotCopyOnlyLeaf"]);

            s.AppendFormat("{0}.treeNodeSrc='FileFolderGetChildNodes.aspx?parentNodeID={1}';", TVOrg.ClientID, FileFolder.VirtualRootID);
            s.AppendFormat("{0}.databind();", TVOrg.ClientID);
            s.AppendFormat("{0}.expandLevel=1;", TVOrg.ClientID);

            this.ClientScript.RegisterStartupScript(this.GetType(), "RegeditMenuOperationScript", s.ToString(), true);
        }
    }

    private void RegditDetailScript()
    {
        if (!ClientScript.IsClientScriptBlockRegistered(this.GetType(), "JsScriptGeographyTree"))
        {
            RM rm = new RM(ResourceFile.Msg);
            StringBuilder s = new StringBuilder(700);
            DialogWindow dw = new DialogWindow();
            dw.Width = 500;
            dw.Height = 325;
            dw.DisplayScrollBar = true;
            dw.Url = UrlHelper.UrlBase + "/Setup/FileFolderDetail.aspx";
            dw.AddUrlClientObjectParameter("Mode", "mode");
            dw.AddUrlClientObjectParameter("KeyValue", "f_getSelectedNodeID(TVOrg)");
            dw.AddUrlClientObjectParameter("ParentName", "f_getSelectedNodeText(TVOrg)");
            dw.AddUrlClientObjectParameter("ParentID", "f_getSelectedNodeID(TVOrg)");//Folder_ID                                 

            s.Append("function ShowDetail(mode,type)");
            s.Append("{");
            s.AppendFormat("if(mode != 'ADD' && !CheckSelected()) {{alert('{0}');return;}}", rm["PleaseSelectNode"]);
            s.Append("var returnValue = '';" + dw.GetShowModalDialogScript("returnValue"));
            s.Append("if(returnValue=='REFRESH'){refreshParentNode(mode,type);}");
            s.Append("}\n");

            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "JsScriptGeographyTree", s.ToString(), true);
        }
    }

    private void SetPageRight()
    {
        if (PageRight.ReadRight)
            BtnView.Enabled = true;

        if (PageRight.DeleteRight)
            BtnDelete.Enabled = true;

        if (PageRight.AddRight)
            BtnAdd.Enabled = true;

        if (PageRight.EditRight)
        {          
            BtnEdit.Enabled = true;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BtnView.OnClientClick = "viewMenu();return false;";
            BtnAdd.OnClientClick = "addMenu();return false;";
            BtnEdit.OnClientClick = "editMenu();return false;";          
            BtnDelete.OnClientClick = "deleteMenu();return false;";

            TVOrg.OnContextMenuClientScript = "showContextMenu();";

            SetPageRight();
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        RegeditMenuScript();

        RegeditMenuOperationScript();

        RegditDetailScript();
    }

    public override void SetPageInfo(ref PageParameter p)
    {
        p.FunctionID = FileFolder.FunctionID;
    }
}
