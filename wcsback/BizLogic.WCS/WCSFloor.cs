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
    public class WCSFloor : DBRowBase
    {
        public WCSFloor()
            : base()
        {
        }

        public WCSFloor(String id)
            : base(id)
        {
        }
        public const int FunctionId = 910010;

        public override DbCommand GetSelectCommand(Microsoft.Practices.EnterpriseLibrary.Data.Database db, string keyValue)
        {
            string proc = "WCS.GetWCSFloorDetail";
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pKeyValue", DbType.Int32, Fn.ToInt(keyValue));
            return cmd;
        }


        protected override void SetParameter(ref DbRowParameter p)
        {
            p.TableName = "wcs_floor";
            p.KeyName = "floor_id";
            p.IsKeyValueIdentity = true;
            p.IsLogicalDelete = false;
            p.PageFunctionID = FunctionId;
            p.ConnectionString = WCSConst.ConnectionName;
            p.DetailDialogWindow.Url = UrlHelper.UrlBase + ("/WCS/WH/FloorDetail.aspx");
            p.DetailDialogWindow.Width = 1000;
            p.DetailDialogWindow.Height = 700;
        }

        public override bool Delete(Database db, DbTransaction transaction)
        {

            string proc = "WCS.DeleteFloor";
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pKeyValue", DbType.Int32, KeyValue);
            db.ExecuteNonQuery(cmd, transaction);
            return base.Delete(db, transaction);
        }

        public static DataSet GetFloorList(string whId)
        {
            string proc = "WCS.GetFloorList";
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
                    UpdateFloorCells(db, transaction);
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
                    UpdateFloorCells(db, transaction);
                    return true;
                }
                catch (SqlException ex)
                {
                    ErrorMessage = ex.Message;
                    return false;
                }
            }
        }


        public void UpdateFloorCells(Database db, DbTransaction transaction)
        {
            string proc = "WCS.UpdateFloorCells";
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pFloorId", DbType.Int32, KeyValue);
            db.ExecuteNonQuery(cmd, transaction);
        }
    }
}
