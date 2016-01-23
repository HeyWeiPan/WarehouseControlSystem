using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;

public partial class CommonUI_MasterPage_MasterEmptyList : System.Web.UI.MasterPage
{
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

        if (!page.PageRight.HasExportOperation)
        {
            this.BtnExport.Visible = false;
        }
        else if (!page.PageRight.ExportRight)
        {
            this.BtnExport.Enabled = false;
        }

        if (!page.PageRight.HasPrintOperation)
        {
            this.BtnPrint.Visible = false;
        }
        else if (!page.PageRight.PrintRight)
        {
            this.BtnPrint.Enabled = false;
        }
    }

   
    protected void BtnRefresh_Click(object sender, EventArgs e)
    {

    }

    protected void BtnExport_Click(object sender, EventArgs e)
    {
        PageBase page = (PageBase)this.Page;

        page.DoAction("EXPORT", sender, e);
    }
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        PageBase page = (PageBase)this.Page;
        page.DoAction("PRINT", sender, e);
    }
}
