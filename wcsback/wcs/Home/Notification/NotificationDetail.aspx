<%@ Page Title="" Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterDetail.master"
    AutoEventWireup="true" CodeFile="NotificationDetail.aspx.cs" Inherits="Home_Notification_NotificationDetail" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table style="width: 100%; height: 100%; table-layout: fixed; background-color: White;">
        <tr>
            <td valign="top">
                <%=NotificationBody%>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C2" runat="Server">
    <cc1:UcButton ID="BtnClose" runat="server" ColumnName="Close" Width="70px" OnClientClick="window.close();return false;" />
</asp:Content>
