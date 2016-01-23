<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcLiftList.ascx.cs" Inherits="WCS_wh_UcLiftList" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<cc1:UcGridView ID="GrdList" runat="server" DataKeyNames="lift_id" AutoGenerateColumns="False"
    Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="lift_code">
            <EditItemTemplate>
                <cc1:UcTextBox ID="TxtLiftCode" runat="server" ColumnName="lift_code"
                    Width="100%" RequiredField="true"></cc1:UcTextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["lift_code"])%>
            </ItemTemplate>
            <FooterTemplate>
                <cc1:UcTextBox ID="TxtLiftCode" runat="server" ColumnName="lift_code"
                    Width="100%" RequiredField="true"></cc1:UcTextBox>
            </FooterTemplate>
            <FooterStyle Width="30%" HorizontalAlign="Left" />
            <ItemStyle Width="30%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="x_num">
            <EditItemTemplate>
                <cc1:UcTextBox ID="TxtX" runat="server" ColumnName="x_num" DbDataType="Int32"
                    Width="100%" RequiredField="true" ></cc1:UcTextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["x_num"])%>
            </ItemTemplate>
            <FooterTemplate>
                <cc1:UcTextBox ID="TxtX" runat="server" ColumnName="x_num" DbDataType="Int32"
                    Width="100%" RequiredField="true" ></cc1:UcTextBox>
            </FooterTemplate>
            <FooterStyle Width="15%" HorizontalAlign="Left" />
            <ItemStyle Width="15%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="y_num">
            <EditItemTemplate>
                <cc1:UcTextBox ID="TxtY" runat="server" ColumnName="y_num" DbDataType="Int32"
                    Width="100%" RequiredField="true" ></cc1:UcTextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["y_num"])%>
            </ItemTemplate>
            <FooterTemplate>
                <cc1:UcTextBox ID="TxtY" runat="server" ColumnName="y_num" DbDataType="Int32"
                    Width="100%" RequiredField="true" ></cc1:UcTextBox>
            </FooterTemplate>
            <FooterStyle Width="15%" HorizontalAlign="Left" />
            <ItemStyle Width="15%" HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="description">
            <EditItemTemplate>
                <cc1:UcTextBox ID="TxtRemark" runat="server" ColumnName="description"
                    Width="100%"></cc1:UcTextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["description"])%>
            </ItemTemplate>
            <FooterTemplate>
                <cc1:UcTextBox ID="TxtRemark" runat="server" ColumnName="description"
                    Width="100%"></cc1:UcTextBox>
            </FooterTemplate>
            <FooterStyle Width="30%" HorizontalAlign="Left" />
            <ItemStyle Width="30%" HorizontalAlign="Left" />
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
