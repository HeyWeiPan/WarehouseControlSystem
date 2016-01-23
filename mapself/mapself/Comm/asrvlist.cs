using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse.Comm
{
    public class asrvlist//存放小车数组的类
    {
        static public int asrv_num;
        static public int[] basrv = new int[100];                  //标记数组
        static public List<asrv> aslist = new List<asrv>();        //小车数组
    }
}