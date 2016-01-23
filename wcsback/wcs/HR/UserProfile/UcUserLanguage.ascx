<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserLanguage.ascx.cs"
    Inherits="HR_UserProfile_UcUserLanguage" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<cc1:UcGridView ID="GrdList" runat="server" DataKeyNames="map_id" AutoGenerateColumns="False"
    Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="language_kind">
            <itemstyle width="20%" />
            <footerstyle width="20%" />
            <itemtemplate>
                <%# ((DataRowView)Container.DataItem).Row["language_kind_name"]%>
            </itemtemplate>
            <edititemtemplate>      

                     <cc2:UcDdlValue ID="UcDdlValue2" runat="server"  Width="100%" ValueSetCode="language_type"
                ColumnName="language_kind" RequiredField="true">
            </cc2:UcDdlValue>         </edititemtemplate>
            <footertemplate>
                     <cc2:UcDdlValue ID="UcDdlValue3" runat="server"  Width="100%" ValueSetCode="language_type"
                ColumnName="language_kind" RequiredField="true">
            </cc2:UcDdlValue>                   
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="language_level">
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["language_level_name"]%>            
            </itemtemplate>
            <edititemtemplate>    
                     <cc2:UcDdlValue ID="DrpLanguageLevel" runat="server" Width="100%" ValueSetCode="language_level"
                ColumnName="language_level" RequiredField="true">
            </cc2:UcDdlValue>  
            </edititemtemplate>
            <footertemplate>    
                       <edititemtemplate>    
                     <cc2:UcDdlValue ID="UcDdlValue1" runat="server"  Width="100%" ValueSetCode="language_level"
                ColumnName="language_level" RequiredField="true">
            </cc2:UcDdlValue>  
            </footertemplate>
            <itemstyle width="20%" />
            <footerstyle width="20%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="language_certificate">
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["language_certificate"]%>            
            </itemtemplate>
            <edititemtemplate>  
                <cc1:UcTextBox ID="T5" ColumnName="language_certificate"  runat="server" Width="100%" />                    
            </edititemtemplate>
            <footertemplate>                
                <cc1:UcTextBox ID="T6" ColumnName="language_certificate"  runat="server" Width="100%" />                    
            </footertemplate>
            <itemstyle width="40%" />
            <footerstyle width="40%" />
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
