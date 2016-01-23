using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.BizLogic.Setup;
using EntpClass.WebControlLib;
using EntpClass.Common;
using System.Data;

public partial class Setup_FileFolderGetChildNodes : System.Web.UI.Page
{
    private int ParentNodeValue
    {
        get
        {
            return Fn.ToInt(Request.Params["parentNodeID"]);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string rootNodeParentValue = "";
        if (ParentNodeValue != FileFolder.VirtualRootID)
        {
            rootNodeParentValue = Fn.ToString(ParentNodeValue);
        }

        Trv1.NodeBinding += new EventHandler<TreeNodeBindingEventArgs>(Trv1_NodeBinding);
        Trv1.BindData(GetDataSource(ParentNodeValue), "folder_id", "folder_pid", "", rootNodeParentValue);

        Response.Write(Trv1.ToXML());
        Response.End();
    }

    void Trv1_NodeBinding(object sender, TreeNodeBindingEventArgs e)
    {
        

        //树的不分页处理
        e.Node.NodeData = Fn.ToString(e.Row["folder_id"]);//oNode.getAttribute("nodedata") = geo_id
        e.Node.Text = Fn.ToString(e.Row["folder_name"]); //oNode.getAttribute("text") = geo_name
            
    }

    private DataTable GetDataSource(int nodeID)
    {
        DataSet ds = FileFolder.GeFileFolderTreeData(nodeID);
        return ds.Tables[0];
    }

   
}
