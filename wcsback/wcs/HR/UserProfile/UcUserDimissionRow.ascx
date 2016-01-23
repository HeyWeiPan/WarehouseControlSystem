<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserDimissionRow.ascx.cs"
    Inherits="HR_UserProfile_UcUserDimissionRow" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<table id="tblData" cellspacing="0" cellpadding="0" width="100%" border="0" style="table-layout: fixed;">
    <colgroup>
        <col class="TdLabel" width="10%" />
        <col align="left" width="14%" />
        <col class="TdLabel" width="13%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="14%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="14%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="L1" ColumnName="leave_date" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcDatePicker ID="D1" runat="server" ColumnName="leave_date" Width="100%" RequiredField="true"></cc1:UcDatePicker>
        </td>
        <td>
            <cc1:UcLabel ID="L9" ColumnName="leave_type" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlValue ID="leave_type" runat="server" Width="100%" ValueSetCode="DIMISSION_TYPE"
                RequiredField="true" ColumnName="leave_type">
            </cc2:UcDdlValue>
        </td>
        <td>
            <cc1:UcLabel ID="L2" ColumnName="leave_reason" runat="server">
            </cc1:UcLabel>
        </td>
        <td colspan="3">
            <cc1:UcTextBox ID="T2" ColumnName="leave_reason" runat="server" RequiredField="true"
                Width="100%">
            </cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L3" ColumnName="leave_advise" runat="server">
            </cc1:UcLabel>
        </td>
        <td colspan="7">
            <cc1:UcTextBox ID="T3" ColumnName="leave_advise" runat="server" Width="100%" TextMode="MultiLine">
            </cc1:UcTextBox>
        </td>
    </tr>
</table>
<cc1:UcHiddenField ID="HidUserID" ColumnName="USER_ID" runat="server" />
