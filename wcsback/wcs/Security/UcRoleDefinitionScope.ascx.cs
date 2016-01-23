using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.Security;

public partial class Security_UcRoleDefinitionScope : ScopeControlBase
{

    public override void InitializeEvents()
    {
        PageBase page = (PageBase)this.Page;
        page.Load += new EventHandler(page_Load);
    }

    void page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DdlInterfaceId.Enabled = false;
        }
    }  

    protected override DbRowParameter GetParameter()
    {
        Role r = new Role();

        return r.Parameter;
    }

    protected override string JoinTable(JoinTableParameters p)
    {
        switch (p.JoinTableName.ToLower())
        {
            case "scr_role_user":
                return string.Format("inner join scr_role_user {1} on {0}.Role_ID = {1}.Role_ID ", p.MainTableAlias, p.JoinTableAlias);

            case "scr_role_function":
                return string.Format("inner join scr_role_function {1} on {0}.Role_ID = {1}.Role_ID ", p.MainTableAlias, p.JoinTableAlias);

            case "scr_role_resource":
                return string.Format("inner join scr_role_resource {1} on {0}.Role_ID = {1}.Role_ID ", p.MainTableAlias, p.JoinTableAlias);

            default:
                return "";
        }
    }

    protected void DdlResourceType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlResourceType.SelectedItem != null && DdlResourceType.SelectedItem.Value != string.Empty)
        {
            DataSet ds = ResourceType.GetSourceResourceInterface(DdlResourceType.SelectedItem.Value);
            DdlInterfaceId.Enabled = true;
            DdlInterfaceId.DataSource = ds.Tables[0];
            DdlInterfaceId.DataBind();
        }
        else
        {
            DdlInterfaceId.SelectedIndex = 0;
            DdlInterfaceId.Enabled = false;
        }
    }    
}

