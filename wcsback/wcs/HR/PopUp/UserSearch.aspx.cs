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

using EntpClass.Common;
using EntpClass.WebUI;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.HR;
using EntpClass.BizLogic.Security;

public partial class HR_PopUp_UserSearch : PageBase
{   
    private bool AutoClose
    {
        get{ return true;}
    }

    private void BindGridView()
    {
        string proc = "";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);        
        db.AddInParameter(cmd, "pFunctionId", DbType.Int32, PageSetting.FunctionID);//资源接口         
        DataSet ds = db.ExecuteDataSet(cmd);

        GrdList.OnClientRowDblClick = "return onSelect();";
        GrdList.DataSource = ds;
        GrdList.DataBind();
    }

    public override void SetPageInfo(ref PageParameter p) { }    

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        RenderCloseFormScript();
    }   

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        BindGridView();
    }
}
