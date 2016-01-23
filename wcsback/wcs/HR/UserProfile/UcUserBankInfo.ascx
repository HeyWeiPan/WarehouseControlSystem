<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcUserBankInfo.ascx.cs"
    Inherits="HR_UserProfile_UcUserBankInfo" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Src="UcUserBankInfoRow.ascx" TagName="UcUserBankInfoRow" TagPrefix="uc1" %>
<cc1:UcGridView ID="GrdBankInfoList" runat="server" AutoGenerateColumns="False" 
    Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="hr_user_bankinfo">
            <edititemtemplate>
                <uc1:UcUserBankInfoRow id="UcUserBankInfoRow1" runat="server"></uc1:UcUserBankInfoRow>                                    
            </edititemtemplate>
            <footertemplate>
                <uc1:UcUserBankInfoRow id="UcUserBankInfoRow2" runat="server"></uc1:UcUserBankInfoRow>                                    
            </footertemplate>
            <itemtemplate>
                <uc1:UcUserBankInfoRow id="UcUserBankInfoRow3" runat="server"></uc1:UcUserBankInfoRow>                                    
            </itemtemplate>
            <headerstyle horizontalalign="Left" />
        </asp:TemplateField>
    </Columns>
    <RowStyle BackColor="#EBF2FC" />
    <EditRowStyle BackColor="#EBF2FC" />
    <AlternatingRowStyle BackColor="#EBF2FC" />
</cc1:UcGridView>
