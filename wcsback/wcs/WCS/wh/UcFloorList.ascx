<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcFloorList.ascx.cs" Inherits="WCS_wh_UcFloorList" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<cc1:UcGridView ID="GrdList" runat="server" DataKeyNames="floor_id" AutoGenerateColumns="False"
    Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="floor_num">
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["floor_num"])%>
            </ItemTemplate>
            <FooterStyle Width="30%" HorizontalAlign="Left" />
            <ItemStyle Width="30%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="floor_code">
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["floor_code"])%>
            </ItemTemplate>
            <ItemStyle Width="30%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="floor_description">

            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["floor_description"])%>
            </ItemTemplate>

            <FooterStyle Width="30%" HorizontalAlign="Left" />
            <ItemStyle Width="30%" HorizontalAlign="Left" />
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
