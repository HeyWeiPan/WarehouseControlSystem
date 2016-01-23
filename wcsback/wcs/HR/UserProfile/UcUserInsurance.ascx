<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserInsurance.ascx.cs" Inherits="HR_UserProfile_UcUserInsurance" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Src="UcUserInsuranceRow.ascx" TagName="UcUserInsuranceRow" TagPrefix="uc1" %>
<cc1:UcGridView ID="GrdEducationList" runat="server" AutoGenerateColumns="False"
    OnClientRowDblClick="" Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="hr_user_insurance">
            <edititemtemplate>
                <uc1:UcUserInsuranceRow id="UcUserInsuranceRow1" runat="server"></uc1:UcUserInsuranceRow>                                    
            </edititemtemplate>
            <footertemplate>
                <uc1:UcUserInsuranceRow id="UcUserInsuranceRow2" runat="server"></uc1:UcUserInsuranceRow>                                    
            </footertemplate>
            <itemtemplate>
                <uc1:UcUserInsuranceRow id="UcUserInsuranceRow3" runat="server"></uc1:UcUserInsuranceRow>                                    
            </itemtemplate>
            <headerstyle horizontalalign="Left" />
        </asp:TemplateField>
    </Columns>
    <RowStyle BackColor="#EBF2FC" />
    <EditRowStyle BackColor="#EBF2FC" />
    <AlternatingRowStyle BackColor="#EBF2FC" />
</cc1:UcGridView>