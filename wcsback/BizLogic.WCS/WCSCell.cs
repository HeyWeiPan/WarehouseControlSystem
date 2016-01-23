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
    public class WCSCell:DBRowBase
    {
         public WCSCell()
            : base()
        {
        }

         public WCSCell(String id)
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
            p.TableName = "wcs_cell";
            p.KeyName = "cell_id";
            p.IsKeyValueIdentity = true;
            p.IsLogicalDelete = false;
            p.PageFunctionID = FunctionId;
            p.ConnectionString = WCSConst.ConnectionName;


        }

        public static DataSet GetFloorCellsList(string floorId)
        {
            string proc = "WCS.GetFloorCellsList";
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pFloorId", DbType.Int32, floorId);
            return db.ExecuteDataSet(cmd);
        }
    }
}
