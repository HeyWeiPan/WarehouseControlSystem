<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcJobStructureScope.ascx.cs"
    Inherits="HR_Setup_UcJobStructureScope" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
    <Services>
        <asp:ServiceReference Path="../WsHR.asmx" />
    </Services>
</asp:ScriptManager>

<script type="text/javascript">        
    function setWorkSkillList(wsCode){
        WsHR.GetWorkSkillXml(wsCode,onSetWorkSkillList,f_wserror);
    }    
</script>

<table id="tabMain" width="100%" style="height: 90%; table-layout: fixed;" cellpadding="0"
    cellspacing="0">
    <colgroup>
        <col width="21%" class="TdLabel" />
        <col width="32%" />
        <col width="15%" class="TdLabel" />
        <col width="31%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="L1" ColumnName="job_code" runat="server"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtJobCode" runat="server" Width="100%" ColumnName="job_code" SearchType="Like"></cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="L2" ColumnName="job_type" runat="server"></cc1:UcLabel></td>
        <td>
            <cc1:UcDropDownList ID="DdlJobType" runat="server" Width="100%" ColumnName="job_type"
                DataValueField="job_type" DataTextField="job_type" AllowCache="true" AutoBindData="true"
                IsInsertItem="true" SqlText="select distinct job_type from hr_job_structure where delete_flag = 0">
            </cc1:UcDropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L3" runat="server" ColumnName="job_function"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtJobFunction" runat="server" Width="100%" ColumnName="job_function"
                SearchType="Like"></cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="L4" runat="server" ColumnName="job_family"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtJobFamily" runat="server" Width="100%" ColumnName="job_family"
                SearchType="Like"></cc1:UcTextBox></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L5" ColumnName="job_level" runat="server"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtJobLevel" runat="server" Width="100%" ColumnName="job_level"
                SearchType="Like"></cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="L6" ColumnName="job_title" runat="server"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtJobTitle" runat="server" Width="100%" ColumnName="job_title"
                SearchType="Like"></cc1:UcTextBox></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L10" runat="server" ColumnName="primary_team_id"></cc1:UcLabel></td>
        <td colspan="3">
            <cc2:UcTreeWebComboHRTeam ID="TVListTeam" runat="server" Width="99%" ColumnName="job_code"
                SearchFormat="{0} in (select job_code from hr_user u,hr_rpt_team_user r where u.user_id = r.user_id and u.delete_flag = 0 and u.enable_flag = -1 and r.team_id ={1})"
                SearchType="Custom" />
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L8" ColumnName="workskill_category_code" runat="server"></cc1:UcLabel></td>
        <td colspan="3">
            <cc1:UcDropDownList ID="DdlWsCode" runat="server" Width="60%" DataTextField="workskill_category_name"
                DataValueField="workskill_category_code" IsInsertItem="true" AutoBindData="true"
                SearchFormat="{0} in (select job_structure_id from hr_job_structure_workskill a,hr_workskill b where workskill_category_code = '{1}' and a.workskill_id = b.workskill_id)"
                SqlText="select workskill_category_code,workskill_category_name from hr_workskill_category order by workskill_category_code"
                AllowCache="true" ColumnName="job_structure_id" SearchType="Custom" OnClientChange="setWorkSkillList(this.options(this.selectedIndex).value);return false;">
            </cc1:UcDropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L20" ColumnName="workskill_name" runat="server"></cc1:UcLabel>
        </td>
        <td colspan="3">
            <cc1:UcDropDownList ID="DdlWorkSkill" runat="server" Width="60%" DataTextField="workskill_name"
                DataValueField="workskill_id" IsInsertItem="true" AutoBindData="true" AllowCache="true"
                SearchType="Custom" SearchFormat="{0} in (select job_structure_id from hr_job_structure_workskill where workskill_id = '{1}')"
                ColumnName="job_structure_id">
            </cc1:UcDropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L9" runat="server" ColumnName="job_users"></cc1:UcLabel></td>
        <td colspan="3">
            <cc1:UcLabel ID="L91" runat="server" ColumnName="From"></cc1:UcLabel>
            <cc1:UcTextBox ID="T91" runat="server" SearchType="Custom" SearchFormat="hr.GetJobUsers({0}) >= {1}"
                DbDataType="int32" ColumnName="job_code" Width="150px"></cc1:UcTextBox>
            <cc1:UcLabel ID="L92" runat="server" ColumnName="To"></cc1:UcLabel>
            <cc1:UcTextBox ID="T92" runat="server" SearchType="Custom" SearchFormat="hr.GetJobUsers({0}) <= {1}"
                DbDataType="int32" ColumnName="job_code" Width="150px"></cc1:UcTextBox></td>
    </tr>
</table>
