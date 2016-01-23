<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcLookUpList.ascx.cs"
    Inherits="Setup_UcLookUpList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="EntpClass.Common" %>
<%@ Import Namespace="System.Data" %>
<cc1:UcGridView ID="GrdList" Width="100%" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField >
            <itemstyle width="3%" />
            <footerstyle width="3%" />
            <itemtemplate>
                <cc1:UcLabel id="L1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "seq_id") %>' Width="100%"></cc1:UcLabel>                 
            </itemtemplate>
            <edititemtemplate>      
                <cc1:UcLabel id="L2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "seq_id") %>' Width="100%"></cc1:UcLabel>                 
            </edititemtemplate>
            <footertemplate>
                <cc1:UcLabel id="L3" runat="server" Width="100%"></cc1:UcLabel>              
            </footertemplate>            
        </asp:TemplateField>
        <asp:TemplateField HeaderText="value_name">
            <itemstyle width="20%" />
            <footerstyle width="20%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["value_name"]%>
            </itemtemplate>
            <edititemtemplate>      
                <cc1:UcTextBox ID="TxtValueNameEdit" runat="server" ColumnName="value_name" DbDataType="String" RequiredField="true"
                    Width="100%"  Text='<%# DataBinder.Eval(Container.DataItem, "value_name") %>'></cc1:UcTextBox>
            </edititemtemplate>
            <footertemplate>  
                 <cc1:UcTextBox ID="TxtValueNameFoot" runat="server" ColumnName="value_name" DbDataType="String"  RequiredField="true" Width="100%"></cc1:UcTextBox>
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="value_name_en">
            <itemstyle width="20%" />
            <footerstyle width="20%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["value_name_en"]%>
            </itemtemplate>
            <edititemtemplate>      
                <cc1:UcTextBox ID="TxtValueNameEnEdit" runat="server" ColumnName="value_name_en" DbDataType="String"  
                    Width="100%"  Text='<%# DataBinder.Eval(Container.DataItem, "value_name_en") %>'></cc1:UcTextBox>
            </edititemtemplate>
            <footertemplate>  
                 <cc1:UcTextBox ID="TxtValueNameEnFoot" runat="server" ColumnName="value_name_en" DbDataType="String"   Width="100%"></cc1:UcTextBox>
            </footertemplate>
        </asp:TemplateField>
       
        <asp:TemplateField HeaderText="remark">
            <itemstyle width="30%" />
            <footerstyle width="30%" />
            <itemtemplate>
                <%# ((DataRowView)Container.DataItem).Row["remark"]%>
            </itemtemplate>
            <edititemtemplate>      
                <cc1:UcTextBox ID="TxtRemarkEdit" runat="server" ColumnName="remark" DbDataType="String" TextMode="MultiLine"
                    style="word-break:break-all;word-wrap:break-word;"  Width="100%" Text='<%# DataBinder.Eval(Container.DataItem, "remark") %>'></cc1:UcTextBox>
            </edititemtemplate>
            <footertemplate>  
                 <cc1:UcTextBox ID="TxtRemarkFoot" runat="server" ColumnName="remark" DbDataType="String" TextMode="MultiLine"
                  style="word-break:break-all;word-wrap:break-word;"  Width="100%" ></cc1:UcTextBox>
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="enable_flag">
            <footerstyle width="5%" />
            <itemstyle width="5%" />
            <edititemtemplate>
               <cc1:UcCheckBox ID="Chk1" runat="server" Width="100%"  ColumnName="enable_flag" Checked='<%# Fn.ToBoolean(DataBinder.Eval(Container.DataItem, "enable_flag")) %>'/>
            </edititemtemplate>
            <footertemplate>
                <cc1:UcCheckBox ID="Chk2" runat="server" Width="100%"   ColumnName="enable_flag" Checked="false" />
            </footertemplate>
            <itemtemplate>
                <cc1:UcCheckBox ID="Chk3" runat="server" Width="100%"  ColumnName="enable_flag" Checked='<%# Fn.ToBoolean(DataBinder.Eval(Container.DataItem, "enable_flag")) %>'  Enabled="false"/>
            </itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="show_order">
            <itemstyle width="5%" />
            <footerstyle width="5%" />
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
    </Columns>
</cc1:UcGridView>
