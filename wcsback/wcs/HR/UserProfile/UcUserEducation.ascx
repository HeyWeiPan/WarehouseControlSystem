<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserEducation.ascx.cs"
    Inherits="HR_UserProfile_UcUserEducation" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Src="UcUserEducationRow.ascx" TagName="UcUserEducationRow" TagPrefix="uc1" %>
<cc1:UcGridView ID="GrdEducationList" runat="server" AutoGenerateColumns="False"
    OnClientRowDblClick="" Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="hr_user_education">
            <edititemtemplate>
                <uc1:UcUserEducationRow id="UcUserEducationRow1" runat="server"></uc1:UcUserEducationRow>                                    
            </edititemtemplate>
            <footertemplate>
                <uc1:UcUserEducationRow id="UcUserEducationRow2" runat="server"></uc1:UcUserEducationRow>                                    
            </footertemplate>
            <itemtemplate>
                <uc1:UcUserEducationRow id="UcUserEducationRow3" runat="server"></uc1:UcUserEducationRow>                                    
            </itemtemplate>
            <headerstyle horizontalalign="Left" />
        </asp:TemplateField>
    </Columns>
    <RowStyle BackColor="#EBF2FC" />
    <EditRowStyle BackColor="#EBF2FC" />
    <AlternatingRowStyle BackColor="#EBF2FC" />
</cc1:UcGridView>
