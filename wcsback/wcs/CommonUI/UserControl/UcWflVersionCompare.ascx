<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcWflVersionCompare.ascx.cs"
    Inherits="CommonUI_UserControl_UcWflVersionCompare" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<table style="width: 700px; table-layout: fixed;" cellpadding="0" cellspacing="0">
    <tr>
        <td align="right">
            <cc1:UcLabel ID="Uc1" runat="server" ColumnName="Current_Version" /></td>
        <td>
            <cc1:UcHyperLink ID="LnkCurrentVersion" runat="server" />
        </td>
        <td align="right">
            <cc1:UcLabel ID="UcLabel1" runat="server" ColumnName="Previous_Version" /></td>
        <td>
            <cc1:UcHyperLink ID="LnkPreviousVersion" runat="server" />
        </td>
    </tr>
</table>
<cc1:UcGridView ID="GrdList" runat="server" AutoGenerateColumns="False" Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="Column_Name">
            <itemstyle width="20%" wrap="true" />
            <itemtemplate>              
                    <span><%# GetColumnName(((DataRowView)Container.DataItem).Row["Column_Name"])%></span>                                    
                </itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Previous_Version_Description">
            <itemstyle width="35%" wrap="true" />
            <itemtemplate>              
                    <span><%# Fn.ToString(((DataRowView)Container.DataItem).Row["Previous_Version_Description"]).Replace("\r", "<br>") %></span>                                       
                </itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Current_Version_Description">
            <itemstyle width="35%" wrap="true" />
            <itemtemplate>              
                    <span><%# Fn.ToString(((DataRowView)Container.DataItem).Row["Current_Version_Description"]).Replace("\r", "<br>") %></span>                                       
                </itemtemplate>
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
<table style="width: 100%; table-layout: fixed;" cellpadding="0" cellspacing="0">
    <tr align="right">
        <td>
            <cc1:UcLinkButton ID="LnkShowAllModification" runat="server" OnClick="LnkShowAllModification_Click"
                ColumnName="Show_All_Modification"></cc1:UcLinkButton>
        </td>
    </tr>
</table>
<asp:DataList ID="LstVersionComparer" runat="server" Width="100%">
    <ItemTemplate>
        <table style="width: 700px; table-layout: fixed;" cellpadding="0" cellspacing="0">
            <tr>
                <td align="right">
                    <cc1:UcLabel ID="LabCurrentVersion" runat="server" ColumnName="Current_Version"></cc1:UcLabel></td>
                <td>
                    <cc1:UcHyperLink ID="LnkCurrentVersion" runat="server"></cc1:UcHyperLink>
                </td>
                <td align="right">
                    <cc1:UcLabel ID="LabPreviousVersion" runat="server" ColumnName="Previous_Version"></cc1:UcLabel></td>
                <td>
                    <cc1:UcHyperLink ID="LnkPreviousVersion" runat="server"></cc1:UcHyperLink>
                </td>
            </tr>
        </table>
        <cc1:UcGridView ID="GrdList" runat="server" AutoGenerateColumns="False" Width="100%"
            EnableViewState="false">
            <Columns>
                <asp:TemplateField HeaderText="Column_Name">
                    <itemstyle width="20%" wrap="true" />
                    <itemtemplate>              
                            <span><%# GetColumnName(((DataRowView)Container.DataItem).Row["Column_Name"])%></span>                               
                        </itemtemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="Previous_Version_Description">
                    <itemstyle width="35%" wrap="true" />
                    <itemtemplate>              
                            <span><%# Fn.ToString(DataBinder.Eval(Container.DataItem, "Previous_Version_Description")).Replace("\r", "<br>")%></span>                                       
                        </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Current_Version_Description">
                    <itemstyle width="35%" wrap="true" />
                    <itemtemplate>              
                            <span><%# Fn.ToString(DataBinder.Eval(Container.DataItem, "Current_Version_Description")).Replace("\r", "<br>")%></span>                                       
                        </itemtemplate>
                </asp:TemplateField>
            </Columns>
        </cc1:UcGridView>
        <br />
    </ItemTemplate>
</asp:DataList>