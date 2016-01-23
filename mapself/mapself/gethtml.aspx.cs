using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Warehouse.Comm;

namespace mapself
{
    public partial class gethtml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Write(GetTableHtml());
            HttpContext.Current.Response.End();
        }


        public string WhId
        {
            get
            {
                object o= Request.QueryString["WhId"];

                if (o == null)
                    return "";
                else
                    return o.ToString();
            }
        }


        public string FloorNum
        {
            get
            {
                object o = Request.QueryString["FloorNum"];

                if (o == null)
                    return "";
                else
                    return o.ToString();
            }
        }

     

        public string GetTableHtml()
        {
//            string selectedWhId = WhId;
//            string selectedFloorNum = FloorNum;
//
//
//
//
//
//            //读取asrv数据库信息
//            string sql6;
//            sql6 = "select * from wcs.wcs.wcs_asrv where wh_id=" + selectedWhId;
//            DataTable dt6 = SQLConnaction.QuerySQL(sql6).Tables[0];
//            int[] asrvX, asrvY;
//            asrvX = new int[dt6.Rows.Count];
//            asrvY = new int[dt6.Rows.Count];
//            for (int a = 0; a < dt6.Rows.Count; a++)
//            {
//                asrvX[a] = int.Parse(dt6.Rows[a]["y_num"].ToString());
//                asrvY[a] = int.Parse(dt6.Rows[a]["x_num"].ToString());
//            }
//
//            //读取cell数据库信息
//            string sql4;
//            sql4 = "select cell_id,cell_num,wh_id,floor_num,celltype_code,x_num,y_num from wcs.wcs.wcs_cell where wh_id=" + selectedWhId + " and floor_num=" + selectedFloorNum;
//            DataTable dt4 = SQLConnaction.QuerySQL(sql4).Tables[0];
//            //读取wh_id信息，确定仓库大小
//            string sql5;
//            sql5 = "select wh_id,x_num_to,y_num_to from wcs.wcs.wcs_wh";
//            DataTable dt5 = SQLConnaction.QuerySQL(sql5).Tables[0];
//            int MaxX = 0, MaxY = 0;
//            for (int wh = 0; wh < dt5.Rows.Count; wh++)
//            {
//                if (dt5.Rows[wh]["wh_id"].ToString() == WhId)
//                {
//                    //注意x_num为横坐标，表示第几列，即列数；y_num为纵坐标，表示第几行，即行数
//                    MaxX = int.Parse(dt5.Rows[wh]["y_num_to"].ToString());
//                    MaxY = int.Parse(dt5.Rows[wh]["x_num_to"].ToString());
//                    break;
//                }
//            }
//            StringBuilder strBuilder = new StringBuilder();
//            strBuilder.Append("<table border=\"0\" class=\"mytable\" >");
//            //行循环、列循环，显示仓库界面
//            for (int x = 0; x < MaxX + 1; x++)
//            {
//                strBuilder.AppendLine("<tr>");
//                for (int y = 0; y < MaxY + 1; y++)
//                {
//                    //遍历表格中每一行
//                    for (int i = 0; i < dt4.Rows.Count; i++)
//                    {
//                        //注意x_num为横坐标，表示第几列，即列数；y_num为纵坐标，表示第几行，即列数
//
//                        if (int.Parse(dt4.Rows[i]["x_num"].ToString()) == y && int.Parse(dt4.Rows[i]["y_num"].ToString()) == x)
//                        {
//                            Boolean flag = false;
//                            for (int a = 0; a < dt6.Rows.Count; a++)
//                            {
//                                if (asrvX[a] == x && asrvY[a] == y)
//                                {
//                                    flag = true;
//                                    break;
//                                }
//                            }
//                            if (flag == false)
//                            {
//                                string type = dt4.Rows[i]["celltype_code"].ToString();
//                                if (type == "0")
//                                {
//                                    strBuilder.AppendLine("<td class='xd' width='30'></td>");
//                                }
//                                else if (type == "1")
//                                {
//                                    strBuilder.AppendLine("<td class='hd' width='30'></td>");
//                                }
//                                else if (type == "2")
//                                {
//                                    strBuilder.AppendLine("<td class='lift' width='30'></td>");
//                                }
//                                else if (type == "3")
//                                {
//                                    strBuilder.AppendLine("<td class='cell' width='30'></td>");
//                                }
//                                else if (type == "4")
//                                {
//                                    strBuilder.AppendLine("<td class='un' width='30'></td>");
//                                }
//                                else if (type == "5")
//                                {
//                                    strBuilder.AppendLine("<td class='cd' width='30'></td>");
//                                }
//                                else { continue; }
//                            }
//                            else { strBuilder.AppendLine("<td width='30'><img width='30' height='30'src=\"images\\car.png\"></td>"); continue; }
//                        }
//                    }
//                }
//                strBuilder.AppendLine("</tr>");
//            }
//
//            strBuilder.Append("</table>");
            return "oo";
        }
    }
}