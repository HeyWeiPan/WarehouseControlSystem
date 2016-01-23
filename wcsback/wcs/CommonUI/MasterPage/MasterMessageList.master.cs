using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.Common;
using EntpClass.WebUI;

public partial class CommonUI_MasterPage_MasterMessageList : System.Web.UI.MasterPage
{
    protected override void OnLoad(EventArgs e)
    {
        PageBase p = this.Page as PageBase;

        p.SetPageIndex(HidPagerArgument.Value);
        base.OnLoad(e);
    }

    public string GetNavigate(object o)
    {
        return string.Format("javascript:SetPager('{0}');", Fn.ToString(o));
    }

    protected void btnGO_Click(object sender, EventArgs e)
    {

    }
}
