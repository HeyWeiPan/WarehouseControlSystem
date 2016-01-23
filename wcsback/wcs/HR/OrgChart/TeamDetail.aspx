<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterSetupDetail.master"
    AutoEventWireup="true" CodeFile="TeamDetail.aspx.cs" Inherits="HR_OrgChart_TeamDetail"
    Title="Untitled Page" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table id="tabMain" width="100%" height="80%" style="table-layout: fixed;" cellpadding="0"
        cellspacing="0">
        <colgroup>
            <col class="TdLabel" width="25%" />
            <col align="left" width="65%" />
            <col align="left" width="10%" />
        </colgroup>
        <tr>
            <td>
                <cc1:UcLabel ID="L2" ColumnName="team_name" runat="server" />
            </td>
            <td>
                <cc1:UcTextBox ID="TxtTeamName" ColumnName="team_name" RequiredField="true" Width="100%"
                    runat="server" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="L3" ColumnName="team_leaderid" runat="server" />
            </td>
            <td>
                <cc2:UcWebComboUser ID="WcbUser" runat="server" ColumnName="team_leaderid" Width="100%"
                    RequiredField="True" CssClass="CssRequired" />
                <cc1:UcTextBox ID="TxtTeamLeader" ColumnName="team_leader_name" Width="100%" runat="server"
                    AllowInsert="false" AllowUpdate="false" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel1" ColumnName="team_type_id" runat="server" /></td>
            <td>
                <cc2:UcDdlTeamType ID="DrpTeamType" runat="server" Width="100%" RequiredField="True">
                </cc2:UcDdlTeamType></td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel2" runat="server" ColumnName="Cost_Center"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="TxtCostCenter" runat="server" ColumnName="Cost_Center" RequiredField="true"
                    Width="100%"></cc1:UcTextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel6" runat="server" ColumnName="Show_Order"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="UcTextBox6" runat="server" ColumnName="Show_Order" RequiredField="True"
                    Width="100%"></cc1:UcTextBox></td>
            <td>
            </td>
        </tr>
        <%-- <tr>
            <td>
                <cc1:UcLabel ID="UcLabel1" ColumnName="delete_Flag" runat="server" /></td>
            <td>
                <cc1:UcCheckBox ID="ChkDeleteFlag" ColumnName="delete_Flag" runat="server" DbDataType="Int32" />
            </td>
            <td>
            </td>
        </tr>--%>
    </table>
    <cc1:UcHiddenField ID="HidTeamPId" runat="server" ColumnName="team_pid" AllowUpdate="false"
        DbDataType="int32" />
</asp:Content>
