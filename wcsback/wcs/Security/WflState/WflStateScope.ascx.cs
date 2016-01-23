using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.Security;
using EntpClass.BizLogic.Workflow;

public partial class Security_WflState_WflStateScope : ScopeControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override DbRowParameter GetParameter()
    {
        WflState w =new WflState();
        return w.Parameter;
    }

    protected override string JoinTable(JoinTableParameters p)
    {
        throw new NotImplementedException();
    }
}