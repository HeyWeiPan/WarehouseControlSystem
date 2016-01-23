using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

using EntpClass.Common;
using EntpClass.BizLogic.Security;


public partial class CommonUI_WebForm_GetMenuTreeData : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        HttpContext.Current.Response.Write(CreateExtTreeJSON());
        HttpContext.Current.Response.End();

    }


    public string CreateExtTreeJSON()
    {
        StringBuilder sb = new StringBuilder();
        CreateExtTreeNode(sb);
        string s = sb.ToString();
        return s.Replace("}{", "},{");
    }

    private void CreateExtTreeNode(StringBuilder sb)
    {
        DataTable dt = GetMenuDatasource();

        if (dt.Rows.Count > 0)
        {
            sb.Append("[");
            foreach (DataRow dr in dt.Rows)
            {




                sb.Append("{");

                sb.Append("id:" + dr["function_id"].ToString() + ",");
                sb.Append(" pId:" + dr["function_pid"].ToString() + ",");
                sb.Append(" name:\"" + dr["function_name"].ToString() + "\",");

                if (dr["page_url"].ToString() != "")
                {
                    sb.Append(" file:\"" + dr["page_url"].ToString() + "\"");
                }
                else
                {
                    sb.Append(" open:false");
                }
                sb.Append("}");
            }


        }

        sb.Append("]");
    }

    private DataTable GetMenuDatasource()
    {
        DataSet ds = RightHelper.GetUserMenuTree(CurrentUser.UserID, ScrFunction.GetRootMenuLineage());

        ds.Tables[0].DefaultView.Sort = "show_order ASC";

        DataTable dtSort = ds.Tables[0].DefaultView.ToTable();
        return dtSort;
    }



}