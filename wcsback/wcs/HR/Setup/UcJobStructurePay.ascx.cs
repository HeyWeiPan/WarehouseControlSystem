using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.Security;
using EntpClass.BizLogic.HR.Setup;

public partial class HR_Setup_UcJobStructurePay : UserControlBase
{
    private void RegisterSetPayScript()
    {
        PageBase page = this.Page as PageBase;
        StringBuilder s = new StringBuilder(1000);

        s.Append("function onSetPay(xmlDoc)");
        s.Append("{");
        s.Append("var oXML = f_loadXML(xmlDoc);");

        page.SetDataControlCollection(this.Controls);

        foreach (DictionaryEntry dic in page.DataControlCollection)
        {
            IWebDataControl ctrl = dic.Value as IWebDataControl;
            if (ctrl is UcTextBox)
            {
                UcTextBox txtCtrl = ctrl as UcTextBox;
                if (txtCtrl.Visible)
                {
                    s.AppendFormat("document.getElementById('{0}').value=f_getXMLNodeValue(oXML,'{1}');\n", txtCtrl.ClientID, ctrl.ColumnName.ToUpper());
                }
            }                        
        }

        s.Append("}");

        page.ClearDataControlCollection();
        Page.ClientScript.RegisterClientScriptBlock(GetType(), "RegisterSetPayScript", s.ToString(), true);
    }

    public override void InitializeEvents()
    {
        base.InitializeEvents();

        PageBase page = (PageBase)this.Parent.Page;
        page.PageModeChanged += new EventHandler<PageModeChangedEventArgs>(page_PageModeChanged);        
    }

    void page_PageModeChanged(object sender, PageModeChangedEventArgs e)
    {
        DdlPayGrade.Visible = true;
        TxtPayGrade.Visible = false;

        bool payRight = RightHelper.CheckFuncRightCached(JobStructure.PayFuncID, OperationCode.EDIT);        
        TxtPayGrade.ReadOnlyWhenUpdate = !payRight;
        
        if (e.NewPageMode == PageMode.View || !payRight)
        {
            DdlPayGrade.Visible = false;
            TxtPayGrade.Visible = true;
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        
        PageBase page = (PageBase)this.Page;
        bool payRight = RightHelper.CheckFuncRightCached(JobStructure.PayFuncID, OperationCode.EDIT);

        if (page.CurrentPageMode != PageMode.View && payRight)
        {            
            RegisterSetPayScript();
        }
    }
}
