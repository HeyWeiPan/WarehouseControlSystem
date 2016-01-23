using System;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.Common;
using EntpClass.BizLogic.Setup;
using EntpClass.BizLogic.Security;
using EntpClass.BizLogic.WCS;
using WCSServer;

/// <summary>
/// WsSetUp 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//[ScriptService]
[System.Web.Script.Services.ScriptService]
public class WsSetup : System.Web.Services.WebService
{
    public WsSetup()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession = true)]
    public string DeleteGeography(int geoId)
    {
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        using (DbConnection connection = db.CreateConnection())
        {
            connection.Open();
            DbTransaction tran = connection.BeginTransaction();
            DbCommand dbCommand = db.GetStoredProcCommand("GeographyDelete");
            db.AddInParameter(dbCommand, "pGeoID", DbType.Int32, geoId);
            db.AddInParameter(dbCommand, "pUserId", DbType.Int32, CurrentUser.UserID);
            db.AddInParameter(dbCommand, "pLanguage", DbType.String, DBSetting.MultiLanguageSuffix);

            try
            {
                db.ExecuteNonQuery(dbCommand, tran);
                tran.Commit();
                return "true";
            }
            catch (Exception err)
            {
                tran.Rollback();
                return err.Message;
            }
            finally
            {
                connection.Close();
            }
        }
    }

    [WebMethod(EnableSession = true)]
    public string CopyGeography(int fromId, int toId)
    {
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        using (DbConnection connection = db.CreateConnection())
        {
            connection.Open();
            DbTransaction tran = connection.BeginTransaction();
            DbCommand dbCommand = db.GetStoredProcCommand("GeographyCopy");
            db.AddInParameter(dbCommand, "pFromId", DbType.Int32, Fn.ToInt(fromId));
            db.AddInParameter(dbCommand, "pToId", DbType.Int32, Fn.ToInt(toId));
            db.AddInParameter(dbCommand, "pUserId", DbType.Int32, CurrentUser.UserID);

            try
            {
                db.ExecuteNonQuery(dbCommand, tran);
                tran.Commit();
                return "true";
            }
            catch (Exception err)
            {
                tran.Rollback();
                return err.Message;
            }
            finally
            {
                connection.Close();
            }
        }
    }

    [WebMethod(EnableSession = true)]
    public string CutGeography(string fromId, string toId)
    {
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        using (DbConnection connection = db.CreateConnection())
        {
            connection.Open();
            DbTransaction tran = connection.BeginTransaction();

            DbCommand dbCommand = db.GetStoredProcCommand("GeographyCut");
            db.AddInParameter(dbCommand, "pFromId", DbType.Int32, Fn.ToInt(fromId));
            db.AddInParameter(dbCommand, "pToId", DbType.Int32, Fn.ToInt(toId));
            db.AddInParameter(dbCommand, "pUserId", DbType.Int32, CurrentUser.UserID);
            db.AddInParameter(dbCommand, "pLanguage", DbType.String, DBSetting.MultiLanguageSuffix);

            try
            {
                db.ExecuteNonQuery(dbCommand, tran);
                tran.Commit();
                return "true";
            }
            catch (Exception err)
            {
                tran.Rollback();
                return err.Message;
            }
            finally
            {
                connection.Close();
            }
        }
    }
    [WebMethod]
    public string GetFileFolderName(string folderId)
    {
        return FileFolder.GetFileFolderName(folderId);
    }


    [WebMethod(EnableSession = true)]
    public string DeleteFileFolder(int folderId)
    {
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        using (DbConnection connection = db.CreateConnection())
        {
            connection.Open();
            DbTransaction tran = connection.BeginTransaction();
            DbCommand dbCommand = db.GetStoredProcCommand("DeleteFileFolder");
            db.AddInParameter(dbCommand, "pFolderID", DbType.Int32, folderId);
            db.AddInParameter(dbCommand, "pUserId", DbType.Int32, CurrentUser.UserID);
            db.AddInParameter(dbCommand, "pLanguage", DbType.String, DBSetting.MultiLanguageSuffix);

            try
            {
                db.ExecuteNonQuery(dbCommand, tran);
                tran.Commit();
                return "true";
            }
            catch (Exception err)
            {
                tran.Rollback();
                return err.Message;
            }
            finally
            {
                connection.Close();
            }
        }
    }


    [WebMethod]
    public string GetGeographyName(string geoId)
    {
        return Geography.GetGeographyName(geoId);
    }

    [WebMethod(EnableSession = true)]
    public string GetCityList(string provinceId)
    {
        DataSet ds = Geography.GetCityList(provinceId);
        return ds.GetXml();
    }

    [WebMethod]
    public string GetAsrvRoute(string cmdId)//得到小车可用路线
    {
        string proc = "WCS.GetAsrvRoute";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pCmdId", DbType.Int32, cmdId);
        return db.ExecuteDataSet(cmd).GetXml();//将可用路线中每个表格的信息以xml的形式返回
    }


    [WebMethod]
    public void UpdateCellsType(string whId, string xmlVal)
        //因为在配置中心保存设置时可能会更改每个方格的属性，即表示巷道、货道或是不可用，更新后需要更新数据库中cells的type
    {
        string proc = "WCS.UpdateCellsType";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pWhId", DbType.Int32, whId);
        db.AddInParameter(cmd, "pXml", DbType.Xml, HttpUtility.UrlDecode(xmlVal));
        db.ExecuteNonQuery(cmd);            //执行命令

    }

    [WebMethod]
    public void UpdateCellsDirection(int whId, int whModeId,int tokenStrategyId, string xmlVal) 
    {
        string proc = "WCS.UpdateCellsDirection";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pWhId", DbType.Int32, whId);
        db.AddInParameter(cmd, "pWhModeId", DbType.Int32, whModeId);
        db.AddInParameter(cmd, "pTokenStrategyId", DbType.Int32, tokenStrategyId);
        db.AddInParameter(cmd, "pXml", DbType.Xml, HttpUtility.UrlDecode(xmlVal));
        db.ExecuteNonQuery(cmd);            //执行命令
    }

    [WebMethod]
    public void ClearCellsDirection(int whId) 
    {
        string proc = "WCS.ClearCellsDirection";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pWhId", DbType.Int32, whId);
        db.ExecuteNonQuery(cmd);            //执行命令
    }

    [WebMethod]
    public string GetFloorList(string whId)//得到对应仓库的楼层信息，以xml形式返回楼层列表各选项
    {
        string sql = "select floor_num text,floor_num value from wcs_floor where wh_id=@whId";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetSqlStringCommand(sql);
        db.AddInParameter(cmd, "whId", DbType.Int32, whId);
        return db.ExecuteDataSet(cmd).GetXml();
    }

    [WebMethod]
    public string GetAsrvList(string whId, string floorNum)//得到对应仓库和楼层的小车信息，以xml形式返回小车列表各选项
    {
        string sql = "select asrv_id value,asrv_code text from wcs_asrv where wh_id=@whId and floor_num=@floorNum and has_task_flag = 0";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetSqlStringCommand(sql);
        db.AddInParameter(cmd, "whId", DbType.Int32, whId); //加入命令参数
        db.AddInParameter(cmd, "floorNum", DbType.Int32, floorNum);//此函数有两个命令参数
        return db.ExecuteDataSet(cmd).GetXml();
    }

    [WebMethod]
    public string SaveAsrvTask(string whId,string asrvId,string floorNum,string fromXNum,string fromYNum,string xNum,string yNum,string taskTypeId)
    {
        string proc = "WCS.SaveAsrvTask";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "asrvId", DbType.Int32, asrvId);
        db.AddInParameter(cmd, "whId", DbType.Int32, whId);
        db.AddInParameter(cmd, "fromXNum", DbType.Int32, fromXNum);
        db.AddInParameter(cmd, "fromYNum", DbType.Int32, fromYNum);
        db.AddInParameter(cmd, "xNum", DbType.Int32, xNum);
        db.AddInParameter(cmd, "yNum", DbType.Int32, yNum);
        db.AddInParameter(cmd, "floorNum", DbType.Int32, floorNum);
        db.AddInParameter(cmd, "taskType", DbType.Int32, taskTypeId);
        db.AddOutParameter(cmd, "pOut", DbType.Int32, 10000);
        db.ExecuteNonQuery(cmd);
        string cmdId = Fn.ToString(db.GetParameterValue(cmd, "pOut"));//任务ID，取名字叫pout       

        Route r = new Route();//一个类，见route.cs文件定义
        bool b=r.CalcRoute(cmdId);//计算任务路径

        if (b)//如果计算得到可用的路径，返回包含路径的任务ID，返回结果是多个函数的result传递值
            return cmdId;
        else
        {
            return "error";
        }

    }

    [WebMethod]
    public void SetRoadRight()
    {
        Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
        DbCommand cmd1 = db.GetStoredProcCommand("wcs.SetRoadRight");
        db.ExecuteNonQuery(cmd1);

        SendCmd sc = new SendCmd();
        //发送路权令牌
        DataSet dsToken = sc.GetRoadRightCMD();
        byte[] bufferRight = null;
        for (int j = 0; j < dsToken.Tables[0].Rows.Count; j++)
        {
            bufferRight = Asrv.GetSendData(Asrv.GetTokenCmd(int.Parse(dsToken.Tables[0].Rows[j]["step_num"].ToString())), (byte[])(dsToken.Tables[0].Rows[j]["address"]));
            string cmdId = dsToken.Tables[0].Rows[j]["cmd_id"].ToString();
            sc.InsertCmdBreakdown(cmdId, bufferRight);
            //if (sc.checktokensendcnt(cmdid, bufferright)) //如果相同的令牌发送次数没有超过最大发送次数则发送路权令牌
            //{

            //    workstream.write(bufferright, 0, bufferright.length);


            //    sc.insertcmdbreakdown(cmdid, bufferright);
            //}
        }
    }

    [WebMethod]
    public string GetWhRack(string whId)
    {
        string sql = "select rack_direction from wcs_wh where wh_id=@whId";//仓库中的架子方向？不明白……

        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetSqlStringCommand(sql);
        db.AddInParameter(cmd, "whId", DbType.Int32, Fn.ToInt(whId));
        return Fn.ToString(db.ExecuteScalar(cmd));
    }

    [WebMethod]
    public string UpdWhMode(string whId,string modeId)
    {
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand("wcs.UpdWhMode");
        db.AddInParameter(cmd, "pWhId", DbType.Int32, Fn.ToInt(whId));
        db.AddInParameter(cmd, "pModeId", DbType.Int32, Fn.ToInt(modeId));
        return Fn.ToString(db.ExecuteScalar(cmd));
    }


    [WebMethod]
    public string SendAsrvCmd(string asrvId,string cmdType)
    {
        AsrvRemoteControl a = new AsrvRemoteControl();

        try
        {
            a.SendCmd(asrvId, cmdType);
            return "";
        }
        catch(Exception ex)
        {
            return ex.Message;
        }
    }

    [WebMethod]
    public string GetWhAsrvLocation(string whId, string floorNum)
    {
        string proc = "wcs.GetWhAsrvLocation";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pWhId", DbType.Int32, Fn.ToInt(whId));
        db.AddInParameter(cmd, "pFloorNum", DbType.Int32, Fn.ToInt(floorNum));
        return db.ExecuteDataSet(cmd).GetXml();
    }



    [WebMethod]
    public string GetRoadRight(string whId, string floorNum)
    {
        string proc = "wcs.GetRoadRight";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pWhId", DbType.Int32, Fn.ToInt(whId));
        db.AddInParameter(cmd, "pFloorNum", DbType.Int32, Fn.ToInt(floorNum));
        return db.ExecuteDataSet(cmd).GetXml();
    }


    [WebMethod]
    public void DeleteCmd(string cmdId)
    {
        string proc = "wcs.DeleteCmd";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pCmdId", DbType.Int32, Fn.ToInt(cmdId));

        db.ExecuteNonQuery(cmd);
    }

    [WebMethod]
    public void SetOperateType(string type,string cmdId) 
    {
        string proc = "wcs.SetOperateType";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pType", DbType.Int32, Fn.ToInt(type));
        db.AddInParameter(cmd, "pCmdId", DbType.Int32, Fn.ToInt(cmdId));
        db.ExecuteNonQuery(cmd);
    }


    [WebMethod]
    public void SetCurrentCMD(string cmdId)
    {
        string proc = "wcs.SetCurrentCMD";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pCmdId", DbType.Int32, Fn.ToInt(cmdId));

        db.ExecuteNonQuery(cmd);
    }

   
}

