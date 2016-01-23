<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcJDSummary.ascx.cs"
    Inherits="HR_Setup_UcJDSummary" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<table style="width: 100%; display: inline; table-layout: fixed; margin: 0 0 0 0;
    padding: 0 0 0 0;" cellpadding="0" cellspacing="0">
    <colgroup>
        <col class="TdLabel" width="10%" />
        <col align="left" width="85%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="L7" runat="server" ColumnName="job_summary"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtJobSummary" runat="server" ColumnName="job_summary" Width="100%" TextMode="MultiLine" Rows="6"></cc1:UcTextBox>
        </td>
    </tr>
</table>
