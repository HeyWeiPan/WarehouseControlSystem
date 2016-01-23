<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterSetupDetail.master"
    AutoEventWireup="false" CodeFile="JobStructureDetail.aspx.cs" Inherits="HR_Setup_JobStructureDetail"
    Title="Untitled Page" %>

<%@ Register Src="UcJDSummary.ascx" TagName="UcJDSummary" TagPrefix="uc3" %>
<%@ Register Src="UcJobStructurePay.ascx" TagName="UcJobStructurePay" TagPrefix="uc2" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="UcJobStructure.ascx" TagName="UcJobStructure" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <uc1:UcJobStructure ID="UcJobStructure1" runat="server" />
    <table style="width: 100%; table-layout: fixed; margin: 0,0,0,0; padding: 0,0,0,0;
        border: 0 0 0 0;" cellpadding="0" cellspacing="0">
        <tr style="height: 20px;">
            <td>
                <cc1:UcHyperLink ID="LnkUser" runat="server" ColumnName="TabUser" Target="IfraSubWindow"
                    ShowStyle="TabBlue"></cc1:UcHyperLink>
                <cc1:UcHyperLink ID="LnkResponsibility" runat="server" ColumnName="TabResponsibility"
                    Target="IfraSubWindow" ShowStyle="TabWhite"></cc1:UcHyperLink>
                <cc1:UcHyperLink ID="LnkQuality" runat="server" ColumnName="TabQuality" ShowStyle="TabWhite"
                    Target="IfraSubWindow"></cc1:UcHyperLink>
                <cc1:UcHyperLink ID="LnkKnowledge" runat="server" ColumnName="TabKnowledge" Target="IfraSubWindow"
                    ShowStyle="TabWhite"></cc1:UcHyperLink>
                <cc1:UcHyperLink ID="LnkSkill" runat="server" ColumnName="TabSkill" Target="IfraSubWindow"
                    ShowStyle="TabWhite"></cc1:UcHyperLink>
                <cc1:UcHyperLink ID="LnkJobPay" runat="server" ColumnName="TabJobPay" Target="IfraSubWindow"
                    ShowStyle="TabWhite"></cc1:UcHyperLink>
                <cc1:UcHiddenField ID="HidSelectedTab" runat="server" RenderToClient="true"></cc1:UcHiddenField>
            </td>
        </tr>
        <tr align="left" valign="top" id="TabJobPay" runat="server" style="display: none;">
            <td valign="top" class="ContainerBorder" style="margin: 0,0,0,0; padding: 0,0,0,0;
                height: 25px;">
                <uc2:UcJobStructurePay ID="UcJobStructurePay1" runat="server" />
            </td>
        </tr>
        <tr align="left" valign="top" id="TabResponsibility" runat="server" style="display: none;">
            <td valign="top" class="ContainerBorder" style="margin: 0,0,0,0; padding: 0,0,0,0;">
                <uc3:UcJDSummary ID="UcJDSummary1" runat="server" />
            </td>
        </tr>
        <tr align="left" valign="top" id="TabIfra" runat="server" style="display: inline;">
            <td valign="top" class="ContainerBorder" style="margin: 0,0,0,0; padding: 0,0,0,0;">
                <iframe style="width: 100%; background-color: #EBF2FC;" frameborder="0" runat="server"
                    scrolling="auto" name="IfraSubWindow" id="IfraSubWindow"></iframe>
            </td>
        </tr>
    </table>
</asp:Content>
