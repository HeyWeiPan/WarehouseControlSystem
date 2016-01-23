<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterSetupDetail.master"
    AutoEventWireup="false" CodeFile="WorkSkillDetail.aspx.cs" Inherits="HR_Setup_WorkSkillDetail"
    Title="Untitled Page" %>

<%@ Register Src="UcWorkSkillLevel.ascx" TagName="UcWorkSkillLevel" TagPrefix="uc2" %>
<%@ Register Src="UcWorkSkill.ascx" TagName="UcWorkSkill" TagPrefix="uc1" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <uc1:UcWorkSkill ID="UcWorkSkill1" runat="server" />
    <table style="width: 100%; table-layout: fixed; margin: 0,0,0,0; padding: 0,0,0,0;
        border: 0 0 0 0;" cellpadding="0" cellspacing="0" id="TabLevel" runat="server"
        visible="false">
        <tr style="height: 20px;">
            <td>
                <cc1:UcHyperLink ID="Lnk" runat="server" ShowStyle="TabBlue" ColumnName="TabLevel"
                    Width="130px"></cc1:UcHyperLink>
            </td>
        </tr>
        <tr>
            <td valign="top" class="ContainerBorder" style="margin: 0,0,0,0; padding: 0,0,0,0;">
                <uc2:UcWorkSkillLevel ID="UcWorkSkillLevel1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
