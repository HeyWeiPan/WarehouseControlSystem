using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.Setup;

public partial class Setup_LookUpMaster : PageBase
{
    public override void SetPageInfo(ref PageParameter p)
    {
        p.FunctionID = AppValue.FUNCTIONID;
    }

    private void BindPageList()
    {
        UcLookUpList1.ValueSetCode = DrpValueSetCode.Text;
        UcLookUpList1.SetGridData();       
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
            DrpValueSetCode.SelectedIndex = 1;

            BindPageList();
        }
    }

    protected void BtnView_Click(object sender, EventArgs e)
    {
    }

    protected void DrpValueSetCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPageList();
    }
}
