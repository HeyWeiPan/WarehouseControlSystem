using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using EntpClass.WebUI;
using EntpClass.Common;


public partial class MasterSetupList : System.Web.UI.MasterPage
{
    protected override void OnLoad(EventArgs e)
    {
        PageBase p = this.Page as PageBase;

        p.SetPageIndex(HidPagerArgument.Value);
        base.OnLoad(e);
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        PageBase p = this.Page as PageBase;
        int functionId = p.RequestPageFuncID;
        int favorateId = HomeInformation.GetFavorateId(functionId);
        LnkFavorate.OnClientClick = string.Format("InsertFavorate({0});return false;", functionId);
        LnkDeleteFavorate.OnClientClick = string.Format("DeleteFavorate({0});return false;", favorateId);
        if (favorateId != 0)
        {
            LnkFavorate.Attributes.Add("style", "display:none;");

        }
        else
        {
            LnkDeleteFavorate.Attributes.Add("style", "display:none;");
        }
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
                //ImgHelpIcon.Visible = true;
                LnkHelpTextCN.Visible = true;
                LnkHelpTextCN.NavigateUrl = page.PageSetting.HelpFileUrlCN;
            }

        }
        RM rm = new RM(ResourceFile.Msg);

        BtnDelete.OnClientClick = "if(!CheckDelete()) return false;";
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

        if (!page.PageRight.HasDeleteOperation)
        {
            this.BtnDelete.Visible = false;
        }
        else if (!page.PageRight.DeleteRight)
        {
            this.BtnDelete.Enabled = false;
        }

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
            BtnPrint.Visible = false;
        }

        //if (!page.PageRight.HasOperation("REFRESH"))
        //{
        //    this.BtnRefresh.Visible = false;
        //}
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


    protected void BtnExport_Click(object sender, EventArgs e)
    {
        PageBase page = (PageBase)this.Page;

        page.DoAction("EXPORT", sender, e);

    }

    /// <summary>
    /// REFRESH current window.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnRefresh_Click(object sender, EventArgs e)
    {

    }
    protected void btnGO_Click(object sender, EventArgs e)
    {

    }
    protected void ddlPageRows_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnExport_Click1(object sender, EventArgs e)
    {
        PageBase page = (PageBase)this.Page;

        page.DoAction("EXPORT", sender, e);
    }
}
