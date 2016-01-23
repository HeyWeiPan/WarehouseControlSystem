using System;
using System.Text;
using System.Web.UI;
using EntpClass.BizLogic.HR.Public;
using EntpClass.BizLogic.Security;
using EntpClass.Common;
using EntpClass.WebUI;

public partial class Home_Notification_UcNotification : UserControlBase
{
    private void RegeditNotifyScript()
    {
        if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegeditNotifyScript"))
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
            s.Append("window.event.cancelBubble = true;return false;");
            s.Append("}");

            Parent.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegeditNotifyScript", s.ToString(), true);
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        RegeditNotifyScript();

        //LnkMore.Visible = false;
        LnkNotify.Visible = false;
        LnkManage.Visible = false;
        sep1.Visible = false;
        sep2.Visible = false;

        bool b = RightHelper.CheckFuncRightCached(Notification.FUNCTIONID, OperationCode.ADD);
        if (b)
        {
            LnkManage.Visible = true;
            LnkNotify.Visible = true;
            LnkNotify.OnClientClick = "if(!ShowNotification('ADD','')){return false;}";

            sep1.Visible = true;
            sep2.Visible = true;
        }

        int totalNotifys = UcNotificationList1.TotalNotifys;
    }

    protected void LnkMore_Click(object sender, EventArgs e)
    {
        string url = UrlHelper.UrlBase + @"/Home/Notification/NotificationList.aspx";
        Server.Transfer(url);
    }
}
