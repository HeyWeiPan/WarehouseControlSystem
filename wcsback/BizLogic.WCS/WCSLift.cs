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
    public class WCSLift : DBRowBase
    {
        public WCSLift()
            : base()
        {
        }

        public WCSLift(String id)
            : base(id)
        {
        }
        public const int FunctionId = 910010;

        public override DbCommand GetSelectCommand(Microsoft.Practices.EnterpriseLibrary.Data.Database db, string keyValue)
        {
            return null;
        }


        protected override void SetParameter(ref DbRowParameter p)
        {
            p.TableName = "wcs_lift";
            p.KeyName = "lift_id";
            p.IsKeyValueIdentity = true;
            p.IsLogicalDelete = false;
            p.PageFunctionID = FunctionId;
            p.ConnectionString = WCSConst.ConnectionName;


        }

      

        public static DataSet GetWHLiftList(string whId)
        {
            string proc = "WCS.GetWHLiftList";
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pWhId", DbType.Int32, whId);
            return db.ExecuteDataSet(cmd);
        }


        public override bool Insert(string newKeyValue, System.Collections.Hashtable dataControlCollection, Database db, DbTransaction transaction)
        {
            if (!base.Insert(newKeyValue, dataControlCollection, db, transaction))
                return false;
            else
            {
                try
                {
                    UpdateLiftCells(db, transaction);
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
            if (!base.Update(dataControlCollection, db, transaction))
                return false;
            else
            {
                try
                {
                    UpdateLiftCells(db, transaction);
                    return true;
                }
                catch (SqlException ex)
                {
                    ErrorMessage = ex.Message;
                    return false;
                }
            }
        }


        public void UpdateLiftCells(Database db, DbTransaction transaction)
        {
            string proc = "WCS.UpdateLiftCells";
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pLiftId", DbType.Int32, KeyValue);
            db.ExecuteNonQuery(cmd, transaction);
        }

    }
}
