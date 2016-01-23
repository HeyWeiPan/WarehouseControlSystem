<%@ Page Title="" Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterSetupDetail.master" AutoEventWireup="true" CodeFile="EquipmentDetail.aspx.cs" Inherits="WCS_wh_EquipmentDetail" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table style="table-layout: fixed; width: 100%;">
        <colgroup>
            <col width="10%" />
            <col width="15%" />
            <col width="10%" />
            <col width="15%" />
            <col width="10%" />
            <col width="15%" />
            <col width="10%" />
            <col width="15%" />
        </colgroup>
        <tr>
            <td>
                <cc1:UcLabel ID="Lb1" runat="server" ColumnName="equipment_code"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtCode" runat="server" ColumnName="equipment_code" Width="100%" RequiredField="true"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel2" runat="server" ColumnName="equipment_name"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox1" runat="server" ColumnName="equipment_name" Width="100%" RequiredField="true"></cc1:UcTextBox>
            </td>

            <td>
                <cc1:UcLabel ID="UcLabel4" runat="server" ColumnName="equipment_model"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox2" runat="server" ColumnName="equipment_model" Width="100%"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel1" runat="server" ColumnName="equipment_type_name"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcDropDownList ID="UcDropDownList1" runat="server" Width="100%" IsInsertItem="true" RequiredField="true"
                    SqlText="select equipment_type_id,equipment_type_name  from wcs_equipment_type where enable_flag=-1 order by show_order"
                    DataValueField="equipment_type_id" DataTextField="equipment_type_name" ColumnName="equipment_type_id" AutoBindData="true">
                </cc1:UcDropDownList>
            </td>
        </tr>
        <tr>

            <td>
                <cc1:UcLabel ID="UcLabel3" runat="server" ColumnName="wh_code"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcDropDownList ID="DdlWh" runat="server" Width="100%" IsInsertItem="true" RequiredField="true"
                    SqlText="select wh_id,wh_code from wcs_wh where enable_flag=-1"
                    DataValueField="wh_id" DataTextField="wh_code" ColumnName="wh_id" AutoBindData="true">
                </cc1:UcDropDownList>
                <cc1:UcLinkButton ID="LnkWh" runat="server" Font-Size="13px"></cc1:UcLinkButton>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel26" runat="server" ColumnName="x_num"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox20" runat="server" Width="100%" ColumnName="x_num" DbDataType="Int32"
                    RequiredField="true"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel27" runat="server" ColumnName="y_num"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox21" runat="server" Width="100%" ColumnName="y_num" DbDataType="Int32"
                    RequiredField="true"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel28" runat="server" ColumnName="floor_num"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox22" runat="server" Width="100%" ColumnName="floor_num"
                    DbDataType="Int32" RequiredField="true"></cc1:UcTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel5" runat="server" ColumnName="enable_flag"></cc1:UcLabel>
            </td>
            <td>

                <cc1:UcCheckBox ID="CbEnableFlag" ColumnName="enable_flag" runat="server" />
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel6" runat="server" ColumnName="remark"></cc1:UcLabel>
            </td>
            <td colspan="5">
                <cc1:UcTextBox ID="UcTextBox3" runat="server" Width="100%" ColumnName="remark"></cc1:UcTextBox>
            </td>
        </tr>
    </table>
</asp:Content>

