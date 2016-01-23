<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcUserWorkExperienceList.ascx.cs"
    Inherits="HR_UserProfile_UcUserWorkExperienceList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Src="UcUserWorkExperienceRow.ascx" TagName="UcUserWorkExperienceRow"
    TagPrefix="uc1" %>
<cc1:UcGridView ID="GrdWorkList" runat="server" AutoGenerateColumns="False" OnClientRowDblClick=""
    Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="hr_work_experience">
            <edititemtemplate>
                <uc1:UcUserWorkExperienceRow id="UcUserWork1" runat="server"></uc1:UcUserWorkExperienceRow>                                    
            </edititemtemplate>
            <footertemplate>
                <uc1:UcUserWorkExperienceRow id="UcUserWork2" runat="server"></uc1:UcUserWorkExperienceRow>                                    
            </footertemplate>
            <itemtemplate>
                <uc1:UcUserWorkExperienceRow id="UcUserWork3" runat="server"></uc1:UcUserWorkExperienceRow>                                    
            </itemtemplate>
            <headerstyle horizontalalign="Left" />
        </asp:TemplateField>
    </Columns>
    <RowStyle BackColor="#EBF2FC" />
    <EditRowStyle BackColor="#EBF2FC" />
    <AlternatingRowStyle BackColor="#EBF2FC" />
</cc1:UcGridView>
