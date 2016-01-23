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
using System.Text;

using EntpClass.Common;

using EntpClass.WebUI;

public partial class CommonUI_MasterPage_UcMasterMenuForSFA : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        RegeditMasterClientScript();
        LnkGlobalSearch.NavigateUrl = UrlHelper.UrlBase + "/SFA/Customer/GlobalSearch.aspx";
    }

    private void RegeditMasterClientScript()
    {
        if (!this.Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegeditMasterClientScript"))
        {
            //StringBuilder s = new StringBuilder();
            ////Estab
            //Lead lead = new Lead();
            //DialogWindow detailWindow = lead.DetailDialogWindow;
            //s.Append(PageBase.GetShowDialogWindowClientFunction(detailWindow, "ShowMasterNewEstabWindow"));            
           
            ////Case
            //Case c = new Case();
            //detailWindow = c.DetailDialogWindow;
            //s.Append(PageBase.GetShowDialogWindowClientFunction(detailWindow, "ShowMasterNewCaseWindow"));            

            ////Activity
            //Activity activity = new Activity();
            //detailWindow = activity.DetailDialogWindow;
            //s.Append(PageBase.GetShowDialogWindowClientFunction(detailWindow, "ShowMasterNewActivityWindow"));            

            ////ActivityPLan
            //ActivityPlan activityPlan = new ActivityPlan();
            //detailWindow = activityPlan.DetailDialogWindow;
            //s.Append(PageBase.GetShowDialogWindowClientFunction(detailWindow, "ShowMasterNewPlanWindow"));

            //LnkNewEstab.OnClientClick = "ShowMasterNewEstabWindow(\"Add\",\"\");return false;";
            //LnkNewCase.OnClientClick = "ShowMasterNewCaseWindow(\"Add\",\"\");return false;";
            //LnkNewActivity.OnClientClick = "ShowMasterNewActivityWindow(\"Add\",\"\");return false;";
            //LnkNewPlan.OnClientClick = "ShowMasterNewPlanWindow(\"Add\",\"\");return false;";

            //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegeditMasterClientScript", s.ToString(), true);
        }
    }

}
