using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.Common;
using EntpClass.WebUI;
using EntpClass.WebControlLib;
using EntpClass.WebControlLib.Derived;
using EntpClass.BizLogic.HR.OrgChart;
using EntpClass.BizLogic.HR.UserProfile;

public partial class HR_OrgChart_UcTeamUserList : GridControlBase<TeamUser>
{
    private int TeamId
    {
        get
        {
            return Fn.ToInt(Request.Params["TeamId"]);
        }
    }

    private string TeamGuid
    {
        get { return Fn.ToString(Request.QueryString["TeamGuid"]); }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        string keyValue = Team.GetKeyValue(TeamGuid);

        Team t = new Team(keyValue);                

        string teamName = Fn.ToString(t["team_name"]);
        string teamLeaderName = Fn.ToString(t["team_leader_name"]);
        string teamLeaderNumber = Fn.ToString(t["team_leader_number"]);
        string teamLeaderGuId = Fn.ToString(t["team_leader_guid"]);

        string teamClickScript
            = string.Format("if(ShowTeam('EDIT','{0}')!= 'REFRESH'){{window.event.cancelBubble = true;return false;}}", TeamGuid)
            + "parent.window.refreshSelectedNode();";

        string userClickScript
            = string.Format("if(ShowUser('VIEW','{0}')!= 'REFRESH'){{window.event.cancelBubble = true;return false;}}", teamLeaderGuId)
            + "parent.window.refreshSelectedNode();";

        LnkTeam.Text = teamName;
        LnkTeam.OnClientClick = teamClickScript;

        Lab.Text = ":";

        LnkTeamLeader.Text = teamLeaderNumber + " " + teamLeaderName;
        LnkTeamLeader.OnClientClick = userClickScript;
    }
    
    private void RegeditDetailLinkScript()
    {
        PageBase page = this.Page as PageBase;

        if (!page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegeditDetailLinkScript"))
        {
            StringBuilder s = new StringBuilder("");

            HRUser user = new HRUser();
            DialogWindow dw = user.DetailDialogWindow;
            s.Append(PageBase.GetShowDialogWindowClientFunction(dw, "ShowUser"));

            Team team = new Team();
            dw = team.DetailDialogWindow;
            s.Append(PageBase.GetShowDialogWindowClientFunction(dw, "ShowTeam"));

            page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegeditDetailLinkScript", s.ToString(), true);
        }
    }

    protected override DataSet GetGridDataSet()
    {
        DataSet ds = TeamUser.GetTeamUserList(TeamId);

        return ds;
    }

    protected override GridView GetGridViewControl()
    {
        return GrdTeamUserList;
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        RegeditDetailLinkScript();
    }

    protected override bool OnPreSave(PageBase page, GridViewRow row, bool isInsert, string keyValue)
    {
        Hashtable dataControlCollection = page.DataControlCollection;

        //team_id
        UcHiddenField HidTeamId = new UcHiddenField();
        HidTeamId.ID = "HidTeamId";
        HidTeamId.ColumnName = "team_id";
        HidTeamId.RequiredField = true;
        HidTeamId.Value = Fn.ToString(TeamId);
        HidTeamId.AllowInsert = true;
        HidTeamId.AllowUpdate = false;

        page.AddControl(HidTeamId);

        return base.OnPreSave(page, row, isInsert, keyValue);
    }
}
