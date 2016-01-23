<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcMasterMenuForSFA.ascx.cs"
    Inherits="CommonUI_MasterPage_UcMasterMenuForSFA" %>
<%@ OutputCache Duration="180" VaryByParam="none" Shared="true" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib" TagPrefix="cc1" %>
<table style="padding-top: 0; font-size: 9pt; font-family: 宋体;" border="0" cellpadding="0"
    cellspacing="0" width="100%">
    <tr valign="top">
        <td align="right" valign="top" style="padding-right: 10px">
            <cc1:UcHyperLink ID="LnkGlobalSearch" NavigateUrl="~/SFA/Customer/GlobalSearch.aspx" runat="server">Global Search</cc1:UcHyperLink>
            &nbsp;<span>|</span>&nbsp;
            <cc1:UcLinkButton ID="LnkNewEstab" runat="server">New Estab</cc1:UcLinkButton>
            &nbsp;<span>|</span>&nbsp;
            <cc1:UcLinkButton ID="LnkNewCase" runat="server">New Case</cc1:UcLinkButton>
            &nbsp;<span>|</span>&nbsp;
            <cc1:UcLinkButton ID="LnkNewActivity" runat="server">New Activity</cc1:UcLinkButton>
            &nbsp;<span>|</span>&nbsp;
            <cc1:UcLinkButton ID="LnkNewPlan" runat="server">New Plan</cc1:UcLinkButton>
            &nbsp;<span></span>&nbsp;
        </td>
    </tr>
</table>
