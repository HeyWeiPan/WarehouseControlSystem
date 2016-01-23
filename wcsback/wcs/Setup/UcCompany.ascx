<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcCompany.ascx.cs" Inherits="Setup_UcCompany" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<cc1:UcGridView ID="GrdCompanyNameList" runat="server" DataKeyNames="company_id"
    AutoGenerateColumns="False" Width="700px">
    <Columns>
        <asp:TemplateField HeaderText="company_name">
            <footertemplate>  
                 <cc1:UcTextBox ID="TxtCompanyName" runat="server" ColumnName="company_name" DbDataType="String" RequiredField="true" Width="100%"></cc1:UcTextBox>            
            </footertemplate>
            <itemtemplate>
                 <%# DataBinder.Eval(Container.DataItem, "company_name") %>
            </itemtemplate>
            <edititemtemplate>  
                 <cc1:UcTextBox ID="TxtCompanyName1" Text='<%# DataBinder.Eval(Container.DataItem, "company_name") %>' runat="server" ColumnName="company_name" DbDataType="String" RequiredField="true" Width="100%"></cc1:UcTextBox>            
            </edititemtemplate>
            <footerstyle width="400px" />
            <itemstyle width="400px" />
        </asp:TemplateField>
          <asp:TemplateField HeaderText="show_order">
            <itemstyle width="100px" />
            <footerstyle width="100px" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["show_order"]%>
            </itemtemplate>
            <edititemtemplate>      
                <cc1:UcTextBox ID="TxtShowOrderEdit" runat="server" ColumnName="show_order" DbDataType="Int32"  RequiredField="true"
                    Width="100%"  Text='<%# DataBinder.Eval(Container.DataItem, "show_order") %>'></cc1:UcTextBox>
            </edititemtemplate>
            <footertemplate>  
                 <cc1:UcTextBox ID="TxtShowOrderFoot" runat="server" ColumnName="show_order" DbDataType="Int32" Width="100%"  RequiredField="true"></cc1:UcTextBox>
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="enable_flag">
            <footerstyle width="100px" />
            <itemstyle width="100px" />
            <itemtemplate>
                 <cc1:UcCheckBox id="ChkEnableFlag" ColumnName="enable_flag" HeaderText="enable_flag"  Checked='<%# Fn.ToBoolean(DataBinder.Eval(Container.DataItem, "enable_flag")) %>' Enabled="false" runat="server" />
            </itemtemplate>
            <edititemtemplate>  
                  <cc1:UcCheckBox id="ChkEnableFlag1"  ColumnName="enable_flag" HeaderText="enable_flag" Checked='<%# Fn.ToBoolean(DataBinder.Eval(Container.DataItem, "enable_flag")) %>' runat="server"/>         
            </edititemtemplate>
        </asp:TemplateField>
        
    </Columns>
</cc1:UcGridView>
