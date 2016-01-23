using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.Common;
using EntpClass.BizLogic.HR;
using EntpClass.BizLogic.HR.OrgChart;
using EntpClass.BizLogic.HR.Setup;
using EntpClass.BizLogic.Security;

/// <summary>
/// WsHR 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WsHR : System.Web.Services.WebService
{
    public WsHR()
    {
        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession = true)]
    public string DeleteTeam(int teamId)
    {
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        using (DbConnection connection = db.CreateConnection())
        {
            connection.Open();
            DbTransaction tran = connection.BeginTransaction();
            DbCommand dbCommand = db.GetStoredProcCommand("HR.TeamDelete");
            db.AddInParameter(dbCommand, "pTeamId", DbType.Int32, teamId);
            db.AddInParameter(dbCommand, "pUserId", DbType.Int32, CurrentUser.UserID);

            if (CurrentUser.UseLanguage == Language.Chinese)
                db.AddInParameter(dbCommand, "pLanguage", DbType.String, "CN");
            else
                db.AddInParameter(dbCommand, "pLanguage", DbType.String, "EN");

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
    public string CopyTeam(int fromId, int toId)
    {
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        using (DbConnection connection = db.CreateConnection())
        {
            connection.Open();
            DbTransaction tran = connection.BeginTransaction();
            DbCommand dbCommand = db.GetStoredProcCommand("HR.TeamCopy");
            db.AddInParameter(dbCommand, "pFromId", DbType.Int32, Fn.ToInt(fromId));
            db.AddInParameter(dbCommand, "pToId", DbType.Int32, Fn.ToInt(toId));
            db.AddInParameter(dbCommand, "pUserId", DbType.Int32, CurrentUser.UserID);

            if (CurrentUser.UseLanguage == Language.Chinese)
                db.AddInParameter(dbCommand, "pLanguage", DbType.String, "CN");
            else
                db.AddInParameter(dbCommand, "pLanguage", DbType.String, "EN");

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
    public string CutTeam(string fromId, string toId)
    {
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        using (DbConnection connection = db.CreateConnection())
        {
            connection.Open();
            DbTransaction tran = connection.BeginTransaction();

            DbCommand dbCommand = db.GetStoredProcCommand("HR.TeamCut");
            db.AddInParameter(dbCommand, "pFromId", DbType.Int32, Fn.ToInt(fromId));
            db.AddInParameter(dbCommand, "pToId", DbType.Int32, Fn.ToInt(toId));
            db.AddInParameter(dbCommand, "pUserId", DbType.Int32, CurrentUser.UserID);

            if (CurrentUser.UseLanguage == Language.Chinese)
                db.AddInParameter(dbCommand, "pLanguage", DbType.String, "CN");
            else
                db.AddInParameter(dbCommand, "pLanguage", DbType.String, "EN");

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
    public string GetTeamName(string teamId)
    {
        return Team.GetTeamName(teamId);
    }

    [WebMethod(EnableSession = true)]
    public string DelTrainingStructure(int teamId)
    {
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        using (DbConnection connection = db.CreateConnection())
        {
            connection.Open();
            DbTransaction tran = connection.BeginTransaction();
            DbCommand dbCommand = db.GetStoredProcCommand("HR.TrainingStructureDel");
            db.AddInParameter(dbCommand, "pStructureId", DbType.Int32, teamId);
            db.AddInParameter(dbCommand, "pUserId", DbType.Int32, CurrentUser.UserID);

            if (CurrentUser.UseLanguage == Language.Chinese)
                db.AddInParameter(dbCommand, "pLanguage", DbType.String, "CN");
            else
                db.AddInParameter(dbCommand, "pLanguage", DbType.String, "EN");

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
    public string CopyTrainingStructure(int fromId, int toId)
    {
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        using (DbConnection connection = db.CreateConnection())
        {
            connection.Open();
            DbTransaction tran = connection.BeginTransaction();
            DbCommand dbCommand = db.GetStoredProcCommand("HR.TrainingStructureCopy");
            db.AddInParameter(dbCommand, "pFromId", DbType.Int32, Fn.ToInt(fromId));
            db.AddInParameter(dbCommand, "pToId", DbType.Int32, Fn.ToInt(toId));
            db.AddInParameter(dbCommand, "pUserId", DbType.Int32, CurrentUser.UserID);

            if (CurrentUser.UseLanguage == Language.Chinese)
                db.AddInParameter(dbCommand, "pLanguage", DbType.String, "CN");
            else
                db.AddInParameter(dbCommand, "pLanguage", DbType.String, "EN");

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
    public string CutTrainingStructure(string fromId, string toId)
    {
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        using (DbConnection connection = db.CreateConnection())
        {
            connection.Open();
            DbTransaction tran = connection.BeginTransaction();

            DbCommand dbCommand = db.GetStoredProcCommand("HR.TrainingStructureCut");
            db.AddInParameter(dbCommand, "pFromId", DbType.Int32, Fn.ToInt(fromId));
            db.AddInParameter(dbCommand, "pToId", DbType.Int32, Fn.ToInt(toId));
            db.AddInParameter(dbCommand, "pUserId", DbType.Int32, CurrentUser.UserID);

            if (CurrentUser.UseLanguage == Language.Chinese)
                db.AddInParameter(dbCommand, "pLanguage", DbType.String, "CN");
            else
                db.AddInParameter(dbCommand, "pLanguage", DbType.String, "EN");

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
    public string GetWorkSkillXml(string workSkillCategoryCode)
    {
        string sql = WorkSkill.GetWorkSkillSql(workSkillCategoryCode);
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetSqlStringCommand(sql);
        DataSet ds = db.ExecuteDataSet(cmd);
        return ds.GetXml();
    }

    [WebMethod]
    public string GetWorkSkillLevelXml(string workSkillId)
    {
        string sql = WorkSkillLevel.GetWorkSkillLevelSql(workSkillId);
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetSqlStringCommand(sql);
        DataSet ds = db.ExecuteDataSet(cmd);
        return ds.GetXml();
    }


    [WebMethod]
    public string GetPayStructureXml(string payGrade)
    {
        string proc = "HR.GetPayStructureDetail";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pPayGrade", DbType.String, payGrade);
        DataSet ds = db.ExecuteDataSet(cmd);
        return ds.GetXml();
    }

    [WebMethod]
    public string GetCourseXml(string courseId)
    {
        string proc = "HR.GetTrainingCourseDetail";
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pCourseId", DbType.String, courseId);
        db.AddInParameter(cmd, "pLanguage", DbType.String, DBSetting.MultiLanguageSuffix);
        DataSet ds = db.ExecuteDataSet(cmd);
        return ds.GetXml();
    }

}

