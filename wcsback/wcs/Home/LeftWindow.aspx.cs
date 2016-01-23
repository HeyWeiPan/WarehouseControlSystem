using System;
using System.Text;
using System.Data;
using System.Data.Common;
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
using EntpClass.BizLogic.Security;
using Microsoft.Practices.EnterpriseLibrary.Data;

public partial class Home_LeftWindow : PageBase
{
    private string _MultiLanguageSuffix = DBSetting.MultiLanguageSuffix;

    //public override void InitializeEvents()
    //{
    //    PageBase page = (PageBase)this.Page;
    //    page.Load += new EventHandler(Page_Load);
    //}

    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    if (!Page.IsPostBack)
    //    {
    //        //string redirectFunctionID = "2900000"; // home page
    //        //if (Fn.ToString(Session["redirect_func_id"]) != string.Empty)
    //        //{
    //        //    redirectFunctionID = Fn.ToString(Session["redirect_func_id"]);
    //        //}

    //        //string s = String.Format("sync(getTreeView().getChildren()[0],{0});", redirectFunctionID);
    //        //AttachClientEvent("syncTree", "window", "onload", s);
    //        //Session["redirect_func_id"] = null;

           

    //        TrvMenu.NodeBinding += new EventHandler<TreeNodeBindingEventArgs>(TrvMenu_NodeBinding);
    //        TrvMenu.BindData(GetMenuDatasource(), "FUNCTION_ID", "FUNCTION_PID", "SHOW_ORDER ASC", ScrFunction.RootID.ToString());
    //        TrvMenu.Target = "MainWindow";

           
    //    }
    //}

    //private void RenderMenuScript()
    //{
    //    ClientPopupMenu menu = new ClientPopupMenu("mLeft", "createMenu");

    //    if (CurrentUser.UseLanguage == Language.English)
    //    {
    //        menu.AddMenuItem("mAddToFav", "Add To Favorate", "addtoFavMenu", ResourceHelper.GetImageUrl(this.Page, "add.png"));
    //    }
    //    else
    //    {
    //        menu.AddMenuItem("mAddToFav", "加入收藏", "addtoFavMenu", ResourceHelper.GetImageUrl(this.Page, "add.png"));
    //    }

    //    menu.RenderScript(Page);
    //}

    //private void RenderFavorateMenuScript()
    //{
    //    ClientPopupMenu menu = new ClientPopupMenu("mFavorate", "createFavMenu");

    //    if (CurrentUser.UseLanguage == Language.English)
    //    {
    //        menu.AddMenuItem("mMoveFromFav", "Move From Favorate", "movefromFavMenu", ResourceHelper.GetImageUrl(this.Page, "delete.small.png"));
    //    }
    //    else
    //    {
    //        menu.AddMenuItem("mMoveFromFav", "移除收藏", "movefromFavMenu", ResourceHelper.GetImageUrl(this.Page, "delete.small.png"));
    //    }

    //    menu.RenderScript(Page);
    //}

    //void TrvMenu_NodeBinding(object sender, TreeNodeBindingEventArgs e)
    //{
    //    e.Node.Text = Fn.ToString(e.Row["function_name_" + _MultiLanguageSuffix]);
    //    string pageUrl = Fn.ToString(e.Row["page_url"]);
    //    if (pageUrl != string.Empty)
    //    {
    //        e.Node.NavigateUrl = "Navigate.aspx?FuncID=" + Fn.ToString(e.Row["function_id"]);
    //    }

    //    string target = Fn.ToString(e.Row["target"]);
    //    if (target != string.Empty) e.Node.Target = target;
    //}

    //private DataTable GetMenuDatasource()
    //{
    //    DataSet ds = RightHelper.GetUserMenuTree(CurrentUser.UserID, ScrFunction.GetRootMenuLineage());
    //    return ds.Tables[0];
    //}

    public override void SetPageInfo(ref PageParameter pageSetting)
    {
        pageSetting.FunctionID = 0;
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        this.HidUserID.Value = Fn.ToString(CurrentUser.UserID);
    }

    #region
    //void UcFavorateTreeMenuList_NodeBinding(object sender, TreeNodeBindingEventArgs e)
    //{
    //    e.Node.Text = Fn.ToString(e.Row["menu_name_" + DBSetting.MultiLanguageSuffix]);
    //    string pageUrl = Fn.ToString(e.Row["page_url"]);
    //    if (pageUrl != string.Empty)
    //    {
    //        e.Node.NavigateUrl = "Navigate.aspx?FuncID=" + Fn.ToString(e.Row["function_id"]);
    //    }

    //    string target = Fn.ToString(e.Row["target"]);
    //    if (target != string.Empty)
    //    {
    //        e.Node.Target = target;
    //    }

    //    e.Node.ImageUrl = "../EApproval/IDMP/Images/txt1.gif";
    //}
    #endregion
}
