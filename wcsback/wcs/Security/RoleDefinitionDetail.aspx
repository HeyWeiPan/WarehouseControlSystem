<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterSetupDetail.master"
    AutoEventWireup="false" CodeFile="RoleDefinitionDetail.aspx.cs" Inherits="RoleDefinitionDetail"
    Title="Untitled Page" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table style="width: 100%; height: 100%; font-size: 11px; table-layout: fixed;" cellpadding="0"
        cellspacing="0">
        <tr style="height: 75px">
            <td colspan="4">
                <table style="width: 100%; height: 100%; font-size: 11px; table-layout: fixed;" cellpadding="0"
                    cellspacing="0">
                    <colgroup>
                        <col width="15%" />
                        <col width="20%" />
                        <col width="15%" />
                        <col width="50%" />
                    </colgroup>
                    <tr>
                        <td>
                            <cc1:UcLabel ID="Uc1" runat="server" ColumnName="ROLE_ID" Width="100%" /></td>
                        <td>
                            <cc1:UcTextBox ID="TxtRoleId" runat="server" AllowInsert="False" AllowUpdate="False"
                                ColumnName="ROLE_ID" ReadOnlyWhenInsert="True" ReadOnlyWhenUpdate="True" Width="100%"
                                TableName="SCR_ROLE" DbDataType="string" /></td>
                        <td align="right">
                            <cc1:UcLabel ID="Uc2" runat="server" ColumnName="System_Role" Width="100%" /></td>
                        <td>
                            <cc1:UcCheckBox ID="CheckBoxSystemRole" runat="server" ColumnName="SYSTEM_ROLE_FLAG"
                                DbDataType="Int16" TableName="SCR_ROLE" Checked="true" />
                            <cc1:UcLinkButton ID="LnkRefresh" runat="server" Visible="false" ColumnName="REFRESH"
                                OnClick="LnkRefresh_Click"></cc1:UcLinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:UcLabel ID="Uc3" runat="server" ColumnName="Role_Name" Width="100%" /></td>
                        <td colspan="3">
                            <cc1:UcTextBox ID="TextBoxRoleName" runat="server" ColumnName="ROLE_NAME" Width="100%"
                                TableName="SCR_ROLE" /></td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:UcLabel ID="UcLabel4" runat="server" ColumnName="description" Width="100%" /></td>
                        <td colspan="3">
                            <cc1:UcTextBox ID="TextBoxRoleDesc" runat="server" ColumnName="description" Width="100%"
                                TableName="SCR_ROLE" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table id="Table2" runat="server" style="width: 100%; height: 100%; font-size: 9pt;
                    font-family: ËÎÌו; display: inline; table-layout: fixed;" border="0" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td style="height: 25px" align="left" colspan="4">
                            <cc1:UcHyperLink ID="LinkUser" Target="IfraSubWindow" ShowStyle="TabWhite" ColumnName="LinkUser"
                                Text="[LinkUser]" runat="server" Width="81px" />
                            <cc1:UcHyperLink ID="LinkFunction" Target="IfraSubWindow" ShowStyle="TabWhite" ColumnName="LinkFunction"
                                Text="[LinkFunction]" runat="server" Width="101px" />
                            <cc1:UcHyperLink ID="LinkResource" Target="IfraSubWindow" ShowStyle="TabWhite" ColumnName="LinkResource"
                                Text="[LinkResource]" runat="server" Width="105px" />
                        </td>
                    </tr>
                    <tr id="trFrame" runat="server">
                        <td colspan="4">
                            <iframe style="width: 100%; height: 100%;" frameborder="0" runat="server" scrolling="auto"
                                name="IfraSubWindow" id="IfraSubWindow"></iframe>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
