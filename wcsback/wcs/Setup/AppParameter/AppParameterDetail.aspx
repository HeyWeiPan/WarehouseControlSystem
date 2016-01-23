<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterSetupDetail.master"
    AutoEventWireup="true" CodeFile="AppParameterDetail.aspx.cs" Inherits="Setup_AppParameter_AppParameterDetail" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
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
                <cc1:UcLabel ID="LabCode" runat="server" ColumnName="Parameter_Code"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtCode" runat="server" ColumnName="Code" RequiredField="True"
                    Width="100%" AllowUpdate="False" ReadOnlyWhenUpdate="True" AllowInsert="False"></cc1:UcTextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="LabDescription" runat="server" ColumnName="Description"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtDescription" runat="server" ColumnName="Description" Width="100%"
                    RequiredField="True"></cc1:UcTextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="LabModuleName" runat="server" ColumnName="Module_Name"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtModuleName" runat="server" ColumnName="Module_Name" Width="70%"
                    ReadOnly="True"></cc1:UcTextBox>
                <cc2:UcDdlModule ID="DdlModule" runat="server" Width="70%">
                </cc2:UcDdlModule>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="LabDbType" runat="server" ColumnName="Data_Type"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcDropDownList ID="DdlDbType" runat="server" ColumnName="Data_Type" ConnectionString="ConJXC"
                    Width="70%" RequiredField="True" AutoBindData="True" DataTextField="DbType" DataValueField="DbType"
                    IsInsertItem="True" SqlText="select 'Date' DbType from app_parameter union select 'String' DbType from app_parameter union select 'Number' DbType from app_parameter union select 'Bool' DbType from app_parameter union select 'DropDownList' DbType from app_parameter">
                </cc1:UcDropDownList>
            </td>
        </tr>
        <tr id="TRValue" runat="server" style="display: inline;">
            <td>
                <cc1:UcLabel ID="LabValue" runat="server" ColumnName="data_Value"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtValue" runat="server" ColumnName="data_Value" Width="70%" AllowInsert="False"
                    AllowUpdate="False" ReadOnlyWhenInsert="True" ReadOnlyWhenUpdate="True"></cc1:UcTextBox>
                <cc1:UcHyperLink ID="HyLParaSet" runat="server">修改</cc1:UcHyperLink>
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
        <tr>
            <td>
                <cc1:UcLabel ID="LabEnableFlag" runat="server" ColumnName="Enable_Flag"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcCheckBox ID="ChkEnableFlag" runat="server" ColumnName="Enable_Flag" Checked="True" />
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
