using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.Comm
{
    public class cell
    {
        public int cell_id,celltype_code;
        public int cellwh_id, cellfloor_num;
        public int x_num, y_num;
        public int used_flag, write_flag;
        public int asrv_id=0;
        public bool road_flag = false;
    }
}