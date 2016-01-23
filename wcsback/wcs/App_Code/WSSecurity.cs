using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.Common;
using EntpClass.BizLogic.Security;

/// <summary>
/// Summary description for Security
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService] 
public class WSSecurity : System.Web.Services.WebService
{
    [WebMethod]
    public string DelSubRole(string RoleID, string RolePID)
    {
        try
        {
            RoleRelation.DelSubRole(RoleID, RolePID);
            return "Sub role was deleted successfully!";
        }
        catch (Exception excp)
        {
            return excp.Message;
        }
    }

    /// <summary>
    /// 删除菜单项
    /// </summary>
    /// <param name="funcionId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    [WebMethod]
    public string DeleteFunction(string funcionId,string userId)
    {
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        using (DbConnection connection = db.CreateConnection())
        {
            connection.Open();
            DbTransaction tran = connection.BeginTransaction();

            DbCommand dbCommand = db.GetStoredProcCommand("DeleteScrFunction");
            db.AddInParameter(dbCommand, "pFunction_id", DbType.Int32, Fn.ToInt(funcionId));
            db.AddInParameter(dbCommand, "pUser", DbType.Int32, userId);

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

    /// <summary>
    /// 拷贝菜单项
    /// </summary>
    /// <param name="fromId"></param>
    /// <param name="toId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    [WebMethod]
    public string CopyFunction(string fromId,string toId,string userId)
    {
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        using (DbConnection connection = db.CreateConnection())
        {
            connection.Open();
            DbTransaction tran = connection.BeginTransaction();

            DbCommand dbCommand = db.GetStoredProcCommand("CopyScrFunction");
            db.AddInParameter(dbCommand, "pFromId", DbType.Int32, Fn.ToInt(fromId));
            db.AddInParameter(dbCommand, "pToId", DbType.Int32, Fn.ToInt(toId));
            db.AddInParameter(dbCommand, "pUser", DbType.Int32, userId);

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

    /// <summary>
    /// cut菜单
    /// </summary>
    /// <param name="fromId"></param>
    /// <param name="toId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    [WebMethod]
    public string CutFunction(string fromId, string toId,string userId)
    {
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        using (DbConnection connection = db.CreateConnection())
        {
            connection.Open();
            DbTransaction tran = connection.BeginTransaction();

            DbCommand dbCommand = db.GetStoredProcCommand("CutScrFunction");
            db.AddInParameter(dbCommand, "pFromId", DbType.Int32, Fn.ToInt(fromId));
            db.AddInParameter(dbCommand, "pToId", DbType.Int32, Fn.ToInt(toId));
            db.AddInParameter(dbCommand, "pUser", DbType.Int32, userId);

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
    public string GetFunctionName(string functionID)
    {    
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);

        DbCommand dbCommand = db.GetSqlStringCommand("select function_name_" + DBSetting.MultiLanguageSuffix + " from scr_function where function_id = " + functionID);
        
        return Fn.ToString(db.ExecuteScalar(dbCommand));
    }

    [WebMethod]
    public string DeleteRoleFunction(string functionID, int roleID,int userID)
    {
        try
        {
            RoleFunctionOperation.SaveRoleFunction(roleID, functionID, userID,1, null);
            return "true";
        }
        catch (Exception err)
        {
            return err.Message;
        }
    }
}

