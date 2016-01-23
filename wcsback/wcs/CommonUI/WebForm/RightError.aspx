<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterDetail.master"
    AutoEventWireup="false" CodeFile="RightError.aspx.cs" Inherits="CommonUI_WebForm_RightError"
    Title="Untitled Page" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table style="width: 100%; height: 100%; display: inline; table-layout: fixed; margin: 0 0 0 0;
        padding: 0 0 0 0;" cellpadding="0" cellspacing="0">
        <colgroup>
            <col class="TdLabel" width="25%" />
            <col align="left" width="50%" />
            <col class="TdLabel" width="25%" />
        </colgroup>
        <tr>
            <td>
            </td>
            <td>
                <cc1:UcLabel ID="LabRight" runat="server" Font-Size="Large"></cc1:UcLabel>
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C2" runat="Server">
    <cc1:UcButton ID="BtnClose" runat="server" ColumnName="Close" Width="70px" OnClientClick="window.close();return false;" />
</asp:Content>
