<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcUserPositionTransferList.ascx.cs"
    Inherits="HR_UserProfile_UcUserPositionTransferList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Src="UcUserPositionTransferRow.ascx" TagName="UcUserPositionTransferRow"
    TagPrefix="uc1" %>
<cc1:UcGridView ID="GrdPosTranList" runat="server" AutoGenerateColumns="False"
    OnClientRowDblClick="" Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="hr_user_team_history">
            <edititemtemplate>
                <uc1:UcUserPositionTransferRow id="UcUserPosTran1" runat="server"></uc1:UcUserPositionTransferRow>                                    
            </edititemtemplate>
            <footertemplate>
                <uc1:UcUserPositionTransferRow id="UcUserPosTran2" runat="server"></uc1:UcUserPositionTransferRow>                                    
            </footertemplate>
            <itemtemplate>
                <uc1:UcUserPositionTransferRow id="UcUserPosTran3" runat="server"></uc1:UcUserPositionTransferRow>                                    
            </itemtemplate>
            <headerstyle horizontalalign="Left" />
        </asp:TemplateField>        
    </Columns>
    <RowStyle BackColor="#EBF2FC" />
    <EditRowStyle BackColor="#EBF2FC" />
    <AlternatingRowStyle BackColor="#EBF2FC" />
</cc1:UcGridView>
