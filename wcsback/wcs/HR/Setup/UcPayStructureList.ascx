<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcPayStructureList.ascx.cs"
    Inherits="HR_Setup_UcPayStructureList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<cc1:UcGridView ID="GrdList" runat="server" DataKeyNames="seq_id" AutoGenerateColumns="False"
    Width="80%">
    <Columns>
        <asp:TemplateField HeaderText="pay_grade">
            <footertemplate>  
                 <cc1:UcTextBox ID="T1" runat="server" ColumnName="pay_grade" DbDataType="String" RequiredField="true" Width="100%"></cc1:UcTextBox>            
            </footertemplate>
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["pay_grade"]%>
            </itemtemplate>
            <edititemtemplate>  
                 <cc1:UcTextBox ID="T2" Text='<%# ((DataRowView)Container.DataItem).Row["pay_grade"]%>' runat="server" ColumnName="pay_grade" DbDataType="String" RequiredField="true" Width="100%"></cc1:UcTextBox>            
            </edititemtemplate>
            <itemstyle width="35%" />
            <footerstyle width="35%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="pay_min">
            <itemstyle width="13%" />
            <footerstyle width="13%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["pay_min"]%>
            </itemtemplate>
            <edititemtemplate>      
                <cc1:UcTextBox ID="T3" runat="server" ColumnName="pay_min" DbDataType="Int32"  
                    Width="100%"  Text='<%# ((DataRowView)Container.DataItem).Row["pay_min"]%>'></cc1:UcTextBox>
            </edititemtemplate>
            <footertemplate>  
                 <cc1:UcTextBox ID="T4" runat="server" ColumnName="pay_min" DbDataType="Int32" Width="100%" ></cc1:UcTextBox>
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="pay_mid">
            <itemstyle width="13%" />
            <footerstyle width="13%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["pay_mid"]%>
            </itemtemplate>
            <edititemtemplate>      
                <cc1:UcTextBox ID="T5" runat="server" ColumnName="pay_mid" DbDataType="Int32" 
                    Width="100%"  Text='<%# ((DataRowView)Container.DataItem).Row["pay_mid"]%>'></cc1:UcTextBox>
            </edititemtemplate>
            <footertemplate>  
                 <cc1:UcTextBox ID="T6" runat="server" ColumnName="pay_mid" DbDataType="Int32" Width="100%"></cc1:UcTextBox>
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="pay_max">
            <itemstyle width="13%" />
            <footerstyle width="13%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["pay_max"]%>
            </itemtemplate>
            <edititemtemplate>      
                <cc1:UcTextBox ID="T7" runat="server" ColumnName="pay_max" DbDataType="Int32" 
                    Width="100%"  Text='<%# ((DataRowView)Container.DataItem).Row["pay_max"]%>'></cc1:UcTextBox>
            </edititemtemplate>
            <footertemplate>  
                 <cc1:UcTextBox ID="T8" runat="server" ColumnName="pay_max" DbDataType="Int32" Width="100%"></cc1:UcTextBox>
            </footertemplate>
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
