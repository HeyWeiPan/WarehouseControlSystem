using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using EntpClass.Common;
using System.Text;

public partial class CommonUI_MasterPage_MasterFiglDjList : System.Web.UI.MasterPage
{

    protected override void OnLoad(EventArgs e)
    {
        PageBase p = this.Page as PageBase;

        p.SetPageIndex(HidPagerArgument.Value);
        base.OnLoad(e);
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        SetPageRight();

        if (!Page.IsPostBack)
        {
            PageBase page = this.Page as PageBase;
            LblTitle.Text = page.Title;
            if (page.PageSetting.HelpFileUrlCN != string.Empty)
            {
                ImgHelpIcon.Visible = true;
                LnkHelpTextCN.Visible = true;
                LnkHelpTextCN.NavigateUrl = page.PageSetting.HelpFileUrlCN;
            }
            if (page.PageSetting.HelpFileUrlEN != string.Empty)
            {
                ImgHelpIcon.Visible = true;
                LnkHelpTextEn.Visible = true;
                LnkHelpTextEn.NavigateUrl = page.PageSetting.HelpFileUrlEN;
            }
        }
    }

    private void SetPageRight()
    {
        PageBase page = (PageBase)this.Page;

        if (!page.PageRight.HasAddOperation)
        {
            this.BtnAdd.Visible = false;
        }
        else if (!page.PageRight.AddRight)
        {
            this.BtnAdd.Enabled = false;
        }

        if (!page.PageRight.HasEditOperation)
        {
            this.BtnEdit.Visible = false;
        }
        else if (!page.PageRight.EditRight)
        {
            this.BtnEdit.Enabled = false;
        }

        if (!page.PageRight.HasExportOperation)
        {
            this.BtnExport.Visible = false;
        }
        else if (!page.PageRight.ExportRight)
        {
            this.BtnExport.Enabled = false;
        }

        if (!page.PageRight.HasDeleteOperation)
        {
            this.BtnDelete.Visible = false;
        }
        else if (!page.PageRight.DeleteRight)
        {
            this.BtnDelete.Enabled = false;
        }

        
        if (!page.PageRight.HasPrintOperation)
        {
            this.BtnPrint.Visible = false;
        }
        else if (!page.PageRight.PrintRight)
        {
            this.BtnPrint.Enabled = false;
        }


        if (!page.PageRight.HasAuditOperation)
        {
            bool b1 = page.PageRight.HasOperation("AUDIT1");
            bool b2 = page.PageRight.HasOperation("AUDIT2");
            bool b3 = page.PageRight.HasOperation("AUDIT3");

            if (!b1 && !b2 && !b3)
            {
                this.BtnAudit.Visible = false;
            }
        }
        else if (!page.PageRight.AuditRight)
        {
            bool b1 = page.PageRight.HasRight("AUDIT1");
            bool b2 = page.PageRight.HasRight("AUDIT2");
            bool b3 = page.PageRight.HasRight("AUDIT3");

            if (!b1 && !b2 && !b3)
            {
                this.BtnAudit.Enabled = false;
            }
        }

        if (!page.PageRight.HasUndoAuditOperation)
        {
            this.BtnUndoAudit.Visible = false;
        }
        else if (!page.PageRight.UndoAuditRight)
        {
            this.BtnUndoAudit.Enabled = false;
        }

        if (!page.PageRight.HasPassOperation)
        {
            this.BtnPass.Visible = false;
        }
        else if (!page.PageRight.PassRight)
        {
            this.BtnPass.Enabled = false;
        }

        if (!page.PageRight.HasUndoPassOperation)
        {
            this.BtnUndoPass.Visible = false;
        }
        else if (!page.PageRight.UndoPassRight)
        {
            this.BtnUndoPass.Enabled = false;
        }
    }

    public string GetNavigate(object o)
    {
        return string.Format("javascript:SetPager('{0}');", Fn.ToString(o));
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        PageBase page = (PageBase)this.Page;
        page.DoAction("DELETE", sender, e);
    }

    protected void BtnAudit_Click(object sender, EventArgs e)
    {
        PageBase page = (PageBase)this.Page;
        page.DoAction("AUDIT", sender, e);
    }

    protected void BtnUndoAudit_Click(object sender, EventArgs e)
    {
        PageBase page = (PageBase)this.Page;
        page.DoAction("UNDOAUDIT", sender, e);
    }

    protected void BtnPass_Click(object sender, EventArgs e)
    {
        PageBase page = (PageBase)this.Page;
        page.DoAction("PASS", sender, e);
    }

    protected void BtnUndoPass_Click(object sender, EventArgs e)
    {
        PageBase page = (PageBase)this.Page;
        page.DoAction("UNDOPASS", sender, e);
    }

    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        PageBase page = (PageBase)this.Page;
        page.DoAction("PRINT", sender, e);
    }

    protected void BtnExport_Click(object sender, EventArgs e)
    {
        PageBase page = (PageBase)this.Page;
        page.DoAction("EXPORT", sender, e);
    }

    protected void btnGO_Click(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        if (!this.Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "JsResizeScrollDiv"))
        {
            StringBuilder s = new StringBuilder();
            s.Append("function resizeScrollDiv()");
            //start
            s.Append("{");
            //设置默认值

            //将divScrollGrid的高度增大,使垂直方向不出现流动条
            s.AppendFormat("if (document.getElementById('divScrollGrid').clientHeight <= document.getElementById('{0}').clientHeight)", this.GridList.ClientID);
            s.Append("{");
            s.Append("document.getElementById('divScrollGrid').style.height = document.getElementById('divScrollGrid').offsetHeight + 21 + 'px';");
            s.Append("}");

            //end
            s.Append("}");

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "JsResizeScrollDiv", s.ToString(), true);
        }

        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "AutoSetDiv", "resizeScrollDiv()", true);
    }

    protected void ddlPageRows_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
