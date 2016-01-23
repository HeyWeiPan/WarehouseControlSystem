using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;

namespace Warehouse.Comm
{
    public class floor
    {
        public int floor_id, wh_id,floor_num;
        public string floor_code;
        public int xstart=32627, ystart=32627,xend=-1,yend=-1;
        public  List<List<cell>> celllist= new List<List<cell>>();        
    }
}