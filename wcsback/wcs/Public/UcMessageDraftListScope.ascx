<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcMessageDraftListScope.ascx.cs"
    Inherits="Public_UcMessageDraftListScope" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<table id="tabMain" width="100%" style="font-size: 9pt; font-family: 宋体; table-layout: fixed;
    height: 100%;">
    <colgroup>
        <col class="TdLabel" width="19%" />
        <col align="left" width="31%" />
        <col class="TdLabel" width="14%" />
        <col align="left" width="36%" />
    </colgroup>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td>
            <cc1:UcLabel ID="LblStatusCode" runat="server" ColumnName="status_code" />
        </td>
        <td>
            <cc1:UcDropDownList ID="DdlStatusCode" runat="server" ColumnName="status_code">
                <asp:ListItem Text="" Value="" />
                <asp:ListItem Text="新建" Value="new" />
                <asp:ListItem Text="已发送" Value="sended" />
                <asp:ListItem Text="未读" Value="unread" />
                <asp:ListItem Text="已读" Value="read" />
            </cc1:UcDropDownList>
        </td>
    </tr>
</table>
