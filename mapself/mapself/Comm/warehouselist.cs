using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.Comm
{
    public class warehouselist
    {
        static public int whnum_start=32627,whnum_end=0,wh_num;
        static public List<warehouse> whlist = new List<warehouse>();
        static public int[] bwh=new int[100];                  //标记数组
    }
}