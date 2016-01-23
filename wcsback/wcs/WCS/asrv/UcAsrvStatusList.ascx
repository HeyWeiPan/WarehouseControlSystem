<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcAsrvStatusList.ascx.cs" Inherits="WCS_asrv_UcAsrvStatusList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<cc1:UcGridView ID="GrdList" runat="server" DataKeyNames="asrv_id" AutoGenerateColumns="False"
    Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="status_code">
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["status_code"])%>
            </ItemTemplate>
            <FooterStyle Width="30%" HorizontalAlign="Left" />
            <ItemStyle Width="30%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="status_value">
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["status_value"])%>
            </ItemTemplate>
            <ItemStyle Width="30%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="status_sync_date">

            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["status_sync_date"])%>
            </ItemTemplate>

            <FooterStyle Width="30%" HorizontalAlign="Left" />
            <ItemStyle Width="30%" HorizontalAlign="Left" />
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
