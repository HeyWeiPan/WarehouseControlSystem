<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterSetupDetail.master"
    AutoEventWireup="true" CodeFile="GeographyDetail.aspx.cs" Inherits="Setup_GeographyDetail" %>

<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table id="tabMain" width="98%" style="font-size: 9pt; font-family: 宋体; table-layout: fixed;
        height: 100%;" cellpadding="0" cellspacing="0" align="left">
        <colgroup>
            <col class="TdLabel" width="30%" />
            <col align="left" width="60%" />
            <col align="left" width="10%" />
        </colgroup>
        <tr>
            <td>
                <cc1:UcLabel ID="Lab2" runat="server" ColumnName="Geo_Name" Width="100%"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtName" runat="server" ColumnName="Geo_Name" Width="100%" RequiredField="True"></cc1:UcTextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="Lab5" runat="server" ColumnName="Pinyin" Width="100%"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="TxtPinyin" runat="server" ColumnName="Pinyin" Width="100%"></cc1:UcTextBox></td>
            <td>
            </td>
        </tr>
        <%--<tr>
            <td>
                <cc1:UcLabel ID="Lab7" runat="server" ColumnName="geo_pid" Width="100%"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="TxtParentID" runat="server" ColumnName="geo_pid" Width="100%"
                    ReadOnlyWhenInsert="True" ReadOnlyWhenUpdate="True" DbDataType="Int32" AllowUpdate="False"></cc1:UcTextBox></td>
            <td>
            </td>
        </tr>--%>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel1" runat="server" ColumnName="Geo_Parent_Name" Width="100%"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="TxtParentName" runat="server" Width="100%" ColumnName="Geo_Parent_Name"
                    AllowInsert="false" AllowUpdate="false" ReadOnlyWhenInsert="True" ReadOnlyWhenUpdate="True"></cc1:UcTextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="Lab6" runat="server" ColumnName="Geo_Type" Width="100%"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcDropDownList ID="DrpType" runat="server" Width="75%" ColumnName="Geo_type"
                    RequiredField="True">
                    <asp:ListItem Selected="True">
                    </asp:ListItem>
                    <asp:ListItem Value="Nationality">Nationality(国家)</asp:ListItem>
                    <asp:ListItem Value="Area">Area(区域)</asp:ListItem>
                    <asp:ListItem Value="Province">Province(省份)</asp:ListItem>
                    <asp:ListItem Value="City">City(城市)</asp:ListItem>
                </cc1:UcDropDownList>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="L6" runat="server" ColumnName="Show_Order"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="TxtShowOrder" runat="server" ColumnName="Show_Order" RequiredField="True"
                    Width="100%" DbDataType="Int32"></cc1:UcTextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel2" runat="server" ColumnName="Delete_flag"></cc1:UcLabel></td>
            <td>
                <cc1:UcCheckBox ID="ChkDelteFalg" ColumnName="Delete_flag" runat="server" />
            </td>
            <td>
            </td>
        </tr>
    </table>
    <cc1:UcHiddenField ID="HidParentID" runat="server" ColumnName="geo_pid" AllowUpdate="false"
        DbDataType="int32" />
</asp:Content>
