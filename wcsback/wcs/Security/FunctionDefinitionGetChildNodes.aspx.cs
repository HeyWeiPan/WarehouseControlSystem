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
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.BizLogic.Security;
using EntpClass.WebControlLib;
using EntpClass.WebControlLib.Derived;

public partial class FunctionDefinitionGetChildNodes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UcTreeMenuList.NodeBinding += new EventHandler<TreeNodeBindingEventArgs>(UcTreeMenuList_NodeBinding);
        int parentNodeValue = Fn.ToInt(Request.Params["parentNodeID"]);
        string rootNodeParentValue = parentNodeValue.ToString();

        if (rootNodeParentValue == "0")
        {
            rootNodeParentValue = "";
        }

        UcTreeMenuList.BindData(GetDataSource(parentNodeValue), "FUNCTION_ID", "FUNCTION_PID", "Show_Order asc", rootNodeParentValue);
        Response.Write(UcTreeMenuList.ToXML());
        Response.End();
    }

    void UcTreeMenuList_NodeBinding(object sender, TreeNodeBindingEventArgs e)
    {
        e.Node.Text = Fn.ToString(e.Row["FUNCTION_name"]);

        if (e.Node.Text == string.Empty)
        {
            e.Node.Text = "Empty";
        }

        if (!Fn.ToBoolean(e.Row["enable_flag"]))
        {
            e.Node.Text = e.Node.Text + "(Disabled)";
        }      

        //if (Fn.ToInt(e.Row["version"]) < 2)
        //{           
        //    e.Node.Text = @"<span style='background-color:yellow;color:blue'>" + e.Node.Text + "</span>";           
        //    e.Node.Type = "1";
        //}
        //else
        //{
        //    e.Node.Type = "2";
        //}
        if (Fn.ToInt(e.Row["function_type_id"]) == 4)
        {
            e.Node.Text = @"<span style='font-weight:bold;'>" + e.Node.Text + "</span>";    
        }

        e.Node.ImageUrl = "Image/folder.small.png";
    }

    private DataTable GetDataSource(int parentNodeID)
    {
        DataSet ds = ScrFunction.GetChildNodes(parentNodeID, false, string.Empty, true);
        return ds.Tables[0];
    }
}
