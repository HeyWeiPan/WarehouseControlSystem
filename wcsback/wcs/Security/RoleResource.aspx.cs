using System;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Security;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.BizLogic.Security;
using EntpClass.WebControlLib.Derived;

public partial class Security_RoleResource : PageBase
{    
    public override void SetPageInfo(ref PageParameter p)
    {
        p.FunctionID = RoleResource.FunctionID;
    }
}
