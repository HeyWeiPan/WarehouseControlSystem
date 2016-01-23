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

public partial class WCS_asrv_UcAsrvStatusList : GridControlBase<WCSAsrv>
{
    public string AsrvId
    {
        get { return Fn.ToString(Request.QueryString["AsrvId"]); }
    }

    protected override DataSet GetGridDataSet()
    {
        return WCSAsrv.GetAsrvStatusList(AsrvId);
    }



    protected override GridView GetGridViewControl()
    {
        return GrdList;
    }

    protected override void SetParameter(GridControlParameter p)
    {
        base.SetParameter(p);
        p.AutoBindControl = true;
        p.AddRight = false;
        p.EditRight = false;
        p.DeleteRight = false;

    }

}