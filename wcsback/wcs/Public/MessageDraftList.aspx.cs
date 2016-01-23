using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using EntpClass.BizLogic.Msg;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Text;
using System.Data.Common;
using EntpClass.Common;
using EntpClass.MessageNotifyTicker.EntpClass.MessageNotifyTicker;

public partial class Public_MessageDraftList : SetUpCheckBoxListPageBase<MsgSend>
{

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!IsPostBack)
        {
            this.UcMessageTab1.SetSelectedTab(1);

            IWebDataControl DdlStatusCode = this.UcScopeControl.FindControl("DdlStatusCode") as IWebDataControl;
            if (DdlStatusCode != null) { DdlStatusCode.SetValue("new"); } //草稿筛选条件为status_code: new


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

        s.Append("select send_id,s.message_guid,s.title,m.receive_user_name_list");

        s.AppendFormat(" from msg_send_box s ,{0},msg_message m ", p.TableSql);
        s.AppendFormat(" where s.send_id = {0}.id ", p.TableAlias);
        s.Append(" and s.message_guid = m.message_guid");
        s.AppendFormat(" order by {0}.show_order", p.TableAlias);

        DbCommand cmd = db.GetSqlStringCommand(s.ToString());
        DataSet ds = db.ExecuteDataSet(cmd);

        return ds;
    }

    protected override void AppendEmptyRow(DataSet ds)
    {
        base.AppendEmptyRow(ds);
        base.MyGrid.DataKeyNames = new String[1] { "message_guid" };
    }

    protected override DataControlField OnGridColumnCreating(string colName)
    {
        DataControlField f = base.OnGridColumnCreating(colName);
        switch (colName.ToUpper())
        {
            case "MESSAGE_GUID":
                return null;
            case "RECEIVE_USER_NAME_LIST":
                f.SortExpression = "send_id";
                break;
            default:
                break;
        }

        return f;
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

        if (!this.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "JsRenderDeleteScript"))
        {
            RM rm = new RM(ResourceFile.Msg);

            StringBuilder s = new StringBuilder("");

            s.Append("function CheckSelectRow()");
            s.Append("{");
            s.Append("var count = _checkboxGridView.getSelectedCount();\n");
            s.Append("if(count==0) {return false;}\n");
            s.Append("return true;");
            s.Append("}\n");

            s.Append("function CheckSend()");
            s.Append("{");
            s.Append("if(!CheckSelectRow()) {alert('").Append(rm["PleaseSelectRow"]).Append("');return false;}");
            s.Append("if(!window.confirm('").Append(rm["StillGoingOn"]).Append("')){return false;}");
            s.Append("return true;");
            s.Append("}\n");


            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "JsRenderDeleteScript", s.ToString(), true);
        }

    }

    protected void BtnSend_Click(object sender, EventArgs e)
    {
        MsgSend send = new MsgSend();
        foreach (var item in base.SelectedRowIDs)
        {
            if (!send.SendMessage(item))
            {
                Alert(send.ErrorMessage);
                break;
            }
        }

        //刷新当前用户的消息，并通知客户端
        MsgReceive msgReceive = new MsgReceive();
        DataSet ds = msgReceive.GetUnReadMessageCount(CurrentUser.UserID.ToString());
        MessageNotifyTicker.Instance.NotifyClients(ds.Tables[0]);
    }
}