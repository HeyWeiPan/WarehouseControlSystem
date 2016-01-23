using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntpClass.Common;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using System.Collections;


namespace EntpClass.BizLogic.WCS
{
    public class Cell
    {
        private string _CellNum;//当前小方块的坐标
        private string _targetNum;//路径中目标方块的坐标
        private string _route;
        private int _cellStatus;//每一个小方块代表的类型，是电梯还是货道
        private string _rack;//路径方向
        public const string NOROUTE = "NoRoute";
        public const char ROUTESPLIT = ',';
        public int _CellXf;//当前小车是否可以往X+方向行驶
        public int _CellXb;//当前小车是否可以往X-方向行驶
        public int _CellYf;//当前小车是否可以往Y+方向行驶
        public int _CellYb;//当前小车是否可以往Y-方向行驶
        public int _WhModeId; //仓库当前使用的模式

        public int WhModeId 
        {
            get { return _WhModeId; }
            set { _WhModeId = value; }
        }
        public int CellXf 
        {
            get { return _CellXf; }
            set { _CellXf = value; }
        }

        public int CellXb
        {
            get { return _CellXb; }
            set { _CellXb = value; }
        }

        public int CellYf
        {
            get { return _CellYf; }
            set { _CellYf = value; }
        }

        public int CellYb
        {
            get { return _CellYb; }
            set { _CellYb = value; }
        }

        public string CellNum
        {
            get { return _CellNum; }
            set { _CellNum = value; }
        }


        public string TargetNum
        {
            get { return _targetNum; }
            set { _targetNum = value; }
        }


        public int CellStatus
        {
            get { return _cellStatus; }
            set { _cellStatus = value; }
        }


        public string Route
        {
            get { return _route; }
            set { _route = value; }
        }
        public string LeftRoute = "";
        public string UpRoute = "";
        public string RightRoute = "";
        public string DownRoute = "";

        public string Rack
        {
            get { return _rack; }
            set { _rack = value; }
        }
        //表示当前小方块的前后左右周围的四个小方块
        public Cell RightCell;
        public Cell LeftCell;
        public Cell UpCell;
        public Cell DownCell;

        public string GetRoute(string targetNum)
        {
            int maxStep = 9999;
            return GetRoute(ROUTESPLIT.ToString(), targetNum, ref maxStep);
        }

        /// <summary>
        /// 计算路线
        /// </summary>
        /// <param name="preRoute">之前的路径，用于判断是否有死循环</param>
        /// <param name="targetNum">目标位置</param>
        /// <param name="maxStep">计算的最大次数</param>
        /// <returns></returns>
        private string GetRoute(string preRoute, string targetNum, ref int maxStep)//函数重载
        {
            int currStep = maxStep;

            if (targetNum != TargetNum)//不相等表明TargetNum被重新赋值了，需要重新计算路径，应该就是有一个新的任务
            {
                //target changed, reset route
                //Route为空说明不是所有方向都计算过了，需要继续计算
                Route = "";
                }

            if (Route == NOROUTE)//route为“NOROUTE”表示经过计算没有可用路径，与route为空是两种情况，route为空是还未开始计算路径的状态
            {
                return NOROUTE;
            }

            //到达目的地
            if (TargetNum == CellNum)
            {
                this.Route = ROUTESPLIT + CellNum + ROUTESPLIT;//cellnum表示计算路径中循环遍历过程的动态方块坐标
            }

            //如果路经不为空，说明之前已经计算出结果
            if (Route != "")
            {
                //计算本次路径的长度
                currStep = GetRouteStep(preRoute) + GetRouteStep(Route);
                //如果本次路径长度为最小长度， 则限定其它路径的计算步数
                if (currStep < maxStep)//maxstep为当前可用路径的计算步数
                {
                    maxStep = currStep;
                }
                //返回路径
                return Route;
            }
            string newRoute = NOROUTE;

            //Route为空的情况
            preRoute = preRoute + CellNum + ROUTESPLIT;

            currStep = GetRouteStep(preRoute);
            if (currStep >= maxStep)//表示现有路径长度大于已有路径的长度，此判断为确保选择最短路径
            {
                //路线长度超出范围
                return NOROUTE;
            }
            Cell c;

            Route route = new Route();

            //计算向上的路径
            if (UpRoute == "")
            {
                c = UpCell;
                
                if (c != null)
                {
                    //route.GetDirection(cmdId, c.CellNum);
                    //if (route.cell_yf == -1)
                    //{
                        if (preRoute.IndexOf(ROUTESPLIT + c.CellNum + ROUTESPLIT) == -1)
                        {
                            UpRoute = c.GetRoute(preRoute, targetNum, ref maxStep);
                        }
                    //}
                }
                else
                {
                    UpRoute = NOROUTE;
                }
            }

            //计算向下的路径
            if (DownRoute == "")
            {
                c = DownCell;
                if (c != null)
                {
                    //route.GetDirection(cmdId, c.CellNum);
                    //if (route.cell_yb == -1)
                    //{
                        if (preRoute.IndexOf(ROUTESPLIT + c.CellNum + ROUTESPLIT) == -1)
                        {
                            DownRoute = c.GetRoute(preRoute, targetNum, ref maxStep);
                        }
                    //}
                }
                else
                {
                    DownRoute = NOROUTE;
                }
            }

            //计算向右的路径
            if (RightRoute == "") //为空表示未计算
            {
                c = RightCell;
                if (c != null)
                {//查找c.CellNum在preRoute中出现的位置，返回-1表示没有找到，即preRoute中不包括c.CellNum，c.CellNum此处为rightcell的坐标位置，是为了保证不走回头路
                    //route.GetDirection(cmdId, c.CellNum);
                    //if (route.cell_xf == -1)
                    //{
                        if (preRoute.IndexOf(ROUTESPLIT + c.CellNum + ROUTESPLIT) == -1) //如果返回值大于0，说明历史路径已经包含本节点，需要排除，否则会有死循环
                        {
                            RightRoute = c.GetRoute(preRoute, targetNum, ref maxStep);
                        }
                    //}
                }
                else
                {
                    //无右边节点，向右无法到达目的地
                    RightRoute = NOROUTE;
                }
            }

            //计算向左的路径
            if (LeftRoute == "")
            {
                c = LeftCell;
                if (c != null)
                {
                    //route.GetDirection(cmdId, c.CellNum);
                    //if (route.cell_xb == -1)
                    //{
                        if (preRoute.IndexOf(ROUTESPLIT + c.CellNum + ROUTESPLIT) == -1)
                        {
                            LeftRoute = c.GetRoute(preRoute, targetNum, ref maxStep);
                        }
                    //}
                }
                else
                {
                    LeftRoute = NOROUTE;
                }
            }

           

            //计算最短路径
            string r = GetShortRoute(GetShortRoute(LeftRoute, RightRoute), GetShortRoute(UpRoute, DownRoute));
            if (r == NOROUTE)
            {
                newRoute = r;//newRoute用来表示计算最终路径
            }
            else
            {
                newRoute = ROUTESPLIT + CellNum + r;
                //计算当前路径的步数
                currStep = currStep + GetRouteStep(newRoute);
                if (currStep < maxStep)
                {
                    maxStep = currStep;
                }
            }
            if (LeftRoute != "" && RightRoute != "" && UpRoute != "" && DownRoute != "")
            {
                //四个方向都计算过了，保存路径，避免下次重复计算
                this.Route = newRoute;
            }



            return newRoute;
        }

        /// <summary>
        /// 获取最短路径
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string GetShortRoute(string a, string b)
        {
            string r = "";
            if (a == "") a = NOROUTE;
            if (b == "") b = NOROUTE;


            if (a == NOROUTE)
            {
                r = b;
            }
            else if (b == NOROUTE)
            {
                r = a;
            }
            else
            {
                r = GetRouteStep(a) < GetRouteStep(b) ? a : b;
            }

            return r;
        }


        public int GetRouteTurn(string[] route, int step)//计算转弯的次数
        {
            int turn = 0;
            int x1, x2, y1, y2;

            if (step < 3)//如果是2的情况，则step之间只有一条路径
                return 0;

            for (int i = 2; i < step; i++)
            {
                x1 = Fn.ToInt(route[i].Split('.')[0]);
                x2 = Fn.ToInt(route[i - 2].Split('.')[0]);//为什么是减去2呢，因为1的话两个方块相邻，必然在同一水平或竖直线上，x或y总有一个相等，则无效
                y1 = Fn.ToInt(route[i].Split('.')[1]);
                y2 = Fn.ToInt(route[i - 2].Split('.')[1]);

                if (x1 != x2 && y1 != y2)
                    turn++;
            }


            return turn;

        }

        public string[] RemoveNullStep(string route)
        {
            //substring返回从第一个数字开始，第二个数字那么长的子字符串，此处即先去头，后去尾
            string[] routes = route.Substring(1, route.Length - 1).Substring(0, route.Length - 2).Split(ROUTESPLIT);


            return routes;
            

        }


        /// <summary>
        /// 计算步数
        /// </summary>
        /// <param name="r">路径</param>
        /// <returns></returns>
        public int GetRouteStep(string r)
        {
            string[] cells = r.Split(ROUTESPLIT);

            return cells.Length - 2+GetRouteTurn(RemoveNullStep(r),cells.Length-2);
        }

    }



}
