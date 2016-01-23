<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserDimission.ascx.cs"
    Inherits="HR_UserProfile_UcUserDimission" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Src="UcUserDimissionRow.ascx" TagName="UcUserDimissionRow" TagPrefix="uc1" %>
<cc1:UcGridView ID="GrdList" runat="server" AutoGenerateColumns="False" OnClientRowDblClick=""
    Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="hr_user_leave">
            <edititemtemplate>
                <uc1:UcUserDimissionRow id="UcUserDimissionRow1" runat="server"></uc1:UcUserDimissionRow>                                    
            </edititemtemplate>
            <footertemplate>
                <uc1:UcUserDimissionRow id="UcUserDimissionRow2" runat="server"></uc1:UcUserDimissionRow>                                    
            </footertemplate>
            <itemtemplate>
                <uc1:UcUserDimissionRow id="UcUserDimissionRow3" runat="server"></uc1:UcUserDimissionRow>                                    
            </itemtemplate>
            <headerstyle horizontalalign="Left" />
        </asp:TemplateField>
    </Columns>
    <RowStyle BackColor="#EBF2FC" />
    <EditRowStyle BackColor="#EBF2FC" />
    <AlternatingRowStyle BackColor="#EBF2FC" />
</cc1:UcGridView>
