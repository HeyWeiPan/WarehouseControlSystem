using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Warehouse.Comm;

namespace mapself.Comm
{
    public class CheckOldTask
    {
        public static void main()
        {
            string sql, sqlcmd_id,sql1,cmdid,temp;
            DataTable dt, dtnew;
            byte[] cmd_byte_list = null;
            int i,asrvid;

            sql = "select b.* from wcs.wcs.wcs_asrv_cmd a, wcs.wcs.wcs_cmd_Breakdown b where a.cmd_id = b.cmd_id and b.cmd_type='TASK' and Task_finish_flag =0";
            dtnew = SQLConnaction.QuerySQL(sql).Tables[0];

            for (i = 0; i < dtnew.Rows.Count; i++)
            {                
                cmd_byte_list = (byte[])dtnew.Rows[i]["cmd_b_code"];

                byte[] cmd_task_list = sqlwatcher.GetCmdTask(cmd_byte_list);//5A之后TASK指令部分
                byte[] taskstring = sqlwatcher.gettask(cmd_task_list);//只包含坐标点，最后终点坐标再重复一次

                cmdid = dtnew.Rows[i]["cmd_id"].ToString();

                temp = dtnew.Rows[i]["asrv_id"].ToString();
                int.TryParse(temp, out asrvid);

                make_it_run.refresh(asrvid);//使用前刷新小车对象的一些属性

                asrvlist.aslist[asrvlist.basrv[asrvid]].cmd_id = cmdid;

                asrvlist.aslist[asrvlist.basrv[asrvid]].load_flag = sqlwatcher.get_task_type(cmd_task_list);

                if (asrvlist.aslist[asrvlist.basrv[asrvid]].load_flag == true) asrvlist.aslist[asrvlist.basrv[asrvid]].max_velocity = asrv.max_velocity_unloaded;
                else asrvlist.aslist[asrvlist.basrv[asrvid]].max_velocity = asrv.max_velocity_loaded;

                for (int ii = 0; ii < 8; ii++)
                {
                    asrvlist.aslist[asrvlist.basrv[asrvid]].macAddress_cmd[ii] = cmd_byte_list[ii + 5];
                }

                once_ylx.main(asrvid, cmdid, cmd_byte_list);
                make_it_run.main(taskstring, asrvid);
            }//end for
        }//end main
    }
}