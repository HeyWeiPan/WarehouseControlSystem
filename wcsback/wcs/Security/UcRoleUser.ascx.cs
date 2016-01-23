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
using EntpClass.WebControlLib;
using EntpClass.WebControlLib.Derived;

public partial class Security_UcRoleUser : GridControlBase<RoleUser>
{
    private int RoleID
    {
        get
        {
            return Fn.ToInt(Request.QueryString["RoleID"]);
        }
    }

    protected override GridView GetGridViewControl()
    {
        return GrdList;
    }

    protected override void InitNewRow(GridViewRow gridViewRow, Hashtable dataControlCollection)
    {
        base.InitNewRow(gridViewRow, dataControlCollection);
        UcHiddenField HidRoleID = dataControlCollection["HidRoleID"] as UcHiddenField;
        HidRoleID.Value = RoleID.ToString();
    }

    protected override DataSet GetGridDataSet()
    {
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetSqlStringCommand(RoleUser.GetRoleUserListSQLByRoleID(RoleID));
        DataSet ds = db.ExecuteDataSet(cmd);

        return ds;
    }

    protected override void SetParameter(GridControlParameter p)
    {
        base.SetParameter(p);
        p.EditRight = false;

        //can not add or delete when current role is system role
        if (Role.IsSystemRole(RoleID))
        {
            p.AddRight = false;
            p.DeleteRight = false;
        }
    }
}
