<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserLeave.ascx.cs" Inherits="HR_UserProfile_UcUserLeave" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Src="UcUserLeaveRow.ascx" TagName="UcUserLeaveRow" TagPrefix="uc1" %>
<cc1:UcGridView ID="GrdLeaveList" runat="server" AutoGenerateColumns="False"
    OnClientRowDblClick="" Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="hr_leave_form">
            <edititemtemplate>
                <uc1:UcUserLeaveRow id="UcUserLeaveRow1" runat="server"></uc1:UcUserLeaveRow>                                    
            </edititemtemplate>
            <footertemplate>
                <uc1:UcUserLeaveRow id="UcUserLeaveRow2" runat="server"></uc1:UcUserLeaveRow>                                    
            </footertemplate>
            <itemtemplate>
                <uc1:UcUserLeaveRow id="UcUserLeaveRow3" runat="server"></uc1:UcUserLeaveRow>                                    
            </itemtemplate>
            <headerstyle horizontalalign="Left" />
        </asp:TemplateField>
    </Columns>
    <RowStyle BackColor="#EBF2FC" />
    <EditRowStyle BackColor="#EBF2FC" />
    <AlternatingRowStyle BackColor="#EBF2FC" />
</cc1:UcGridView>