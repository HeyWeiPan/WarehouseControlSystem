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
    public class WCSWH : DBRowBase
    {
        public WCSWH()
            : base()
        {
        }

        public WCSWH(String id)
            : base(id)
        {
        }
        public const int FunctionId = 910010;

        public override DbCommand GetSelectCommand(Microsoft.Practices.EnterpriseLibrary.Data.Database db, string keyValue)
        {
            string proc = "WCS.GetWCSWHDetail";
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pKeyValue", DbType.Int32, Fn.ToInt(keyValue));
            return cmd;
        }

        protected override void InitNewRow()
        {
            base.InitNewRow();
            this["enable_flag"] = -1;
        }


        protected override void SetParameter(ref DbRowParameter p)
        {
            p.TableName = "wcs_wh";
            p.KeyName = "wh_id";
            p.IsKeyValueIdentity = true;
            p.IsLogicalDelete = false;
            p.PageFunctionID = FunctionId;
            p.ConnectionString = WCSConst.ConnectionName;
            p.DetailDialogWindow.Url = UrlHelper.UrlBase + ("/WCS/WH/WHDetail.aspx");
            p.DetailDialogWindow.Width = 1000;
            p.DetailDialogWindow.Height = 700;
        }

        public override bool Delete(Database db, DbTransaction transaction)
        {

            string proc = "WCS.DeleteWH";
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pKeyValue", DbType.Int32,KeyValue);
            db.ExecuteNonQuery(cmd,transaction);
            return base.Delete(db, transaction);
        }

        public override bool Insert(string newKeyValue, System.Collections.Hashtable dataControlCollection, Microsoft.Practices.EnterpriseLibrary.Data.Database db, System.Data.Common.DbTransaction transaction)
        {
            if (base.Insert(newKeyValue, dataControlCollection, db, transaction))
            {
                DbCommand cmd = db.GetStoredProcCommand("wcs.AddCellDirection");
                db.AddInParameter(cmd, "pWhId", DbType.Int32, KeyValue);
                db.ExecuteNonQuery(cmd, transaction);
                return true;
            }

            return true;
        }
    }
}
