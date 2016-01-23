<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterMessageList.master"
    AutoEventWireup="true" CodeFile="MessageList.aspx.cs" Inherits="Public_MessageList" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="UcMessageTab.ascx" TagName="UcMessageTab" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="server">
    <uc3:UcMessageTab ID="UcMessageTab1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C2" runat="server">
    <code><a href="#" title="">收件箱列表</a></code>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="C3" runat="server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0" style="height: 100%;">
        <tr>
            <td>
                <cc1:UcButton ID="BtnDelete" runat="server" ColumnName="Delete" Width="70px" OnClick="BtnDelete_Click"
                    OnClientClick="return CheckDelete1()" />
                <cc1:UcButton ID="BtnRefresh" runat="server" ColumnName="Refresh" Width="70px" 
                    onclick="BtnRefresh_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="LblStatusCode" ColumnName="status_code" runat="server" />
                <cc1:UcDropDownList ID="DdlStatusCodeQuick" runat="server" ColumnName="status_code"
                    AutoPostBack="True" OnSelectedIndexChanged="DdlStatusCodeQuick_SelectedIndexChanged">
                    <asp:ListItem Text="" Value="" Selected="True" />
                    <asp:ListItem Text="未读" Value="unread" />
                    <asp:ListItem Text="已读" Value="read" />
                </cc1:UcDropDownList>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="C4" runat="server">
    <code><a href="MesaageSend.aspx">
        <img src="images/WriteMail.gif" alt="写信" />写信</a></code> <code><a href="MessageList.aspx">
            <img src="images/ReceiveMail.gif" alt="收信" />收信</a></code> <code><a href="MessageDraftList.aspx">
                <img src="images/MailContact.gif" alt="草稿" />草稿</a></code> <code><a href="MessageSendedList.aspx">
                    <img src="images/MailContact.gif" alt="已发送" />已发送</a></code>
</asp:Content>
