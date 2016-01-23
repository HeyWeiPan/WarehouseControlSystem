<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcAppParameterScope.ascx.cs"
    Inherits="Setup_AppParameter_UcAppParameterScope" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<table style="width: 100%; height: 100%; table-layout: fixed;">
    <colgroup>
        <col width="17%" class="TdLabel" />
        <col width="33%" />
        <col width="17%" class="TdLabel" />
        <col width="33%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="LabCode" runat="server" ColumnName="Parameter_code"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtCode" runat="server" Width="100%" ColumnName="Code" SearchType="Like"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="LabDescription" runat="server" ColumnName="Description"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtDescription" runat="server" Width="100%" ColumnName="Description"
                SearchType="Like"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="LabModuleName" runat="server" ColumnName="Module_Name"></cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlModule ID="DdlModule" runat="server" Width="100%"></cc2:UcDdlModule>
        </td>
        <td>
            <cc1:UcLabel ID="LabDbType" runat="server" ColumnName="Data_Type"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcDropDownList ID="DdlDbType" runat="server" Width="100%" ColumnName="Data_Type"
                ConnectionString="ConJXC" AutoBindData="True" DataTextField="DbType" DataValueField="DbType"
                IsInsertItem="True" SqlText="select 'Date' DbType from app_parameter union select 'String' DbType from app_parameter union select 'Number' DbType from app_parameter union select 'Bool' DbType from app_parameter union select 'DropDownList' DbType from app_parameter">
            </cc1:UcDropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="LabValue" runat="server" ColumnName="data_Value"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtValue" runat="server" Width="100%" ColumnName="data_Value"
                SearchType="Equal"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="LabEnableFlag" runat="server" Width="100%" ColumnName="Enable_Flag"></cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlYesNo ID="Ddlenable" ColumnName="enable_flag" runat="server" Width="100%" DefaultValue="-1">
            </cc2:UcDdlYesNo>
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
</table>
