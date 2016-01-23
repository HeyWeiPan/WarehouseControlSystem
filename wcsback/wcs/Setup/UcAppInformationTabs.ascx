<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcAppInformationTabs.ascx.cs"
    Inherits="Base_UcAppInformationTabs" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib" TagPrefix="cc1" %>
<table id="tabLink" runat="server" style="font-size: 9pt; font-family: 宋体; table-layout: fixed;"
    border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <cc1:UcHyperLink ID="HyperAppInformation" ShowStyle="TabWhite" runat="server" Text="" ColumnName="app_information" ResourceFileType="UI"
                NavigateUrl="AppInformation.aspx" />
         <%--   <cc1:UcHyperLink ID="HyperAppParameter" ShowStyle="TabWhite" runat="server" Text="" ColumnName="app_parameter" ResourceFileType="UI"
                NavigateUrl="AppParameter.aspx" />
            <cc1:UcHyperLink ID="HyperDjParameter" ShowStyle="TabWhite" runat="server" Text="" ColumnName="dj_parameter" ResourceFileType="UI"
                NavigateUrl="DjParameter.aspx" />--%>
        </td>
    </tr>
</table>
