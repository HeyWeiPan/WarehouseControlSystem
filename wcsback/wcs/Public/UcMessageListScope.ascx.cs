using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using EntpClass.BizLogic.Msg;

public partial class Public_UcMessageListScope : ScopeControlBase
{

    protected override EntpClass.Common.DbRowParameter GetParameter()
    {
        return new MsgReceive().Parameter;
    }

    protected override string JoinTable(JoinTableParameters p)
    {
        return string.Empty;
    }
}