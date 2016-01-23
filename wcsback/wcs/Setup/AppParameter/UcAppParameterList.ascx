<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcAppParameterList.ascx.cs"
    Inherits="Setup_AppParameter_AppParameterList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<cc1:UcGridView ID="GrdParameterList" Width="100%" runat="server" AutoGenerateColumns="False" 
    AutoSetHeaderText="True" UseHTCBehavior="True">
    <Columns>
        <asp:TemplateField HeaderText="description">
            <HeaderStyle Width="40%" />
            <ItemStyle Width="40%" />
            <ItemTemplate>
                <%# ((DataRowView)Container.DataItem).Row["description"]%>
            </ItemTemplate>
            <EditItemTemplate>
                <%# ((DataRowView)Container.DataItem).Row["description"]%>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="data_text">
            <HeaderStyle Width="40%" />
            <ItemStyle Width="40%" />
            <ItemTemplate>
                <%# ((DataRowView)Container.DataItem).Row["data_text"]%>
            </ItemTemplate>
            <EditItemTemplate>
                <cc1:UcTextBox ID="TxtDataText" runat="server" ColumnName="data_text" DbDataType="String"
                    RequiredField="false" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem, "data_text") %>'></cc1:UcTextBox>
            </EditItemTemplate>
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
