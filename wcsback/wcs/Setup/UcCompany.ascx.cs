using System;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.BizLogic.Setup;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.Security;

public partial class Setup_UcCompany : GridControlBase<Company>
{
    protected override bool SupportAutoEvents
    {
        get
        {
            return false;
        }
    }

    protected override GridView GetGridViewControl()
    {
        return GrdCompanyNameList;
    }

    protected override DataSet GetGridDataSet()
    {
        string sql
                = " select company_id,company_name,show_order,enable_flag from def_company order by show_order, company_id";

        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetSqlStringCommand(sql);

        DataSet ds = db.ExecuteDataSet(cmd);

        return ds;
    }

    protected override void SetParameter(GridControlParameter p)
    {
        p.DialogMode = false;
    }

    protected override bool OnInsert(PageBase page, Database db, DbTransaction transaction)
    {
        Hashtable dataControlCollection = page.DataControlCollection;

        //enable_flag
        UcHiddenField HidEnableFlag = new UcHiddenField();
        HidEnableFlag.ID = "HidEnableFlag";
        HidEnableFlag.ColumnName = "enable_flag";
        HidEnableFlag.RequiredField = true;
        HidEnableFlag.Value = "-1";

        page.AddControl(HidEnableFlag);        

        return base.OnInsert(page, db, transaction);
    }

}
