using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using EntpClass.Common;
using EntpClass.BizLogic.Security;

public class HomeInformation
{
    public static DataSet GetPendingMattersList()
    {
        string proc = "PA.GetPendingMattersList";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pUserId", DbType.Int32, CurrentUser.UserID);
        return db.ExecuteDataSet(cmd);
    }

    public static int GetFavorateId(int functionId)
    {
        string sql = "select favorate_id from scr_favorate where user_id=@pUserId and function_id=@pFunctionId";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetSqlStringCommand(sql);
        db.AddInParameter(cmd, "pUserId", DbType.Int32, CurrentUser.UserID);
        db.AddInParameter(cmd, "pFunctionId", DbType.Int32, functionId);
        object rnt = db.ExecuteScalar(cmd);
        if (rnt != null)
        {
            return Fn.ToInt(rnt);
        }
        else
            return 0;

    }

    public static DataSet GetUserFavorateList()
    {
        string sql = "select menu_name_cn function_name,page_url,function_id from scr_favorate where user_id=@pUserId order by show_order";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetSqlStringCommand(sql);
        db.AddInParameter(cmd, "pUserId", DbType.Int32, CurrentUser.UserID);
        return db.ExecuteDataSet(cmd);
    }


    public static DataSet GetMsgList()
    {
        StringBuilder s = new StringBuilder(200);
        s.Append("select receive_id,datename(mm,send_date)+'/'+datename(dd,send_date)+' '+datename(hh,send_date)+':'+datename(mi,send_date) send_date,");
        s.Append("title from msg_receive_box where receive_user_id=@pUserId and delete_flag=0 and status_code='unread' order by send_date desc");
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetSqlStringCommand(s.ToString());
        db.AddInParameter(cmd, "pUserId", DbType.Int32, CurrentUser.UserID);
        return db.ExecuteDataSet(cmd);
    }
}

