<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcNotification.ascx.cs"
    Inherits="Home_Notification_UcNotification" %>
<%@ Register Src="UcNotificationList.ascx" TagName="UcNotificationList" TagPrefix="uc1" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<table style="width: 100%; margin: 0,0,0,0; padding: 0,0,0,0; border: 0 0 0 0;" cellspacing="0"
    cellpadding="0" border="0">
    <tr>
        <td>
            <code>
                <cc1:UcHyperLink ID="Lnk1" ColumnName="hr_notification" runat="server" ResourceFileType="UI"
                    NavigateUrl=""></cc1:UcHyperLink><a id="sep1" runat="server">|</a><cc1:UcLinkButton
                        ID="LnkNotify" runat="server" ColumnName="NotifyIssue"></cc1:UcLinkButton><a id="sep2"
                            runat="server">|</a><cc1:UcLinkButton ID="LnkManage" runat="server" ColumnName="NotifyManage"
                                OnClick="LnkMore_Click"></cc1:UcLinkButton></code>
        </td>
    </tr>
    <tr>
        <td>
            <uc1:UcNotificationList ID="UcNotificationList1" runat="server"></uc1:UcNotificationList>
        </td>
    </tr>
</table>
