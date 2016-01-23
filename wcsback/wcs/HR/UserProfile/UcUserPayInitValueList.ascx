<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcUserPayInitValueList.ascx.cs"
    Inherits="HR_UserProfile_UcUserPayInitValueList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<cc1:UcGridView ID="GrdList" runat="server"  AutoGenerateColumns="False"
    Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="init_item_code">
            <itemstyle width="20%" />
            <itemtemplate>                                
                <%# ((DataRowView)Container.DataItem).Row["init_item_code"]%>
            </itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="init_item_name">
            <itemstyle width="25%" />
            <itemtemplate>                                
                <%# ((DataRowView)Container.DataItem).Row["init_item_name"]%>
            </itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="init_item_value">
            <itemstyle width="15%" horizontalalign="Right"/>
            <itemtemplate>                         
                <%# string.Format("{0:N2}", Fn.ToDecimal(((DataRowView)Container.DataItem)["init_item_value"]))%>                                                         
            </itemtemplate>                   
        </asp:TemplateField>
        <asp:TemplateField HeaderText="unit_name">
            <itemstyle width="10%" />
            <itemtemplate>                
                <%# ((DataRowView)Container.DataItem).Row["unit_name"]%>                                
            </itemtemplate>
        </asp:TemplateField>        
        <asp:TemplateField HeaderText="readonly_flag">
            <itemstyle width="10%" />
            <itemtemplate>
                <cc1:UcCheckBox ID="Chk1" runat="server" Width="100%"  Checked='<%# Fn.ToBoolean(((DataRowView)Container.DataItem).Row["readonly_flag"]) %>' Enabled="false"/>
            </itemtemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="show_order">
            <itemstyle width="10%" />
            <footerstyle width="10%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["show_order"]%>
            </itemtemplate>           
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
