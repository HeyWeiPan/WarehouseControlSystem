using System;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Security;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.BizLogic.Security;
using EntpClass.WebControlLib;
using EntpClass.WebControlLib.Derived;

public partial class Security_UcRoleResource : GridControlBase<RoleResource>
{
    public override void InitializeEvents()
    {
        PageBase page = (PageBase)this.Page;
        page.Load += new EventHandler(page_Load);
    }

    void page_Load(object sender, EventArgs e)
    {
        HidRoleId.Value = RoleID;
    }

    private string RoleID
    {
        get
        {
            return Fn.ToString(Request.QueryString["RoleID"]);
        }
    }
  
    private string TypeId
    {
        set 
        { 
            ViewState["RoleResource_TypeId"] = value; 
        }
        get 
        {
            return Fn.ToString(ViewState["RoleResource_TypeId"]); 
        }
    }

    private string InterfaceId
    {
        get
        {
            return ViewState["RoleResource_InterfaceId"].ToString();
        }
        set 
        { 
            ViewState["RoleResource_InterfaceId"] = value; 
        }        
    }

    private void BindDdlSetMember(int flag, string InterfaceId, string sql)
    {
        UcDropDownList DdlSetMember = null;

        if (flag == 0)
            DdlSetMember = ((UcDropDownList)GetGridViewControl().Rows[GetGridViewControl().EditIndex].FindControl("DdlSetMember"));
        else
            DdlSetMember = ((UcDropDownList)GetGridViewControl().FooterRow.FindControl("DdlSetMemberAdd"));

        if (sql == string.Empty)
            sql = ResourceType.GeStringSqlSetMember(TypeId, InterfaceId);

        if (sql == string.Empty)
            DdlSetMember.Visible = false;
        else
        {
            DataSet ds = ResourceType.GetSourceSqlSetMember(sql);
            if (ds.Tables[0].Rows.Count == 0)
                DdlSetMember.Visible = false;
            else
            {
                DdlSetMember.Visible = true;

                DdlSetMember.DataSource = ds;
                DdlSetMember.DataBind();
            }
        }
    }

    private void BindDdlInterface(int flag, string TypeId)
    {
        UcDropDownList DdlInterface = null;

        if (flag == 0)
            DdlInterface = ((UcDropDownList)GetGridViewControl().Rows[GetGridViewControl().EditIndex].FindControl("DdlInterface"));
        else
            DdlInterface = ((UcDropDownList)GetGridViewControl().FooterRow.FindControl("DdlInterfaceAdd"));

        DdlInterface.DataSource = ResourceType.GetSourceResourceInterface(TypeId);
        DdlInterface.DataBind();
    }

    private void OperateCurrentItem()
    {
        int editIndex = GetGridViewControl().EditIndex;

        if (editIndex != -1)//Edit
        {
            DataSet ds = (DataSet)GetGridViewControl().DataSource;

            UcDropDownList DdlType = ((UcDropDownList)GetGridViewControl().Rows[GetGridViewControl().EditIndex].FindControl("DdlType"));
            UcDropDownList DdlInterface = ((UcDropDownList)GetGridViewControl().Rows[GetGridViewControl().EditIndex].FindControl("DdlInterface"));

            TypeId = ds.Tables[0].Rows[editIndex]["resource_type"].ToString().Trim();
            InterfaceId = ds.Tables[0].Rows[editIndex]["resource_interface_id"].ToString().Trim();

            OperateCurrentItem(TypeId, InterfaceId, DdlType, DdlInterface);

            String setMemberSql = Fn.ToString(ds.Tables[0].Rows[editIndex]["set_member_sql"]);

            BindDdlSetMember(0, InterfaceId, setMemberSql);
        }

        if (GetGridViewControl().ShowFooter)//Add
        {
            UcDropDownList DdlType = (UcDropDownList)GetGridViewControl().FooterRow.FindControl("DdlTypeAdd");
            UcDropDownList DdlInterface = (UcDropDownList)GetGridViewControl().FooterRow.FindControl("DdlInterfaceAdd");

            TypeId = ((UcDropDownList)GetGridViewControl().FooterRow.FindControl("DdlTypeAdd")).SelectedValue;
            InterfaceId = ((UcDropDownList)GetGridViewControl().FooterRow.FindControl("DdlInterfaceAdd")).SelectedValue;

            OperateCurrentItem(TypeId, InterfaceId, DdlType, DdlInterface);

            BindDdlSetMember(-1, InterfaceId, string.Empty);
        }
    }

    private void OperateCurrentItem(string typeID, string interfaceID, UcDropDownList DdlType, UcDropDownList DdlInterface)
    {
        DdlType.Text = typeID;

        DdlInterface.DataSource = ResourceType.GetSourceResourceInterface(typeID);
        DdlInterface.DataBind();

        DdlInterface.Text = interfaceID;
    }

    public String GetResourceTypeSQL
    {
        get
        {
            return "select resource_type,description as description_type From scr_resource_type order by resource_type";
        }
    }

    public String GetResourceInterfaceSQL
    {
        get
        {
            return "select resource_interface_id,description_en as description_interface from Scr_Resource_Interface order by resource_interface_id";
        }
    }

    public string GetMemberSQL
    {
        get
        {
            return "select resource_interface_id data_value,set_member_sql data_text from Scr_Resource_Interface order by resource_interface_id";
        }
    }
      
    protected override bool OnPreSave(PageBase page, GridViewRow row, bool isInsert, string keyValue)
    {
        //存放DropDownList中的DataText
        UcDropDownList DdlSetMember = null;
        if (isInsert)
            DdlSetMember = ((UcDropDownList)row.FindControl("DdlSetMemberAdd"));
        else
            DdlSetMember = ((UcDropDownList)row.FindControl("DdlSetMember"));

        if (DdlSetMember.Visible)
            this.HidDescription.Value = DdlSetMember.SelectedItem.Text;
        else
            this.HidDescription.Value = string.Empty;

        page.AddControl(HidRoleId);
        page.AddControl(HidDescription);

        return base.OnPreSave(page, row, isInsert, keyValue);
    }

    protected override GridView GetGridViewControl()
    {
        return GrdRoleResource;
    }

    protected override DataSet GetGridDataSet()
    {
        return RoleResource.GetResourceByRole(RoleID); ;
    }

    protected override void InitNewRow(GridViewRow gridViewRow, Hashtable dataControlCollection)
    {
        base.InitNewRow(gridViewRow, dataControlCollection);

        OperateCurrentItem();
    }

    protected override void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        base.OnRowEditing(sender, e);

        OperateCurrentItem();
    }
    
    protected void DdlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        TypeId = ((UcDropDownList)sender).SelectedValue.ToString().Trim();
        BindDdlInterface(0, TypeId);

        InterfaceId = ((UcDropDownList)GetGridViewControl().Rows[GetGridViewControl().EditIndex].FindControl("DdlInterface")).SelectedValue.ToString().Trim();
        BindDdlSetMember(0, InterfaceId, string.Empty);
    }

    protected void DdlTypeAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        TypeId = ((UcDropDownList)sender).SearchValue.ToString().Trim();
        BindDdlInterface(-1, TypeId);

        InterfaceId = ((UcDropDownList)GetGridViewControl().FooterRow.FindControl("DdlInterfaceAdd")).SelectedValue.ToString().Trim();
        BindDdlSetMember(-1, InterfaceId, string.Empty);
    }

    protected void DdlInterface_SelectedIndexChanged(object sender, EventArgs e)
    {
        InterfaceId = ((UcDropDownList)sender).SelectedValue.ToString();
        BindDdlSetMember(0, InterfaceId, string.Empty);
    }    

    protected void DdlInterfaceAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        InterfaceId = ((UcDropDownList)sender).SelectedValue.ToString();
        BindDdlSetMember(-1, InterfaceId, string.Empty);
    }    
}
