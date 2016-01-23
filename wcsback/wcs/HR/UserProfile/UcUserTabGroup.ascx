<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserTabGroup.ascx.cs"
    Inherits="HR_UserProfile_UcUserTabGroup" %>
<%@ Register Src="UcUserWorkExpand.ascx" TagName="UcUserWorkExpand" TagPrefix="uc8" %>
<%@ Register Src="UcUserPay.ascx" TagName="UcUserPay" TagPrefix="uc7" %>
<%@ Register Src="UcUserContractInfo.ascx" TagName="UcUserContractInfo" TagPrefix="uc6" %>
<%@ Register Src="UcUserSalary.ascx" TagName="UcUserSalary" TagPrefix="uc1" %>
<%@ Register Src="UcUserJob.ascx" TagName="UcUserJob" TagPrefix="uc5" %>
<%@ Register Src="UcUserFamilyInfo.ascx" TagName="UcUserFamilyInfo" TagPrefix="uc4" %>
<%@ Register Src="UcUserContact.ascx" TagName="UcUserContact" TagPrefix="uc2" %>
<%@ Register Src="UcUserPersonalInfo.ascx" TagName="UcUserPersonalInfo" TagPrefix="uc3" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<table style="width: 100%; display: inline; table-layout: fixed;" cellpadding="0"
    cellspacing="0">
    <tr valign="top" align="left">
        <td style="height: 20px">
            <cc1:UcHyperLink ID="LnkUserContact" runat="server" ColumnName="TabContact" ShowStyle="TabBlue"
                Target="IfraSubWindow"></cc1:UcHyperLink>
            <cc1:UcHyperLink ID="LnkUserPersonal" runat="server" ColumnName="TabPersonal" ShowStyle="TabWhite"
                Target="IfraSubWindow"></cc1:UcHyperLink>
            <cc1:UcHyperLink ID="LnkUserFamily" runat="server" ColumnName="TabFamily" Target="IfraSubWindow"
                ShowStyle="TabWhite"></cc1:UcHyperLink>
            <cc1:UcHyperLink ID="LnkUserWork" runat="server" ColumnName="TabWork" Target="IfraSubWindow"
                ShowStyle="TabWhite"></cc1:UcHyperLink>
            <cc1:UcHyperLink ID="LnkUserTraining" runat="server" ColumnName="TabTraining" Target="IfraSubWindow"
                ShowStyle="TabWhite"></cc1:UcHyperLink>
            <cc1:UcHyperLink ID="LnkUserEducation" runat="server" ColumnName="TabEducation" Target="IfraSubWindow"
                ShowStyle="TabWhite"></cc1:UcHyperLink>
            <cc1:UcHyperLink ID="LnkUserRewards" runat="server" ColumnName="TabRewards" Target="IfraSubWindow"
                ShowStyle="TabWhite"></cc1:UcHyperLink>
            <cc1:UcHyperLink ID="LnkUserContract" runat="server" ColumnName="TabContract" Target="IfraSubWindow"
                ShowStyle="TabWhite"></cc1:UcHyperLink>
            <cc1:UcHyperLink ID="LnkUserJob" runat="server" ColumnName="TabJob" Target="IfraSubWindow"
                ShowStyle="TabWhite"></cc1:UcHyperLink>
            <cc1:UcHyperLink ID="LnkUserSalary" runat="server" ColumnName="TabSalary" Target="IfraSubWindow"
                ShowStyle="TabWhite"></cc1:UcHyperLink>
            <cc1:UcHyperLink ID="LnkUserLeave" runat="server" ColumnName="TabLeave" Target="IfraSubWindow"
                ShowStyle="TabWhite"></cc1:UcHyperLink>
            <cc1:UcHyperLink ID="LnkUserPay" runat="server" ColumnName="TabPay" Target="IfraSubWindow"
                ShowStyle="TabWhite"></cc1:UcHyperLink>
            <cc1:UcHiddenField ID="HidSelectedTab" runat="server" RenderToClient="true"></cc1:UcHiddenField>
        </td>
    </tr>
    <tr align="left" valign="top" id="TabContact" runat="server" style="display: none;">
        <td valign="top" class="ContainerBorder" style="margin: 0,0,0,0; padding: 0,0,0,0;
            height: 150px;">
            <uc2:UcUserContact ID="UcUserContact1" runat="server"></uc2:UcUserContact>
        </td>
    </tr>
    <tr align="left" valign="top" id="TabPersonal" runat="server" style="display: none;">
        <td valign="top" class="ContainerBorder" style="margin: 0,0,0,0; padding: 0,0,0,0;
            height: 210px;">
            <uc3:UcUserPersonalInfo ID="UcUserPersonalInfo1" runat="server"></uc3:UcUserPersonalInfo>
        </td>
    </tr>
    <tr align="left" valign="top" id="TabFamily" runat="server" style="display: none;">
        <td valign="top" class="ContainerBorder" style="margin: 0,0,0,0; padding: 0,0,0,0;
            height: 110px;">
            <uc4:UcUserFamilyInfo ID="UcUserFamilyInfo1" runat="server"></uc4:UcUserFamilyInfo>
        </td>
    </tr>
    <tr align="left" valign="top" id="TabJob" runat="server" style="display: none;">
        <td valign="top" class="ContainerBorder" style="margin: 0,0,0,0; padding: 0,0,0,0;
            height: 100px;">
            <uc5:UcUserJob ID="UcUserJob1" runat="server" />
        </td>
    </tr>
    <tr align="left" valign="top" id="TabSalary" runat="server" style="display: none;">
        <td valign="top" class="ContainerBorder" style="margin: 0,0,0,0; padding: 0,0,0,0;
            height: 160px;">
            <uc1:UcUserSalary ID="UcUserSalary1" runat="server" />
        </td>
    </tr>
    <tr align="left" valign="top" id="TabUserPay" runat="server" style="display: none;">
        <td valign="top" class="ContainerBorder" style="margin: 0,0,0,0; padding: 0,0,0,0;">
            <uc7:UcUserPay ID="UcUserPay1" runat="server" />
        </td>
    </tr>
    <tr align="left" valign="top" id="TabUserContract" runat="server" style="display: none;">
        <td valign="top" class="ContainerBorder" style="margin: 0,0,0,0; padding: 0,0,0,0;">
            <uc6:UcUserContractInfo ID="UcUserContractInfo1" runat="server" />
        </td>
    </tr>
    <tr align="left" valign="top" id="TabIfra" runat="server" style="display: none;">
        <td valign="top" class="ContainerBorder" style="margin: 0,0,0,0; padding: 0,0,0,0;">
            <iframe style="width: 100%; background-color: #EBF2FC;" frameborder="0" runat="server"
                scrolling="auto" name="IfraSubWindow" id="IfraSubWindow"></iframe>
        </td>
    </tr>
    <tr align="left" valign="top" id="TabWorkExpand" runat="server" style="display: none;">
        <td valign="top" class="ContainerBorder" style="margin: 0,0,0,0; padding: 0,0,0,0;">
            <uc8:UcUserWorkExpand ID="UcUserWorkExpand1" runat="server" />
        </td>
    </tr>
</table>
