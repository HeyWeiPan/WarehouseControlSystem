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

public partial class WCS_wh_UcFloorList : GridControlBase<WCSFloor>//仓库明细中楼层信息gridView，包括三列
{
    public string WhId
    {
        get { return Fn.ToString(Request.QueryString["WhId"]); }
    }

    protected override DataSet GetGridDataSet()
    {
        return WCSFloor.GetFloorList(WhId);
    }



    protected override GridView GetGridViewControl()
    {
        return GrdList;
    }

    protected override void SetParameter(GridControlParameter p)
    {
        base.SetParameter(p);
        p.AutoBindControl = true;
        p.DialogMode = true;

    }

    protected override void SetDialogWindowParameter(ref DialogWindow w)
    {
        base.SetDialogWindowParameter(ref w);
        w.AddUrlClientObjectParameter("WhId", WhId);
    }
}