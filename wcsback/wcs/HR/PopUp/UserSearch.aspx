<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterDetail.master"
    AutoEventWireup="false" CodeFile="UserSearch.aspx.cs" Inherits="HR_PopUp_UserSearch"
    Title="Untitled Page" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">

    <script src="Js/JScript.js" type="text/javascript"></script>

    <table id="tabMain" style="font-size: 9pt; font-family: 宋体; width: 100%; height: 24px;
        table-layout: fixed;">
        <colgroup>
            <col class="TdLabel" width="10%" />
            <col align="left" width="40%" />
            <col class="TdLabel" width="10%" />
            <col align="left" width="40%" />
        </colgroup>
        <tr style="height: 8px">
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="L1" runat="server" ColumnName="user_select" /></td>
            <td>
                <cc2:UcWebComboUser ID="WcbUser" runat="server" Width="100%" ColumnName="user_id"
                    IncludeInactiveUser="True" />
            </td>
            <td>
                <cc1:UcLabel ID="L3" runat="server" ColumnName="role_name"></cc1:UcLabel></td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="L5" runat="server" ColumnName="primary_team_id"></cc1:UcLabel></td>
            <td>
                <cc2:UcTreeWebComboHRTeam ID="WcbTeam" runat="server" Width="100%" ColumnName="user_id" />
            </td>
            <td>
                <cc1:UcLabel ID="U2" runat="server" ColumnName="job_code" /></td>
            <td>
            </td>
        </tr>
        <tr style="width: 95%">
            <td colspan="4" align="right">
                <cc1:UcButton ID="BtnSearch" runat="server" ColumnName="Search" OnClick="BtnSearch_Click" /></td>
        </tr>
        <tr>
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <cc1:UcGridView ID="GrdList" runat="server" AutoGenerateColumns="False" Width="100%"
                    DataKeyNames="user_id" IsSelectable="True" ShowNoRecordsMessage="True">
                    <Columns>
                        <asp:TemplateField>
                            <headertemplate><cc1:UcCheckBox ID="ChkAll" runat="server" onclick="setSelect('GrdList',this.checked);"/></headertemplate>
                            <itemstyle horizontalalign="Center" width="5%" />
                            <itemtemplate><cc1:UcCheckBox ID="Chk" runat="server" /></itemtemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="user_number" HeaderText="user_number" />
                        <asp:BoundField DataField="native_name" HeaderText="native_name" />
                        <asp:BoundField DataField="primary_team_id" HeaderText="primary_team_id" />
                        <asp:BoundField DataField="user_type_id" HeaderText="job_code" />
                        <asp:BoundField DataField="job_code" HeaderText="job_code" />
                        <asp:BoundField DataField="job_title" HeaderText="job_title" />
                    </Columns>
                </cc1:UcGridView>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C2" runat="Server">
    <cc1:UcButton ID="BtnSelect" runat="server" ColumnName="Select" Width="75px" OnClientClick="return onSelect();" />
    <cc1:UcButton ID="BtnClose" runat="server" OnClientClick="window.returnValue ='closed';window.close();return false;"
        ColumnName="Close" Width="53px" />
</asp:Content>
