using EntpClass.WebUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.BizLogic.WCS;
public partial class WCS_TCPTest : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public override void SetPageInfo(ref EntpClass.Common.PageParameter p)
    {
        
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        BtnClick.Click += BtnClick_Click;
    }

    void BtnClick_Click(object sender, EventArgs e)
    {
        WCSTCP tcp=new WCSTCP();
        string msg = tcp.SendCmd();

        TxtReceive.Text = msg;
    }
}