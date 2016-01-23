<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcEquipmentLink.ascx.cs" Inherits="WCS_wh_UcEquipmentLink" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<cc1:UcGridView ID="GrdList" runat="server" DataKeyNames="link_id" AutoGenerateColumns="False"
    Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="seq_id">
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["seq_id"])%>
            </ItemTemplate>
            <EditItemTemplate>

                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["seq_id"])%>
            </EditItemTemplate>
            <FooterTemplate>
                <cc1:UcTextBox ID="TxtSeqId" runat="server" Width="100%" CssClass="TransparentText" ColumnName="seq_id" ReadOnly="true" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"></cc1:UcTextBox>
            </FooterTemplate>
            <FooterStyle Width="10%" HorizontalAlign="Left" />
            <ItemStyle Width="10%" HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="equipment_name">
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["equipment_name"])%>
            </ItemTemplate>
            <EditItemTemplate>

                <cc1:UcDropDownList ID="DdlEquipment" runat="server" Width="100%" RequiredField="true" ColumnName="equipment_id"></cc1:UcDropDownList>
            </EditItemTemplate>
            <FooterTemplate>
                <cc1:UcDropDownList ID="DdlEquipment" runat="server" Width="100%" RequiredField="true" ColumnName="equipment_id"></cc1:UcDropDownList>
            </FooterTemplate>
            <FooterStyle Width="80%" HorizontalAlign="Left" />
            <ItemStyle Width="80%" HorizontalAlign="Left" />
            <HeaderStyle Width="80%" HorizontalAlign="Center" />
        </asp:TemplateField>

    </Columns>
</cc1:UcGridView>
