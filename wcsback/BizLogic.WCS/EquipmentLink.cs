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
    public class EquipmentLink : DBRowBase
    {

        public EquipmentLink()
            : base()
        {
        }

        public EquipmentLink(String id)
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
            p.TableName = "wcs_equipment_link";
            p.KeyName = "link_id";
            p.IsKeyValueIdentity = true;
            p.IsLogicalDelete = false;
            p.PageFunctionID = FunctionId;
            p.ConnectionString = WCSConst.ConnectionName;


        }

        public static DataSet GetEquipmentLinkList(string whId,string taskTypeId)
        {
            string proc = "WCS.GetEquipmentLinkList";
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pWhId", DbType.Int32, whId);
            db.AddInParameter(cmd, "pTaskTypeId", DbType.Int32, taskTypeId);
            return db.ExecuteDataSet(cmd);
        }

    }
}
