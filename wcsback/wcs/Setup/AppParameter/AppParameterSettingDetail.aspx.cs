using System;
using System.Data;
using System.Text;
using System.Web.UI;
using EntpClass.WebUI;
using EntpClass.BizLogic.Setup;
using EntpClass.Common;

public partial class Setup_AppParameter_AppParameterSettingDetail : SetUpDetailPageBase<AppParameter>
{
    public override void InitializeEvents()
    {
        PageBase page = (PageBase)this.Page;
        // page.PageModeChanged += new EventHandler<PageModeChangedEventArgs>(page_PageModeChanged);
        // page.PreSave += new System.ComponentModel.CancelEventHandler(page_PreSave);
        page.PreRender += new EventHandler(Page_PreRender);
    }


    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        string datatype = Fn.ToString(RowData["data_type"]).ToLower();

        if (CurrentPageMode == PageMode.Add || CurrentPageMode == PageMode.Edit)
        {
            TRDataText.Visible = false;
            TRValue.Visible = false;
            TRDatePicker.Visible = false;
            TRCheck.Visible = false;
            if (datatype == "date")
            {
                TRDatePicker.Visible = true;
                DpkValue.RequiredField = true;
                try
                {
                    DpkValue.Text = DateTime.Parse(DpkValue.Text).ToString(AppSetting.DateFormat).ToString();
                }
                catch
                {
                    DpkValue.Text = "";
                }
            }
            else if (datatype == "bool")
            {
                TRCheck.Visible = true;
                ChkValue.RequiredField = true;
            }
            else
            {
                TxtValue.RequiredField = true;
                TRValue.Visible = true;
            }
        }
        else
        {
            TRValue.Visible = false;
            TRDatePicker.Visible = false;
            TRCheck.Visible = false;
            TRDataText.Visible = true;
        }

    }

    protected override PageRights GetPageRight()
    {
        PageRights p = base.GetPageRight();

        p.AddRight = false;
        p.HasAddOperation = false;

        return p;
    }

    protected override bool OnUpdate(DBRowBase r)
    {
        string datatype = Fn.ToString(RowData["data_type"]).ToLower();
        string datavalue = "";
        string datatext = "";

        if (datatype == "date")
        {
            try
            {
                datavalue = DateTime.Parse(DpkValue.Text).ToString("yyyy/MM/dd");
                datatext = datavalue;
            }
            catch
            {
                RM rm = new RM(ResourceFile.Msg);
                SetUpDetailPageBase<AppParameter> page = (SetUpDetailPageBase<AppParameter>)this.Page;
                page.Alert(rm["DataTypeError"]);
                DpkValue.Text = "";
                return false;
            }
        }
        else if (datatype == "bool")
        {
            if (ChkValue.Checked)
            {
                datavalue = "-1";
                datatext = "是";
            }
            else
            {
                datavalue = "0";
                datatext = "否";
            }
        }
        else if (datatype == "number")
        {
            try
            {
                datavalue = double.Parse(TxtValue.Text).ToString();
                datatext = datavalue;
            }
            catch
            {
                RM rm = new RM(ResourceFile.Msg);
                SetUpDetailPageBase<AppParameter> page = (SetUpDetailPageBase<AppParameter>)this.Page;
                page.Alert(rm["DataTypeError"]);
                TxtValue.Text = "";
                return false;
            }
        }
        else
        {
            datavalue = TxtValue.Text;
            datatext = datavalue;
        }

        return AppParameter.SetAppParameterValue(KeyValue, datavalue, datatext);
    }
}