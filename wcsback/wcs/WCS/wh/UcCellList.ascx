<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcCellList.ascx.cs" Inherits="WCS_wh_UcCellList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<cc1:UcGridView ID="GrdList" runat="server" DataKeyNames="cell_id" AutoGenerateColumns="False"
    Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="cell_num">
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["cell_num"])%>
            </ItemTemplate>
            <ItemStyle Width="20%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="floor_num">
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["floor_num"])%>
            </ItemTemplate>
            <ItemStyle Width="20%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="celltype_code">
            <EditItemTemplate>
                <cc1:UcDropDownList ID="DdlCellType" runat="server" Width="100%" RequiredField="true" SqlText="select celltype_code,celltype_name from wcs_celltype order by show_order " DataValueField="celltype_code" DataTextField="celltype_name" ColumnName="celltype_code" IsInsertItem="true" AutoBindData="true"></cc1:UcDropDownList>
            </EditItemTemplate>
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["celltype_name"])%>
            </ItemTemplate>
            <FooterTemplate>
                <cc1:UcDropDownList ID="DdlCellType" runat="server" Width="100%"  RequiredField="true" SqlText="select celltype_code,celltype_name from wcs_celltype order by show_order " DataValueField="celltype_code" DataTextField="celltype_name" ColumnName="celltype_code" IsInsertItem="true" AutoBindData="true"></cc1:UcDropDownList>
            </FooterTemplate>
            <ItemStyle Width="20%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="x_num">
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["x_num"])%>
            </ItemTemplate>
            <ItemStyle Width="15%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="y_num">
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["y_num"])%>
            </ItemTemplate>
            <ItemStyle Width="15%" HorizontalAlign="Left" />
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
