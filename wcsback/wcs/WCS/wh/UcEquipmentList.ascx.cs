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

public partial class WCS_wh_UcEquipmentList : GridControlBase<Equipment>
{
    public string WhId
    {
        get { return Fn.ToString(Request.QueryString["WhId"]); }
    }


    protected override DataSet GetGridDataSet()
    {
        return Equipment.GetWHEquipmentList(WhId);
    }



    protected override GridView GetGridViewControl()
    {
        return GrdList;//包含asrv_code和enable_flag两个模板框，均用自己写的gridView
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
        w.AddUrlParameter("WhId", WhId);
    }
}