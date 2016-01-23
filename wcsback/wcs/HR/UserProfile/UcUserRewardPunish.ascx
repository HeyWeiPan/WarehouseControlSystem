<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserRewardPunish.ascx.cs" Inherits="HR_UserProfile_UcUserRewardPunish" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Src="UcUserRewardPunishRow.ascx" TagName="UcUserRewardPunishRow"
    TagPrefix="uc1" %>
<cc1:UcGridView ID="GrdList" runat="server" AutoGenerateColumns="False"
    OnClientRowDblClick="" Width="100%">
    <Columns>
        <asp:TemplateField>
            <edititemtemplate>
                <uc1:UcUserRewardPunishRow id="U1" runat="server"></uc1:UcUserRewardPunishRow>                                    
            </edititemtemplate>
            <footertemplate>
                <uc1:UcUserRewardPunishRow id="U2" runat="server"></uc1:UcUserRewardPunishRow>                                    
            </footertemplate>
            <itemtemplate>
                <uc1:UcUserRewardPunishRow id="U3" runat="server"></uc1:UcUserRewardPunishRow>                                    
            </itemtemplate>
            <headerstyle horizontalalign="Left" />
        </asp:TemplateField>
    </Columns>
    <RowStyle BackColor="#EBF2FC" />
    <EditRowStyle BackColor="#EBF2FC" />
    <AlternatingRowStyle BackColor="#EBF2FC" />
</cc1:UcGridView>
