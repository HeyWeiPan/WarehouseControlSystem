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
//using EntpClass.BizLogic.JXC.Base;

public partial class Home_UcTopTitle : System.Web.UI.UserControl
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

//#if DEBUG       
//        //this.lblTitle.InnerText = "Testing...";
//#else
        string appName = AppSetting.GetAppName();
        this.lblTitle.InnerText = appName;
//#endif      
    }
}
