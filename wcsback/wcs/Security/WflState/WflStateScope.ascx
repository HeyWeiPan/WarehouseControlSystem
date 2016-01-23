<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WflStateScope.ascx.cs" Inherits="Security_WflState_WflStateScope" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib" TagPrefix="cc1" %>
<table id="tabMain" width="100%" style="table-layout: fixed;
    height: 100%;" cellpadding="0" cellspacing="0">
    <colgroup>
        <col align="left" width="30%" />
        <col align="left" width="60%" />
        <col align="left" width="10%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="L1" runat="server" ColumnName="state_id" Width="100%"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtStateId" runat="server" ColumnName="state_id" DbDataType="Int32" Width="100%"
                SearchFormat="{0} in (select state_id from wfl_state where state_id = '{1}')" TableName="wfl_state"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel1" runat="server" ColumnName="state_code" Width="100%"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="UcTextBox1" runat="server" ColumnName="state_code"  Width="100%"
                SearchFormat="{0} in (select state_id from wfl_state where state_code like '%{1}%')" TableName="wfl_state"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel2" runat="server" ColumnName="state_name_cn" Width="100%"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="UcTextBox2" runat="server" ColumnName="state_name_cn"  Width="100%"
                 SearchFormat="{0} in (select state_id from wfl_state where state_name_cn like '%{1}%')" TableName="wfl_state"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel3" runat="server" ColumnName="state_name_en" Width="100%"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="UcTextBox3" runat="server" ColumnName="state_name_en"  Width="100%"
                SearchFormat="{0} in (select state_id from wfl_state where state_name_en like '%{1}%')" TableName="wfl_state"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel4" runat="server" ColumnName="role_id" Width="100%"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="UcTextBox4" runat="server" ColumnName="role_id"  Width="100%"
                SearchFormat="{0} in (select state_id from wfl_state where role_id = '{1}')" TableName="wfl_state"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel5" runat="server" ColumnName="assignto_function" Width="100%"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="UcTextBox5" runat="server" ColumnName="assignto_function"  Width="100%"
                SearchFormat="{0} in (select state_id from wfl_state where assignto_function like '%{1}%')" TableName="wfl_state"></cc1:UcTextBox>
        </td>
    </tr>
</table>