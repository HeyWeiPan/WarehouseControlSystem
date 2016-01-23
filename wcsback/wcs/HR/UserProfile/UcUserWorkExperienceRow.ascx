<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcUserWorkExperienceRow.ascx.cs"
    Inherits="HR_UserProfile_UcUserWorkExperienceRow" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<table id="tblData" cellspacing="0" cellpadding="0" width="100%" border="0">
    <colgroup>
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="11%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="9%" />
        <col align="left" width="15%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="L1" runat="server" ColumnName="start_date"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcDatePicker ID="DpkStartDate" ColumnName="start_date" runat="server" Width="100%"
                RequiredField="true"></cc1:UcDatePicker>
        </td>
        <td>
            <cc1:UcLabel ID="L2" ColumnName="end_date" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcDatePicker ID="DpkEndDate" runat="server" ColumnName="end_date" Width="100%"
                RequiredField="true"></cc1:UcDatePicker>
        </td>
        <td>
            <cc1:UcLabel ID="L3" ColumnName="company_name" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtCompanyName" ColumnName="company_name" runat="server" Width="100%"
                RequiredField="true">
            </cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="L5" ColumnName="department" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtDepartmentName" ColumnName="department_name" runat="server"
                RequiredField="True" Width="100%">
            </cc1:UcTextBox></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L4" ColumnName="job_name" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtJobTitle" ColumnName="job_name" runat="server" Width="100%"
                RequiredField="true">
            </cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="L6" ColumnName="job_formal_title" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="T6" ColumnName="job_formal_title" runat="server" Width="100%"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L7" ColumnName="social_service_month" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="T7" ColumnName="social_service_month" runat="server" Width="100%"
                ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true" InsertExpression="" UpdateExpression=""
                DbDataType="decimal">
            </cc1:UcTextBox></td>
        <td>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L8" ColumnName="JOB_DESCRIPTION" runat="server">
            </cc1:UcLabel></td>
        <td colspan="7">
            <cc1:UcTextBox ID="T8" ColumnName="JOB_DESCRIPTION" runat="server" Width="100%">
            </cc1:UcTextBox></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L9" ColumnName="leave_reason" runat="server">
            </cc1:UcLabel></td>
        <td colspan="7">
            <cc1:UcTextBox ID="T9" ColumnName="leave_reason" runat="server" Width="100%">
            </cc1:UcTextBox></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L10" ColumnName="remark" runat="server">
            </cc1:UcLabel></td>
        <td colspan="7">
            <cc1:UcTextBox ID="T10" ColumnName="remark" runat="server" Width="100%">
            </cc1:UcTextBox></td>
    </tr>
</table>
