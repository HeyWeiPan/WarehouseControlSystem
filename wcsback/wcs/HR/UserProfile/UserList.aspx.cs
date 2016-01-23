using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.Common;
using EntpClass.WebUI;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.HR.UserProfile;

public partial class HR_UserProfile_UserList : SetUpListPageBase<HRUser>
{
    protected override void SetScopeParameter(ref ScopeWindowParameters p)
    {
        p.Width = 600;
        p.Height = 400;
        p.UserControlPath = "~/HR/UserProfile/UcUserScope.ascx";
    }

    protected override DataSet GetDataSet(ScopeSqlParameters p)
    {
        Database db = DatabaseFactory.CreateDatabase(EntpClass.BizLogic.HR.HRConst.ConnectionName);
        StringBuilder s = new StringBuilder(100);

        s.Append("SELECT user_guid,user_number,native_name,hr.getUserTeamName(user_id) primary_team_name,[dbo].[GetUserTypeName](user_type_id) user_type_id,[dbo].[GetUserStatusName](user_status_code) user_status_code,direct_line,phone_ext,office_mobile,company_email");

        s.AppendFormat(" FROM hr_user u ,{0} ", p.TableSql);
        s.AppendFormat(" where u.user_guid = {0}.id ", p.TableAlias);
        s.AppendFormat(" order by {0}.show_order", p.TableAlias);

        DbCommand cmd = db.GetSqlStringCommand(s.ToString());
        DataSet ds = db.ExecuteDataSet(cmd);

        return ds;
    }

    public override DataSet GetExportDataSet(ScopeSqlParameters p)
    {
        Database db = DatabaseFactory.CreateDatabase(EntpClass.BizLogic.HR.HRConst.ConnectionName);
        StringBuilder s = new StringBuilder(100);

        s.Append("SELECT user_guid,user_number,native_name,[dbo].[GetGender](gender_code,'CN') gender,convert(char(10),onboard_date,111) onboard_date,");
        s.Append("hr.GetTeamName(hr.GetPrimaryTeamByType(u.user_id, 1)) as primary_company,");
        s.Append("hr.GetTeamName(hr.GetPrimaryTeamByType(u.user_id, 3)) as primary_department,");   //部门
        s.Append("hr.GetTeamName(hr.GetPrimaryTeamByType(u.user_id, 4)) as primary_sub_department,");//分部门
        s.Append("hr.GetTeamName(hr.GetPrimaryTeamByType(u.user_id, 6)) as primary_child_department,");//子部门
        s.Append("hr.GetTeamName(hr.GetPrimaryTeamByType(u.user_id, 7)) as primary_team_group,"); //班
        s.Append("hr.GetTeamName(hr.GetPrimaryTeamByType(u.user_id, 5)) as primary_group,");            //组
        s.Append("dbo.getusername(replace_user_id,'') as replace_user_name,");
        s.Append("dbo.getcompanyname(contract_company_id) as contract_company_name,");
        s.Append("dbo.getusername( hr.getreportmanagerid(u.user_id),'') direct_manager_name,");
        s.Append("[dbo].[GetUserTypeName](user_type_id) user_type_id,[dbo].[GetUserStatusName](user_status_code) user_status_code,direct_line,phone_ext,office_mobile,company_email");
        s.AppendFormat(" FROM hr_user u ,{0} ", p.TableSql);
        s.AppendFormat(" where u.user_guid = {0}.id ", p.TableAlias);
        s.AppendFormat(" order by {0}.show_order", p.TableAlias);

        DbCommand cmd = db.GetSqlStringCommand(s.ToString());
        DataSet ds = db.ExecuteDataSet(cmd);

        return ds;
    }

    protected override DataControlField OnGridColumnCreating(string colName)
    {
        switch (colName.ToUpper())
        {
            case "USER_NUMBER":
                UCDialogHyperLinkField f = new UCDialogHyperLinkField();
                f.DataTextField = "user_number";
                f.DataLinkFiled = "user_guid";
                f.DataLinkClientScriptFunction = "ShowDetail('VIEW',linkParam)";
                f.HeaderText = "user_number";
                f.SortExpression = "user_number";
                return f;
            case "PRIMARY_TEAM_NAME":
                DataControlField ft = base.OnGridColumnCreating(colName);
                ft.SortExpression = "hr.getUserTeamName(user_id)";
                return ft;
            case "USER_GUID":
                return null;
        }

        return base.OnGridColumnCreating(colName);
    }    
}