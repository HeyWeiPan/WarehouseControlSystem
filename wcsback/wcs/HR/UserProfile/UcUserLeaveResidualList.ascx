<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserLeaveResidualList.ascx.cs"
    Inherits="HR_UserProfile_UcUserLeaveResidualList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<cc1:UcGridView ID="GrdUserLeaveList" runat="server" AutoGenerateColumns="False"
    Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="period_id">
            <itemstyle width="7%" />
            <footerstyle width="7%" />
            <itemtemplate>
                <cc1:UcLabel id="L1" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["period_id"]%> ' Width="100%"></cc1:UcLabel>                 
            </itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="leave_type_code">
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["leave_type_code"]%>            
            </itemtemplate>
            <itemstyle width="25%" />            
        </asp:TemplateField>
        <asp:TemplateField HeaderText="init_days">
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["init_days"]%>            
            </itemtemplate>
            <itemstyle width="10%"  HorizontalAlign="right"/>            
        </asp:TemplateField>
        <asp:TemplateField HeaderText="residual_days">
            <itemtemplate>
                <%# ((DataRowView)Container.DataItem).Row["residual_days"]%>                                       
            </itemtemplate>
            <itemstyle width="10%"  HorizontalAlign="right"/>            
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
