using System;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.BizLogic.Security;
using EntpClass.WebControlLib;
using EntpClass.WebControlLib.Derived;

public partial class RoleDefinitionDetail : SetUpDetailPageBase<Role>
{
    private UcHyperLink GetFirstTab()
    {
        if (LinkUser.Visible) { return LinkUser; }
        else if (LinkFunction.Visible) { return LinkFunction; }
        else if (LinkResource.Visible) { return LinkResource; }
        else { return null; }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (!IsPostBack)
        {
            bool userRight = false;
            bool funcOperRight = false;
            bool resourceRight = false;       

            if (this.KeyValue != string.Empty)
            {
                userRight = RightHelper.CheckFuncRightCached(RoleUser.FunctionID, OperationCode.READ);
                funcOperRight = RightHelper.CheckFuncRightCached(RoleFunctionOperation.FunctionID, OperationCode.READ);
                resourceRight = RightHelper.CheckFuncRightCached(RoleResource.FunctionID, OperationCode.READ);                
            }

            if (!userRight) { LinkUser.Visible = false; }
            if (!funcOperRight) { LinkFunction.Visible = false; }
            if (!resourceRight) { LinkResource.Visible = false; }                      
        }

        LinkUser.Attributes.Add("onclick", "setSelectedTab(this);");
        LinkFunction.Attributes.Add("onclick", "setSelectedTab(this);");
        LinkResource.Attributes.Add("onclick", "setSelectedTab(this);");
    }   

    protected override void OnAfterSetControlValue(SetControlValueEventArgs e)
    {
        base.OnAfterSetControlValue(e);

        bool systemRoleFlag = Fn.ToBoolean(RowData["system_role_flag"]);
        if (systemRoleFlag) { LnkRefresh.Visible = true; }
    }

    protected override void OnPageModeChanged(PageModeChangedEventArgs arg)
    {
        base.OnPageModeChanged(arg);

        LinkUser.NavigateUrl = "";
        LinkFunction.NavigateUrl = "";
        LinkResource.NavigateUrl = "";        
        IfraSubWindow.Visible = true;

        if (CurrentPageMode == PageMode.View)
        {
            LinkUser.NavigateUrl = "RoleUser.aspx?RoleId=" + KeyValue + "&mode=" + CurrentPageMode.ToString();
            LinkFunction.NavigateUrl = "RoleFunctionOperation.aspx?RoleId=" + KeyValue + "&mode=" + CurrentPageMode.ToString();
            LinkResource.NavigateUrl = "RoleResource.aspx?RoleId=" + KeyValue + "&mode=" + CurrentPageMode.ToString();
        }
        else
        {
            LinkUser.NavigateUrl = "";
            LinkFunction.NavigateUrl = "";
            LinkResource.NavigateUrl = "";
            IfraSubWindow.Attributes.Add("src", "");  
            IfraSubWindow.Visible = false;
        }

        if (!LinkUser.Visible) { LinkUser.NavigateUrl = ""; }
        if (!LinkFunction.Visible) { LinkFunction.NavigateUrl = ""; }
        if (!LinkResource.Visible) { LinkResource.NavigateUrl = ""; }
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        UcHyperLink LnkCurrent = GetFirstTab();
        if (LnkCurrent == null) { IfraSubWindow.Visible = false; return; }        
        AttachClientEvent("windowonload", "window", "onload", string.Format("document.getElementById('{0}').click();", LnkCurrent.ClientID));        
    }

    protected void LnkRefresh_Click(object sender, EventArgs e)
    {
        RM rmMs = new RM(ResourceFile.Msg);
        bool b = Role.SyncRoleUser(Fn.ToInt(RowData["role_id"]));
        if (b)
            Alert(rmMs["RefreshSuccess"]);
        else
            Alert(rmMs["RefreshFailed"]);
    }
}
