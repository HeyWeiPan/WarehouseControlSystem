﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcWCSStatus.ascx.cs" Inherits="WCS_wh_UcWCSStatus" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<cc1:UcGridView ID="GrdList" runat="server" DataKeyNames="status_id" AutoGenerateColumns="False"
    Width="800px">
    <Columns>
        <asp:TemplateField HeaderText="status_code">
            <EditItemTemplate>
                <cc1:UcTextBox ID="TxtLiftCode" runat="server" ColumnName="status_code"
                    Width="100%" RequiredField="true"></cc1:UcTextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["status_code"])%>
            </ItemTemplate>
            <FooterTemplate>
                <cc1:UcTextBox ID="TxtLiftCode" runat="server" ColumnName="status_code"
                    Width="100%" RequiredField="true"></cc1:UcTextBox>
            </FooterTemplate>
            <FooterStyle Width="30%" HorizontalAlign="Left" />
            <ItemStyle Width="30%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="status_name">
            <EditItemTemplate>
                <cc1:UcTextBox ID="TxtName" runat="server" ColumnName="status_name"
                    Width="100%" RequiredField="true"></cc1:UcTextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["status_name"])%>
            </ItemTemplate>
            <FooterTemplate>
                <cc1:UcTextBox ID="TxtName" runat="server" ColumnName="status_name"
                    Width="100%" RequiredField="true"></cc1:UcTextBox>
            </FooterTemplate>
            <FooterStyle Width="30%" HorizontalAlign="Left" />
            <ItemStyle Width="30%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="show_order">
            <EditItemTemplate>
                <cc1:UcTextBox ID="TxtShowOrder" runat="server" ColumnName="show_order"
                    Width="100%" RequiredField="true" DbDataType="Int32"></cc1:UcTextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["show_order"])%>
            </ItemTemplate>
            <FooterTemplate>
                <cc1:UcTextBox ID="TxtShowOrder" runat="server" ColumnName="show_order"
                    Width="100%" RequiredField="true" DbDataType="Int32"></cc1:UcTextBox>
            </FooterTemplate>
            <FooterStyle Width="20%" HorizontalAlign="Left" />
            <ItemStyle Width="20%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="enable_flag">
            <FooterStyle Width="10%" HorizontalAlign="Center" />
            <ItemStyle Width="10%" HorizontalAlign="Center" />
            <EditItemTemplate>
                <cc1:UcCheckBox ID="Chk1" runat="server" Width="100%" ColumnName="enable_flag" Checked='<%# Fn.ToBoolean(((DataRowView)Container.DataItem).Row["enable_flag"]) %>' />
            </EditItemTemplate>
            <FooterTemplate>
                <cc1:UcCheckBox ID="Chk2" runat="server" Width="100%" ColumnName="enable_flag" Enabled="false" />
            </FooterTemplate>
            <ItemTemplate>
                <cc1:UcCheckBox ID="Chk3" runat="server" Width="100%" ColumnName="enable_flag" Checked='<%# Fn.ToBoolean(((DataRowView)Container.DataItem).Row["enable_flag"]) %>'
                    Enabled="false" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
