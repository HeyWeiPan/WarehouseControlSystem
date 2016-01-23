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
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EntpClass.Common;
using EntpClass.BizLogic.Security;
using EntpClass.WebUI;
using System.Diagnostics;

public partial class Security_FunctionDefinitionDetail : SetUpDetailPageBase<ScrFunction>
{
    public override void InitializeEvents()
    {
        PageBase page = (PageBase)this.Page;
        page.Load += new EventHandler(page_Load);
    }

    void page_Load(object sender, EventArgs e)
    {
        if (!AppSetting.UseMultiLanguage)
        {
            //确保trMenuNameEN中的控件在visible属性设为false后仍加入到datacontrolcollection中
            this.SetDataControlCollection();

            trMenuNameEN.Visible = false;
            LblMenuName.ColumnName = "FUNCTION_NAME";
            //TxtMenuNameEN.UpdateExpression = TxtMenuNameCN.ColumnName;
            //TxtMenuNameEN.InsertExpression = TxtMenuNameCN.ColumnName;
        }


        this.HideNavigator();
    }

    protected override void OnPageModeChanged(PageModeChangedEventArgs arg)
    {
        base.OnPageModeChanged(arg);
        if (CurrentPageMode == PageMode.Add && !Page.IsPostBack)
        {
            TxtParentFunctionID.Text = Request.Params["KeyValue"];

            TxtParentFunctionName.Text = ScrFunction.GetFunctionName(Fn.ToInt(TxtParentFunctionID.Text));
        }

        if (CurrentPageMode == PageMode.Add || CurrentPageMode == PageMode.Edit)
        {
            ChkListOperation.Enabled = true;
        }
        else
        {
            ChkListOperation.Enabled = false;
        }
    }

    /// <summary>
    /// 初始化listoperation控件
    /// </summary>
    /// <returns></returns>
    public override void SetControlValue(DBRowBase r)
    {
        if (!IsPostBack)
        {
            this.ChkListOperation.DataSource = Operation.GetAllOperation();
            this.ChkListOperation.DataBind();
        }

        if (CurrentPageMode == PageMode.Add)
        {
            for (int j = 0; j < ChkListOperation.Items.Count; j++)
            {
                //初始化为未选中
                ChkListOperation.Items[j].Selected = false;
            }
        }
        else
        {
            DataSet ds = FunctionOperation.GetFunctionOperation(KeyValue);
            for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
            {
                string operationID = Fn.ToString(ds.Tables[0].DefaultView[i]["Operation_ID"]);
                for (int j = 0; j < ChkListOperation.Items.Count; j++)
                {
                    if (ChkListOperation.Items[j].Value == operationID)
                    {
                        ChkListOperation.Items[j].Selected = true;
                        break;
                    }
                }
            }
        }

        base.SetControlValue(r);
    }

    protected override bool OnPreSave()
    {
        if (!AppSetting.UseMultiLanguage)
        {
            TxtMenuNameEN.Text = TxtMenuNameCN.Text;
        }

        return base.OnPreSave();
    }

    /// <summary>
    /// insert
    /// </summary>
    /// <param name="r"></param>
    /// <returns></returns>
    protected override bool OnInsert(DBRowBase r)
    {
        return Save();
    }

    protected override bool OnUpdate(DBRowBase r)
    {
        return Save();
    }

    private bool Save()
    {
        RM rm = new RM(ResourceFile.Msg);
       
        if (TxtFunctionID.Text == string.Empty)
        {
            TxtFunctionID.Text = KeyValue;
        }

        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);

        FunctionOperation funcOp = new FunctionOperation();

        //get dataset of function operations.
        DataSet ds = FunctionOperation.GetFunctionOperation(KeyValue);
        ds.Tables[0].DefaultView.Sort = "operation_id";

        //update dataset by selected status of checklist control.
        int find = -1;
        for (int i = 0; i < ChkListOperation.Items.Count; i++)
        {
            find = ds.Tables[0].DefaultView.Find(ChkListOperation.Items[i].Value);
            if (find > -1)
            {
                if (!ChkListOperation.Items[i].Selected)
                {
                    //当前项被取消选择
                    ds.Tables[0].DefaultView.Delete(find);
                }
            }
            else
            {
                if (ChkListOperation.Items[i].Selected)
                {
                    //新增项
                    //DataRowView drv = ds.Tables[0].DefaultView.AddNew();
                    DataRow dr = ds.Tables[0].NewRow();

                    dr["map_id"] = funcOp.GetNewKeyValue();
                    dr["function_id"] = TxtFunctionID.Text;
                    dr["operation_id"] = ChkListOperation.Items[i].Value;

                    ds.Tables[0].Rows.Add(dr);
                }
            }                 
        }

        using (DbConnection connection = db.CreateConnection())
        {
            connection.Open();
            DbTransaction transaction = connection.BeginTransaction();

            try
            {
                ScrFunction row = RowData;

                if (CurrentPageMode == PageMode.Add)
                {
                    row.Insert(base.DataControlCollection, db, transaction);
                    row.BuildTreeLineage(db, transaction);
                }
                else
                {
                    row.Update(DataControlCollection, db, transaction);
                }

                funcOp.UpdateDataset(ds, db, transaction);

                //检查数据完整性
                if (FunctionOperation.CheckValid(db, transaction, KeyValue))
                {
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                    connection.Close();
                    RowData.ErrorMessage = rm["CannotDeleteFunctionOperationInUse"];

                    return false;
                }
            }
            catch(Exception err)
            {               
                // Roll back the transaction. 
                transaction.Rollback();
                connection.Close();

                throw err;
            }
            connection.Close();
        }

        return true;
    }
    
    protected void DdlFunctionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //就是function定义页面保存后会把state_id设成空
        //暂时注释 20071206 DZD
        //if (DdlFunctionType.SelectedValue == FunctionType.StateType.ToString())
        //{
        //    this.DdlStateList.Enabled = true;
        //}
        //else
        //{
        //    this.DdlStateList.Enabled = false;
        //    this.DdlStateList.SelectedValue = this.DdlStateList.InsertedItemValue;
        //}
    }
}
