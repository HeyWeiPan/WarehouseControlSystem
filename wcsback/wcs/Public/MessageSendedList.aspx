<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterMessageList.master"
    AutoEventWireup="true" CodeFile="MessageSendedList.aspx.cs" Inherits="Public_MessageSendedList" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="UcMessageTab.ascx" TagName="UcMessageTab" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="server">
    <uc3:UcMessageTab ID="UcMessageTab1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C2" runat="server">
    <code><a href="#" title="">已发送列表</a></code>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="C3" runat="server">
        
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="C4" runat="server">
    <code><a href="MesaageSend.aspx">
        <img src="images/WriteMail.gif" alt="写信" />写信</a></code> <code><a href="MessageList.aspx">
            <img src="images/ReceiveMail.gif" alt="收信" />收信</a></code> <code><a href="MessageDraftList.aspx">
                <img src="images/MailContact.gif" alt="草稿" />草稿</a></code> <code><a href="MessageSendedList.aspx">
                    <img src="images/MailContact.gif" alt="已发送" />已发送</a></code>
</asp:Content>
