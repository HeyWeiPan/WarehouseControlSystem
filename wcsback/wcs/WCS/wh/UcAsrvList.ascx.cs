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

public partial class WCS_wh_UcAsrvList : GridControlBase<WCSAsrv>//仓库明细中小车信息gridView
{
    public string WhId
    {
        get { return Fn.ToString(Request.QueryString["WhId"]); }
    }

    public string Rack
    {
        get { return Fn.ToString(Request.QueryString["Rack"]); }
    }

    protected override DataSet GetGridDataSet()
    {
        return WCSAsrv.GetAsrvList(WhId);
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
        w.AddUrlParameter("Rack", Rack);
    }
}