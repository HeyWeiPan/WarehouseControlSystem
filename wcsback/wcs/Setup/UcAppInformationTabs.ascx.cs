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
using EntpClass.WebControlLib;
using EntpClass.Common;

public partial class Base_UcAppInformationTabs : System.Web.UI.UserControl
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
      
        DeselectAllTab();
        SelectTab(SelectedTabID);
    }

    private string _selectedTabID = "HyperAppInformation";

    public string SelectedTabID
    {
        get{return _selectedTabID;}       
        set{_selectedTabID = value;}        
    }

    private void DeselectAllTab()
    {
        DeselectAllTab(this.Controls);
    }

    private void DeselectAllTab(ControlCollection collection)
    {
        foreach (Control c in collection)
        {
            if (c is UcHyperLink)
            {
                UcHyperLink obj = c as UcHyperLink;
                obj.ShowStyle = EnumHyperLinkShowStyle.TabWhite;
            }
            if (c.HasControls())
            {
                DeselectAllTab(c.Controls);
            }
        }
    }

    public void SetTabEnabled(bool isEnabled)
    {
        SetTabEnabled(isEnabled, this.Controls);
    }

    private void SetTabEnabled(bool isEnabled, ControlCollection collection)
    {
        foreach (Control c in collection)
        {
            if (c is UcHyperLink)
            {
                UcHyperLink obj = c as UcHyperLink;
                obj.Enabled = isEnabled;
            }
            if (c.HasControls())
            {
                SetTabEnabled(isEnabled, c.Controls);
            }
        }
    }

    private void SelectTab(string tabID)
    {
        UcHyperLink selectedTab = Fn.FindControlWithLoop(tabID, this.Controls) as UcHyperLink;
        selectedTab.ShowStyle = EnumHyperLinkShowStyle.TabBlue;
    }    
}
