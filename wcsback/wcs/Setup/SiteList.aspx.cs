using System;
using System.Configuration;
using System.Collections;
using System.Text;
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

public partial class Setup_SiteList : SetUpListPageBase<SiteProfile>
{   
    protected override void SetScopeParameter(ref ScopeWindowParameters p)
    {        
    }

    protected override DataSet GetDataSet(ScopeSqlParameters p)
    {
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        StringBuilder s = new StringBuilder(100);

        s.Append("SELECT site_id,site_name,province_id = dbo.GetGeographyName(province_id),city_id = dbo.GetGeographyName(city_id),");
        s.Append("site_address,zip_code,phone,fax,enable_flag");                                        
        s.AppendFormat(" FROM def_site u ,{0} ", p.TableSql);
        s.AppendFormat(" where u.site_id = {0}.id ", p.TableAlias);
        s.AppendFormat(" order by {0}.show_order", p.TableAlias);

        DbCommand cmd = db.GetSqlStringCommand(s.ToString());
        DataSet ds = db.ExecuteDataSet(cmd);

        return ds;
    }

    protected override DataControlField OnGridColumnCreating(string colName)
    {
        switch (colName.ToUpper())
        {
            case "SITE_NAME":
                UCDialogHyperLinkField f = new UCDialogHyperLinkField();
                f.DataTextField = "site_name";
                f.DataLinkFiled = "site_id";
                f.DataLinkClientScriptFunction = "ShowDetail('VIEW',linkParam)";
                f.HeaderText = "site_name";
                f.SortExpression = "site_name";
                return f;
            case "SITE_ID":
                return null;
        }

        return base.OnGridColumnCreating(colName);
    }    
}
