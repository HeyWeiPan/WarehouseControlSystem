<%@ Page Title="" Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterSetupDetail.master"
    AutoEventWireup="true" CodeFile="AppParameterSettingDetail.aspx.cs" Inherits="Setup_AppParameter_AppParameterSettingDetail" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table id="tabMain" width="98%" style="font-size: 9pt; font-family: 宋体; table-layout: fixed;
        height: 98%;" cellpadding="0" cellspacing="0">
        <colgroup>
            <col width="25%" align="left" />
            <col width="65%" align="left" />
            <col width="10%" align="right" />
        </colgroup>
        <tr>
            <td>
                <cc1:UcLabel ID="LabModuleName" runat="server" ColumnName="Module_Name"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtModuleName" runat="server" ColumnName="Module_Name" Width="70%"
                    ReadOnly="True" ReadOnlyWhenInsert="True" ReadOnlyWhenUpdate="True" AllowInsert="False"
                    AllowSearch="False"></cc1:UcTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="LabDescription" runat="server" ColumnName="Description"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtDescription" runat="server" ColumnName="Description" Width="100%"
                    RequiredField="True" AllowInsert="False" AllowUpdate="False" ReadOnlyWhenInsert="True"
                    ReadOnlyWhenUpdate="True"></cc1:UcTextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr id="TRValue" runat="server">
            <td>
                <cc1:UcLabel ID="LabValue" runat="server" ColumnName="data_Value"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtValue" runat="server" ColumnName="data_Value" Width="70%" 
                   ></cc1:UcTextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr id="TRDatePicker" runat="server">
            <td>
                <cc1:UcLabel ID="LabDpk" runat="server" ColumnName="data_Value"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcDatePicker ID="DpkValue" runat="server" ColumnName="data_Value" 
                    Width="70%" ></cc1:UcDatePicker>
            </td>
            <td>
            </td>
        </tr>
        <tr id="TRCheck" runat="server">
            <td>
                <cc1:UcLabel ID="LabCheck" runat="server" ColumnName="data_Value"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcCheckBox ID="ChkValue" runat="server" ColumnName="data_Value" 
                    />
            </td>
            <td>
            </td>
        </tr>
        <tr id="TRDataText" runat="server">
            <td>
                <cc1:UcLabel ID="LabDataText" runat="server" ColumnName="Data_Text"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtDataText" runat="server" ColumnName="Data_Text" Width="70%"></cc1:UcTextBox>
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
