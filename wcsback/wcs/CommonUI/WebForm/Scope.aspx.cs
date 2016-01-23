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

public partial class CommonUI_WebForm_Scope : DialogPageBase
{
    private ScopeControlBase _ScopeUC = null;

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        //获取scope usercontrol的路径
        string scopeUCPath = Request.QueryString["ScopeUCPath"];

        _ScopeUC = (ScopeControlBase)Page.LoadControl(scopeUCPath);
       
        P1.Controls.Add(_ScopeUC);
    }    

    public override void SetPageInfo(ref PageParameter pageSetting)
    {
        return;
    }

    protected void BtnOK_Click(object sender, EventArgs e)
    {
        if (_ScopeUC.DoSearch())
        {
            Close();
        }
    }
}
