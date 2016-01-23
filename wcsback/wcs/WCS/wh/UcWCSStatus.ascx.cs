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
public partial class WCS_wh_UcWCSStatus : GridControlBase<WCSStatus>
{
    protected override DataSet GetGridDataSet()
    {
        return WCSStatus.GetWCSStatusList();
    }



    protected override GridView GetGridViewControl()
    {
        return GrdList;
    }

    protected override void InitNewRow(GridViewRow r, Hashtable rowCtrlCollection)
    {
        base.InitNewRow(r, rowCtrlCollection);
        UcCheckBox enableFlag = Fn.GetControlByColumnName(rowCtrlCollection, "enable_flag") as UcCheckBox;
        enableFlag.Checked = true;

        UcTextBox txtShowOrder = Fn.GetControlByColumnName(rowCtrlCollection, "show_order") as UcTextBox;
        txtShowOrder.Text = "999";
    }

    protected override void SetParameter(GridControlParameter p)
    {
        base.SetParameter(p);
        p.AutoBindControl = true;
        
            }
}