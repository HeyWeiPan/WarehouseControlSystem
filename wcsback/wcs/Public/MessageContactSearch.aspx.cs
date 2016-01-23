using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using EntpClass.Common;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

using EntpClass.WebControlLib;
using EntpClass.BizLogic.Security;

public partial class Public_MessageContactSearch : PageBase
{
   
    public override void SetPageInfo(ref EntpClass.Common.PageParameter p)
    {
       
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!this.IsPostBack)
        { 
            //如果传入了userid
            if (Fn.ToLength(UserIds) != 0)
            {        
                this.BindGridView(this.GetDataSource());

                this.SetGridRowSelected(UserIds);
            }
        }
    }

    private void SetGridRowSelected(string userIds)
    {
        int selectedCount = 0;
        string [] userIdList = userIds.Split(';');

        //根据传入的参数Link_DJ_ID_List设置相应的行的复选框的初始值为选中或未选中
        for (int i = 0; i < userIdList.Length; i++)
        {
            for (int j = 0; j < GrdList.Rows.Count; j++)
            {
                DataKey id = GrdList.DataKeys[GrdList.Rows[j].RowIndex];

                if (string.Equals(userIdList[i], Fn.ToString(id.Value), StringComparison.OrdinalIgnoreCase))
                {
                    ((UcCheckBox)GrdList.Rows[j].Cells[0].FindControl("Chk")).Checked = true;

                    selectedCount += 1;
                }
            }
        }

        if (selectedCount == GrdList.Rows.Count)
        {
            ((UcCheckBox)GrdList.HeaderRow.Cells[0].FindControl("ChkAll")).Checked = true;
        }
    }    

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        this.BindGridView(this.GetDataSource());
    }

    private DataTable GetDataSource()
    {
        string proc = "dbo.GetMsgContactList";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);

        db.AddInParameter(cmd, "pPrimaryTeamId", DbType.Int32, Fn.ToDBNullObject(this.TVListTeam.Value));
        db.AddInParameter(cmd, "pNativeName", DbType.String, this.TxtNativeName.Text);
        db.AddInParameter(cmd, "pUserNumber", DbType.String, this.TxtUserNumber.Text);
     

        DataSet ds = db.ExecuteDataSet(cmd);

        return ds.Tables[0];
    }

    private void BindGridView(DataTable dt)
    {
        GrdList.OnClientRowDblClick = "return onSelect();";
        GrdList.DataSource = dt;
        GrdList.DataBind();
    }

    private string UserIds
    {
        get {
            return Fn.ToString(this.Request.QueryString["UserIds"]);
        }
    }

}