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

public partial class Setup_AppInformation : PageBase
{
    private void SetPageRight()
    {
        if (!PageRight.HasEditOperation)
        {
            BtnEdit.Visible = false;
        }
        else if (!PageRight.EditRight)
        {
            BtnEdit.Enabled = false;
        }
    }

    private void SetReadOnly(bool isReadOnly, ControlCollection collection)
    {
        foreach (DictionaryEntry dic in DataControlCollection)
        {
            IWebDataControl dc = (IWebDataControl)dic.Value;
            dc.SetReadOnly(isReadOnly);
        }

        TxtVersion.SetReadOnly(true);
    }

    private void SetSwitchOperate(bool isEnabled)
    {        
        UcAppInformationTabs1.SetTabEnabled(isEnabled);

        SetReadOnly(isEnabled, this.Controls);

        BtnEdit.Enabled = isEnabled;       
        BtnSave.Visible = !isEnabled;
        BtnCancel.Visible = !isEnabled;
    }

    private AppInformation _RowData = null;
   
    public AppInformation RowData
    {
        get
        {
            if (_RowData == null)
            {
                _RowData = new AppInformation(AppInformation.CorpID.ToString());//不需要用 KeyValue 取数据,系统中有且只有一行数据             
            }

            return _RowData;
        }
    }        

    public override void SetPageInfo(ref PageParameter p)
    {
        p.FunctionID = AppInformation.FunctionID;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!IsPostBack)
        {
            SetReadOnly(true, this.Controls);            
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        SetPageRight();
        SetControlValue(RowData);
    }

    protected void BtnEdit_Click(object sender, EventArgs e)
    {
        SetSwitchOperate(false);
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        SetSwitchOperate(true);
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TxtCorpname.Text))
        {
            Alert((new RM(ResourceFile.Msg))["PleaseInput"] + ":" + (new RM(ResourceFile.Database))["corp_name"]);
            return;
        }

        SetSwitchOperate(true);

        bool b = RowData.Update(DataControlCollection);
        if (b)
            Alert((new RM(ResourceFile.Msg))["SaveSuccess"]);
        else
            Alert((new RM(ResourceFile.Msg))["SaveFailed"]);
    }
}
