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

using Microsoft.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.BizLogic.Security;
using EntpClass.WebControlLib;
using EntpClass.WebControlLib.Derived;
using EntpClass.BizLogic.Setup;

public partial class Setup_GeographyGetChildNodes : System.Web.UI.Page
{   
    private int ParentNodeValue
    {
        get
        {
            return Fn.ToInt(Request.Params["parentNodeID"]);//geo_id
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string rootNodeParentValue = "";
        if (ParentNodeValue != Geography.VirtualRootID)
        {
            rootNodeParentValue = Fn.ToString(ParentNodeValue);
        }

        Trv1.NodeBinding += new EventHandler<TreeNodeBindingEventArgs>(Trv1_NodeBinding);
        Trv1.BindData(GetDataSource(ParentNodeValue), "GEO_ID", "GEO_PID", "", rootNodeParentValue);

        //树分页的处理
        //Trv1.BindData(GetDataSource(ParentNodeValue, CurrPageIndex, CurrRowCount), "GEO_ID", "GEO_PID", "", rootNodeParentValue);

        Response.Write(Trv1.ToXML());
        Response.End();
    }

    void Trv1_NodeBinding(object sender, TreeNodeBindingEventArgs e)
    {
        #region

        //树分页的处理
        //DZD 2007-12-10

        //e.Node.ExtendedProperties.Add("geo_pid", Fn.ToString(e.Row["geo_pid"]));        
        //e.Node.ExtendedProperties.Add("childCount", Fn.ToString(e.Row["childcount"]));//当前节点的子节点个数
        //e.Node.ExtendedProperties.Add("currcount", Fn.ToString(e.Row["currcount"]));//树分页,当前节点已经取出的子节点的个数
        //e.Node.ExtendedProperties.Add("lastcount", Fn.ToString(e.Row["lastcount"]));//树分页,当前节点的子节点总数               
                       
        //e.Node.NodeData = Fn.ToString(e.Row["geo_id"]);//oNode.getAttribute("nodedata") = geo_id
        //e.Node.Text = Fn.ToString(e.Row["text"]); //oNode.getAttribute("text") = geo_name
        //e.Node.Type = Fn.ToString(e.Row["type"]);//oNode.getAttribute("type") = geo_type

        //if (e.Row.Table.Columns["currPageIndex"] != null)//只有在[See More]节点出现,才有 currPageIndex 数据
        //    e.Node.ExtendedProperties.Add("currPageIndex", Fn.ToString(e.Row["currPageIndex"]));

        ////是否有子节点,分级取节点                   
        ////第一次,取数据,如果数据库没有根节点的话,会增加一条根节点。
        ////把根节点和其下的子节点取出来,如果是根节点的话,不设置 TreeNodeSrc。节省了一次数据库连接。
        //if (Fn.ToInt(e.Row["hasChild"]) == -1 && !string.IsNullOrEmpty(Fn.ToString(e.Row["geo_pid"])))
        //    e.Node.TreeNodeSrc = string.Format("JxcGeographyGetChildNodes.aspx?parentNodeID={0}", Fn.ToString(e.Row["geo_id"]));
        
        //if (e.Node.Text == string.Empty)
        //    e.Node.Text = "Empty";

        #endregion

        //树的不分页处理
        e.Node.NodeData = Fn.ToString(e.Row["geo_id"]);//oNode.getAttribute("nodedata") = geo_id
        e.Node.Text = Fn.ToString(e.Row["text"]); //oNode.getAttribute("text") = geo_name
        e.Node.Type = Fn.ToString(e.Row["type"]);//oNode.getAttribute("type") = geo_type        
    }

    private DataTable GetDataSource(int nodeID)
    {
        DataSet ds = Geography.GetGeographyTreeData(nodeID, Geography.VirtualRootID);
        return ds.Tables[0];
    }

    #region 
    //树分页的处理
    //DZD 2007-12-10

    //public int CurrPageIndex
    //{
    //    get
    //    {
    //        //记录着,树分页的页数索引
    //        int count = Fn.ToInt(Request.Params["currPageIndex"]);

    //        return count == 0 ? 1 : count;
    //    }
    //}

    //public int CurrRowCount
    //{
    //    get
    //    {
    //        //记录着,已经取出来某节点的,子节点的个数
    //        return Fn.ToInt(Request.Params["currRowCount"]);
    //    }
    //}

    //private DataTable GetDataSource(int nodeID, int currPageCount, int currRowCount)
    //{       
    //    return Geography.GetTreeNodes(nodeID, currPageCount, currRowCount).Tables[0];                     
    //}
    #endregion    
}
