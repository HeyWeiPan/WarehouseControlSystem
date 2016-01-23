using System;
using EntpClass.BizLogic.HR.Public;
using EntpClass.Common;
using EntpClass.WebUI;

public partial class Home_Notification_NotificationDetail : PageBase
{
    private string NotifyId
    {
        get { return Fn.ToString(Request.QueryString["KeyValue"]); }
    }

    //private void RegeditClientScript()
    //{
    //    if (!ClientScript.IsClientScriptBlockRegistered(this.GetType(), "JsClientScript"))
    //    {
    //        string str = string.Format("var FCKeditor1 = '{0}';", FCKeditor1.ClientID);
    //        ClientScript.RegisterClientScriptBlock(this.GetType(), "JsClientScript", str, true);
    //    }
    //}

    //private void SetFCKeditor()
    //{
    //    FCKeditor1.Config["AutoDetectLanguage"] = "false";
    //    FCKeditor1.Config["SkinPath"] = UrlHelper.UrlBase + @"/FCKeditor/editor/skins/office2003/";
    //    FCKeditor1.Config["SkinEditorCSS"] = UrlHelper.UrlBase + @"/FCKeditor/editor/skins/fck_editor.css";
    //    FCKeditor1.Config["ToolbarStartExpanded"] = "false";

    //    if (CurrentUser.UseLanguage == Language.English)
    //        FCKeditor1.Config["DefaultLanguage"] = "en";
    //    else
    //        FCKeditor1.Config["DefaultLanguage"] = "zh-cn";
    //}

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!IsPostBack)
        {
            //SetFCKeditor();

            Notification notification = new Notification(NotifyId);

            this.Title = Fn.ToString(notification.CurrentRowView["title"]);
            //TxtTitle.Text = Fn.ToString(notification.CurrentRowView["title"]);
            //FCKeditor1.Value = Fn.ToString(notification.CurrentRowView["notify_content"]);

            NotificationBody = Fn.ToString(notification.CurrentRowView["notify_content"]);
            //TxtIssueBy.Text = Fn.ToString(notification.CurrentRowView["issue_by"]);
            //DtpIssueDate.Text = ((DateTime)notification.CurrentRowView["issue_date"]).ToString(AppSetting.DateFormat);
        }
    }

    protected string NotificationBody = string.Empty;


    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        //RegeditClientScript();
    }

    public override void SetPageInfo(ref PageParameter p)
    {
    }
}
