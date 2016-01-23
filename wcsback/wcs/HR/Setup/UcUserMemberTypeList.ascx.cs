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

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.HR;
using EntpClass.BizLogic.HR.Setup;
using EntpClass.WebControlLib.Derived;

public partial class HR_Setup_UcUserMemberTypeList : GridControlBase<UserMemberType>
{
    protected override GridView GetGridViewControl()
    {
        return GrdList;
    }

    protected override DataSet GetGridDataSet()
    {
        return UserMemberType.GetUserNumberTypeList();
    }

    protected override void SetParameter(GridControlParameter p)
    {
        base.SetParameter(p);

        p.DialogMode = false;
    }

    //protected override void SetRowRight(GridView gv, GridViewRowEventArgs e, string keyValue, ref bool editRight, ref bool deleteRight)
    //{
    //    if (keyValue == string.Empty)
    //    {
    //        editRight = false;
    //        deleteRight = false;
    //        return;
    //    }

    //    base.SetRowRight(gv, e, keyValue, ref editRight, ref deleteRight);

    //    DataRowView r = e.Row.DataItem as DataRowView;

    //    if (r == null)
    //    {
    //        r = new UserMemberType(keyValue).CurrentRowView;
    //    }

    //    string userNumberTypePrefix = Fn.ToString(r["user_number_type_prefix"]);
    //    int usePrefixCount  =Fn.ToInt(r["use_prefix_count"]);
    //    if (!string.IsNullOrEmpty(userNumberTypePrefix) && usePrefixCount > 0)
    //    {
    //        editRight = false;
    //        deleteRight = false;
    //    }
    //}
}
