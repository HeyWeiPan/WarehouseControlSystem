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

public partial class CommonUI_WebForm_RightError : PageBase
{
    private string Message
    {
        get { return Fn.ToString(Request.QueryString["Message"]); }
    }   

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        RM rmMs = new RM(ResourceFile.Msg);
        LabRight.Text = rmMs[Message];        
    }

    public override void SetPageInfo(ref PageParameter p)
    {        
    }
}
