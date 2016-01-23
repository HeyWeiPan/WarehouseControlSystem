<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserEducationRow.ascx.cs"
    Inherits="HR_UserProfile_UcUserEducationRow" %>
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
            <cc1:UcLabel ID="L4" ColumnName="school_name" runat="server">
            </cc1:UcLabel>
        </td>
        <td colspan="3">
            <cc1:UcTextBox ID="TxtSchoolName" ColumnName="school_name" runat="server" Width="100%"
                RequiredField="true">
            </cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="L5" ColumnName="major" runat="server">
            </cc1:UcLabel>
        </td>
        <td colspan="3">
            <cc1:UcTextBox ID="TxtMajor" ColumnName="major" RequiredField="true" runat="server"
                Width="100%">
            </cc1:UcTextBox>
        </td>
    </tr>
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
            <cc1:UcLabel ID="L" ColumnName="heducational_background" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlValue ID="DrpEducationalBackground" runat="server" Width="100%" ValueSetCode="EDUCATIONAL_BACKGROUND"
                ColumnName="heducational_background" RequiredField="true">
            </cc2:UcDdlValue>
        </td>
        <td>
            <cc1:UcLabel ID="L3" ColumnName="degree" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc2:UcDdlValue ID="DrpDegree" runat="server" Width="100%" ValueSetCode="ACADEMIC_DEGREE"
                ColumnName="academic_degree">
            </cc2:UcDdlValue>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L6" ColumnName="remark" runat="server">
            </cc1:UcLabel></td>
        <td colspan="7">
            <cc1:UcTextBox ID="TxtRemark" ColumnName="remark" runat="server" Width="100%">
            </cc1:UcTextBox></td>
    </tr>
</table>
