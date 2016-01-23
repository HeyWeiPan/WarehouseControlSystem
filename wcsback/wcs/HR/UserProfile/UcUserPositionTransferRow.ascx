<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcUserPositionTransferRow.ascx.cs"
    Inherits="HR_UserProfile_UcUserPositionTransferRow" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived.HR" Namespace="EntpClass.WebControlLib.Derived.HR"
    TagPrefix="cc3" %>
<table id="tblData" cellspacing="0" cellpadding="0" width="100%" border="0">
    <colgroup>
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="11%" />
        <col align="left" width="14%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="L1" runat="server" ColumnName="start_date"></cc1:UcLabel></td>
        <td>
            <cc1:UcDatePicker ID="DpkStartDate" ColumnName="start_date" runat="server" Width="100%"
                RequiredField="True"></cc1:UcDatePicker></td>
        <td>
            <cc1:UcLabel ID="L2" ColumnName="end_date" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcDatePicker ID="DpkEndDate" runat="server" ColumnName="end_date" Width="100%"
                RequiredField="True"></cc1:UcDatePicker></td>
        <td>
            <cc1:UcLabel ID="UcLabel1" ColumnName="job_code" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="UcTextBox1" ColumnName="job_code" runat="server" Width="100%"></cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="L4" ColumnName="job_title" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtJobTitle" ColumnName="job_title" runat="server" Width="100%"></cc1:UcTextBox></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L3" ColumnName="company_name" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc2:UcDdlCompany ID="DrpCompany" ColumnName="company_id" runat="server" Width="100%"
                IncludeDisabledValue="true" RequiredField="True">
            </cc2:UcDdlCompany>
        </td>
        <td>
            <cc1:UcLabel ID="LL" ColumnName="team_name" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtTeamName" ColumnName="team_name" runat="server" Width="100%"
                RequiredField="true"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L5" ColumnName="team_leaderid" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtTeamLeaderName" ColumnName="team_leader_name" runat="server"
                RequiredField="true" Width="100%"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L7" ColumnName="service_month" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtService" ColumnName="service_month" runat="server" Width="100%"
                DbDataType="Int32" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true">
            </cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L8" ColumnName="change_reason" runat="server">
            </cc1:UcLabel></td>
        <td colspan="7">
            <cc1:UcTextBox ID="TxtChangeReason" ColumnName="change_reason" runat="server" Width="100%">
            </cc1:UcTextBox></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L6" ColumnName="remark" runat="server">
            </cc1:UcLabel></td>
        <td colspan="7">
            <cc1:UcTextBox ID="TxtRemark" ColumnName="remark" runat="server" Width="100%" Rows="2"
                TextMode="MultiLine"></cc1:UcTextBox></td>
    </tr>
</table>
