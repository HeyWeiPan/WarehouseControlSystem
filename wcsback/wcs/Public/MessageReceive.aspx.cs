using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.BizLogic.Msg;
using System.Collections;
using EntpClass.WebControlLib;
using EntpClass.MessageNotifyTicker.EntpClass.MessageNotifyTicker;
using System.Data;

public partial class Public_MessageReceive : PageBase
{
    private string KeyValue
    {
        get {
            return Fn.ToString(this.Request.QueryString["KeyValue"]);
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!this.IsPostBack)
        {       

            MsgReceive msgData = new MsgReceive(this.KeyValue);

            this.TxtTitle.Text = Fn.ToString(msgData["title"]);
            this.TxtSendUser.Text = Fn.ToString(msgData["send_user_name"]);
            this.HidSendUserId.Value = Fn.ToString(msgData["send_user_id"]);
            this.TxtSendDate.Text = Fn.ToString(msgData["send_date"]);
            this.LContent.Text = Fn.ToString(msgData["content"]);

            if (Fn.ToString(msgData["status_code"]).ToLower() == "unread")
            {
                //设置状态为‘已读'
                Hashtable table = new Hashtable();
                UcHiddenField hidStatusCode = new UcHiddenField();
                hidStatusCode.ID = "HidStatusCode";
                hidStatusCode.ColumnName = "status_code";
                hidStatusCode.Value = "read";
                table.Add(hidStatusCode.ID, hidStatusCode);

                msgData.Update(table);


                //保存消息通知信息
                MsgReceive msgReceive = new MsgReceive();
                DataSet ds = msgReceive.GetUnReadMessageCount(Fn.ToString(msgData["receive_user_id"]));
                MessageNotifyTicker.Instance.NotifyClients(ds.Tables[0]);

            }

            //如果是系统链接传入，直接跳回列表
            if (Fn.ToInt(this.Request.QueryString["syslink"]) == -1)
            {
                this.Response.Redirect("MessageList.aspx");
                return;
            }
        }
    }

    public override void SetPageInfo(ref PageParameter p)
    {
       
    }


    protected void BtnReply_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(string.Format("MesaageSend.aspx?ReceiveUserId={0}&ReceiveUserName={1}", this.HidSendUserId.Value, this.TxtSendUser.Text));
    }
}