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

using EntpClass.Common;
using EntpClass.WebControlLib;

using EntpClass.WebUI;

public partial class MasterSetupHeadDetail : System.Web.UI.MasterPage
{
    PageBase page = null;

    public static string ImageUrl = UrlHelper.UrlCommonMasterPage + "/Images/1_0";

    private bool IsOperationDisabled
    {
        get
        {
            return Fn.ToBoolean(ViewState["IsOperationDisabled"]);
        }
        set
        {
            ViewState["IsOperationDisabled"] = value;
        }
    }


    private void SetPageRight()
    {
        if (IsOperationDisabled)
            return;

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

        if (!page.PageRight.HasPrintOperation)
        {
            this.BtnPrint.Visible = false;
        }
        else if (!page.PageRight.PrintRight)
        {
            this.BtnPrint.Enabled = false;
        }

        if (!page.PageRight.HasExportOperation)
        {
            this.BtnExport.Visible = false;
        }
        else if (!page.PageRight.ExportRight)
        {
            this.BtnExport.Enabled = false;
        }


        if (!page.PageRight.HasSubmitOperation)
        {
            this.BtnSubmit.Visible = false;
        }
        else if (!page.PageRight.SubmitRight)
        {
            this.BtnSubmit.Enabled = false;
        }

        if (!page.PageRight.HasUndoSubmitOperation)
        {
            this.BtnUndoSubmit.Visible = false;
        }
        else if (!page.PageRight.UndoSubmitRight)
        {
            this.BtnUndoSubmit.Enabled = false;
        }

        #region

        //if (!page.PageRight.HasSubmitOperation)
        //{
        //    this.BtnSubmit.Visible = false;
        //}
        //else if (!page.PageRight.SubmitRight)
        //{
        //    this.BtnSubmit.Enabled = false;
        //}
        #endregion

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        page = (PageBase)this.Page;

        page.PageModeChanged += new EventHandler<PageModeChangedEventArgs>(page_PageModeChanged);
        LblTitle.Text = page.Title;
    }

    void page_PageModeChanged(object sender, PageModeChangedEventArgs e)
    {
        if (IsOperationDisabled)
        {
            return;
        }
        this.BtnAdd.Enabled = false;
        this.BtnEdit.Enabled = false;
        this.BtnFirst.Enabled = false;
        this.BtnLast.Enabled = false;
        this.BtnPrevious.Enabled = false;
        this.BtnNext.Enabled = false;
        this.BtnSave.Enabled = false;
        this.BtnCancel.Enabled = true;
        this.BtnSubmit.Enabled = false;
        this.BtnUndoSubmit.Enabled = false;
        this.BtnPrint.Enabled = false;
        this.BtnPrint.Visible = true;
        this.BtnSubmit.Visible = true;
        this.BtnUndoSubmit.Visible = true;
        this.BtnSave.Visible = true;
        this.BtnCancel.Visible = true;
        this.BtnEdit.Visible = true;

        if (e.OldPageMode == PageMode.Unknown && e.NewPageMode == PageMode.Add)
        {
            this.BtnCancel.Visible = false;
        }
        else
        {
            this.BtnCancel.Visible = true;
        }

        switch (e.NewPageMode)
        {
            case PageMode.Edit:
                this.BtnCancel.Enabled = true;
                this.BtnSave.Enabled = true;
                this.BtnPrint.Visible = false;
                this.BtnSubmit.Visible = false;
                this.BtnUndoSubmit.Visible = false;
                this.BtnExport.Visible = false;
                this.BtnEdit.Visible = false;
                this.BtnAdd.Visible = false;
                break;
            case PageMode.Add:
                this.BtnSave.Enabled = true;
                this.BtnPrint.Visible = false;
                this.BtnSubmit.Visible = false;
                this.BtnUndoSubmit.Visible = false;
                this.BtnEdit.Visible = false;
                this.BtnAdd.Visible = false;
                this.BtnExport.Visible = false;
                break;
            case PageMode.View:
            case PageMode.Unknown:
                this.BtnEdit.Enabled = true;
                this.BtnAdd.Enabled = true;
                this.BtnFirst.Enabled = true;
                this.BtnPrevious.Enabled = true;
                this.BtnNext.Enabled = true;
                this.BtnLast.Enabled = true;
                this.BtnSubmit.Enabled = true;
                this.BtnUndoSubmit.Enabled = true;
                this.BtnPrint.Enabled = true;
                this.BtnSave.Visible = false;
                this.BtnCancel.Visible = false;
                break;
            default:
                break;
        }

        SetPageRight();
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        RM rm = new RM(ResourceFile.Msg);
        BtnSubmit.OnClientClick = BtnSubmit.OnClientClick +  string.Format("if(!window.confirm('{0}')){{return false;}}", rm["CONFIRMSUBMITFORM"]);
        BtnUndoSubmit.OnClientClick = BtnUndoSubmit.OnClientClick + string.Format("if(!window.confirm('{0}')){{return false;}}", rm["CONFIRMUNSUBMITFORM"]);
    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        if (!page.DoAction("ADD", sender, e))
        {
            return;
        }
        page.CurrentPageMode = PageMode.Add;
    }

    protected void BtnEdit_Click(object sender, EventArgs e)
    {
        if (!page.DoAction("EDIT", sender, e))
        {
            return;
        }
        page.CurrentPageMode = PageMode.Edit;
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (!page.DoAction("SAVE", sender, e))
        {
            return;
        }
        page.CurrentPageMode = PageMode.View;
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        if (!page.DoAction("CANCEL", sender, e))
        {
            return;
        }
        page.CurrentPageMode = PageMode.View;
    }

    protected void BtnFirst_Click(object sender, EventArgs e)
    {
        if (!page.DoAction("FIRST", sender, e))
        {
            return;
        }
    }

    protected void BtnPrevious_Click(object sender, EventArgs e)
    {
        if (!page.DoAction("PREV", sender, e))
        {
            return;
        }
    }

    protected void BtnNext_Click(object sender, EventArgs e)
    {
        if (!page.DoAction("NEXT", sender, e))
        {
            return;
        }
    }

    protected void BtnLast_Click(object sender, EventArgs e)
    {
        if (!page.DoAction("LAST", sender, e))
        {
            return;
        }
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (!page.DoAction("SUBMIT", sender, e))
        {
            return;
        }
        BtnSubmit.Enabled = false;
    }

    protected void BtnUndoSubmit_Click(object sender, EventArgs e)
    {
        if (!page.DoAction("UNDOSUBMIT", sender, e))
        {
            return;
        }
        BtnUndoSubmit.Enabled = false;
    }

    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        if (!page.DoAction("PRINT", sender, e))
        {
            return;
        }
    }

    protected void BtnExport_Click(object sender, EventArgs e)
    {
        PageBase page = (PageBase)this.Page;
        page.DoAction("EXPORT", sender, e);
    }

    public void DisableOperation()
    {
        this.BtnCancel.Visible = false;
        this.BtnSave.Visible = false;
        this.BtnEdit.Visible = false;
        this.BtnAdd.Visible = false;
        this.BtnSubmit.Visible = false;
        this.BtnUndoSubmit.Visible = false;


        IsOperationDisabled = true;
    }

    public void DisableNavigation()
    {
        this.BtnPrevious.Visible = false;
        this.BtnNext.Visible = false;
        this.BtnLast.Visible = false;
        this.BtnFirst.Visible = false;
    }
}
