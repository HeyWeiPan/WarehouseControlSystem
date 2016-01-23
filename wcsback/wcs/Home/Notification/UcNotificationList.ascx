<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcNotificationList.ascx.cs"
    Inherits="Home_Notification_UcNotificationList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<%--<asp:Repeater ID="RptNotifyList" runat="server" Visible="false">
    <ItemTemplate>
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td style="height: 20px;">
                    <img src="images/one_10.jpg" alt="" />
                    <cc1:UcLinkButton ID="L1" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["issue_time"] %>'
                        a='<%# ((DataRowView)Container.DataItem).Row["notify_id"] %>' OnClientClick='<%# GetOnClientClick(((DataRowView)Container.DataItem).Row["attachment_notify_flag"]) %>'></cc1:UcLinkButton>
                    <cc1:UcLinkButton ID="LnkNotify" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["title"] %>'
                        Visible='<%# !Fn.ToBoolean(((DataRowView)Container.DataItem).Row["attachment_notify_flag"]) %>'
                        a='<%# ((DataRowView)Container.DataItem).Row["notify_id"] %>' OnClientClick="if(!ShowNotify(this.a)){return false;}"></cc1:UcLinkButton>
                    <asp:Repeater ID="RptList" runat="server" Visible='<%# Fn.ToBoolean(((DataRowView)Container.DataItem).Row["attachment_notify_flag"]) %>'>
                        <ItemTemplate>
                            <cc1:UcHyperLink ID="LnkFile" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["title"] %>'
                                NavigateUrl='<%# ((DataRowView)Container.DataItem).Row["GetFileLink"] %>' Target="Attachment"></cc1:UcHyperLink>
                        </ItemTemplate>
                    </asp:Repeater>
                    <img id="Img1" runat="server" alt="" src="Image/top.gif" visible='<%# Fn.ToBoolean(((DataRowView)Container.DataItem).Row["set_top_flag"]) %>'
                        height="10" />
                    <img id="Img2" runat="server" alt="" src="Image/new.gif" visible='<%# GetShowNew(((DataRowView)Container.DataItem).Row["issue_date"]) %>'
                        height="10" />
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:Repeater>--%>
<ul class="ul_one ul_two" style="height: 300px;">
    <asp:Repeater ID="RptNotifyList" runat="server" Visible="false">
        <ItemTemplate>
            <li>
                <img src="images/one_04.jpg" alt="" />
                <%# ((DataRowView)Container.DataItem).Row["issue_time"] %>
                <cc1:UcLinkButton ID="LnkNotify" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["title"] %>'
                    Visible='<%# !Fn.ToBoolean(((DataRowView)Container.DataItem).Row["attachment_notify_flag"]) %>'
                    a='<%# ((DataRowView)Container.DataItem).Row["notify_id"] %>' OnClientClick="if(!ShowNotify(this.a)){return false;}"></cc1:UcLinkButton>
                <asp:Repeater ID="RptList" runat="server" Visible='<%# Fn.ToBoolean(((DataRowView)Container.DataItem).Row["attachment_notify_flag"]) %>'>
                    <ItemTemplate>
                        <cc1:UcHyperLink ID="LnkFile" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["title"] %>'
                            NavigateUrl='<%# ((DataRowView)Container.DataItem).Row["GetFileLink"] %>' Target="Attachment"></cc1:UcHyperLink>
                    </ItemTemplate>
                </asp:Repeater>
                <img id="Img2" runat="server" alt="" src="images/new.gif" visible='<%# GetShowNew(((DataRowView)Container.DataItem).Row["issue_date"]) %>'
                    height="10" />
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
