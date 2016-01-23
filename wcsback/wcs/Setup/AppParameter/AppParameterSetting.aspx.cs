using System;
using System.Data;
using System.Data.Common;
using System.Text;
using EntpClass.BizLogic.Setup;
using EntpClass.BizLogic.Security;
using EntpClass.Common;
using EntpClass.WebUI;
using Microsoft.Practices.EnterpriseLibrary.Data;

public partial class Setup_AppParameter_AppParameterSetting : PageBase
{
     public override void SetPageInfo(ref EntpClass.Common.PageParameter p)
    {
        //p.FunctionID = Parameter.FunctionID;
        p.FunctionID = 3900160;

    }

    private void BindPageList()
    {
        UcParameterList1.ModuleID = Fn.ToInt(this.DdlModule.Text);
        UcParameterList1.SetGridData();
    }

    protected override bool SupportAutoEvents
    {
        get
        {
            return false;
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!IsPostBack)
        {
            this.DdlModule.SelectedIndex = 1;

            BindPageList();
        }
    }

    protected void BtnView_Click(object sender, EventArgs e)
    {
    }

    protected void DdlModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPageList();
    }
}