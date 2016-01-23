<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterDetail.master"
    AutoEventWireup="true" CodeFile="WflChangeState.aspx.cs" Inherits="HR_Base_WflChangeState"
    Title="Untitled Page" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table id="tabMain" style="font-size: 9pt; font-family: 宋体; width: 100%; table-layout: fixed;">
        <colgroup>
            <col class="TdLabel" width="10%" />
            <col align="left" width="40%" />
            <col width="50%" style="padding-right: 20px;" />
        </colgroup>
        <tr style="height: 8px">
            <td colspan="3">
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="L1" runat="server" ColumnName="Status"></cc1:UcLabel></td>
            <td>
                <cc1:UcDropDownList ID="DdlStatus" runat="server" DbDataType="Int32" ColumnName="Status"
                    IsInsertItem="true" SearchType="Custom" Width="100%" DataTextField="text" DataValueField="value"
                    RequiredField="True">
                </cc1:UcDropDownList></td>
            <td>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <cc1:UcLabel ID="U2" runat="server" ColumnName="remark" /></td>
            <td colspan="2">
                <cc1:UcTextBox ID="TxtWfRemark" runat="server" Width="100%" TextMode="multiLine"
                    ColumnName="remark" Rows="14"></cc1:UcTextBox></td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C2" runat="Server">
    <cc1:UcButton ID="BtnSubmit" runat="server" ColumnName="Submit" Width="70px" UseSubmitBehavior="False"
        OnClientClick="window.returnValue='REFRESH';" InsureClickOnce="True" OnClick="BtnSubmit_Click" />
    <cc1:UcButton ID="BtnClose" runat="server" ColumnName="Close" Width="70px" OnClientClick="window.close();return false;" />
</asp:Content>
