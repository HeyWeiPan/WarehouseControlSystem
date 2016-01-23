<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterSetupDetail.master"
    AutoEventWireup="true" CodeFile="FunctionDefinitionDetail.aspx.cs" Inherits="Security_FunctionDefinitionDetail"
    Title="Untitled Page" %>

<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table style="display: inline; width: 100%; table-layout: fixed;">
        <colgroup>
            <col align="right" width="25%" style="padding-right: 6px;" />
            <col width="75%" style="padding-right: 8px;" />
        </colgroup>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel1" runat="server" ColumnName="function_id"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtFunctionID" runat="server" AllowUpdate="False" ColumnName="function_id"
                    Width="100%" ReadOnlyWhenUpdate="True"></cc1:UcTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel2" runat="server" ColumnName="Parent_FUNCTION_Name"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="TxtParentFunctionName" runat="server" ColumnName="Parent_FUNCTION_Name"
                    Width="100%" AllowInsert="False" AllowUpdate="False" ReadOnlyWhenInsert="True"
                    ReadOnlyWhenUpdate="True"></cc1:UcTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="LblMenuName" runat="server" ColumnName="FUNCTION_name_cn"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="TxtMenuNameCN" runat="server" ColumnName="FUNCTION_name_cn" Width="100%"
                    RequiredField="True"></cc1:UcTextBox></td>
        </tr>
        <tr id="trMenuNameEN" runat="server">
            <td>
                <cc1:UcLabel ID="UcLabel4" runat="server" ColumnName="FUNCTION_name_en"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="TxtMenuNameEN" runat="server" ColumnName="FUNCTION_name_en" Width="100%"
                    RequiredField="True"></cc1:UcTextBox></td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel5" runat="server" ColumnName="page_url"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="UcTextBox5" runat="server" Width="100%" ColumnName="page_url"></cc1:UcTextBox></td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel6" runat="server" ColumnName="Show_Order"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="UcTextBox6" runat="server" ColumnName="Show_Order" Width="100%"
                    RequiredField="True"></cc1:UcTextBox></td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel7" runat="server" ColumnName="Target"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="UcTextBox7" runat="server" ColumnName="Target" Width="100%"></cc1:UcTextBox></td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel3" runat="server" ColumnName="function_type_id"></cc1:UcLabel></td>
            <td>
                <cc1:UcDropDownList ID="DdlFunctionType" runat="server" CacheMinutes="600" ColumnName="function_type_id"
                    ConnectionString="ConSecurity" DataTextField="function_type_name" DataValueField="function_type_id"
                    AllowCache="True" RequiredField="True" SqlText="select function_type_id, function_type_name from scr_function_type order by  function_type_id"
                    Width="100%" OnSelectedIndexChanged="DdlFunctionType_SelectedIndexChanged" AutoBindData="True" AutoPostBack="True">
                </cc1:UcDropDownList></td>
        </tr>        
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel8" runat="server" ColumnName="State_ID"></cc1:UcLabel></td>
            <td>
                <cc2:UcDdlProcessState ID="DdlStateList" runat="server" Width="100%" Enabled="False"
                    AllowInsert="false" AllowUpdate="false" DbDataType="Int32" IsInsertItem="True"
                    ReadOnlyWhenInsert="True" ReadOnlyWhenUpdate="True">
                </cc2:UcDdlProcessState></td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel10" runat="server" ColumnName="Attribute"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="TxtAttribute" runat="server" ColumnName="Attribute" Width="100%"></cc1:UcTextBox></td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel11" runat="server" ColumnName="visible_flag"></cc1:UcLabel></td>
            <td>
                <cc1:UcCheckBox ID="ChkVisible" runat="server" ColumnName="visible_flag"/>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel9" runat="server" ColumnName="description">DESCRIPTION</cc1:UcLabel></td>
            <td rowspan="2" valign="top">
                <cc1:UcTextBox ID="UcTextBox8" runat="server" Height="100%" TextMode="MultiLine"
                    Width="100%" ColumnName="description" Rows="2"></cc1:UcTextBox></td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                <asp:CheckBoxList ID="ChkListOperation" runat="server" DataTextField="Operation_Name"
                    DataValueField="Operation_ID" RepeatColumns="6" RepeatDirection="Horizontal"
                    Width="100%">
                </asp:CheckBoxList></td>
        </tr>
    </table>
    <cc1:UcTextBox ID="TxtParentFunctionID" runat="server" AllowUpdate="False" ColumnName="function_pid"
        ReadOnlyWhenInsert="True" ReadOnlyWhenUpdate="True" Visible="False" Width="0"></cc1:UcTextBox>
</asp:Content>
