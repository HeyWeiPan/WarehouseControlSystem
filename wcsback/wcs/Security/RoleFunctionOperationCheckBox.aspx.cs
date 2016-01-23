using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.BizLogic.Security;

public partial class Security_RoleFunctionOperationCheckBox : PageBase
{
    public override void InitializeEvents()
    {
        PageBase page = (PageBase)this.Page;
        page.Load += new EventHandler(page_Load);
    }

    void page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet dsSource = FunctionOperation.GetFunctionOperation(FunctionId);//得到指菜单下所有的操作

            this.ChkListOperation.DataSource = dsSource;//将菜单下所有的操作绑定至checkBox组
            this.ChkListOperation.DataBind();

            int iFlag = 0;

            DataSet dsEdit = RoleFunctionOperation.GetRoleFunctionOperation(Fn.ToInt(RoleId), FunctionId);//得到指定角色,菜单ID下的被选中的功能
            ViewState["dtRoleFunctionOperation"] = dsEdit.Tables[0];

            for (int i = 0; i < dsEdit.Tables[0].DefaultView.Count; i++)
            {
                string operationID = Fn.ToString(dsEdit.Tables[0].DefaultView[i]["Operation_ID"]);
                for (int j = 0; j < ChkListOperation.Items.Count; j++)
                {
                    if (ChkListOperation.Items[j].Value == operationID)
                    {
                        iFlag++;
                        ChkListOperation.Items[j].Selected = true;
                        break;
                    }
                }
            }

            if (dsSource.Tables[0].Rows.Count == 0)
            {
                this.LabState.Text = "this function doesn't have any operation";
                SetVisible(true);
            }
            else
            {
                this.LabState.Text = string.Empty;
                SetVisible(false);
            }
        }
    }

    private string Mode
    {
        get
        {
            return Fn.ToString(Request.QueryString["mode"]);
        }       
    }
    
    private string RoleId
    {
        get
        {
            return Fn.ToString(Request.QueryString["RoleID"]);
        }       
    }
    
    private string FunctionId
    {
        get
        {
            return Fn.ToString(Request.QueryString["FunctionID"]);
        }      
    }
   
    private void SetVisible(bool b)
    {
        this.LabState.Visible = b;
        this.BtnSave.Visible = !b;
    }

    public override void SetPageInfo(ref PageParameter p) { }
   
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        DataTable dtRoleOperation = (DataTable)ViewState["dtRoleFunctionOperation"];//指定角色,菜单ID下的被选中的功能
        DataColumn[] col = { dtRoleOperation.Columns[3] };
        dtRoleOperation.PrimaryKey = col;

        int iFlag = 0;
        string operation_id = null;
        DataRow drRoleOperation = null;

        DataSet dsNew = new DataSet();
        DataTable dtNew = dtRoleOperation.Clone();
        RoleFunctionOperation role = new RoleFunctionOperation();

        #region
        for (int j = 0; j < ChkListOperation.Items.Count; j++)
        {
            if (ChkListOperation.Items[j].Selected == true)
            {                
                operation_id = ChkListOperation.Items[j].Value;//得到当前选中的checkbox对应的值                
                drRoleOperation = dtRoleOperation.Rows.Find(new object[] {operation_id });//在原始的DataTable中找到对应的值:create_by/create_date
                
                DataRow drNew = dtNew.NewRow();//在用于底层更新的DataTable中将当前行添加进去                
                //获取主键值
                //已经使用自动编号
                drNew["map_id"] = role.GetNewKeyValue();                
                drNew["role_id"] = RoleId;
                drNew["function_id"] = FunctionId;
                drNew["operation_id"] = Fn.ToInt(operation_id);

                if (drRoleOperation == null)
                {
                    drNew["create_by"] = Fn.ToString(CurrentUser.UserID);
                    drNew["create_date"] = DateTime.Now.Date;
                }
                else
                {
                    drNew["create_by"] = drRoleOperation["create_by"];
                    drNew["create_date"] = drRoleOperation["create_date"];
                }

                drNew["last_update_by"] = Fn.ToString(CurrentUser.UserID);
                drNew["last_update_date"] = DateTime.Now.Date;

                dtNew.Rows.Add(drNew);

                iFlag++;
            }
        }
        #endregion

        dsNew.Tables.Add(dtNew);

        if (String.Equals(Mode,"Add",StringComparison.OrdinalIgnoreCase))
        {
            
            if (iFlag == 0)//当前checkbox没有选中项
            {
                if (dtRoleOperation.Rows.Count == 0)//角色下没有操作
                {                    
                    //Alert("");
                }
                else  //角色下有操作
                {                    
                    RoleFunctionOperation.SaveRoleFunction(Fn.ToInt(RoleId), FunctionId,CurrentUser.UserID, -1, dsNew);
                }
            }
            else
            {
                RoleFunctionOperation.SaveRoleFunction(Fn.ToInt(RoleId), FunctionId, CurrentUser.UserID, - 1, dsNew);
            }
        }
        else if (String.Equals(Mode, "Edit", StringComparison.OrdinalIgnoreCase))
        {
            RoleFunctionOperation.SaveRoleFunction(Fn.ToInt(RoleId), FunctionId,CurrentUser.UserID, 0, dsNew);
        }

        RM rm = new RM(ResourceFile.Msg);

        Alert(rm["SaveSuccess"]);
    }  
}
