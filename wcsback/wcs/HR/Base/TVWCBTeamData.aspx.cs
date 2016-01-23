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
using EntpClass.BizLogic.HR.OrgChart;



public partial class HR_Base_TVWCBTeamData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = 60;

        UcTVTeam.NodeBinding += new EventHandler<EntpClass.WebControlLib.TreeNodeBindingEventArgs>(UcTVTeam_NodeBinding);
        int functionID = Fn.ToInt(Request.Params["functionID"]);
        UcTVTeam.BindData(GetDataSource(), "TEAM_ID", "TEAM_PID", "", "");
        Response.Write(UcTVTeam.ToXML());
        Response.End();
    }

    void UcTVTeam_NodeBinding(object sender, EntpClass.WebControlLib.TreeNodeBindingEventArgs e)
    {
        string teamId = Fn.ToString(e.Row["team_id"]);
        string teamPid = Fn.ToString(e.Row["team_pid"]);
        //string teamGuid = Fn.ToString(e.Row["team_guid"]);
        string teamName = Fn.ToString(e.Row["text"]);
        string teamType = Fn.ToString(e.Row["type"]);
        string teamTypeId = Fn.ToString(e.Row["team_type_id"]);
        string imageUrl = Fn.ToString(e.Row["image_url"]);

        e.Node.NodeData = teamId;
        e.Node.Text = teamName;
        //e.Node.Type = teamType;
        e.Node.ImageUrl = UrlHelper.UrlBase + "/HR/OrgChart/" + imageUrl;
        //e.Node.ExtendedProperties.Add("team_guid", teamGuid);
        //e.Node.ExtendedProperties.Add("team_type_id", teamTypeId);

    }

    private DataTable GetDataSource()
    {
        DataSet ds = Team.GetTeamTreeDataResource(0, 0, Team.FUNCTIONID);
        return ds.Tables[0];
    }

}
