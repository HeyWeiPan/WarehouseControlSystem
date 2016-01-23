<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcEquipmentList.ascx.cs" Inherits="WCS_wh_UcEquipmentList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<cc1:UcGridView ID="GrdList" runat="server" DataKeyNames="equipment_id" AutoGenerateColumns="False"
    Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="equipment_type_name">
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["equipment_type_name"])%>
            </ItemTemplate>
            <FooterStyle Width="10%" HorizontalAlign="Left" />
            <ItemStyle Width="10%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="equipment_code">
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["equipment_code"])%>
            </ItemTemplate>
            <FooterStyle Width="10%" HorizontalAlign="Left" />
            <ItemStyle Width="10%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="equipment_name">
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["equipment_name"])%>
            </ItemTemplate>
            <FooterStyle Width="20%" HorizontalAlign="Left" />
            <ItemStyle Width="20%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="equipment_model">
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["equipment_model"])%>
            </ItemTemplate>
            <FooterStyle Width="10%" HorizontalAlign="Left" />
            <ItemStyle Width="10%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="x_num">
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["x_num"])%>
            </ItemTemplate>
            <FooterStyle Width="10%" HorizontalAlign="Left" />
            <ItemStyle Width="10%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="y_num">
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["y_num"])%>
            </ItemTemplate>
            <FooterStyle Width="10%" HorizontalAlign="Left" />
            <ItemStyle Width="10%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="floor_num">
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["floor_num"])%>
            </ItemTemplate>
            <FooterStyle Width="10%" HorizontalAlign="Left" />
            <ItemStyle Width="10%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="enable_flag">

            <ItemTemplate>
                <cc1:UcCheckBox ID="Chk3" runat="server" Width="100%" ColumnName="enable_flag" Checked='<%# Fn.ToBoolean(((DataRowView)Container.DataItem).Row["enable_flag"]) %>'
                    Enabled="false" />
            </ItemTemplate>

            <FooterStyle Width="10%" HorizontalAlign="Left" />
            <ItemStyle Width="10%" HorizontalAlign="Left" />
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
