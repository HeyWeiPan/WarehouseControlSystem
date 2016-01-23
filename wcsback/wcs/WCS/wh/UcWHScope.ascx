<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcWHScope.ascx.cs" Inherits="WCS_wh_UcWHScope" %>
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
            <cc1:UcLabel ID="LabDjNo" runat="server" ColumnName="wh_code"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtDjNo" runat="server" ColumnName="wh_code" Width="100%"
                SearchType="LikeAndCaseInsensitive"></cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="UcLabel3" runat="server" ColumnName="wh_name"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="UcTextBox1" runat="server" ColumnName="wh_name" Width="100%"
                SearchType="LikeAndCaseInsensitive"></cc1:UcTextBox></td>

    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel1" runat="server" ColumnName="floor_description"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="UcTextBox2" runat="server" ColumnName="wh_name" Width="100%"
                SearchType="Custom" SearchFormat="wh_id in (select wh_id from wcs_floor where upper(floor_description) like '%'+upper('{1}')+'%' )"> </cc1:UcTextBox>

        </td>
        <td>
            <cc1:UcLabel ID="LabStateID" runat="server" ColumnName="enable_flag"></cc1:UcLabel></td>
        <td>
            <cc2:UcDdlYesNo ID="DdlEnable" runat="server" ColumnName="enable_flag" IsInsertItem="true" SearchType="Equal" Width="100%"></cc2:UcDdlYesNo>
        </td>

    </tr>

</table>

