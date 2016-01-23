<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserMemberTypeList.ascx.cs" Inherits="HR_Setup_UcUserMemberTypeList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Import Namespace="EntpClass.Common" %>
<%@ Import Namespace="System.Data" %>
<cc1:UcGridView ID="GrdList" Width="100%" runat="server" AutoGenerateColumns="False"
    DataKeyNames="user_number_type_id">
    <Columns>
        <asp:TemplateField HeaderText="user_number_type_name">
            <itemstyle width="25%" />
            <footerstyle width="25%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["user_number_type_name"]%>
            </itemtemplate>
            <edititemtemplate>      
                <cc1:UcTextBox ID="T1" runat="server" ColumnName="user_number_type_name" DbDataType="String"  Width="100%" RequiredField="true"  Text='<%# DataBinder.Eval(Container.DataItem, "user_number_type_name") %>'></cc1:UcTextBox>
            </edititemtemplate>
            <footertemplate>  
                 <cc1:UcTextBox ID="T2" runat="server" ColumnName="user_number_type_name" DbDataType="String"  RequiredField="true" Width="100%"></cc1:UcTextBox>
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="user_number_type_prefix">
            <itemstyle width="15%" />
            <footerstyle width="15%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["user_number_type_prefix"]%>
            </itemtemplate>
            <edititemtemplate>                  
                 <cc1:UcTextBox ID="T21" runat="server" ColumnName="user_number_type_prefix" DbDataType="String" Width="100%"  Text='<%# DataBinder.Eval(Container.DataItem, "user_number_type_prefix") %>'></cc1:UcTextBox>
            </edititemtemplate>
            <footertemplate>                                   
                <cc1:UcTextBox ID="T22" runat="server" ColumnName="user_number_type_prefix" DbDataType="String" Width="100%"></cc1:UcTextBox>                  
            </footertemplate>
        </asp:TemplateField>        
       
        <asp:TemplateField HeaderText="show_order">
            <itemstyle width="10%" />
            <footerstyle width="10%" />
            <itemtemplate>
                  <%# string.Format("{0:N0}", ((DataRowView)Container.DataItem)["show_order"])%> 
            </itemtemplate>
            <edititemtemplate> 
                <cc1:UcTextBox ID="T11" runat="server" ColumnName="show_order" DbDataType="int32" RequiredField="true"
                    Width="100%"  Text='<%# DataBinder.Eval(Container.DataItem, "show_order") %>'></cc1:UcTextBox>                       
            </edititemtemplate>
            <footertemplate>     
                <cc1:UcTextBox ID="T12" runat="server" ColumnName="show_order" DbDataType="int32"  RequiredField="true" Width="100%"></cc1:UcTextBox>                
            </footertemplate>
        </asp:TemplateField>
       <%-- <asp:TemplateField HeaderText="delete_flag">
            <itemstyle width="10%" />
            <footerstyle width="10%" />
            <itemtemplate>
                 <cc1:UcCheckBox ID="Chk31" runat="server" Width="100%"  ColumnName="delete_flag" Checked='<%# Fn.ToBoolean(((DataRowView)Container.DataItem).Row["delete_flag"]) %>'  Enabled="false"/>
            </itemtemplate>
            <edititemtemplate> 
                <cc1:UcCheckBox ID="Chk11" runat="server" Width="100%"  ColumnName="delete_flag" Checked='<%# Fn.ToBoolean(((DataRowView)Container.DataItem).Row["delete_flag"]) %>'/>
            </edititemtemplate>
            <footertemplate>   
                <cc1:UcCheckBox ID="Chk21" runat="server" Width="100%"   ColumnName="delete_flag" Checked="false"/>
            </footertemplate>
        </asp:TemplateField>--%>
    </Columns>
</cc1:UcGridView>
