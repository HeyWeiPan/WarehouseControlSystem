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
using EntpClass.WebUI;
using EntpClass.BizLogic.HR.OrgChart;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.Security;

public partial class HR_OrgChart_TeamDetail : SetUpDetailPageBase<Team>
{
    private string TeamId
    {
        //新增节点的 PID = 当前节点的 ID
        get { return Fn.ToString(Request.QueryString["TeamId"]); }
    }

    private string TeamTypeId
    {
        get { return Fn.ToString(Request.QueryString["TeamTypeId"]); }
    }   

    protected override void OnPageModeChanged(PageModeChangedEventArgs e)
    {
        base.OnPageModeChanged(e);

        WcbUser.Visible = true;        
        TxtTeamLeader.Visible = false;

        if (e.NewPageMode == PageMode.View)
        {
            WcbUser.Visible = false;            
            TxtTeamLeader.Visible = true;
        }
        
        if (e.NewPageMode == PageMode.Add)
        {
            HidTeamPId.Value = TeamId;            
        }        
    }

    public override bool OnCheckRequired(bool autoAlertErrorInfo, out Control requiredControl, out string outputMsg)
    {
        Hashtable dataControlCollection = DataControlCollection;

        if (CurrentPageMode == PageMode.Add)
        {
            int teamId = Fn.ToInt(Fn.GetAppSequence(ScrConst.ConnectionName, RowData.TableName));

            //team_id
            UcHiddenField HidTeamId = new UcHiddenField();
            HidTeamId.ID = "HidTeamId";
            HidTeamId.ColumnName = "team_id";
            HidTeamId.RequiredField = true;
            HidTeamId.Value = teamId.ToString();

            AddControl(HidTeamId);
        }
        else
        {
            //team_id
            //在更新的时候,使用了 user_id。
            UcHiddenField HidTeamId = new UcHiddenField();
            HidTeamId.ID = "HidTeamId";
            HidTeamId.ColumnName = "team_id";
            HidTeamId.RequiredField = true;
            HidTeamId.Value = Fn.ToString(RowData["team_id"]);
            HidTeamId.AllowUpdate = false;

            AddControl(HidTeamId);
        }


        return base.OnCheckRequired(autoAlertErrorInfo, out requiredControl, out outputMsg);
    }
}
