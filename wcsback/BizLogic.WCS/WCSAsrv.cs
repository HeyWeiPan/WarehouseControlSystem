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

namespace EntpClass.BizLogic.WCS
{
    public class WCSAsrv : DBRowBase
    {
        public WCSAsrv()
            : base()
        {
        }

        public WCSAsrv(String id)
            : base(id)
        {
        }
        public const int FunctionId = 910020;

        public override DbCommand GetSelectCommand(Microsoft.Practices.EnterpriseLibrary.Data.Database db, string keyValue)
        {
            string proc = "WCS.GetWCSAsrvDetail";
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pKeyValue", DbType.Int32, Fn.ToInt(keyValue));
            return cmd;
        }


        protected override void SetParameter(ref DbRowParameter p)
        {
            p.TableName = "wcs_asrv";
            p.KeyName = "asrv_id";
            p.IsKeyValueIdentity = true;
            p.IsLogicalDelete = false;
            p.PageFunctionID = FunctionId;
            p.ConnectionString = WCSConst.ConnectionName;
            p.DetailDialogWindow.Url = UrlHelper.UrlBase + ("/WCS/Asrv/AsrvDetail.aspx");
            p.DetailDialogWindow.Width = 1000;
            p.DetailDialogWindow.Height = 700;
        }

        protected override void InitNewRow()
        {
            base.InitNewRow();
            this["enable_flag"] = -1;

        }

        public override bool Delete(Database db, DbTransaction transaction)
        {

            string proc = "WCS.DeleteAsrv";
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pKeyValue", DbType.Int32, KeyValue);
            db.ExecuteNonQuery(cmd, transaction);
            return base.Delete(db, transaction);
        }

        public static DataSet GetAsrvStatusList(string asrvId)
        {
            string proc = "WCS.GetAsrvStatusList";
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pAsrvId", DbType.Int32, asrvId);
            return db.ExecuteDataSet(cmd);
        }

        public static DataSet GetAsrvList(string whId)
        {
            string proc = "WCS.GetAsrvList";
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pWhId", DbType.Int32, whId);
            return db.ExecuteDataSet(cmd);
        }

        public void UpdateWhInfo(Database db, DbTransaction transaction)
        {
            string sql = "update a set a.wh_name=b.wh_name ,a.wh_code=b.wh_code from wcs_asrv a,wcs_wh b where a.wh_id=b.wh_id and a.asrv_id=@pKeyValue";
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "pKeyValue", DbType.Int32, KeyValue);
            db.ExecuteNonQuery(cmd, transaction);
        }

        public void CheckAsrvInit(Database db, DbTransaction transaction,byte[] b)
        {
            string proc = "WCS.CheckAsrvInit";
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pKeyValue", DbType.Int32, KeyValue);
            db.AddInParameter(cmd, "pAddress", DbType.Binary, b);
            db.ExecuteNonQuery(cmd, transaction);
        }


        public byte[] CheckMacAdress(string mac)
        {
            string[] s = mac.Split(':');

            if (s.Length != 8)
            {
                throw new Exception("地址格式不正确，请用‘:’隔开8位十六进制数");
               
            }
            try
            {

                byte[] buffer = new byte[8];

                for (int i = 0; i < s.Length; i++)
                {
                    buffer[i] = (byte)int.Parse(s[i], System.Globalization.NumberStyles.HexNumber);
                }
                return buffer;
            }
            catch
            {
                throw new Exception("地址格式不正确，请用‘:’隔开8位十六进制数");
            }

        }


        public override bool Insert(string newKeyValue, System.Collections.Hashtable dataControlCollection, Microsoft.Practices.EnterpriseLibrary.Data.Database db, System.Data.Common.DbTransaction transaction)
        {

            IWebDataControl macAdress = Fn.GetControlByColumnName(dataControlCollection, "mac_adress");
            string mac = macAdress.GetValue();

            if (!base.Insert(newKeyValue, dataControlCollection, db, transaction))
                return false;
            else
            {
                try
                {

                    CheckAsrvInit(db, transaction, CheckMacAdress(mac));
                    return true;
                }
                catch (SqlException ex)
                {
                    ErrorMessage = ex.Message;
                    return false;
                }
            }
        }

        public override bool Update(System.Collections.Hashtable dataControlCollection, Database db, DbTransaction transaction)
        {
            IWebDataControl macAdress = Fn.GetControlByColumnName(dataControlCollection, "mac_adress");
            string mac = macAdress.GetValue();
            if (!base.Update(dataControlCollection, db, transaction))
                return false;
            else
            {
                try
                {
                    CheckAsrvInit(db, transaction, CheckMacAdress(mac));

                    return true;
                }
                catch (SqlException ex)
                {
                    ErrorMessage = ex.Message;
                    return false;
                }
            }
        }
    }
}
