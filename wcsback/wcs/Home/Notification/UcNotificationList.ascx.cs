using System;
using System.Data;
using System.Web.UI.WebControls;
using EntpClass.BizLogic.HR.Public;
using EntpClass.Common;
using EntpClass.WebUI;

public partial class Home_Notification_UcNotificationList : UserControlBase
{
    private int _TotalNotifys = 0;
    public int TotalNotifys
    {
        get { return _TotalNotifys; }
        set { _TotalNotifys = value; }
    }

    public bool GetShowNew(object issueDate)
    {
        DateTime issueDateTime = (DateTime)issueDate;

        if (DateTime.Now > issueDateTime.AddDays(Notification.MaxShowNewDays))
            return false;

        return true;
    }

    public string GetOnClientClick(object attachmentNotifyFlag)
    {
        bool b = Fn.ToBoolean(attachmentNotifyFlag);

        if (b)
            return "return false;";

        return "if(!ShowNotify(this.a)){return false;}";
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        RptNotifyList.ItemDataBound += new RepeaterItemEventHandler(RptNotifyList_ItemDataBound);
    }

    void RptNotifyList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int notifyId = Fn.ToInt(((DataRowView)e.Item.DataItem).Row["notify_id"]);
            string title = Fn.ToString(((DataRowView)e.Item.DataItem).Row["title"]);
            int attachmentNotifyFlag = Fn.ToInt(((DataRowView)e.Item.DataItem).Row["attachment_notify_flag"]);

            if (attachmentNotifyFlag == 0)
                return;

            Repeater RptList = (Repeater)e.Item.FindControl("RptList");
            DataSet ds = FileHelper.GetFileList(Notification.FUNCTIONID, notifyId);
            RptList.DataSource = ds;

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                RptList.DataBind();
                return;
            }

            ds.Tables[0].Columns.Add("title", typeof(string));
            ds.Tables[0].Rows[0]["title"] = title;

            RptList.DataBind();
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        DataSet ds = Notification.GetNotificationList();

        RptNotifyList.Visible = true;
        RptNotifyList.DataSource = ds;
        RptNotifyList.DataBind();

        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            return;

        TotalNotifys = Fn.ToInt(ds.Tables[0].Rows[0]["total_notify"]);
    }
}
