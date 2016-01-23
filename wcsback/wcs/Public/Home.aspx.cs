using System;
using System.Web.UI.WebControls;

using EntpClass.BizLogic.Security;
using EntpClass.Common;
using EntpClass.WebUI;
using System.Text;
using System.Data;
using EntpClass.BizLogic.HR.Public;
using System.Web.UI;


public partial class Public_Home : PageBase
{
    public override void SetPageInfo(ref PageParameter p)
    {
        p.FunctionID = 2000000;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!IsPostBack)
        {
            ///bool homeRight = RightHelper.CheckFuncRightCached(JXCConst.HomeFuncID, OperationCode.READ);
            ////bool kaoqinRight = RightHelper.CheckFuncRightCached(KQDaily.FUNCTIONID, OperationCode.READ);

            //UcHomeTab1.SetSelectedTab(1);

            //UcNotification1.Visible = true;
            ////UcJxcRemindList1.Visible = true;

            //// TabKaoQin.Visible = true;
            //// UcKQDaily1.Visible = true;
        }

        //刷新通告
        ShowNotification();
        //ShowPendingMattersList();
        ShowFavorateList();
        ShowMsgList();
    }

    private void ShowNotification()
    {
        DataSet ds = Notification.GetNotificationList();
        string notificationStr = "";
        bool b;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            b = Fn.ToBoolean(ds.Tables[0].Rows[i]["attachment_notify_flag"]);

            notificationStr += "<li><span>";
            notificationStr += ds.Tables[0].Rows[i]["issue_time"].ToString().Replace("(", "").Replace(")", "");
            notificationStr += "</span><a href=\"" + GetNotificationUrl(b, Fn.ToInt(ds.Tables[0].Rows[i]["notify_id"]));
            notificationStr += ds.Tables[0].Rows[i]["title"].ToString() + "</a>";
            if (GetShowNew(ds.Tables[0].Rows[i]["issue_date"]))
            {
                notificationStr += "<img src=\"../Home/images/new.gif\"  alt=\"New\" />";
            }

            notificationStr += "</li>";

        }

        PHNotice.Controls.Add(new LiteralControl(notificationStr));
    }


    private string GetNotificationUrl(bool b, int notifyId)
    {
        if (!b)
            return "javascript:" + string.Format("ShowNotify({0});\" >", notifyId);
        else
        {
            DataSet ds = FileHelper.GetFileList(Notification.FUNCTIONID, notifyId);

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {

                return "javascript:" + string.Format("ShowNotify({0});\" >", notifyId);
            }

            return ds.Tables[0].Rows[0]["GetFileLink"].ToString().Replace("~",UrlHelper.UrlBase) + "\" Target=\"Attachment\" > ";
        }
    }

 

    private void ShowFavorateList()
    {
        DataSet ds = HomeInformation.GetUserFavorateList();
        string favorateStr = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            favorateStr += "<li>";
            favorateStr += "<a href=\"javascript:PageTrans('../Home/" + ds.Tables[0].Rows[i]["page_url"] + "'," + ds.Tables[0].Rows[i]["function_id"].ToString() + ");\" >";
            favorateStr += ds.Tables[0].Rows[i]["function_name"] + "</a>";
            favorateStr += "</li>";
        }
        PHFavorate.Controls.Add(new LiteralControl(favorateStr));
    }


    private void ShowMsgList()
    {
        DataSet ds = HomeInformation.GetMsgList();
        string msgStr = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {

            msgStr += "<li><span>";
            msgStr += ds.Tables[0].Rows[i]["send_date"].ToString();
            msgStr += "</span><a href=\"javascript:" + string.Format("ShowMsg({0})", ds.Tables[0].Rows[i]["receive_id"]) + ";\" >";
            msgStr += ds.Tables[0].Rows[i]["title"].ToString() + "</a>";
            msgStr += "</li>";

        }

        PHMsg.Controls.Add(new LiteralControl(msgStr));
    }

    public bool GetShowNew(object issueDate)
    {
        DateTime issueDateTime = (DateTime)issueDate;

        if (DateTime.Now > issueDateTime.AddDays(Notification.MaxShowNewDays))
            return false;

        return true;
    }


    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        RegisterNotice();
        if (!ClientScript.IsClientScriptBlockRegistered(this.GetType(), "JsLoadRemind"))
        {
            StringBuilder s = new StringBuilder();

            s.Append("function loadRemind()");
            s.Append("{");
            s.Append("$('#divRemind').html('&nbsp;');");
            s.Append("$('#divRemind').css('background', 'white url(images/ajax-loader.gif) no-repeat centerd center');");

            s.Append("window.setTimeout(function () {");
            s.AppendFormat(" $.get('GetUserControlHtml.ashx?uc=Public/UcRemindList&UserID={0}&Id={1}',", CurrentUser.UserID, DateTime.Now.ToShortTimeString() + DateTime.Now.Millisecond);
            s.Append("          function (data) {");
            s.Append("             $('#divRemind').html(data); ");
            s.Append("             $('#divRemind').css('background', '');");
            s.Append("         }");
            s.Append("       );");
            s.Append("  }, 500);");
            s.Append("}");

            ClientScript.RegisterClientScriptBlock(this.GetType(), "JsLoadRemind", s.ToString(), true);
        }
    }

    private void RegisterNotice()
    {
        if (!ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegisterNotice"))
        {
            Notification notify = new Notification();
            DialogWindow dw = notify.DetailDialogWindow;
            dw.AddUrlClientObjectParameter("KeyValue", "keyValue");
            dw.AddUrlClientObjectParameter("Mode", "mode");

            StringBuilder s = new StringBuilder(300);

            s.Append("function ShowNotification(mode, keyValue)");
            s.Append("{");
            s.Append("var returnValue = '';" + dw.GetShowModalDialogScript("returnValue"));
            s.Append("if(returnValue=='REFRESH'){return true;}");
            s.Append("window.event.cancelBubble = true;return false;");
            s.Append("}");

            dw = new DialogWindow();
            dw.Url = UrlHelper.UrlBase + @"/Home/Notification/NotificationDetail.aspx";
            dw.AddUrlClientObjectParameter("KeyValue", "keyValue");
            dw.Width = 1000;
            dw.Height = 700;

            s.Append("function ShowNotify(keyValue)");
            s.Append("{");
            s.Append("var returnValue = '';" + dw.GetShowModalDialogScript("returnValue"));
            //s.Append("window.event.cancelBubble = true;return false;");
            s.Append("}");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "RegisterNotice", s.ToString(), true);
        }
    }


    protected void More_Click(object sender, EventArgs e)
    {
        string url = UrlHelper.UrlBase + @"/Home/Notification/NotificationList.aspx";
        Server.Transfer(url);
    }
}