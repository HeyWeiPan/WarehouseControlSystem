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
    public class WCSStatus : DBRowBase
    {
        public WCSStatus()
            : base()
        {
        }

        public WCSStatus(String id)
            : base(id)
        {
        }
        public const int FunctionId = 910030;

        public override DbCommand GetSelectCommand(Microsoft.Practices.EnterpriseLibrary.Data.Database db, string keyValue)
        {
            return null;
        }


        protected override void SetParameter(ref DbRowParameter p)
        {
            p.TableName = "wcs_status";
            p.KeyName = "status_id";
            p.IsKeyValueIdentity = true;
            p.IsLogicalDelete = false;
            p.PageFunctionID = FunctionId;
            p.ConnectionString = WCSConst.ConnectionName;


        }

        public static DataSet GetWCSStatusList()
        {
            string proc = "WCS.GetWCSStatus";
            Database db = DatabaseFactory.CreateDatabase(WCSConst.ConnectionName);
            DbCommand cmd = db.GetStoredProcCommand(proc);
            return db.ExecuteDataSet(cmd);
        }


    }
}
