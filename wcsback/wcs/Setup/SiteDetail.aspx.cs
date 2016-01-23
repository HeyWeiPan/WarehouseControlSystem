using System;
using System.Text;
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
using EntpClass.WebControlLib;
using EntpClass.BizLogic.Setup;

public partial class Setup_SiteDetail : SetUpDetailPageBase<SiteProfile>
{
    protected override bool SupportAutoEvents
    {
        get
        {
            return false;
        }
    }
}
