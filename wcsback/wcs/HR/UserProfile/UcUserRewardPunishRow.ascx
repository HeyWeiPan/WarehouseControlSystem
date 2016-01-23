<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserRewardPunishRow.ascx.cs"
    Inherits="HR_UserProfile_UcUserRewardPunishRow" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<table id="tblData" cellspacing="0" cellpadding="0" width="100%" border="0">
    <colgroup>
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="L1" runat="server" ColumnName="reward_punish_date"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcDatePicker ID="DpkDate" ColumnName="reward_punish_date" runat="server" Width="100%"
                RequiredField="true"></cc1:UcDatePicker>
        </td>
        <td>
            <cc1:UcLabel ID="L2" ColumnName="reward_punish_type" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlValue ID="DrpJobType" runat="server" Width="100%" ValueSetCode="REWARD_PUNISH_TYPE"
                ColumnName="reward_punish_type" RequiredField="true">
            </cc2:UcDdlValue>
        </td>
        <%--<td>
            <cc1:UcLabel ID="L3" ColumnName="category" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="T1" ColumnName="category" runat="server" Width="100%">
            </cc1:UcTextBox></td>--%>
        <td>
            <cc1:UcLabel ID="L4" ColumnName="reward_punish_name" runat="server">
            </cc1:UcLabel></td>
        <td colspan="3">
            <cc1:UcTextBox ID="T4" ColumnName="reward_punish_name" runat="server" RequiredField="true"
                Width="100%">
            </cc1:UcTextBox></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L6" ColumnName="description" runat="server">
            </cc1:UcLabel></td>
        <td colspan="7">
            <cc1:UcTextBox ID="TxtDesc" ColumnName="description" runat="server" Width="100%"
                TextMode="MultiLine">
            </cc1:UcTextBox></td>
    </tr>
</table>
