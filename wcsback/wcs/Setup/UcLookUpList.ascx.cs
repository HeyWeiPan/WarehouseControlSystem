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
using EntpClass.BizLogic.Setup;
using EntpClass.WebControlLib;

public partial class Setup_UcLookUpList : GridControlBase<AppValue>
{      
    public string ValueSetCode
    {
        get
        {
            object obj2 = this.ViewState["ValueSetCode"];
            if (obj2 != null)
            {
                return (string)obj2;
            }

            return "";
        }
        set
        {
            this.ViewState["ValueSetCode"] = value;
        }
    }    

    protected override bool SupportAutoEvents
    {
        get
        {
            return false;
        }
    }

    protected override GridView GetGridViewControl()
    {
        return GrdList;
    }

    protected override DataSet GetGridDataSet()
    {
        DataSet ds = AppValue.GetAppValueList(ValueSetCode);

        return ds;
    }

    protected override void InitNewRow(GridViewRow gridViewRow, Hashtable dataControlCollection)
    {
        base.InitNewRow(gridViewRow, dataControlCollection);

        UcLabel LabSeqId = (UcLabel)gridViewRow.Cells[0].Controls[1];
        IWebDataControl TxtShowder = Fn.GetControlByColumnName(dataControlCollection, "show_order");
        IWebDataControl ChkEnabled = Fn.GetControlByColumnName(dataControlCollection, "enable_flag");

        //
        int seqId = AppValue.GetSeqId(ValueSetCode);
        string showOrder = Fn.ToString((seqId * 10));

        LabSeqId.Text = Fn.ToString(seqId);
        TxtShowder.SetValue(showOrder);
        ChkEnabled.SetValue("-1");
    }

    protected override bool OnPreSave(PageBase page, GridViewRow row, bool isInsert, string keyValue)
    {
        Hashtable dataControlCollection = page.DataControlCollection;

        UcLabel LabSeqId = (UcLabel)row.Cells[0].Controls[1];

        //seq_id
        UcHiddenField HidSeqId = new UcHiddenField();
        HidSeqId.ID = "HidSeqId";
        HidSeqId.ColumnName = "seq_id";
        HidSeqId.RequiredField = true;
        HidSeqId.Value = LabSeqId.Text;

        //valueset_code
        UcHiddenField HidValueSetCode = new UcHiddenField();
        HidValueSetCode.ID = "HidValueSetCode";
        HidValueSetCode.ColumnName = "valueset_code";
        HidValueSetCode.RequiredField = true;
        HidValueSetCode.Value = ValueSetCode;

        //value_code
        UcHiddenField HidValueCode = new UcHiddenField();
        HidValueCode.ID = "HidValueCode";
        HidValueCode.ColumnName = "value_code";
        HidValueCode.RequiredField = true;
        HidValueCode.Value = ValueSetCode + "_" + LabSeqId.Text;

        //value_code
        UcHiddenField HidValueDesc = new UcHiddenField();
        HidValueDesc.ID = "HidValueDesc";
        HidValueDesc.ColumnName = "value_desc";
        UcTextBox TxtValueName = Fn.GetControlByColumnName(dataControlCollection, "value_name") as UcTextBox;
        UcTextBox TxtValueNameEn = Fn.GetControlByColumnName(dataControlCollection, "value_name_en") as UcTextBox;
        if (TxtValueNameEn.Text.Trim() == string.Empty)
        {
            HidValueDesc.Value = TxtValueName.Text;
        }
        else
        {
            HidValueDesc.Value = string.Format("{0}({1})", TxtValueName.Text, TxtValueNameEn.Text);
        }

        page.AddControl(HidSeqId);
        page.AddControl(HidValueSetCode);
        page.AddControl(HidValueCode);
        page.AddControl(HidValueDesc);

        return base.OnPreSave(page, row, isInsert, keyValue);
    }
}
