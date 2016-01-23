using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.BizLogic.WCS;
using EntpClass.WebUI;
using System.Data;
using EntpClass.WebControlLib;
using System.Collections;
using EntpClass.Common;

public partial class WCS_wh_UcLiftList : GridControlBase<WCSLift>//仓库明细中电梯信息gridView，包括四列
{
    public string WhId
    {
        get { return Fn.ToString(Request.QueryString["WhId"]); }
    }

    protected override DataSet GetGridDataSet()
    {
        return WCSLift.GetWHLiftList(WhId);
    }



    protected override GridView GetGridViewControl()
    {
        return GrdList;
    }

    protected override void SetParameter(GridControlParameter p)
    {
        base.SetParameter(p);
        p.AutoBindControl = true;
    }

    protected override bool OnInsert(PageBase page, Microsoft.Practices.EnterpriseLibrary.Data.Database db, System.Data.Common.DbTransaction transaction)
    {

        UcHiddenField HidWhId = new UcHiddenField();
        HidWhId.ID = "HidDJID";
        HidWhId.ColumnName = "wh_id";
        HidWhId.Value = WhId;
        page.AddControl(HidWhId);
        return base.OnInsert(page, db, transaction);
    }
}