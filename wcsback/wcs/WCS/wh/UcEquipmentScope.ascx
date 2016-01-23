<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcEquipmentScope.ascx.cs" Inherits="WCS_wh_UcEquipmentScope" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>

<table style="width: 100%; height: 100%; table-layout: fixed;">
    <colgroup>
        <col width="20%" class="TdLabel" />
        <col width="30%" />
        <col width="20%" class="TdLabel" />
        <col width="30%" />
    </colgroup>
    <tr>

        <td>
            <cc1:UcLabel ID="UcLabel2" runat="server" ColumnName="wh_code"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcDropDownList ID="DdlWh" runat="server" Width="100%" IsInsertItem="true"
                SqlText="select wh_id,wh_code from wcs_wh where enable_flag=-1"
                DataValueField="wh_id" DataTextField="wh_code" ColumnName="wh_id" AutoBindData="true" SearchType="Equal">
            </cc1:UcDropDownList>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel1" runat="server" ColumnName="equipment_type_name"></cc1:UcLabel></td>
        <td>
            <cc1:UcDropDownList ID="UcDropDownList1" runat="server" Width="100%" IsInsertItem="true" SqlText="select equipment_type_id,equipment_type_name  from wcs_equipment_type order by show_order"
                DataValueField="equipment_type_id" DataTextField="equipment_type_name" ColumnName="wh_id" AutoBindData="true" SearchType="Equal">
            </cc1:UcDropDownList>

        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="LabDjNo" runat="server" ColumnName="equipment_code"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtDjNo" runat="server" ColumnName="equipment_code" Width="100%"
                SearchType="LikeAndCaseInsensitive"></cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="UcLabel3" runat="server" ColumnName="equipment_name"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="UcTextBox1" runat="server" ColumnName="equipment_name" Width="100%"
                SearchType="LikeAndCaseInsensitive"></cc1:UcTextBox></td>

    </tr>
    <tr>

        <td>
            <cc1:UcLabel ID="LabStateID" runat="server" ColumnName="enable_flag"></cc1:UcLabel></td>
        <td>
            <cc2:UcDdlYesNo ID="DdlEnable" runat="server" ColumnName="enable_flag" IsInsertItem="true" SearchType="Equal" Width="100%"></cc2:UcDdlYesNo>
        </td>

    </tr>

</table>

