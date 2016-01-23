<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserTrainingRow.ascx.cs"
    Inherits="HR_UserProfile_UcUserTrainingRow" %>
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
            <cc1:UcLabel ID="L3" ColumnName="training_name" runat="server">
            </cc1:UcLabel>
        </td>
        <td colspan="3">
            <cc1:UcTextBox ID="T1" ColumnName="training_name" runat="server" Width="100%" RequiredField="true">
            </cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="L4" ColumnName="training_institute" runat="server">
            </cc1:UcLabel></td>
        <td colspan="3">
            <cc1:UcTextBox ID="T2" ColumnName="training_institute" runat="server" Width="100%"
                RequiredField="true">
            </cc1:UcTextBox></td>
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
            <cc1:UcLabel ID="UcLabel1" ColumnName="training_type" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlValue ID="DrpTrainingType" runat="server" Width="100%" ValueSetCode="training_type"
                ColumnName="training_type" RequiredField="true">
            </cc2:UcDdlValue>
        </td>
        <td>
            <cc1:UcLabel ID="LA" ColumnName="actual_training_days" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="T23" ColumnName="actual_training_days" runat="server" Width="100%"
                DbDataType="int32">
            </cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="LblCN" ColumnName="achieved_certificate_number" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtCN" ColumnName="achieved_certificate_number" runat="server"
                Width="100%">
            </cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="LL" ColumnName="achieved_certificate_name" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="T22" ColumnName="achieved_certificate_name" runat="server" Width="100%">
            </cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="L" ColumnName="achieved_certificate_date" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcDatePicker ID="D1" runat="server" ColumnName="achieved_certificate_date" Width="100%"></cc1:UcDatePicker>
        </td>
        <td>
            <cc1:UcLabel ID="LblCVD1" ColumnName="achieved_certificate_validate" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcDatePicker ID="TxtCVD1" runat="server" ColumnName="achieved_certificate_validate"
                Width="100%"></cc1:UcDatePicker>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="LB" ColumnName="remark" runat="server">
            </cc1:UcLabel></td>
        <td colspan="7">
            <cc1:UcTextBox ID="T24" ColumnName="remark" runat="server" Width="100%">
            </cc1:UcTextBox></td>
    </tr>
</table>
