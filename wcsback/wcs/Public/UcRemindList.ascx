<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcRemindList.ascx.cs"
    Inherits="Public_UcRemindList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<%--<table style="width: 100%; margin: 0,0,0,0; padding: 0,0,0,0; border: 0 0 0 0;" cellspacing="0"
    cellpadding="0" border="0">   
    <tr>
        <td>--%>
<ul class="ul_one ul_two">
    <asp:Repeater ID="RptRemindList" runat="server" Visible="false">
        <ItemTemplate>
            <li><span>
                <%# ((DataRowView)Container.DataItem).Row["remind_head"] %>
                <asp:HyperLink ID="Lnk" Text='<%# ((DataRowView)Container.DataItem).Row["remind_count"] %>'
                    runat="server">HyperLink</asp:HyperLink>
                <%# ((DataRowView)Container.DataItem).Row["remind_name"] %></span> </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
<%--   </td>
    </tr>
</table>--%>
