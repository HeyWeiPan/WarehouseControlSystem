<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterMessage.master"
    AutoEventWireup="true" CodeFile="MessageReceive.aspx.cs" Inherits="Public_MessageReceive" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="UcMessageTab.ascx" TagName="UcMessageTab" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="server">
    <uc3:UcMessageTab ID="UcMessageTab1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C2" runat="server">
    <code><a href="MesaageSend.aspx">
        <img src="images/WriteMail.gif" alt="写信" />写信</a></code> <code><a href="MessageList.aspx">
            <img src="images/ReceiveMail.gif" alt="收信" />收信</a></code> <code><a href="MessageDraftList.aspx">
                <img src="images/MailContact.gif" alt="草稿" />草稿</a></code> <code><a href="MessageSendedList.aspx">
                    <img src="images/MailContact.gif" alt="已发送" />已发送</a></code>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="C3" runat="server">
    <table style="width: 99%; table-layout: fixed;">
        <tr>
            <td>
                <code><a href="#" title="">邮件内容</a></code>
            </td>
        </tr>
    </table>
    <table style="width: 99%; table-layout: fixed;">
        <colgroup>
            <col width="5%" />
            <col width="7%" />
            <col width="8%" />
            <col width="20%" />
            <col width="20%" />
            <col width="20%" />
        </colgroup>
        <tr>
            <td>
            </td>
            <td>
                <cc1:UcLabel ID="LblTitle" runat="server" Width="100%" ColumnName="Title" ResourceFileType="UI" />
            </td>
            <td colspan="3">
                <cc1:UcTextBox ID="TxtTitle" runat="server" Width="100%" UseDefaultStyle="false"
                    CssClass="TransparentTextWithBottom" ReadOnly="true" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <cc1:UcLabel ID="LblSendUser" runat="server" Width="100%" ColumnName="SendUserName"
                    ResourceFileType="UI" />
            </td>
            <td colspan="3">
                <cc1:UcTextBox ID="TxtSendUser" runat="server" Width="100%" UseDefaultStyle="false"
                    CssClass="TransparentTextWithBottom" ReadOnly="true" />
                <cc1:UcHiddenField ID="HidSendUserId" runat="server" RenderToClient="true" />
            </td>
            <td>
                <cc1:UcButton ID="BtnReply" runat="server" ColumnName="Reply" Width="55px" UseSubmitBehavior="false"
                    OnClick="BtnReply_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <cc1:UcLabel ID="LblSendDate" runat="server" Width="100%" ColumnName="SendDate" ResourceFileType="UI" />
            </td>
            <td colspan="3">
                <cc1:UcTextBox ID="TxtSendDate" runat="server" Width="100%" UseDefaultStyle="false"
                    CssClass="TransparentTextWithBottom" ReadOnly="true" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="6">&nbsp;</td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="vertical-align: top">
                <cc1:UcLabel ID="LblContent" runat="server" Width="100%" ColumnName="Content" ResourceFileType="UI" />
            </td>
            <td colspan="3">
                <asp:Panel ID="PnlContent" runat="server">
                    
                    <asp:Literal ID="LContent" runat="server" />
                </asp:Panel>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <table style="width: 99%; table-layout: fixed; background-color: #ffffff;">
        <tr>
        </tr>
    </table>
</asp:Content>
