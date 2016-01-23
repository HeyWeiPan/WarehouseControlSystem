using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Security;

using EntpClass.WebUI;
using EntpClass.Common;

public partial class HR_PopUp_InfoList : PageBase
{
    private string SuccessRowIds
    {
        get
        {
            return Fn.ToString(this.Request.QueryString["SuccessRowIds"]);
        }
    }

    private string FailedRowIds
    {
        get
        {
            return Fn.ToString(this.Request.QueryString["FailedRowIds"]);
        }
    }

    protected override bool SupportAutoEvents
    {
        get
        {
            return false;
        }
    }

    public override void SetPageInfo(ref PageParameter p)
    {        
    }
}
