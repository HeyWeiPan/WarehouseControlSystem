using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.BizLogic.WCS;
using EntpClass.WebUI;

public partial class WCS_wh_UcEquipmentScope : ScopeControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override EntpClass.Common.DbRowParameter GetParameter()
    {
        return new Equipment().Parameter;
    }

    protected override string JoinTable(JoinTableParameters p)
    {
        return "";
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!IsPostBack)
        {
            DdlEnable.Text = "-1";
        }
    }
}