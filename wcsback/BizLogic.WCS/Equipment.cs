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
    public class Equipment : DBRowBase
    {
        public Equipment()
            : base()
        {
        }

        public Equipment(String id)
            : base(id)
        {
        }
        public const int FunctionId = 910050;

        public override DbCommand GetSelectCommand(Microsoft.Practices.EnterpriseLibrary.Data.Database db, string keyValue)
        {
            string proc = "WCS.GetEquipmentDetail";
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pKeyValue", DbType.Int32, Fn.ToInt(keyValue));
            return cmd;
        }


        protected override void SetParameter(ref DbRowParameter p)
        {
            p.TableName = "wcs_equipment";
            p.KeyName = "equipment_id";
            p.IsKeyValueIdentity = true;
            p.IsLogicalDelete = false;
            p.PageFunctionID = FunctionId;
            p.ConnectionString = WCSConst.ConnectionName;
            p.DetailDialogWindow.Url = UrlHelper.UrlBase + ("/WCS/WH/EquipmentDetail.aspx");
            p.DetailDialogWindow.Width = 800;
            p.DetailDialogWindow.Height = 600;
        }


        protected override void InitNewRow()
        {
            base.InitNewRow();
            this["enable_flag"] = -1;

        }

        public static DataSet GetWHEquipmentList(string whId)
        {
            string proc = "WCS.GetWHEquipmentList";
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pWhId", DbType.Int32, whId);
            return db.ExecuteDataSet(cmd);
        }


    }
}
