using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using EntpClass.MessageNotifyTicker.EntpClass.MessageNotifyTicker;
using EntpClass.Common;
using System.Text;
using EntpClass.BizLogic.Msg;
using System.Data;

public partial class Public_MesaageSend : PageBase
{

    public override void SetPageInfo(ref EntpClass.Common.PageParameter p)
    {
       
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!this.IsPostBack)
        {
            this.HidReceiveUserId.Value = this.ReceiveUserId;
            this.TxtReceiveUserName.Text = this.ReceiveUserName;
        }
    }

    private string ReceiveUserId
    {
        get {
            return Fn.ToString(this.Request.QueryString["ReceiveUserId"]);
        }
    }


    private string ReceiveUserName
    {
        get
        {
            return Fn.ToString(this.Request.QueryString["ReceiveUserName"]);
        }
    }


    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        this.BtnContact.OnClientClick = "return ShowContact();";

        this.RenderShowContact();
    }

    private void RenderShowContact()
    {
        if (!ClientScript.IsClientScriptBlockRegistered(this.GetType(), "JsShowContact"))
        {
            DialogWindow dw = new DialogWindow();
            dw.Width = 600;
            dw.Height = 600;
            dw.DisplayScrollBar = true;
            dw.Url = UrlHelper.UrlBase + "/Public/MessageContactSearch.aspx";

            dw.AddUrlClientObjectParameter("UserIds", string.Format("document.getElementById('{0}').value",this.HidReceiveUserId.ClientID));

            StringBuilder s = new StringBuilder();

            s.Append("function ShowContact()");
            s.Append("{");
            s.Append("    var tObj;");
            s.Append("    var nativeNames='';");
            s.Append("    var userIds='';");
            s.Append("    var returnValue = '';");
            s.Append("    " + dw.GetShowModalDialogScript("returnValue"));

            s.Append("if(typeof(returnValue) == 'undefined' || typeof(returnValue) == 'string')");
            s.Append("{");
            s.Append("return;");
            s.Append("}");
            s.Append("else if(typeof(returnValue) == 'object')");
            s.Append("{");
            s.Append("for(var i=0;i<returnValue.length;i++)");
            s.Append("{");
            //第一行
            s.Append("if (i==0)");
            s.Append("{");
            s.Append("tObj = returnValue[0];");
            s.Append("nativeNames = tObj.nativeName;");
            s.Append("userIds = tObj.userId;");
            s.Append("}");
            //从第二行开始,在最后先插入行,再向新行赋值
            s.Append("else");
            s.Append("{");
            s.Append("tObj = returnValue[i];");
            s.Append("nativeNames = nativeNames + ';' + tObj.nativeName;");
            s.Append("userIds = userIds + ';'+ tObj.userId;");
            s.Append("}");// end if
            s.Append("}");// end for
            s.Append("}");// end if

            s.AppendFormat("document.getElementById('{0}').value=nativeNames;", this.TxtReceiveUserName.ClientID);
            s.AppendFormat("document.getElementById('{0}').value=userIds;", this.HidReceiveUserId.ClientID);
            
            s.Append("}\n");

            ClientScript.RegisterClientScriptBlock(this.GetType(), "JsShowContact", s.ToString(), true);
        }
    }
    /// <summary>
    /// 保存按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        RM rm = new RM(ResourceFile.Msg);
        if (Fn.ToLength(this.TxtTitle.Text) == 0)
        {
            Alert(rm["PleaseInputTitle"]);
            return;
        }
        else if (Fn.ToLength(this.TxtContent.Text) == 0)
        {
            Alert(rm["PleaseInputContent"]);
            return;
        }

        string errorMsg = string.Empty;

        MsgSend msgSend = new MsgSend();
        //保存消息
        if (msgSend.SaveMessage(this.HidReceiveUserId.Value,this.TxtReceiveUserName.Text, this.TxtTitle.Text, this.TxtContent.Text, 0))
        {
            Alert(rm["SaveSuccess"]);
            this.ClearForm();
        }
        else
        {
            Alert(msgSend.ErrorMessage);
        }
    }

    protected void BtnSend_Click(object sender, EventArgs e)
    {
        RM rm = new RM(ResourceFile.Msg);
        if (Fn.ToLength(this.TxtTitle.Text) == 0)
        {
            Alert(rm["PleaseInputTitle"]);
            return;
        }
        else if (Fn.ToLength(this.TxtContent.Text) == 0)
        {
            Alert(rm["PleaseInputContent"]);
            return;
        }

        string errorMsg = string.Empty;
        MsgSend msgSend = new MsgSend();

        //保存消息
        if (msgSend.SaveAndSendMessage(this.HidReceiveUserId.Value,this.TxtReceiveUserName.Text, this.TxtTitle.Text, this.TxtContent.Text, 0))
        {
          
            //获取未读消息
            MsgReceive msgReceive = new MsgReceive();
            DataSet ds = msgReceive.GetUnReadMessageCount(this.HidReceiveUserId.Value);
            //刷新消息提醒机制
            MessageNotifyTicker.Instance.NotifyClients(ds.Tables[0]);

            Alert(rm["SendSuccess"]);
            this.ClearForm();
        }
        else
        {
            Alert(msgSend.ErrorMessage);
        }      
    }

    private void ClearForm()
    {
        this.TxtTitle.Text = string.Empty;
        this.TxtContent.Text = string.Empty;
        this.TxtAttachment.Text = string.Empty;
        this.TxtReceiveUserName.Text = string.Empty;
        this.HidReceiveUserId.Value = string.Empty;
    }



}