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
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

public partial class WCS_wh_UcEquipmentLink : GridControlBase<EquipmentLink>
{
    public string WhId
    {
        get { return Fn.ToString(Request.QueryString["WhId"]); }
    }
    public string TaskTypeId
    {
        get { return Fn.ToString(Request.QueryString["TaskTypeId"]); }
    }


    protected override DataSet GetGridDataSet()
    {
        return EquipmentLink.GetEquipmentLinkList(WhId, TaskTypeId);
    }



    protected override GridView GetGridViewControl()
    {
        return GrdList;
    }



    protected override void SetParameter(GridControlParameter p)
    {
        base.SetParameter(p);
        p.AutoBindControl = true;

    }

    protected override void InitNewRow(GridViewRow r, Hashtable rowCtrlCollection)
    {
        base.InitNewRow(r, rowCtrlCollection);

        DataTable dt = this.GetGridDataSet().Tables[0];

        IWebDataControl seqId = Fn.GetControlByColumnName(rowCtrlCollection, "seq_id");

        int cnt = dt.Rows.Count;

        if (cnt == 0)
        { seqId.SetValue("1"); }
        else
        {
            string nextSeq = (Fn.ToInt(dt.Rows[cnt - 1]["seq_id"]) + 1).ToString();
            seqId.SetValue(nextSeq);
        }

        UcDropDownList DdlEquipment = Fn.GetControlByColumnName(rowCtrlCollection, "equipment_id") as UcDropDownList;
        BindEquipment(DdlEquipment);

    }

    private void BindEquipment(UcDropDownList ddl)
    {
        ddl.DataTextField = "equipment_name";
        ddl.DataValueField = "equipment_id";
        ddl.SqlText = string.Format("select equipment_id,equipment_code+'--'+equipment_name equipment_name from wcs_equipment where wh_id={0} union all select 0 equipment_id,'小车' equipment_name ", WhId);
        ddl.DataBind();
    }

    protected override void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        base.OnRowEditing(sender, e);

        int editIndex = e.NewEditIndex;

        GridView gv = GetGridViewControl();
        GridViewRow r = gv.Rows[editIndex];
        DataSet ds = (DataSet)GetGridViewControl().DataSource;

        PageBase page = this.Page as PageBase;
        page.ClearDataControlCollection();
        page.SetDataControlCollection(r.Controls);
        string equipmentId = Fn.ToString(ds.Tables[0].Rows[editIndex]["equipment_id"]);
        Hashtable dataControlCollection = page.DataControlCollection;
        UcDropDownList DdlEquipment = Fn.GetControlByColumnName(dataControlCollection, "equipment_id") as UcDropDownList;
        BindEquipment(DdlEquipment);

        DdlEquipment.Text = equipmentId;
    }


    protected override bool OnInsert(PageBase page, Database db, DbTransaction transaction)
    {
        UcHiddenField HidWhID = new UcHiddenField();
        HidWhID.ID = "HidWhId";
        HidWhID.ColumnName = "wh_id";
        HidWhID.Value = WhId;
        page.AddControl(HidWhID);


        UcHiddenField HidTaskTypeId = new UcHiddenField();
        HidTaskTypeId.ID = "HidSeq";
        HidTaskTypeId.ColumnName = "task_type_id";
        HidTaskTypeId.RequiredField = true;
        HidTaskTypeId.Value = TaskTypeId;

        page.AddControl(HidTaskTypeId);
        return base.OnInsert(page, db, transaction);
    }
}