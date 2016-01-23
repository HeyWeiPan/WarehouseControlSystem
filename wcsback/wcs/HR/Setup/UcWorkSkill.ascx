<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcWorkSkill.ascx.cs" Inherits="HR_Setup_UcWorkSkill" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<table style="width: 100%; display: inline; table-layout: fixed; margin: 0 0 0 0;
    padding: 0 0 0 0;" cellpadding="0" cellspacing="0">
    <colgroup>
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="L1" ColumnName="workskill_number" runat="server"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtWorkSkillNumber" runat="server" Width="100%" ColumnName="workskill_number"
                RequiredField="true"></cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="L2" ColumnName="workskill_category_code" runat="server"></cc1:UcLabel></td>
        <td>
            <cc1:UcDropDownList ID="DdlWsCode" runat="server" Width="100%" DataTextField="workskill_category_name"
                DataValueField="workskill_category_code" IsInsertItem="true" AutoBindData="true"
                AllowCache="true" ColumnName="workskill_category_code" RequiredField="true" SqlText="select workskill_category_code,workskill_category_name from hr_workskill_category order by workskill_category_code">
            </cc1:UcDropDownList>
        </td>
        <td>
            <cc1:UcLabel ID="L4" ColumnName="show_order" runat="server"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="T4" runat="server" ColumnName="show_order" Width="100%"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L3" runat="server" ColumnName="workskill_name"></cc1:UcLabel></td>
        <td colspan="7">
            <cc1:UcTextBox ID="TxtWorkSkillName" runat="server" Width="100%" ColumnName="workskill_name"
                RequiredField="true"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L7" runat="server" ColumnName="skill"></cc1:UcLabel></td>
        <td colspan="7">
            <cc1:UcTextBox ID="TxtSkill" runat="server" ColumnName="skill" Width="100%" TextMode="MultiLine"
                Rows="6"></cc1:UcTextBox>
        </td>
    </tr>
</table>
