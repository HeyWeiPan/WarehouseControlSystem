<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserLeaveRow.ascx.cs"
    Inherits="HR_UserProfile_UcUserLeaveRow" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived.HR" Namespace="EntpClass.WebControlLib.Derived.HR"
    TagPrefix="cc3" %>
<table width="100%;" style="display: inline;" cellpadding="0" cellspacing="0">
    <colgroup>
        <col class="TdLabel" width="10%" />
        <col align="left" width="24%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="25%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="25%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="L1" ColumnName="leave_form_code" runat="server"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtLeaveFormCode" runat="server" Width="100%" ColumnName="leave_form_code"
                InsertExpression="hr.GetNewLeaveFormCode()" AllowUpdate="false" ReadOnlyWhenInsert="true"
                ReadOnlyWhenUpdate="true"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L2" runat="server" ColumnName="process_type_name"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtLeaveProcessName" ColumnName="process_type_name" Width="100%"
                ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true" AllowUpdate="false" AllowInsert="false"
                runat="server" /></td>
        <td>
            <cc1:UcLabel ID="L3" runat="server" ColumnName="Status_id"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="T" ColumnName="Status_id" Width="100%" ReadOnlyWhenInsert="true"
                ReadOnlyWhenUpdate="true" AllowUpdate="false" AllowInsert="false" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L6" runat="server" ColumnName="start_time"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtStartTime" ColumnName="start_time_desc" Width="100%" runat="server"
                AllowInsert="false" AllowUpdate="false" />
        </td>
        <td>
            <cc1:UcLabel ID="L7" runat="server" ColumnName="end_time"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtEndTime" ColumnName="end_time_desc" Width="100%" runat="server"
                AllowInsert="false" AllowUpdate="false" />
        </td>
        <td>
            <cc1:UcLabel ID="L4" runat="server" ColumnName="number_of_days"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtNumberOfDays" ColumnName="number_of_days" Width="20%" runat="server"
                RequiredField="true" DbDataType="Int32" />天
            <cc1:UcTextBox ID="UcTextBox1" ColumnName="NUMBER_OF_HOURS" Width="20%" runat="server"
                RequiredField="true" DbDataType="decimal" />小时
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L8" runat="server" ColumnName="reason"></cc1:UcLabel>
        </td>
        <td colspan="5">
            <cc1:UcTextBox ID="TxtReason" ColumnName="reason" Width="100%" TextMode="MultiLine"
                RequiredField="true" runat="server" Rows="3" />
        </td>
    </tr>
</table>
