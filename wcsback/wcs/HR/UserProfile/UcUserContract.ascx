<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserContract.ascx.cs"
    Inherits="HR_UserProfile_UcUserContract" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Src="UcUserContractRow.ascx" TagName="UcUserContractRow" TagPrefix="uc1" %>
<cc1:UcGridView ID="GrdContractList" runat="server" AutoGenerateColumns="False" OnClientRowDblClick=""
    Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="hr_user_Contract">
            <edititemtemplate>
                <uc1:UcUserContractRow id="UcUserContractRow1" runat="server"></uc1:UcUserContractRow>                                    
            </edititemtemplate>
            <footertemplate>
                <uc1:UcUserContractRow id="UcUserContractRow2" runat="server"></uc1:UcUserContractRow>                                    
            </footertemplate>
            <itemtemplate>
                <uc1:UcUserContractRow id="UcUserContractRow3" runat="server"></uc1:UcUserContractRow>                                    
            </itemtemplate>
            <headerstyle horizontalalign="Left" />
        </asp:TemplateField>
    </Columns>
    <RowStyle BackColor="#EBF2FC" />
    <EditRowStyle BackColor="#EBF2FC" />
    <AlternatingRowStyle BackColor="#EBF2FC" />
</cc1:UcGridView>
