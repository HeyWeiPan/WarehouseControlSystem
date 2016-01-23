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

public partial class CC_Images_ext : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

        HttpContext.Current.Response.Write(CreateExtTreeJSON());
        HttpContext.Current.Response.End();
    }

    //DataTable _Alldt = new DataTable();

    DataTable _Alldt = null;

    private DataTable GetAllNodes()
    {
        DataSet ds = RightHelper.GetUserMenuTree(CurrentUser.UserID, "//1999999//2900000");


        ds.Tables[0].DefaultView.Sort = "show_order ASC";

        DataTable dtSort = ds.Tables[0].DefaultView.ToTable();
        _Alldt = dtSort;
        return dtSort;
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
        DataTable dt = GetAllNodes("2900000");

        if (dt.Rows.Count > 0)
        {
            sb.Append("[");
            foreach (DataRow dr in dt.Rows)
            {
                if (Fn.ToString(dr["function_id"]) == "2000000" || Fn.ToString(dr["function_id"]) == "3900110")
                    continue;

                sb.Append("{");
                sb.Append("text:'" + dr["function_name"].ToString() + "',");
                sb.Append("id:'" + dr["function_id"].ToString() + "'");
                //sb.Append("center:'" + dr["cost_center"].ToString() + "',");
                //sb.Append("icon:'" + "Images/Ext/icons/folder.gif" + "',");
                AddChildrenNode(GetAllNodes(dr["function_id"].ToString()), sb);
                sb.Append("}");
            }
        }

        sb.Append("]");
    }

    private void AddChildrenNode(DataTable dt, StringBuilder sb)
    {
        if (dt.Rows.Count > 0)
        {
            sb.Append(",leaf:false,children:[");
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("{");
                sb.Append("text:'" + dr["function_name"].ToString() + "',");
                sb.Append("id:'" + dr["function_id"].ToString() + "'");
                //sb.Append("center:'" + dr["cost_center"].ToString() + "',");
                //sb.Append("icon:'" + "Images/Ext/icons/folder.gif" + "',");
                //sb.Append("hrefTarget:'main'");
                AddChildrenNode(GetAllNodes(dr["function_id"].ToString()), sb);
                sb.Append("}");
            }

            sb.Append("]");
        }
        else
            sb.Append(",leaf:true");
    }



    private DataTable GetAllNodes(string parentid)
    {
        if (_Alldt == null)
        {
            _Alldt = GetAllNodes();
        }

        DataTable _dt = _Alldt.Clone();
        foreach (DataRow dr in _Alldt.Rows)
        {
            if (dr["function_pid"].ToString() == parentid.ToString())
                _dt.Rows.Add(dr.ItemArray);
        }

        return _dt;
    }

}