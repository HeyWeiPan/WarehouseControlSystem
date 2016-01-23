<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcWorkSkilScope.ascx.cs"
    Inherits="HR_Setup_UcWorkSkilScope" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
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
        <col align="left" width="30%" />
        <col align="left" width="60%" />
        <col align="left" width="10%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="L1" ColumnName="workskill_category_code" runat="server"></cc1:UcLabel></td>
        <td>
            <cc1:UcDropDownList ID="DdlWsCode" runat="server" Width="100%" DataTextField="workskill_category_name"
                DataValueField="workskill_category_code" IsInsertItem="true" AutoBindData="true"
                AllowCache="true" ColumnName="workskill_category_code" OnClientChange="setWorkSkillList(this.options(this.selectedIndex).value);return false;"
                SqlText="select workskill_category_code,workskill_category_name from hr_workskill_category order by workskill_category_code">
            </cc1:UcDropDownList>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L20" ColumnName="workskill_name" runat="server"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcDropDownList ID="DdlWorkSkill" runat="server" Width="100%" DataTextField="workskill_name"
                ColumnName="workskill_id" DataValueField="workskill_id" IsInsertItem="true" AutoBindData="false">
            </cc1:UcDropDownList>
        </td>
        <td>
        </td>
    </tr>
</table>
