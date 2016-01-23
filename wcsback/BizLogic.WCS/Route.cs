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
    public class Route
    {

        public enum CellType//枚举，小方块类型
        {
            RoadWay = 0,//无货
            Goods = 1,//有货
            Lift = 2,//电梯
            Aisle = 3,//货道
            NoRoad = 4//不可用
        }


        public int _cXnum, _cYnum, _cFloor, _tXnum, _tYnum, _tFloor, _taskType;
        public string _rack = string.Empty;
        public int _xf, _xb, _yf, _yb;
        public string _currentNum = string.Empty;
        public string _toNum = string.Empty;
        public string _fromNum = string.Empty;
        public string _macAdress = string.Empty;
        Hashtable _Cells;//哈希表，用以查找
        public int cell_xf, cell_xb, cell_yf, cell_yb;

        /// <summary>
        /// 计算任务路径
        /// </summary>
        /// <param name="cmdId">任务ID</param>
        /// <returns></returns>
        public bool CalcRoute(string cmdId)
        {
            //设置任务参数
            InitParameter(cmdId);

            Cell c = _Cells[_currentNum] as Cell;//起始位置

            //获取从小车当前位置到A点的路径
            // string route = c.GetRoute(_fromNum);

            //获取路径
            string r = c.GetRoute(_toNum);//以结束位置信息为参数获取路径

            if (r.IndexOf("NoRoute") != -1)
                return false;

            //SaveRoute(cmdId,route);

            SaveRoute(cmdId, r);

            CmdBreak cb = new CmdBreak();
            InitCmdBreak(cb, cmdId);
            bool b = cb.RouteBreak();

            //SetRoadRight();

            return b;

        }

        /// <summary>
        /// 设置路权
        /// </summary>
        public void SetRoadRight()
        {
            //设置路权
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd1 = db.GetStoredProcCommand("wcs.SetRoadRight");
            db.ExecuteNonQuery(cmd1);
        }



        //把路径存入数据库

        public void SaveRoute(string cmdId, string route)//route即为以上r，为路径信息
        {
            int step = 1;
            string[] cells = route.Split(',');//路径中包含的每一个小方块位置坐标信息的集合
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("step_id", typeof(string));//在table表中新建三列，分别取名字
            dt.Columns.Add("cell_num", typeof(string));
            dt.Columns.Add("floor_num", typeof(string));
            DataRow dr;
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i] == "" || cells[i] == _currentNum)
                    continue;
                dr = dt.NewRow();
                dr["step_id"] = step.ToString();//一行一行填充表中内容，步骤数、位置坐标、楼层为1（估计是本楼层的意思）？
                dr["cell_num"] = cells[i];
                dr["floor_num"] = Fn.ToString(1);
                dt.Rows.Add(dr);
                step++;      //一行提供路程中一个位置坐标的信息
            }

            ds.Tables.Add(dt);//数据集中加入新表

            string proc = "WCS.SaveTaskRoute";//更新数据库
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pCmdId", DbType.Int32, cmdId);
            db.AddInParameter(cmd, "pXml", DbType.Xml, ds.GetXml());

            db.ExecuteNonQuery(cmd);//执行命令


        }



        //public int GetRouteTurn(string[] route, int step)
        //{
        //    int turn = 0;
        //    int x1, x2, y1, y2;

        //    if (step < 3)
        //        return 0;

        //    for (int i = 2; i < step; i++)
        //    {
        //        x1 = Fn.ToInt(route[i].Split('.')[0]);
        //        x2 = Fn.ToInt(route[i - 2].Split('.')[0]);
        //        y1 = Fn.ToInt(route[i].Split('.')[1]);
        //        y2 = Fn.ToInt(route[i - 2].Split('.')[1]);

        //        if (x1 != x2 && y1 != y2)
        //            turn++;
        //    }


        //    return turn;

        //}



        /// <summary>
        /// 获取任务信息
        /// </summary>
        /// <param name="cmdId">任务ID</param>
        /// <returns></returns>
        public DataSet GetTask(string cmdId)//从数据库中获取任务信息
        {
            string proc = "WCS.GetTaskDetail";
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pCmdId", DbType.Int32, cmdId);

            return db.ExecuteDataSet(cmd);
        }

        /// <summary>
        /// 获取仓库布局
        /// </summary>
        /// <param name="cmdId">任务ID</param>
        /// <returns></returns>
        public DataSet GetWhCells(string cmdId)
        {
            string proc = "WCS.GetWhCells";
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pCmdId", DbType.Int32, cmdId);

            return db.ExecuteDataSet(cmd);
        }


        public void InitParameter(string cmdId)
        {
            InitTaskParameter(cmdId);
            DataTable dtCell = GetWhCells(cmdId).Tables[0];
            _Cells = new Hashtable();


            for (int i = 0; i < dtCell.Rows.Count; i++)
            {
                //为每个单元格实例化一个类
                Cell c = new Cell();
                c.TargetNum = _toNum;
                c.CellNum = Fn.ToString(dtCell.Rows[i]["cell_num"]);
                c.Rack = _rack;
                c.CellStatus = Fn.ToInt(dtCell.Rows[i]["celltype_code"]);
                c.Route = "";
                c.CellXf = Fn.ToInt(dtCell.Rows[i]["cell_xf"]);
                c.CellXb = Fn.ToInt(dtCell.Rows[i]["cell_xb"]);
                c.CellYf = Fn.ToInt(dtCell.Rows[i]["cell_yf"]);
                c.CellYb = Fn.ToInt(dtCell.Rows[i]["cell_yb"]);
                c.WhModeId = Fn.ToInt(dtCell.Rows[i]["wh_mode_id"]);
                _Cells.Add(Fn.ToString(dtCell.Rows[i]["cell_num"]), c);
            }

            SetCellsNextCells(cmdId);
        }
        /// <summary>
        /// 初始化任务参数
        /// </summary>
        /// <param name="cmdId"></param>
        public void InitTaskParameter(string cmdId)
        {
            DataRow drTask = GetTask(cmdId).Tables[0].Rows[0];
            _cXnum = Fn.ToInt(drTask["current_x_num"]);
            _cYnum = Fn.ToInt(drTask["current_y_num"]);
            _cFloor = Fn.ToInt(drTask["current_floor"]);
            _tXnum = Fn.ToInt(drTask["to_x_num"]);
            _tYnum = Fn.ToInt(drTask["to_y_num"]);
            _tFloor = Fn.ToInt(drTask["to_floor_num"]);
            _rack = Fn.ToString(drTask["channel_direction"]);
            _currentNum = Fn.ToString(drTask["current_cell_num"]);
            _toNum = Fn.ToString(drTask["to_cell_num"]);
            _fromNum = Fn.ToString(drTask["from_cell_num"]);
            _taskType = Fn.ToInt(drTask["task_type_id"]);

            _xf = ((byte[])(drTask["xf"]))[0];
            _xb = ((byte[])(drTask["xb"]))[0];
            _yf = ((byte[])(drTask["yf"]))[0];
            _yb = ((byte[])(drTask["yb"]))[0];

            _macAdress = Fn.ToString(drTask["mac_adress"]);

        }


        /// <summary>
        /// 设置所有单元格各个方向的点
        /// </summary>
        public void SetCellsNextCells(string cmdId)
        {

            foreach (DictionaryEntry dic in _Cells)
            {
                Cell cell = (Cell)dic.Value;
                GetNextCells(cell, cmdId);
            }
        }


        public void GetDirection(string cmdId, string cellNum)
        {
            string proc = "WCS.GetDirection";
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pCmdId", DbType.Int32, cmdId);
            db.AddInParameter(cmd, "pCellNum", DbType.String, cellNum);
            db.AddOutParameter(cmd, "pCellXf", DbType.Int32, 100);
            db.AddOutParameter(cmd, "pCellXb", DbType.Int32, 100);
            db.AddOutParameter(cmd, "pCellYf", DbType.Int32, 100);
            db.AddOutParameter(cmd, "pCellYb", DbType.Int32, 100);
            db.ExecuteDataSet(cmd);
            cell_xf = Fn.ToInt(db.GetParameterValue(cmd, "pCellXf"));
            cell_xb = Fn.ToInt(db.GetParameterValue(cmd, "pCellXb"));
            cell_yf = Fn.ToInt(db.GetParameterValue(cmd, "pCellYf"));
            cell_yb = Fn.ToInt(db.GetParameterValue(cmd, "pCellYb"));
        }

        /// <summary>
        /// 设置单元格各个方向的点
        /// </summary>
        /// <param name="c">单元格</param>
        public void GetNextCells(Cell c, string cmdId)
        {

            string cellNum = c.CellNum;
            string spreadNum = string.Empty;
            int x, y;

            string[] num = cellNum.Split('.');
            x = Fn.ToInt(num[0]);
            y = Fn.ToInt(num[1]);

            GetDirection(cmdId, cellNum);

            ArrayList cells = new ArrayList();
            if (InThisWh(cellNum))
            {


                if (c.CellStatus == (int)Route.CellType.Aisle)  //如果是货道，只能有1个方向要么是X，要么是Y
                {
                    //货道为X方向
                    if (_rack == "x")
                    {
                        spreadNum = GetSpreadNum(x, y, 1, 0);
                        if (c.WhModeId == 2 && cell_xf == -1)
                        {                            
                            if (InThisWh(spreadNum))
                            {
                                c.RightCell = (Cell)_Cells[spreadNum];
                            }
                        }
                        else if (c.WhModeId != 2)
                        {
                            if (InThisWh(spreadNum))
                            {
                                c.RightCell = (Cell)_Cells[spreadNum];
                            }
                        }
                        else
                        {
                            c.RightCell = null;
                        }

                        spreadNum = GetSpreadNum(x, y, -1, 0);
                        if (c.WhModeId == 2 && cell_xb == -1)
                        {
                            if (InThisWh(spreadNum))
                            {
                                c.LeftCell = (Cell)_Cells[spreadNum];
                            }
                        }
                        else if (c.WhModeId != 2)
                        {
                            if (InThisWh(spreadNum))
                            {
                                c.LeftCell = (Cell)_Cells[spreadNum];
                            }
                        }
                        else
                        {
                            c.LeftCell = null;
                        }


                    }
                    //货道为Y方向
                    if (_rack == "y")
                    {
                        spreadNum = GetSpreadNum(x, y, 0, 1);
                        if (c.WhModeId == 2 && cell_yf == -1)
                        {
                            if (InThisWh(spreadNum))
                            {
                                c.DownCell = (Cell)_Cells[spreadNum];
                            }
                        }
                        else if (c.WhModeId != 2)
                        {
                            if (InThisWh(spreadNum))
                            {
                                c.DownCell = (Cell)_Cells[spreadNum];
                            }
                        }
                        else
                        {
                            c.DownCell = null;
                        }


                        spreadNum = GetSpreadNum(x, y, 0, -1);
                        if (c.WhModeId == 2 && cell_yb == -1)
                        {
                            if (InThisWh(spreadNum))
                            {
                                c.UpCell = (Cell)_Cells[spreadNum];
                            }
                        }
                        else if (c.WhModeId != 2)
                        {
                            if (InThisWh(spreadNum))
                            {
                                c.UpCell = (Cell)_Cells[spreadNum];
                            }
                        }
                        else
                        {
                            c.UpCell = null;
                        }


                    }
                }
                else if (c.CellStatus == (int)Route.CellType.Goods)//有货
                {
                    if (_taskType == 2) //1为卸货 0为存货，有货的时候只能是卸货，所以未讨论0为存货的情况
                    {
                        if (_rack == "x")
                        {
                            spreadNum = GetSpreadNum(x, y, 1, 0);
                            if (c.WhModeId == 2 && cell_xf == -1)
                            {
                                if (InThisWh(spreadNum))
                                {
                                    c.RightCell = (Cell)_Cells[spreadNum];
                                }
                            }
                            else if (c.WhModeId != 2)
                            {
                                if (InThisWh(spreadNum))
                                {
                                    c.RightCell = (Cell)_Cells[spreadNum];
                                }
                            }
                            else
                            {
                                c.RightCell = null;
                            }

                            spreadNum = GetSpreadNum(x, y, -1, 0);
                            if (c.WhModeId == 2 && cell_xb == -1)
                            {
                                if (InThisWh(spreadNum))
                                {
                                    c.LeftCell = (Cell)_Cells[spreadNum];
                                }
                            }
                            else if (c.WhModeId != 2)
                            {
                                if (InThisWh(spreadNum))
                                {
                                    c.LeftCell = (Cell)_Cells[spreadNum];
                                }
                            }
                            else
                            {
                                c.LeftCell = null;
                            }

                        }
                        //货道为Y方向
                        if (_rack == "y")
                        {
                            spreadNum = GetSpreadNum(x, y, 0, 1);
                            if (c.WhModeId == 2 && cell_yf == -1)
                            {
                                if (InThisWh(spreadNum))
                                {
                                    c.DownCell = (Cell)_Cells[spreadNum];
                                }
                            }
                            else if (c.WhModeId != 2)
                            {
                                if (InThisWh(spreadNum))
                                {
                                    c.DownCell = (Cell)_Cells[spreadNum];
                                }
                            }
                            else
                            {
                                c.DownCell = null;
                            }

                            spreadNum = GetSpreadNum(x, y, 0, -1);
                            if (c.WhModeId == 2 && cell_yb == -1)
                            {
                                if (InThisWh(spreadNum))
                                {
                                    c.UpCell = (Cell)_Cells[spreadNum];
                                }
                            }
                            else if (c.WhModeId != 2)
                            {
                                if (InThisWh(spreadNum))
                                {
                                    c.UpCell = (Cell)_Cells[spreadNum];
                                }
                            }
                            else
                            {
                                c.UpCell = null;
                            }

                        }
                    }
                }
                else if (c.CellStatus == (int)Route.CellType.Lift || c.CellStatus == (int)Route.CellType.RoadWay)
                {
                    spreadNum = GetSpreadNum(x, y, 1, 0);//return spreadNum=(x+1,y+0)，即平行向右一步
                    if (c.WhModeId == 2 && cell_xf == -1)
                    {
                        if (InThisWh(spreadNum))
                        {
                            c.RightCell = (Cell)_Cells[spreadNum];
                        }
                    }
                    else if (c.WhModeId != 2)
                    {
                        if (InThisWh(spreadNum))
                        {
                            c.RightCell = (Cell)_Cells[spreadNum];
                        }
                    }
                    else
                    {
                        c.RightCell = null;
                    }

                    spreadNum = GetSpreadNum(x, y, -1, 0);
                    if (c.WhModeId == 2 && cell_xb == -1)
                    {
                        if (InThisWh(spreadNum))
                        {
                            c.LeftCell = (Cell)_Cells[spreadNum];
                        }
                    }
                    else if (c.WhModeId != 2)
                    {
                        if (InThisWh(spreadNum))
                        {
                            c.LeftCell = (Cell)_Cells[spreadNum];
                        }
                    }
                    else
                    {
                        c.LeftCell = null;
                    }


                    spreadNum = GetSpreadNum(x, y, 0, -1);
                    if (c.WhModeId == 2 && cell_yf == -1)
                    {
                        if (InThisWh(spreadNum))
                        {

                            c.DownCell = (Cell)_Cells[spreadNum];
                        }
                    }
                    else if (c.WhModeId != 2)
                    {
                        if (InThisWh(spreadNum))
                        {

                            c.DownCell = (Cell)_Cells[spreadNum];
                        }
                    }
                    else
                    {
                        c.DownCell = null;
                    }

                    spreadNum = GetSpreadNum(x, y, 0, 1);
                    if (c.WhModeId == 2 && cell_yb == -1)
                    {
                        if (InThisWh(spreadNum))
                        {
                            c.UpCell = (Cell)_Cells[spreadNum];
                        }
                    }
                    else if (c.WhModeId != 2)
                    {
                        if (InThisWh(spreadNum))
                        {
                            c.UpCell = (Cell)_Cells[spreadNum];
                        }
                    }
                    else
                    {
                        c.UpCell = null;
                    }



                }

               

            }


        }

        /// <summary>
        /// 以X.Y为原点向四周扩散，找到下一点
        /// </summary>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        /// <param name="a">x增量</param>
        /// <param name="b">y增量</param>
        /// <returns></returns>
        public string GetSpreadNum(int x, int y, int a, int b)
        {
            return Fn.ToString(x + a) + "." + Fn.ToString(y + b);

        }


        /// <summary>
        /// 判读该单元格是否可用
        /// </summary>
        /// <param name="cellNum">单元格坐标</param>
        /// <returns></returns>
        public bool InThisWh(string cellNum)
        {
            if (_Cells[cellNum] != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 任务分解初始化参数
        /// </summary>
        /// <param name="c"></param>
        /// <param name="cmdId"></param>

        public void InitCmdBreak(CmdBreak c, string cmdId)
        {
            c.CmdId = cmdId;
            c.Xnum = _cXnum;
            c.Ynum = _cYnum;
            c.FloorNum = _cFloor;
            c.CellNum = _currentNum;
            c.Rack = _rack;
            c.TaskType = _taskType;

            c.XF = _xf;
            c.XB = _xb;
            c.YF = _yf;
            c.YB = _yb;
            c.MACADRESS = _macAdress;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="cmdId"></param>
        /// <returns></returns>
        public int GetAToBStepNum(int cmdId)
        {
            string proc = "WCS.GetAToBStepNum";
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pCmdId", DbType.Int32, cmdId);
            db.AddOutParameter(cmd, "pAsrvId", DbType.Int32, 1000);
            db.ExecuteDataSet(cmd);
            return int.Parse(db.GetParameterValue(cmd, "pAsrvId").ToString());
        }
    }


}
