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

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.BizLogic.Security;
using EntpClass.WebControlLib;
using EntpClass.WebControlLib.Derived;

public partial class Security_RoleFunctionOperationGetTreeNodes : PageBase
{
    public override void InitializeEvents()
    {
        PageBase page = (PageBase)this.Page;
        page.Load += new EventHandler(page_Load);
    }

    void page_Load(object sender, EventArgs e)
    {
        Trv1.NodeBinding += new EventHandler<TreeNodeBindingEventArgs>(Trv1_NodeBinding);

        int roleID = Fn.ToInt(Request.Params["RoleID"]);
        string rootNodeParentValue = Fn.ToString(Fn.ToInt(Request.Params["parentNodeID"]));

        if (rootNodeParentValue == "0") rootNodeParentValue = Fn.ToString(ScrFunction.RootID);

        Trv1.BindData(GetDataSource(roleID), "FUNCTION_ID", "FUNCTION_PID", "SHOW_ORDER ASC", rootNodeParentValue);

        Response.Write(Trv1.ToXML());
        Response.End();
    }


    private DataTable GetDataSource(int roleID)
    {
        DataSet ds = RoleFunctionOperation.GetRoleFuncTreeData(roleID, "");

        return ds.Tables[0];
    }
   
    void Trv1_NodeBinding(object sender, TreeNodeBindingEventArgs e)
    {
        e.Node.Text = Fn.ToString(e.Row["function_name"]);

        if (e.Node.Text == string.Empty)
            e.Node.Text = "Empty";
    }
   
    public override void SetPageInfo(ref PageParameter p) { }   
}
