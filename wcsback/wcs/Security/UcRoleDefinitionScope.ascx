<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcRoleDefinitionScope.ascx.cs"
    Inherits="Security_UcRoleDefinitionScope" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib" TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc3" %>
<table id="tabMain" width="100%" style="table-layout: fixed;
    height: 100%;" cellpadding="0" cellspacing="0">
    <colgroup>
        <col align="left" width="30%" />
        <col align="left" width="60%" />
        <col align="left" width="10%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="LabUser" runat="server" ColumnName="User_ID" Width="100%"></cc1:UcLabel></td>
        <td>
            <cc3:UcWebComboUser ID="DdlUser" runat="server" Width="100%" ColumnName="User_ID"
                TableName="SCR_ROLE_USER"></cc3:UcWebComboUser>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="LabRoleId" runat="server" Width="100%" ColumnName="Role_Id"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtRoleId" runat="server" Width="100%" ColumnName="Role_ID" DbDataType="Int32"></cc1:UcTextBox></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="LabRoleName" runat="server" ColumnName="Role_Name" Width="100%"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtRoleName" runat="server" ColumnName="Role_Name" SearchType="LikeAndCaseInsensitive"
                Width="100%"></cc1:UcTextBox></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="LabSystemRoleFlag" runat="server" ColumnName="system_role"
                Width="100%"></cc1:UcLabel></td>
        <td>
            <cc1:UcDropDownList ID="DdlSystemRole" runat="server" AutoBindData="True" ColumnName="System_Role_Flag"
                DataTextField="FlagName" DataValueField="System_Role_Flag" IsInsertItem="True"
                SqlText="select 'Yes' as FlagName,-1 as system_role_flag from scr_role union select 'No' as FlagName,0 as system_role_flag from scr_role "
                Width="100%" DbDataType="Int32">
            </cc1:UcDropDownList></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="LabFunctionId" runat="server" ColumnName="Function_Id" Width="100%"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtFunctionId" runat="server" Width="100%" ColumnName="Function_Id" TableName="SCR_ROLE_FUNCTION" DbDataType="Int32"></cc1:UcTextBox></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="LabFunctionNameEN" runat="server" ColumnName="Function_Name_EN"
                Width="100%"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtFunctionNameEN" runat="server" Width="100%" ColumnName="function_id" SearchFormat="{0} in (select function_id from scr_function where upper(function_name_en) like upper('%{1}%'))" SearchType="Custom" TableName="scr_role_function"></cc1:UcTextBox></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="LabFunctionNameCN" runat="server" ColumnName="Function_Name_CN"
                Width="100%"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtFunctionNameCN" runat="server" Width="100%" SearchType="Custom" ColumnName="function_id" SearchFormat="{0} in (select function_id from scr_function where upper(function_name_cn) like upper('%{1}%'))" TableName="scr_role_function"></cc1:UcTextBox></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="LabResourceType" runat="server" ColumnName="resource_type" Width="100%"></cc1:UcLabel></td>
        <td>
            <cc1:UcDropDownList ID="DdlResourceType" runat="server" DataTextField="description"
                DataValueField="resource_type" SqlText="select resource_type,description from scr_resource_type order by resource_type"
                Width="100%" ColumnName="resource_type" TableName="SCR_ROLE_RESOURCE" AutoBindData="True"
                IsInsertItem="True" AutoPostBack="True" OnSelectedIndexChanged="DdlResourceType_SelectedIndexChanged">
            </cc1:UcDropDownList></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="LabInterfaceId" runat="server" ColumnName="resource_interface_id" Width="100%"></cc1:UcLabel></td>
        <td>
            <cc1:UcDropDownList ID="DdlInterfaceId" runat="server" DataTextField="description_interface"
                DataValueField="resource_interface_id" SqlText="select resource_interface_id,description_en as description_interface from scr_resource_interface order by resource_interface_id"
                Width="100%" ColumnName="resource_interface_id" TableName="SCR_ROLE_RESOURCE"
                AutoBindData="True" IsInsertItem="True">
            </cc1:UcDropDownList></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="LabDescription" runat="server" ColumnName="Description" Width="100%"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtDescription" runat="server" ColumnName="Description" TextMode="MultiLine"
                Width="100%" SearchType="LikeAndCaseInsensitive"></cc1:UcTextBox></td>
        <td>
        </td>
    </tr>
</table>