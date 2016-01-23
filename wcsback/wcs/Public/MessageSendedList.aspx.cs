using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using EntpClass.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Text;
using System.Data;
using System.Data.Common;
using EntpClass.BizLogic.Msg;

public partial class Public_MessageSendedList : SetUpCheckBoxListPageBase<MsgSend>
{

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!IsPostBack)
        {
            this.UcMessageTab1.SetSelectedTab(1);

            IWebDataControl DdlStatusCode = this.UcScopeControl.FindControl("DdlStatusCode") as IWebDataControl;
            if (DdlStatusCode != null) { DdlStatusCode.SetValue("sended"); } //筛选条件为status_code: sended


            this.UcScopeControl.LoadValue();
            this.UcScopeControl.SaveValue();

        }
    }

    protected override PageRights GetPageRight()
    {
        PageRights p = base.GetPageRight();
        p.ExportRight = false;

        return p;
    }

    protected override void SetScopeParameter(ref ScopeWindowParameters p)
    {
        p.UserControlPath = "UcMessageDraftListScope.ascx";
    }

    protected override DataSet GetDataSet(ScopeSqlParameters p)
    {
        Database db = DatabaseFactory.CreateDatabase(EntpClass.BizLogic.HR.HRConst.ConnectionName);
        StringBuilder s = new StringBuilder(100);

        s.Append("select send_id,s.title,receive_user_name_list,send_time = m.send_date");

        s.AppendFormat(" from msg_send_box s,{0},msg_message m ", p.TableSql);
        s.AppendFormat(" where s.send_id = {0}.id ", p.TableAlias);
        s.Append(" and s.message_guid = m.message_guid");
        s.AppendFormat(" order by {0}.show_order", p.TableAlias);
        

        DbCommand cmd = db.GetSqlStringCommand(s.ToString());
        DataSet ds = db.ExecuteDataSet(cmd);

        return ds;
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        if (!this.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "JsShowDetail"))
        {
            StringBuilder s = new StringBuilder();
            //view details.
            s.Append("function ShowDetail()");
            s.Append("{");
        
            s.Append("}\n");

            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "JsShowDetail", s.ToString(), true);
        }
    }

    protected override DataControlField OnGridColumnCreating(string colName)
    {
        DataControlField f = base.OnGridColumnCreating(colName);
        switch (colName.ToUpper())
        {
            case "SEND_USER_NAME":
                f.ItemStyle.Width = Unit.Pixel(100);
                f.SortExpression = "T.send_user_id";
                break;
            case "RECEIVE_USER_NAME_LIST":
                f.SortExpression = "T.send_id";
                break;
            case "SEND_TIME":
                f.ItemStyle.Width = Unit.Pixel(120);
                f.SortExpression = "T.Create_date";
                break;

            case "STATUS_CODE":
                return null;
        }

        return f;
    }
    
}