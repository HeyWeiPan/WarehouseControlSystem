using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.Common;
using EntpClass.WebUI;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.HR;
using EntpClass.BizLogic.HR.PayRoll;
using EntpClass.WebControlLib.Derived.HR;

public partial class HR_UserProfile_UcUserPayInitValueList : GridControlBase<PaySetInitItem>
{
    private int UserId
    {
        get { return Fn.ToInt(Request.QueryString["UserId"]); }
    }

    private int PaySetId
    {
        get { return Fn.ToInt(Request.QueryString["PaySetId"]); }
    }

    protected override GridView GetGridViewControl()
    {
        return GrdList;
    }

    protected override DataSet GetGridDataSet()
    {
        DataSet ds = UserPayInitValue.GetUserPayInitValueList(UserId, PaySetId);
        return ds;
    }

    protected override void SetParameter(GridControlParameter p)
    {
        base.SetParameter(p);        
        p.AddRight = false;
        p.EditRight = false;
        p.DeleteRight = false;        
    }
}
