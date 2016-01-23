using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Warehouse.Comm
{
    public class init//初始化读入仓库楼层等信息，小车初始信息
    {
        static private int findmax(int p, int q) { if (p > q) return p; else return q; }
        static private int findmin(int p, int q) { if (p < q) return p; else return q; }
        
        public static void main()
        {
            int i,whnum,floornum;
            string sql,temp;
            
            sql = "select * from wcs.wcs.wcs_wh";
            DataTable dt = SQLConnaction.QuerySQL(sql).Tables[0];
            warehouselist.wh_num = dt.Rows.Count;

            for (i = 0; i < dt.Rows.Count;i++ )
            {
                System.Console.Write(i);
                
                warehouse new_wh = new warehouse();

                temp = dt.Rows[i]["wh_id"].ToString();
                int.TryParse(temp, out new_wh.wh_id);
                warehouselist.whnum_start = findmin(new_wh.wh_id, warehouselist.whnum_start);
                warehouselist.whnum_end = findmax(new_wh.wh_id, warehouselist.whnum_end);

                new_wh.wh_code = dt.Rows[i]["wh_code"].ToString();

                new_wh.wh_name = dt.Rows[i]["wh_name"].ToString();

                temp = dt.Rows[i]["enable_flag"].ToString();
                int.TryParse(temp, out new_wh.enable_flag);

                temp = dt.Rows[i]["cell_width"].ToString();
                int.TryParse(temp, out new_wh.cell_width);

                temp = dt.Rows[i]["cell_depth"].ToString();
                int.TryParse(temp, out new_wh.cell_depth);

                temp = dt.Rows[i]["cell_margin"].ToString();
                int.TryParse(temp, out new_wh.cell_margin);

                temp = dt.Rows[i]["aisle_margin"].ToString();
                int.TryParse(temp, out new_wh.aisle_margin);

                temp = dt.Rows[i]["rack_margin"].ToString();
                int.TryParse(temp, out new_wh.channel_gap);

                temp = dt.Rows[i]["x_num_from"].ToString();
                int.TryParse(temp, out new_wh.xstart);

                temp = dt.Rows[i]["x_num_to"].ToString();
                int.TryParse(temp, out new_wh.xend);

                temp = dt.Rows[i]["y_num_from"].ToString();
                int.TryParse(temp, out new_wh.ystart);

                temp = dt.Rows[i]["y_num_to"].ToString();
                int.TryParse(temp, out new_wh.yend);

                new_wh.channel_direction = dt.Rows[i]["rack_direction"].ToString();

                
                warehouselist.whlist.Add(new_wh);               
                warehouselist.bwh[new_wh.wh_id] = i;
                             
            }

            sql = "select * from wcs.wcs.wcs_floor";
            dt = SQLConnaction.QuerySQL(sql).Tables[0];

            for (i = 0; i < dt.Rows.Count; i++)
            {
                floor new_floor = new floor();

                temp = dt.Rows[i]["floor_id"].ToString();
                int.TryParse(temp, out new_floor.floor_id);

                temp = dt.Rows[i]["floor_num"].ToString();
                int.TryParse(temp, out new_floor.floor_num);

                temp = dt.Rows[i]["wh_id"].ToString();
                int.TryParse(temp, out new_floor.wh_id);

                new_floor.floor_code = dt.Rows[i]["floor_code"].ToString();

                whnum = warehouselist.bwh[new_floor.wh_id];

                warehouselist.whlist[whnum].floorlist.Add(new_floor);
                warehouselist.whlist[whnum].bfl[new_floor.floor_id] = i;
            }

            sql = "select * from wcs.wcs.wcs_cell";
            dt = SQLConnaction.QuerySQL(sql).Tables[0];

            int itemflag = -1, whnum1=-1, floornum1=-1;
            List<cell> sublist = new List<cell>();

            for (i = 0; i < dt.Rows.Count; i++)
            {              
                cell new_cell = new cell();

                temp = dt.Rows[i]["celltype_code"].ToString();
                int.TryParse(temp, out new_cell.celltype_code);
                
                temp = dt.Rows[i]["cell_id"].ToString();
                int.TryParse(temp, out new_cell.cell_id);

                temp = dt.Rows[i]["wh_id"].ToString();
                int.TryParse(temp, out new_cell.cellwh_id);

                temp = dt.Rows[i]["floor_num"].ToString();
                int.TryParse(temp, out new_cell.cellfloor_num);

                whnum = warehouselist.bwh[new_cell.cellwh_id];
                floornum = warehouselist.whlist[whnum].bfl[new_cell.cellfloor_num];

                temp = dt.Rows[i]["x_num"].ToString();
                int.TryParse(temp, out new_cell.x_num);
                if (itemflag == -1)
                {
                    itemflag = new_cell.x_num;
                    whnum1 = whnum;
                    floornum1 = floornum;
                }
                if (itemflag != new_cell.x_num)
                {
                    warehouselist.whlist[whnum1].floorlist[floornum1].celllist.Add(sublist);
                    itemflag = new_cell.x_num;
                    sublist = new List<cell>();
                }

                temp = dt.Rows[i]["y_num"].ToString();
                int.TryParse(temp, out new_cell.y_num);

                warehouselist.whlist[whnum].floorlist[floornum].xstart = findmin(new_cell.x_num, warehouselist.whlist[whnum].floorlist[floornum].xstart);
                warehouselist.whlist[whnum].floorlist[floornum].xend = findmax(new_cell.x_num, warehouselist.whlist[whnum].floorlist[floornum].xend);
                warehouselist.whlist[whnum].floorlist[floornum].ystart = findmin(new_cell.y_num, warehouselist.whlist[whnum].floorlist[floornum].ystart);
                warehouselist.whlist[whnum].floorlist[floornum].yend = findmax(new_cell.y_num, warehouselist.whlist[whnum].floorlist[floornum].yend);

                temp = dt.Rows[i]["used_flag"].ToString();
                int.TryParse(temp, out new_cell.used_flag);

                temp = dt.Rows[i]["write_flag"].ToString();
                int.TryParse(temp, out new_cell.write_flag);

                whnum1 = whnum;
                floornum1 = floornum;
                sublist.Add(new_cell);
            }
            warehouselist.whlist[whnum1].floorlist[floornum1].celllist.Add(sublist);

            sql = "select * from wcs.wcs.wcs_asrv";
            dt = SQLConnaction.QuerySQL(sql).Tables[0];
            asrvlist.asrv_num = dt.Rows.Count;

            for (i = 0; i < dt.Rows.Count; i++)
            {
                asrv new_asrv = new asrv();

                temp = dt.Rows[i]["asrv_id"].ToString();
                int.TryParse(temp, out new_asrv.asrv_id);

                temp = dt.Rows[i]["wh_id"].ToString();
                int.TryParse(temp, out new_asrv.asrvwh_num);

                temp = dt.Rows[i]["floor_num"].ToString();
                int.TryParse(temp, out new_asrv.asrvfloor_num);

                temp = dt.Rows[i]["x_num"].ToString();
                double.TryParse(temp, out new_asrv.asrvx_num);
                int p;
                int.TryParse(temp, out p);
                new_asrv.xstring = p.ToString("X2");

                temp = dt.Rows[i]["y_num"].ToString();
                double.TryParse(temp, out new_asrv.asrvy_num);
                int.TryParse(temp, out p);
                new_asrv.ystring = p.ToString("X2");

               

                asrvlist.aslist.Add(new_asrv);
                asrvlist.basrv[new_asrv.asrv_id] = i;

            }
        }//end main
    }
}

