using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using EntpClass.Common;

using EntpClass.BizLogic.Security;
using EntpClass.WebControlLib.Derived;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using EntpClass.BizLogic.HR.UserProfile;
using System.Drawing;
using EntpClass.BizLogic.Msg;
using EntpClass.WebControlLib;
using EntpClass.MessageNotifyTicker.EntpClass.MessageNotifyTicker;

public partial class Public_MessageList : SetUpCheckBoxListPageBase<MsgReceive>
{
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!IsPostBack)
        {
            this.UcMessageTab1.SetSelectedTab(1);

            IWebDataControl TxtReceiveUserId = this.UcScopeControl.FindControl("TxtReceiveUserId") as IWebDataControl;
            if (TxtReceiveUserId != null) { TxtReceiveUserId.SetValue(Fn.ToString(CurrentUser.UserID)); }


            this.UcScopeControl.LoadValue();
            this.UcScopeControl.SaveValue();

            //每次进入，刷新当前用户的消息（因为工作流，和业务单据的提醒，2分钟执行一次，会出现提醒不即时，每次进入，立即刷新状态)
            MsgReceive msgReceive = new MsgReceive();
            DataSet ds = msgReceive.GetUnReadMessageCount(Fn.ToString(CurrentUser.UserID));
            //刷新消息提醒机制
            MessageNotifyTicker.Instance.NotifyClients(ds.Tables[0]);

        }
    }

    public override void SetPageInfo(ref EntpClass.Common.PageParameter p)
    {

    }

    protected override void SetScopeParameter(ref ScopeWindowParameters p)
    {
        p.UserControlPath = "UcMessageListScope.ascx";
    }

    protected override PageRights GetPageRight()
    {
        PageRights p = base.GetPageRight();
        p.ExportRight = false;

        return p;
    }

    protected override void OnLoadClientScript()
    {
        return;
    }

    protected override DataSet GetDataSet(ScopeSqlParameters p)
    {
        Database db = DatabaseFactory.CreateDatabase(EntpClass.BizLogic.HR.HRConst.ConnectionName);
        StringBuilder s = new StringBuilder(100);

      
        s.Append("select receive_id,dbo.GetUserName(send_user_id,'') as send_user_name,title,send_time =send_date,status_code,link_url=link_url+'?'+append_querystring,syslink_flag,instance_id");

        s.AppendFormat(" from msg_receive_box r ,{0} ", p.TableSql);
        s.AppendFormat(" where r.receive_id = {0}.id ", p.TableAlias);
        s.AppendFormat(" order by {0}.show_order", p.TableAlias);

        DbCommand cmd = db.GetSqlStringCommand(s.ToString());
        DataSet ds = db.ExecuteDataSet(cmd);

        return ds;
    }

    protected override void OnCreatePrefixColumn(GridView g, DataSet ds)
    {
        base.OnCreatePrefixColumn(g, ds);

        //第二列显示当前单据的状态
        TemplateField colorBlockField = new TemplateField();
        colorBlockField.HeaderTemplate = new UcMailStatusColorTemplate(DataControlRowType.Header, "status_code", "");

        colorBlockField.ItemTemplate = new UcMailStatusColorTemplate(DataControlRowType.DataRow, "status_code");
        colorBlockField.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
        colorBlockField.HeaderStyle.Width = Unit.Pixel(30);
        colorBlockField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;


        g.Columns.Add(colorBlockField);
    }
 
    protected override DataControlField OnGridColumnCreating(string colName)
    {
        DataControlField f = base.OnGridColumnCreating(colName);
        switch (colName.ToUpper())
        {
            case "TITLE":
                UCDialogHyperLinkField lfc = new UCDialogHyperLinkField();
                lfc.DataTextField = "title";
                lfc.DataLinkFiled = "link_url";                
                lfc.DataLinkFormatScript = "ShowDjLinkDetail('{0}')";
                lfc.DataLinkClientScriptField = "link_url";
                lfc.HeaderText = "title";
                lfc.SortExpression = "title";
                return lfc;
            case "SEND_USER_NAME":
                f.ItemStyle.Width = Unit.Pixel(100);
                f.SortExpression = "T.send_user_id";
                break;
            case "SEND_TIME":
                f.ItemStyle.Width = Unit.Pixel(120);
                f.SortExpression = "T.Send_Date";
                break;
            case "STATUS_CODE":
                return null;
            case "LINK_URL":
                return null;
            case "SYSLINK_FLAG":
                return null;
            case "INSTANCE_ID":
                return null;
        }

        return f;
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        MyGrid.AlternatingRowStyle.BackColor = Color.White;

        if (!this.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "JsShowDetail"))
        {
            StringBuilder s = new StringBuilder();
            //view details.
            s.Append("function ShowDetail()");
            s.Append("{");
            s.AppendFormat("window.location.href='" + UrlHelper.HttpsUrlBase + "/Public/MessageReceive.aspx?KeyValue='+{0}.selectedRowID;", MyGrid.ClientID);
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

            s.Append("function CheckDelete1()");
            s.Append("{");
            s.Append("if(!CheckSelectRow()) {alert('").Append(rm["PleaseSelectRow"]).Append("');return false;}");
            s.Append("if(!window.confirm('").Append(rm["ConfirmDeleteRow"]).Append("')){return false;}");
            s.Append("return true;");
            s.Append("}\n");


            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "JsRenderDeleteScript", s.ToString(), true);
        }


        this.RenderShowDjLinkDetailScript();
    }
    protected void DdlStatusCodeQuick_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.UcScopeControl.SaveControlValue("DdlStatusCode", (sender as UcDropDownList).SelectedValue);
        this.UcScopeControl.SaveControlValue("DdlStatusCodeQuick", (sender as UcDropDownList).SelectedValue);

        this.UcScopeControl.LoadValue();      
        this.UcScopeControl.DoSearch();
    }


    /// <summary>
    ///  呈现单据链接明细脚本(一览表上的单据链接)
    /// </summary>
    public void RenderShowDjLinkDetailScript()
    {
        if (!ClientScript.IsClientScriptBlockRegistered(this.GetType(), "JsShowDjLinkDetailScript"))
        {
            DialogWindow dw = new DialogWindow();
            dw.Width = 1000;
            dw.Height = 700;
            //dw.AddUrlClientObjectParameter("Mode", "mode");
            //dw.AddUrlClientObjectParameter("KeyValue", "linkParam");
            dw.Url = UrlHelper.HttpsUrlBase + "\" + detailUrl +\"";

            //--列表上弹出明细，会调用DialogFrame.aspx,需要对&进行转义	,=可不转义    
            //--& - %26
            // --http://localhost/jxc/CommonUI/WebForm/DialogFrame.aspx?DialogUrl=jxc/jxc/xs/JxcXsOrderHeadDetail.aspx?Mode=View&KeyValue=A0D26898-364C-4D71-B7D6-67C99F245F7C
            //--http://localhost/jxc/CommonUI/WebForm/DialogFrame.aspx?DialogUrl=jxc/jxc/xs/JxcXsOrderHeadDetail.aspx?ModeView%26KeyValue%3dA0D26898-364C-4D71-B7D6-67C99F245F7C
            
            StringBuilder s = new StringBuilder();
            s.Append("function ShowDjLinkDetail(detailUrl)");
            s.Append("{");
            s.Append(" detailUrl=detailUrl.replace(/&/g,'%26');"); //将&替换为%26,原来是在存储过程中统一将& Replace为%26，但在传入ShowDjLinkDetail后，%26又被识别为&,改为在js中处理
            s.Append(dw.GetShowModalDialogScript("rtn"));
            //添加一个链接，目的是，将当前消息设置为‘已读’
            s.AppendFormat("window.location.href='" + UrlHelper.HttpsUrlBase + "/Public/MessageReceive.aspx?syslink=-1&KeyValue='+{0}.selectedRowID;", MyGrid.ClientID);
            s.Append("}");

            ClientScript.RegisterClientScriptBlock(this.GetType(), "JsShowDjLinkDetailScript", s.ToString(), true);
        }
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        string receiveMsgIds = string.Empty;

        foreach (var item in base.SelectedRowIDs)
        {
            receiveMsgIds += ("," + item);
        }
        

        //刷新当前用户的消息，并通知客户端
        MsgReceive msgReceive = new MsgReceive();
        if (!msgReceive.DeleteReceiveMsg(receiveMsgIds))
        {
            Alert(msgReceive.ErrorMessage);
        }


        DataSet ds = msgReceive.GetUnReadMessageCount(CurrentUser.UserID.ToString());
        MessageNotifyTicker.Instance.NotifyClients(ds.Tables[0]);
    }

    protected void BtnRefresh_Click(object sender, EventArgs e)
    {
        MsgReceive msgReceive = new MsgReceive();
        DataSet ds = msgReceive.GetUnReadMessageCount(CurrentUser.UserID.ToString());
        MessageNotifyTicker.Instance.NotifyClients(ds.Tables[0]);
    }
}