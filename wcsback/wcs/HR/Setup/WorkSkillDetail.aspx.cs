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

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.BizLogic.HR.Setup;

public partial class HR_Setup_WorkSkillDetail : SetUpDetailPageBase<WorkSkill>
{
    protected override void OnLoad(EventArgs e)
    {
        UcWorkSkillLevel1.WorkSkillId = Fn.ToInt(RowData["workskill_id"]);
        base.OnLoad(e);
    }

    protected override void OnPageModeChanged(PageModeChangedEventArgs e)
    {
        base.OnPageModeChanged(e);

        TabLevel.Visible = false;
        if (e.NewPageMode == PageMode.View) { TabLevel.Visible = true; }
    }
}
