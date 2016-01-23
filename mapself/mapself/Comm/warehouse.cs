using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.Comm
{
    public class warehouse
    {
        public int wh_id, enable_flag;
        public int floornum_start=32627,floornum_end=0;
        public string wh_name, wh_code, channel_direction;
        public int cell_width, cell_depth, cell_margin, aisle_margin, channel_gap;
        public int xstart, xend, ystart, yend;
        public double len1 = 28.1972, len2 = 61.9693;

        public List<floor> floorlist = new List<floor>();
        public int[] bfl = new int[100];  
        
    }
}