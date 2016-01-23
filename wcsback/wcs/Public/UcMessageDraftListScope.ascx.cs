using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using EntpClass.BizLogic.Msg;
using EntpClass.Common;

public partial class Public_UcMessageDraftListScope : ScopeControlBase
{
    protected override EntpClass.Common.DbRowParameter GetParameter()
    {
        return new MsgSend().Parameter;
    }

    protected override string JoinTable(JoinTableParameters p)
    {
        return string.Empty;
    }

    protected override void OnAppendWhereSql(AppendSqlParameter p)
    {
        base.OnAppendWhereSql(p);

        p.SqlToAppend = string.Format(" send_user_id = {0}", CurrentUser.UserID);
    }
        
}