<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserFamilyList.ascx.cs"
    Inherits="HR_UserProfile_UcUserFamilyList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<cc1:UcGridView ID="GrdUserFamilyList" runat="server" DataKeyNames="family_id" AutoGenerateColumns="False"
    Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="person_name">
            <itemstyle width="10%" />
            <footerstyle width="10%" />
            <itemtemplate>
                <cc1:UcLabel id="L1" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["person_name"]%> ' Width="100%"></cc1:UcLabel>                 
            </itemtemplate>
            <edititemtemplate>      
            <cc1:UcTextBox ID="TxtPersonNameEdit" ColumnName="person_name"  runat="server" Width="100%" RequiredField="True" />                     
            </edititemtemplate>
            <footertemplate>
                <cc1:UcTextBox ID="TxtPersonNameFoot" ColumnName="person_name"  runat="server" Width="100%" RequiredField="True"/>                     
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="relation">
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["relation"]%>            
            </itemtemplate>
            <edititemtemplate>      
                <cc2:UcDdlValue ID="DrpRelationEdit" runat="server" Width="100%" ValueSetCode="RELATIONS" ColumnName="relation" DataValueField="data_text" RequiredField="True" />                
            </edititemtemplate>
            <footertemplate>    
                <cc2:UcDdlValue ID="DrpRelationFoot" runat="server" Width="100%" ValueSetCode="RELATIONS" ColumnName="relation" DataValueField="data_text" RequiredField="True" />            
            </footertemplate>
            <itemstyle width="6%" />
            <footerstyle width="6%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="work_company">
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["work_company"]%>            
            </itemtemplate>
            <edititemtemplate>  
                <cc1:UcTextBox ID="TxtWorkEdit" ColumnName="work_company" RequiredField="True"  runat="server" Width="100%" />                    
            </edititemtemplate>
            <footertemplate>                
                <cc1:UcTextBox ID="TxtWorkFoot" ColumnName="work_company" RequiredField="True"  runat="server" Width="100%" />                    
            </footertemplate>
            <itemstyle width="22%" />
            <footerstyle width="22%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="job_position">
            <itemtemplate>
                <%# ((DataRowView)Container.DataItem).Row["job_position"]%>                                       
            </itemtemplate>
            <edititemtemplate>  
                <cc1:UcTextBox ID="TxtJobEdit" ColumnName="job_position" RequiredField="True"   runat="server" Width="100%" />                                        
            </edititemtemplate>
            <footertemplate>                
                <cc1:UcTextBox ID="TxtJobFoot" ColumnName="job_position" RequiredField="True"  runat="server" Width="100%" />                                        
            </footertemplate>
            <itemstyle width="10%" />
            <footerstyle width="10%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="contact_phone">
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["contact_phone"]%>                                       
            </itemtemplate>
            <edititemtemplate>  
                <cc1:UcTextBox ID="TxtPhoneEdit" ColumnName="contact_phone"  runat="server" Width="100%" />                                                            
            </edititemtemplate>
            <footertemplate>   
                <cc1:UcTextBox ID="TxtPhoneFoot" ColumnName="contact_phone"  runat="server" Width="100%" />                                                     
            </footertemplate>
            <itemstyle width="10%" />
            <footerstyle width="10%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="address">
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["address"]%>                                       
            </itemtemplate>
            <edititemtemplate>    
                <cc1:UcTextBox ID="TxtAddressEdit" ColumnName="address"  runat="server" Width="100%" />                                                                       
            </edititemtemplate>
            <footertemplate>     
                <cc1:UcTextBox ID="TxtAddressFoot" ColumnName="address"  runat="server" Width="100%" />                                                                
            </footertemplate>
            <itemstyle width="25%" />
            <footerstyle width="25%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="zip_code">
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["zip_code"]%>                                       
            </itemtemplate>
            <edititemtemplate>  
                <cc1:UcTextBox ID="TxtZIPEdit" ColumnName="zip_code"  runat="server" Width="100%" />                                                                                    
            </edititemtemplate>
            <footertemplate>     
                <cc1:UcTextBox ID="TxtZIPFoot" ColumnName="zip_code"  runat="server" Width="100%" />                                                                           
            </footertemplate>
            <itemstyle width="8%" />
            <footerstyle width="8%" />
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
