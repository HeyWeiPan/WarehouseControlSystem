using System;
using System.Text;
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
/// WsHome 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService] 
public class WsHome : System.Web.Services.WebService
{
    public WsHome() { }

    [WebMethod]
    public string GetUserInfoXML(string userId)
    {
        //字段 lowercase_login_name,email 统一大写
        string str = "select user_id,LOWERCASE_LOGIN_NAME,EMAIL from def_user where user_ID = " + userId;

        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetSqlStringCommand(str.ToString());
        DataSet ds = db.ExecuteDataSet(cmd);

        return ds.GetXml();
    }

    [WebMethod(EnableSession = true)]
    public void InsertScrFavorate(string functionId)
    {        
        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand("InsertScrFavorate");
        db.AddInParameter(cmd, "@pFunctionID", DbType.Int32, Fn.ToInt(functionId));
        db.AddInParameter(cmd, "@pUuserID", DbType.Int32, CurrentUser.UserID);
        db.ExecuteNonQuery(cmd);
    }

    [WebMethod]
    public void DeleteScrFavorate(string functionId)
    {
        string str = "delete from scr_favorate where favorate_ID= " + functionId;

        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);        
        DbCommand dbCommand = db.GetSqlStringCommand(str.ToString());
        db.ExecuteNonQuery(dbCommand);
    }
}

