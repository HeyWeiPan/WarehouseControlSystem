<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcAsrvList.ascx.cs" Inherits="WCS_wh_UcAsrvList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<cc1:UcGridView ID="GrdList" runat="server" DataKeyNames="asrv_id" AutoGenerateColumns="False"
    Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="asrv_code">
            <ItemTemplate>
                <%# Fn.ToString(((DataRowView)Container.DataItem).Row["asrv_code"])%>
            </ItemTemplate>
            <FooterStyle Width="30%" HorizontalAlign="Left" />
            <ItemStyle Width="30%" HorizontalAlign="Left" />
        </asp:TemplateField>
          <asp:TemplateField HeaderText="enable_flag">

            <ItemTemplate>
                <cc1:UcCheckBox ID="Chk3" runat="server" Width="100%" ColumnName="enable_flag" Checked='<%# Fn.ToBoolean(((DataRowView)Container.DataItem).Row["enable_flag"]) %>'
                    Enabled="false" />
            </ItemTemplate>

            <FooterStyle Width="30%" HorizontalAlign="Left" />
            <ItemStyle Width="30%" HorizontalAlign="Left" />
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
