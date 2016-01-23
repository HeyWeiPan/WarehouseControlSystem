using mapself.Comm;
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
    public partial class getNewhtml : System.Web.UI.Page
    {
        public static int onmove_asrv_num = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //检测页面返回的url
            string param = HttpContext.Current.Request.Url.Query;
            if (param.Contains("asrv_move_id"))
            {
                //if (sqlwatcher.cmd_new_flag==true)
                HttpContext.Current.Response.Write(GetAsrvMoveId());
            }
            else if (param.Contains("realX"))
            {
               //if (sqlwatcher.cmd_new_flag==true)
                HttpContext.Current.Response.Write(GetRealX());
            }
            else if (param.Contains("realY"))
            {
               // if (sqlwatcher.cmd_new_flag == true)
                HttpContext.Current.Response.Write(GetRealY());
            }
            else if (param.Contains("WhId") && param.Contains("FloorNum"))
            {
                HttpContext.Current.Response.Write(GetNewTableHtml());
            }
            else if(param.Contains("init"))
            {
                HttpContext.Current.Response.Write(InitPW());
            }
            HttpContext.Current.Response.End();
        }

        public string NewWhId
        {
            get
            {
                object o = Request.QueryString["WhId"];

                if (o == null)
                    return "";
                else
                    return o.ToString();
            }
        }

        public string InitPW()
        {
            init.main();
            //CheckOldTask.main();
            sqlwatcher.main();
            int t;
            t = make_it_run.c_time;
            return t.ToString();
        }
        public string NewFloorNum
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
        /// <summary>
        /// 目前正在执行任务的小车id，显示到页面“当前执行任务小车编号：”后的文本框中
        /// </summary>
        /// <returns></returns>
        public string GetAsrvMoveId()
        {
            return "oo";
            //return asrvlist.aslist[asrvlist.basrv[15]].c_stepnum.ToString() + "SX" + asrvlist.aslist[asrvlist.basrv[15]].start_x.ToString() + "SY" + asrvlist.aslist[asrvlist.basrv[15]].start_y;
        }
        /// <summary>
        /// 目前正在执行任务的小车X坐标，显示到页面“当前小车X坐标：”后的文本框中
        /// </summary>
        /// <returns></returns>
        public string GetRealX()
        {
           // return asrvlist.aslist[asrvlist.basrv[15]].cubenum_token.ToString() + "__EX" + asrvlist.aslist[asrvlist.basrv[15]].end_x.ToString() + "__EY" + asrvlist.aslist[asrvlist.basrv[15]].end_y.ToString();
            return "oo";

        }
        /// <summary>
        /// 目前正在执行任务的小车Y坐标，显示到页面“当前小车Y坐标：”后的文本框中
        /// </summary>
        /// <returns></returns>
        public string GetRealY()
        {
            return "oo";

           // return asrvlist.aslist[asrvlist.basrv[15]].state_flag.ToString() + "xd" + "__EY" + asrvlist.aslist[asrvlist.basrv[15]].onmove_x_flag_decrease + "xi" + asrvlist.aslist[asrvlist.basrv[15]].onmove_x_flag_increase;
           
        }
        /// <summary>
        /// 页面一秒刷新一次，一秒调用一次此函数
        /// 保存当前任务指令：cmd_byte_list = (byte[]) 字节数组
        /// </summary>
        /// <returns></returns>
        public string GetNewTableHtml()
        {
            return "oo";

            //string selectedWhId = NewWhId;
            //string selectedFloorNum = NewFloorNum;
            
            ///// <summary>
            ///// int[] asrvX, asrvY：存储本仓库中所有小车实时坐标信息
            ///// 实现正在执行任务的小车坐标变化，而不执行的小车不移动
            ///// </summary>
            //string sql6;
            //sql6 = "select * from wcs.wcs.wcs_asrv where wh_id=" + selectedWhId + " and floor_num=" + selectedFloorNum;
            //DataTable dt6 = SQLConnaction.QuerySQL(sql6).Tables[0];
            //int[] asrvX, asrvY;
            //asrvX = new int[dt6.Rows.Count];
            //asrvY = new int[dt6.Rows.Count];
            

            //for (int a = 0; a < dt6.Rows.Count; a++)
            //{
            //    int temp=int.Parse(dt6.Rows[a]["asrv_id"].ToString());
            //    if (asrvlist.aslist[asrvlist.basrv[temp]].onmove_flag==true)
            //    {
            //        asrvX[a] = Convert.ToInt32(asrvlist.aslist[asrvlist.basrv[temp]].asrvy_num);
            //        asrvY[a] = Convert.ToInt32(asrvlist.aslist[asrvlist.basrv[temp]].asrvx_num);
            //        onmove_asrv_num++;

            //        //StringBuilder sb = new StringBuilder();
            //        //sb.AppendFormat("insert wcs.dbo.xxx set x={0},y={1} ",asrvX[a],asrvY[a]);
            //        ////更新数据库wcs_asrv中小车坐标
            //        ////string sql_asrv;
            //        ////sql_asrv = "update wcs.wcs.wcs_asrv set x_num=" + asrvY[a] + ",y_num=" + asrvX[a] + " where asrv_id="+temp;
            //        //SQLConnaction.ExecuteSQL(sb.ToString());

                    



            //    }
            //    else
            //    {
            //        asrvX[a] = Convert.ToInt32(asrvlist.aslist[asrvlist.basrv[temp]].asrvy_num);
            //        asrvY[a] = Convert.ToInt32(asrvlist.aslist[asrvlist.basrv[temp]].asrvx_num);
            //    }
            //}

            
            ////读取cell数据库信息
            //string sql4;
            //sql4 = "select cell_id,cell_num,wh_id,floor_num,celltype_code,x_num,y_num from wcs.wcs.wcs_cell where wh_id=" + selectedWhId + " and floor_num=" + selectedFloorNum;
            //DataTable dt4 = SQLConnaction.QuerySQL(sql4).Tables[0];

            ////string sql9;
            ////sql9 = "insert into asrv_work_statistics(work_id,asrv_id) values(1,6)";
            ////sql9 = "update asrv_work_statistics set asrv_id=6 where work_id=1";
            ////sql9 = "delete from asrv_work_statistics";
            ////SQLConnaction.ExecuteSQL(sql9);

            ////读取wh_id信息，确定仓库大小
            //string sql5;
            //sql5 = "select wh_id,x_num_to,y_num_to from wcs.wcs.wcs_wh";
            //DataTable dt5 = SQLConnaction.QuerySQL(sql5).Tables[0];
            //int MaxX = 0, MaxY = 0;
            //for (int wh = 0; wh < dt5.Rows.Count; wh++)
            //{
            //    if (dt5.Rows[wh]["wh_id"].ToString() == selectedWhId)
            //    {
            //        //注意x_num为横坐标，表示第几列，即列数；y_num为纵坐标，表示第几行，即行数
            //        MaxX = int.Parse(dt5.Rows[wh]["y_num_to"].ToString());
            //        MaxY = int.Parse(dt5.Rows[wh]["x_num_to"].ToString());
            //        break;
            //    }
            //}
            //StringBuilder strBuilder = new StringBuilder();
            //strBuilder.Append("<table border=\"0\" class=\"mytable\" >");
            ////行循环、列循环，显示仓库界面
            //for (int x = 0; x < MaxX + 1; x++)
            //{
            //    strBuilder.AppendLine("<tr>");
            //    for (int y = 0; y < MaxY + 1; y++)
            //    {
            //        //遍历表格中每一行
            //        for (int i = 0; i < dt4.Rows.Count; i++)
            //        {
            //            //注意x_num为横坐标，表示第几列，即列数；y_num为纵坐标，表示第几行，即列数

            //            if (int.Parse(dt4.Rows[i]["x_num"].ToString()) == y && int.Parse(dt4.Rows[i]["y_num"].ToString()) == x)
            //            {
            //                //判断是否为路径中方格
            //                    Boolean ROAD = false;
            //                if (sqlwatcher.OnMoveAsrvNum!=0)
            //                {
            //                    for( int j=0;j<asrvlist.asrv_num;j++)
            //                    {
            //                        if (asrvlist.aslist[j].onmove_flag == true)
            //                        {
            //                            for (int k = 0; k < asrvlist.aslist[j].pathlen+1; k++)
            //                            {
            //                                if(asrvlist.aslist[j].pathx[k]==y&&asrvlist.aslist[j].pathy[k]==x)
            //                                {
            //                                    ROAD = true;
            //                                    break;
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //                //判断是否为小车位置的方格
            //                Boolean flag = false;
            //                for (int a = 0; a < dt6.Rows.Count; a++)
            //                {
            //                    if (asrvX[a] == x && asrvY[a] == y)
            //                    {
            //                        flag = true;
            //                        break;
            //                    }
            //                }
            //                if (flag == false && ROAD == false)
            //                {
            //                    string type = dt4.Rows[i]["celltype_code"].ToString();
            //                    if (type == "0")
            //                    {
            //                        strBuilder.AppendLine("<td class='xd' width='30'></td>");
            //                    }
            //                    else if (type == "1")
            //                    {
            //                        strBuilder.AppendLine("<td class='hd' width='30'></td>");
            //                    }
            //                    else if (type == "2")
            //                    {
            //                        strBuilder.AppendLine("<td class='lift' width='30'></td>");
            //                    }
            //                    else if (type == "3")
            //                    {
            //                        strBuilder.AppendLine("<td class='cell' width='30'></td>");
            //                    }
            //                    else if (type == "4")
            //                    {
            //                        strBuilder.AppendLine("<td class='un' width='30'></td>");
            //                    }
            //                    else if (type == "5")
            //                    {
            //                        strBuilder.AppendLine("<td class='cd' width='30'></td>");
            //                    }
            //                    else { continue; }
            //                }
            //                else if (ROAD == true && flag==false) { strBuilder.AppendLine("<td class='road' width='30' height='30'></td>"); continue; }
            //                else if (flag == true) { strBuilder.AppendLine("<td width='30'><img width='28' height='28'src=\"images\\car.png\"></td>"); continue; }
            //            }
            //        }
            //    }
            //    strBuilder.AppendLine("</tr>");
            //}

            //strBuilder.Append("</table>");
            //return strBuilder.ToString();
        }
    }
}