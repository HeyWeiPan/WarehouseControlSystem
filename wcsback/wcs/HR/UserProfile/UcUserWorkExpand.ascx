<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcUserWorkExpand.ascx.cs"
    Inherits="HR_UserProfile_UcUserWorkExpand" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<table id="tblData" cellspacing="0" cellpadding="0" width="100%" border="0" style="table-layout: fixed;">
    <colgroup>
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="13%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel1" runat="server" ColumnName="hr_service_month"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="UcTextBox1" runat="server" ColumnName="hr_service_month" ReadOnlyWhenInsert="true"
                ReadOnlyWhenUpdate="true" AllowInsert="false" AllowUpdate="false"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L2" runat="server" ColumnName="total_service_month"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtTotalServiceMonth" runat="server" ColumnName="total_service_month"
                ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true" AllowInsert="false" AllowUpdate="false"></cc1:UcTextBox>
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
</table>
