<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterMessage.master"
    AutoEventWireup="true" CodeFile="MesaageSend.aspx.cs" Inherits="Public_MesaageSend" %>

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
                <code><a href="#" title="">ERP系统邮件</a></code>
            </td>
        </tr>
    </table>
    <table style="width: 99%; table-layout: fixed; background-color: #ffffff;">
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
                <cc1:UcLabel ID="LblReceiveUserName" runat="server" Width="100%" ColumnName="ReceiveUserName"
                    ResourceFileType="Msg" />
            </td>
            <td colspan="3">
                <cc1:UcTextBox ID="TxtReceiveUserName" runat="server" Width="100%" ReadOnly="true"
                    TextMode="MultiLine" Rows="2" />
                <cc1:UcHiddenField ID="HidReceiveUserId" runat="server" RenderToClient="true" />
            </td>
            <td>
                <cc1:UcButton ID="BtnContact" runat="server" Width="80px" Text="添加联系人" UseSubmitBehavior="false" />
            </td>
        </tr>
        <%-- <tr>
            <td>
            </td>
            <td>
                <span style="font-size: 11pt">抄送</span>
            </td>
            <td colspan="3">
                <cc1:UcTextBox ID="UcTextBox1" runat="server" Width="100%" />
            </td>
            <td>
            </td>
        </tr>--%>
        <tr>
            <td>
            </td>
            <td>
                <cc1:UcLabel ID="LblTitle" runat="server" Width="100%" ColumnName="Title"   ResourceFileType="Msg" />
            </td>
            <td colspan="3">
                <cc1:UcTextBox ID="TxtTitle" runat="server" Width="100%" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <cc1:UcLabel ID="LblAttachment" runat="server" Width="100%" ColumnName="Attachment"
                     ResourceFileType="Msg" />
            </td>
            <td colspan="3">
                <cc1:UcTextBox ID="TxtAttachment" runat="server" Width="100%" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="vertical-align: top">
                <cc1:UcLabel ID="LblContent" runat="server" Width="100%" ColumnName="Content"   ResourceFileType="Msg" />
            </td>
            <td colspan="3">
                <cc1:UcTextBox ID="TxtContent" runat="server" Width="100%" Rows="25" TextMode="MultiLine" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <cc1:UcButton ID="BtnSave" ColumnName="Save" Width="70px" runat="server" OnClick="BtnSave_Click" />
                <cc1:UcButton ID="BtnSend" ColumnName="Send" Width="70px" runat="server" OnClick="BtnSend_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
