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

using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.HR.OrgChart;

public partial class HR_OrgChart_TeamTreeGetChildNode : Page
{
    private int ParentNodeValue
    {
        get
        {
            return Fn.ToInt(Request.Params["parentNodeID"]);//team_id
        }
    }

    protected override bool SupportAutoEvents
    {
        get
        {
            return false;
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
   
        string rootNodeParentValue = "";
        if (ParentNodeValue != Team.VirtualRootID)
        {
            rootNodeParentValue = Fn.ToString(ParentNodeValue);
        }

        UcTreeMenuList.NodeBinding += new EventHandler<TreeNodeBindingEventArgs>(UcTreeMenuList_NodeBinding);
        UcTreeMenuList.BindData(GetDataSource(ParentNodeValue), "TEAM_ID", "TEAM_PID", "", rootNodeParentValue);

        Response.Write(UcTreeMenuList.ToXML());
        Response.End();
    }

    void UcTreeMenuList_NodeBinding(object sender, TreeNodeBindingEventArgs e)
    {
        //oNode.getAttribute("nodedata") = team_id
        //oNode.getAttribute("text") = team_name
        //oNode.getAttribute("type") = team_type        
        string teamId = Fn.ToString(e.Row["team_id"]);
        string teamPid = Fn.ToString(e.Row["team_pid"]);
        string teamGuid = Fn.ToString(e.Row["team_guid"]);
        string teamName = Fn.ToString(e.Row["text"]);
        string teamType = Fn.ToString(e.Row["type"]);
        string teamTypeId = Fn.ToString(e.Row["team_type_id"]);
        string imageUrl = Fn.ToString(e.Row["image_url"]);

        e.Node.NodeData = teamId;
        e.Node.Text = teamName;
        e.Node.Type = teamType;
        e.Node.ImageUrl = imageUrl;
        e.Node.ExtendedProperties.Add("team_guid", teamGuid);
        e.Node.ExtendedProperties.Add("team_type_id", teamTypeId);

        //根节点下也可以挂人
        e.Node.Target = "IfraSubWindow";
        e.Node.NavigateUrl = string.Format("TeamUserList.aspx?TeamId={0}&TeamGuid={1}", teamId, teamGuid);

        //根节点
        if (teamId == "0")
            e.Node.ImageUrl = "Image/root.gif";
    }

    private DataTable GetDataSource(int nodeID)
    {
        //一:
        //没有使用资源文件,取数据
        //DataSet ds = Team.GetTeamTreeData(nodeID);

        //二:
        DataSet ds = Team.GetTeamTreeDataResource(nodeID, Team.FUNCTIONID);
        return ds.Tables[0];
    }  
}

