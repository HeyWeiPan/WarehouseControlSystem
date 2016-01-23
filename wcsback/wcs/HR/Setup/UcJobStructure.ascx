<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcJobStructure.ascx.cs"
    Inherits="HR_Setup_UcJobStructure" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<table style="width: 100%; display: inline; table-layout: fixed; margin: 0 0 0 0;
    padding: 0 0 0 0;" cellpadding="0" cellspacing="0">
    <colgroup>
        <col class="TdLabel" width="10%" />
        <col align="left" width="20%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="25%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="25%" />
      
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="L1" ColumnName="job_code" runat="server"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtJobCode" runat="server" Width="100%" ColumnName="job_code"
                ReadOnlyWhenInsert="false" ReadOnlyWhenUpdate="true" RequiredField="true"></cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="L2" ColumnName="job_type" runat="server"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtJobType" runat="server" Width="100%" ColumnName="job_type"
                RequiredField="true"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L3" runat="server" ColumnName="job_function"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtJobFunction" runat="server" Width="100%" ColumnName="job_function"
                RequiredField="true"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L4" runat="server" ColumnName="job_family"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtJobFamily" runat="server" Width="100%" ColumnName="job_family"
                RequiredField="true"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L6" ColumnName="job_title" runat="server"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtJobTitle" runat="server" Width="100%" ColumnName="job_title"
                RequiredField="true"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L5" ColumnName="job_level" runat="server"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtJobLevel" runat="server" Width="100%" ColumnName="job_level"
                RequiredField="true"></cc1:UcTextBox>
        </td>
        
    </tr>  
</table>
