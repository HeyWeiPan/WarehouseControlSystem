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
using EntpClass.WebUI;


public partial class CommonUI_MasterPage_MasterReportScope : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PageBase page = (PageBase)this.Page;
            LblTitle.Text = page.Title;     
        }
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
}
