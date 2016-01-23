<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcCostCenterList.ascx.cs"
    Inherits="HR_Setup_UcCostCenterList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<cc1:UcGridView ID="GrdList" runat="server" DataKeyNames="seq_id" AutoGenerateColumns="False"
    Width="80%">
    <Columns>
        <asp:TemplateField HeaderText="costcenter_code">
            <footertemplate>  
                 <cc1:UcTextBox ID="T1" runat="server" ColumnName="costcenter_code" DbDataType="String" RequiredField="true" Width="100%"></cc1:UcTextBox>            
            </footertemplate>
            <itemtemplate>
                 <%# DataBinder.Eval(Container.DataItem, "costcenter_code") %>
            </itemtemplate>
            <edititemtemplate>  
                 <cc1:UcTextBox ID="T2" Text='<%# DataBinder.Eval(Container.DataItem, "costcenter_code") %>' runat="server" ColumnName="costcenter_code" DbDataType="String" RequiredField="true" Width="100%"></cc1:UcTextBox>            
            </edititemtemplate>
            <itemstyle width="15%" />
            <footerstyle width="15%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="costcenter_name">
            <footertemplate>  
                 <cc1:UcTextBox ID="T3" runat="server" ColumnName="costcenter_name" DbDataType="String" RequiredField="true" Width="100%"></cc1:UcTextBox>            
            </footertemplate>
            <itemtemplate>
                 <%# DataBinder.Eval(Container.DataItem, "costcenter_name") %>
            </itemtemplate>
            <edititemtemplate>  
                 <cc1:UcTextBox ID="T4" Text='<%# DataBinder.Eval(Container.DataItem, "costcenter_name") %>' runat="server" ColumnName="costcenter_name" DbDataType="String" RequiredField="true" Width="100%"></cc1:UcTextBox>            
            </edititemtemplate>
            <itemstyle width="57%" />
            <footerstyle width="57%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="enable_flag">
            <itemstyle width="13%" />
            <footerstyle width="13%" />
            <itemtemplate>
                 <cc1:UcCheckBox id="Ch1" ColumnName="enable_flag" Checked='<%# Fn.ToBoolean(((DataRowView)Container.DataItem).Row["enable_flag"]) %>' Enabled="false" runat="server" />
            </itemtemplate>
            <edititemtemplate>  
                  <cc1:UcCheckBox id="Ch2"  ColumnName="enable_flag"  Checked='<%# Fn.ToBoolean(((DataRowView)Container.DataItem).Row["enable_flag"]) %>' runat="server"/>         
            </edititemtemplate>
            <footertemplate>  
                 <cc1:UcCheckBox id="Ch3"  ColumnName="enable_flag"  Checked="true" runat="server"/>         
            </footertemplate>
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
