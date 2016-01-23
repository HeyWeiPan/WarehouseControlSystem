using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.WebUI;
using EntpClass.BizLogic.WCS;
using System.Data;
using System.Data.Common;
using System.Text;

public partial class WCS_wh_EquipmentDetail : SetUpDetailPageBase<Equipment>
{
    public string WhId
    {
        get { return Fn.ToString(Request.QueryString["WhId"]); }
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        bool isEdit = false;
        if (CurrentPageMode == PageMode.Add || CurrentPageMode == PageMode.Edit)
        {
            isEdit = true;
        }

        DdlWh.Visible = isEdit;
        LnkWh.Visible = !isEdit;

        if (WhId != "")
            DdlWh.Text = WhId;



        RegditDetailScript();



    }

    public override void SetControlValue(DBRowBase r)
    {
        base.SetControlValue(r);
        LnkWh.Text = Fn.ToString(r["wh_code"]);
        LnkWh.OnClientClick = string.Format("ShowWh('VIEW','{0}');return false;", r["wh_id"]);
    }


    public void RegditDetailScript()
    {
        if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegditDetailScript"))
        {
            StringBuilder s = new StringBuilder(1000);
            WCSWH w = new WCSWH();
            DialogWindow dw = w.DetailDialogWindow;
            s.Append(PageBase.GetShowDialogWindowClientFunction(dw, "ShowWh"));

            ClientScript.RegisterClientScriptBlock(this.GetType(), "RegditDetailScript", s.ToString(), true);

        }
    }

}