using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using EntpClass.BizLogic.Security;
using EntpClass.Common;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Text;

/// <summary>
///WflState 的摘要说明
/// </summary>
/// 
namespace EntpClass.BizLogic.Workflow
{
    public class WflState : DBRowBase
    {
        public const int FunctionID = 6911201;

        protected override void SetParameter(ref DbRowParameter p)
        {
            p.TableName = "wfl_state";
            p.KeyName = "state_id";
            p.PageFunctionID = FunctionID;
            p.ConnectionString = ScrConst.ConnectionName;
            p.IsLogicalDelete = false; //表中是否有delete_flag 如果有则为true，如果没有则为false

            p.DetailDialogWindow.Url = UrlHelper.UrlBase + ("/Security/WflState/WflStateDetail.aspx");
            p.DetailDialogWindow.Width = 500;
            p.DetailDialogWindow.Height = 400;
            p.DefaultSortExpression = "state_code";
        }

        //protected override void InitNewRow()
        //{
            
        //    this["assignto_function"] = "wfl.f_GetAssignTo_StateOwner";
        //    base.InitNewRow();
            
        //}
        public override DbCommand GetSelectCommand(Microsoft.Practices.EnterpriseLibrary.Data.Database db, string keyValue)
        {
            if (keyValue == "") keyValue = "0";

            string proc = "security.GetWflStateHeadDetail";
            DbCommand cmd = db.GetStoredProcCommand(proc);
            db.AddInParameter(cmd, "pDjId", DbType.String, keyValue);
            return cmd;
        }
        //根据字段里面的值来判断有没有权限删除数据
        public override bool Delete(Database db, DbTransaction transaction)
        {
            if (Fn.ToInt(this["system_flag"]) == -1)
            {
                this.ErrorMessage = "不能删除！";
                return false;
            }
            
            else
                return base.Delete(db, transaction); 
        }
        public override bool Update(System.Collections.Hashtable dataControlCollection, Database db, DbTransaction transaction)
        {
            IWebDataControl a = Fn.GetControlByColumnName(dataControlCollection, "assign_type");
            IWebDataControl b = Fn.GetControlByColumnName(dataControlCollection, "assignto_function");
            if (a.GetValue() == "user")
            {
                b.SetValue("wfl.f_GetAssignTo_StateOwner");
            }
            return base.Update(dataControlCollection, db, transaction);
        }
        public override bool Insert(string newKeyValue, System.Collections.Hashtable dataControlCollection, Database db, DbTransaction transaction)
        {
            IWebDataControl a = Fn.GetControlByColumnName(dataControlCollection, "assign_type");
            IWebDataControl b = Fn.GetControlByColumnName(dataControlCollection, "assignto_function");
            if (a.GetValue() == "user")
            {
                b.SetValue("wfl.f_GetAssignTo_StateOwner");
            }

            
            

            return base.Insert(newKeyValue, dataControlCollection, db, transaction);
        }
    }
}
