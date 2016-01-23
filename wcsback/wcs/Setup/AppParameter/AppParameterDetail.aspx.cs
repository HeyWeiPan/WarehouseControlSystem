///----------------------------------------------------------------'
///Author:lzj
///Date: 2011-5-21
///Comments:base/ParameterDeatil
///Version History: (Add most recent change to top of list)
///Date：
///Name:
///Description:        
///----------------------------------------------------------------

using System;
using System.Data;
using System.Text;
using EntpClass.WebUI;
using EntpClass.BizLogic.Setup;
using EntpClass.BizLogic.Security;
using EntpClass.Common;

public partial class Setup_AppParameter_AppParameterDetail : SetUpDetailPageBase<AppParameter>
{
    public override void InitializeEvents()
    {
        PageBase page = (PageBase)this.Page;
        page.PageModeChanged += new EventHandler<PageModeChangedEventArgs>(page_PageModeChanged);
        page.PreSave += new System.ComponentModel.CancelEventHandler(page_PreSave);
        page.PreRender += new EventHandler(Page_PreRender);
    }

    public string GetHref(string Code)
    {
        return string.Format("javascript:ShowParaSet('EDIT','{0}');", Code);
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        RegeditClientScript();

        HyLParaSet.NavigateUrl = GetHref(Fn.ToString(RowData["code"]));

    }

    void page_PageModeChanged(object sender, PageModeChangedEventArgs e)
    {
        switch (e.NewPageMode)
        {
            case PageMode.Add:
            case PageMode.Edit:
                DdlModule.Visible = true;
                TxtModuleName.Visible = false;
                TRDataText.Visible = false;
                HyLParaSet.Visible = false;
                break;
            default:
                DdlModule.Visible = false;
                TxtModuleName.Visible = true;
                TRDataText.Visible = false;
                break;
        }
    }

    void page_PreSave(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (DdlModule.SelectedItem != null)
        {
            TxtModuleName.Text = DdlModule.SelectedItem.Text;
        }

     }

    private void RegeditClientScript()
    {
        if (!ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegeditClientScript"))
        {
            StringBuilder s = new StringBuilder();

            //Parameter value Setting Diaglog
            AppParameter Para = new AppParameter();
            DialogWindow dw = Para.DetailDialogWindow;
            dw.Url = UrlHelper.UrlBase + ("/Setup/AppParameter/ParameterSettingDetail.aspx");
            dw.Width = 500;
            dw.Height = 250;

            s.Append(PageBase.GetShowDialogWindowClientFunction(dw, "ShowParaSet"));

            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegeditClientScript", s.ToString(), true);
        }
    }
}

