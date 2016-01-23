using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using EntpClass.WebControlLib;
using System.Data;
using EntpClass.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Text;
using EntpClass.BizLogic.WCS;

public partial class Setup_MapLeftMenu : PageBase
{
    public override void SetPageInfo(ref EntpClass.Common.PageParameter p)
    {
        return;
    }

    protected override void OnPreRender(EventArgs e)//在信息被写入到客户端前触发
    {
        base.OnPreRender(e);

        //RenderMenuScript();
        //RenderClientScript();
    }


    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);     //在网页初始化时开始发生，生成并显示任务列表


        DataSet dsWait = GetAsrvTask(0);//数据集，存放等待完成任务信息
        DataSet dsEnd = GetAsrvTask(-1);

        //可变的字符序列，类似字符串
        StringBuilder s1 = new StringBuilder();//存储等待完成任务列表，为无序字符序列
        StringBuilder s2 = new StringBuilder();
        for (int i = 0; i < dsWait.Tables[0].Rows.Count; i++)//等待完成任务的个数
        {
            s1.Append("<li>");//添加到s1字符串的后面
            //第一个参数为显示路径的链接，第二个参数为显示在页面上的任务说明
            s1.AppendFormat("<a href=\"javascript:ShowRoute({0},{1},{2});\">{3}</a>", dsWait.Tables[0].Rows[i]["cmd_id"], dsWait.Tables[0].Rows[i]["wh_id"], dsWait.Tables[0].Rows[i]["to_floor_num"], dsWait.Tables[0].Rows[i]["task_desc"]);
            s1.AppendFormat("&nbsp;&nbsp;<a id=\"delete_{0}\" style=\"color:red;\"  href=\"javascript:var b=confirm('是否删除该任务？');if(b) DeleteCmd({0},{1},{2});\">删除</a>", dsWait.Tables[0].Rows[i]["cmd_id"], dsWait.Tables[0].Rows[i]["wh_id"], dsWait.Tables[0].Rows[i]["to_floor_num"]);
            s1.AppendFormat("&nbsp;&nbsp;<a id=\"setcurrent_{0}\" style=\"color:green;\"  href=\"javascript:var b=confirm('是否设置该任务为小车{1}正在执行任务？');if(b) SetCurrentCMD({0},{2},{3});\">置为当前</a>", dsWait.Tables[0].Rows[i]["cmd_id"], dsWait.Tables[0].Rows[i]["asrv_code"], dsWait.Tables[0].Rows[i]["wh_id"], dsWait.Tables[0].Rows[i]["from_floor_num"]);
            s1.AppendFormat("&nbsp;&nbsp;<a id=\"hand_{0}\" href=\"javascript:SetOperate({0});\">手动</a>", dsWait.Tables[0].Rows[i]["cmd_id"]);
            s1.AppendFormat("&nbsp;&nbsp;<a id=\"auto_{0}\" href=\"javascript:SetOperateType(-1,{0});\">自动</a>", dsWait.Tables[0].Rows[i]["cmd_id"]);
            //s1.AppendFormat("&nbsp;&nbsp;<a id=\"start\" href=\"javascript:startTask()\">开始</a>");
            //s1.AppendFormat("&nbsp;&nbsp;<a id=\"stop\" href=\"javascript:stopTask()\">停止</a>");
            s1.Append("</li>");
        }

        for (int i = 0; i < dsEnd.Tables[0].Rows.Count; i++)
        {
            s2.Append("<li>");
            s2.AppendFormat("{0}", dsEnd.Tables[0].Rows[i]["task_desc"]);
            s2.Append("</li>");
        }





        //向aspx文件中预留的位置添加任务列表
        PHTaskWait.Controls.Add(new LiteralControl(s1.ToString()));
        PHTaskEnd.Controls.Add(new LiteralControl(s2.ToString()));
    }


    public DataSet GetAsrvTask(int endFlag)
    {
        string proc = "WCS.GetAsrvTask";
        Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc); //存储过程命令
        db.AddInParameter(cmd, "pEndFlag", DbType.Int32, endFlag);
        return db.ExecuteDataSet(cmd);//返回数据库存放地，即一系列数据列表，为一个dataTable
    }
}