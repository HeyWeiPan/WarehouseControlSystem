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

using EntpClass.Common;
using System.Text;
using EntpClass.WebControlLib;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using EntpClass.WebUI;

public partial class CacheList : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    public override void SetPageInfo(ref PageParameter p)
    {
        p.FunctionID = 20014450;
        return;
    }
    private void BindGrid()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("CacheKey", typeof(string)));
        dt.Columns.Add(new DataColumn("CacheValue", typeof(string)));
        ds.Tables.Add(dt);
        foreach (DictionaryEntry de in HttpRuntime.Cache)
        {
            DataRow dr = dt.NewRow();
            dr["CacheKey"] = de.Key.ToString();
            dr["CacheValue"] = de.Value.ToString();
            dt.Rows.Add(dr);
        }
        
        DataView dv = ds.Tables[0].DefaultView;
        dv.Sort = "CacheKey";
        string skey = TxtKey.Text.Trim();
        string sValue = TxtValue.Text.Trim();
        dv.RowFilter = "(CacheKey like '%" + skey + "%' and CacheValue like '%" + sValue + "%') or Isnull(CacheKey,'Null Column') = 'Null Column'";
        GrdList.DataSource = dv;
        GrdList.DataBind();
    }
    protected void GrdList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdList.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void BtnRemove_Click(object sender, EventArgs e)
    {
        ArrayList akeys = new ArrayList();

        foreach (DictionaryEntry de in HttpRuntime.Cache)
        {
            akeys.Add(de.Key.ToString());
        }

        for (int i = 0; i < akeys.Count; i++)
        {
            HttpRuntime.Cache.Remove(akeys[i].ToString());
        }
        BindGrid();
    }

    protected void BtnDeleteList_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("CacheKey", typeof(string)));
        dt.Columns.Add(new DataColumn("CacheValue", typeof(string)));
        ds.Tables.Add(dt);
        foreach (DictionaryEntry de in HttpRuntime.Cache)
        {
            DataRow dr = dt.NewRow();
            dr["CacheKey"] = de.Key.ToString();
            dr["CacheValue"] = de.Value.ToString();
            dt.Rows.Add(dr);
        }

        DataView dv = ds.Tables[0].DefaultView;
        dv.Sort = "CacheKey";
        string skey = TxtKey.Text.Trim();
        string sValue = TxtValue.Text.Trim();
        dv.RowFilter = "(CacheKey like '%" + skey + "%' and CacheValue like '%" + sValue + "%') or Isnull(CacheKey,'Null Column') = 'Null Column'";
        
        ArrayList akeys = new ArrayList();

        for (int i = 0; i < dv.Count; i++)
        {
            akeys.Add(dv[i]["CacheKey"].ToString());
        }

        for (int i = 0; i < akeys.Count; i++)
        {
            HttpRuntime.Cache.Remove(akeys[i].ToString());
        }
        BindGrid();
    }

    protected void BtnRefresh_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void GrdList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HttpRuntime.Cache.Remove(GrdList.DataKeys[e.RowIndex].Value.ToString());
            //GrdList.Rows[e.RowIndex].Cells[1].Text.Replace("&nbsp;"," "));
        BindGrid();
    }
}
