using System;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.BizLogic.HR;
using EntpClass.BizLogic.HR.Setup;

public partial class HR_Setup_UcCostCenterList : GridControlBase<CostCenter>
{
    protected override GridView GetGridViewControl()
    {
        return GrdList;
    }

    protected override DataSet GetGridDataSet()
    {
        string proc = "HR.GetCostCenterList";
        Database db = DatabaseFactory.CreateDatabase(HRConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        DataSet ds = db.ExecuteDataSet(cmd);
        return ds;
    }

    protected override void SetParameter(GridControlParameter p)
    {
        p.DialogMode = false;
    } 
}
