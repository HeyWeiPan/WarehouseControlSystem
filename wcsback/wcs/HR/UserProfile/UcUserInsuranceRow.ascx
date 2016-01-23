<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserInsuranceRow.ascx.cs"
    Inherits="HR_UserProfile_UcUserInsuranceRow" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<table id="tblData" cellspacing="0" cellpadding="0" width="100%" border="0">
    <colgroup>
        <col class="TdLabel" width="9%" />
        <col align="left" width="16%" />
        <col class="TdLabel" width="9%" />
        <col align="left" width="20%" />
        <col class="TdLabel" width="9%" />
        <col align="left" width="14%" />
        <col class="TdLabel" width="9%" />
        <col align="left" width="14%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="L1" runat="server" ColumnName="insurance_num"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtInsuranceNum" ColumnName="insurance_num" runat="server" Width="100%"
                RequiredField="true">
            </cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L2" runat="server" ColumnName="INSURANCE_BY_COMPANY_ID"></cc1:UcLabel></td>
        <td>
            <cc2:UcDdlCompany ID="UcINSURANCE_BY_COMPANY_ID" RequiredField="true" runat="server"
                ColumnName="INSURANCE_BY_COMPANY_ID" Width="100%">
            </cc2:UcDdlCompany></td>
        <td>
            <cc1:UcLabel ID="L3" runat="server" ColumnName="start_date"></cc1:UcLabel></td>
        <td>
            <cc1:UcDatePicker ID="DtpStartDate" ColumnName="start_date" runat="server" Width="100%"
                RequiredField="true"></cc1:UcDatePicker>
        </td>
        <td>
            <cc1:UcLabel ID="L4" runat="server" ColumnName="end_date"></cc1:UcLabel></td>
        <td>
            <cc1:UcDatePicker ID="UcDatePicker1" ColumnName="end_date" runat="server" Width="100%"
                RequiredField="true"></cc1:UcDatePicker></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L5" runat="server" ColumnName="insurance_type"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtInsuranceType" ColumnName="insurance_type" RequiredField="true"
                runat="server" Width="100%"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L6" runat="server" ColumnName="insurance_amount"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtInsuranceAmount" ColumnName="insurance_amount" RequiredField="true"
                runat="server" Width="100%"></cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="L7" ColumnName="insurance_fees" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtInsuranceFees" ColumnName="insurance_fees" RequiredField="true"
                runat="server" Width="100%" DbDataType="decimal"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L8" ColumnName="beneficiary_by" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtBeneficiaryBy" ColumnName="beneficiary_by" RequiredField="true"
                Text="法定受益人" runat="server" Width="100%"></cc1:UcTextBox>
        </td>
    </tr>
</table>
