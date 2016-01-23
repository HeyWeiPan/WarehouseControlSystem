<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcJDResponsibilityList.ascx.cs"
    Inherits="HR_Setup_UcJDResponsibilityList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<cc1:UcGridView ID="GrdList" runat="server" DataKeyNames="map_id" AutoGenerateColumns="False"
    Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="seq_id">
            <itemstyle width="15%" />
            <footerstyle width="15%" />
            <itemtemplate>
                <%# ((DataRowView)Container.DataItem).Row["seq_id"]%>
            </itemtemplate>
            <edititemtemplate> 
                <cc1:UcTextBox ID="TE3" runat="server" ColumnName="show_order" Width="100%" DbDataType="int32"
                    RequiredField="true" Text='<%# ((DataRowView)Container.DataItem).Row["seq_id"]%>'/>
            </edititemtemplate>
            <footertemplate>                                   
                <cc1:UcTextBox ID="TF3" runat="server" ColumnName="seq_id" DbDataType="int32" Width="100%"  RequiredField="true"></cc1:UcTextBox>                  
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="job_duties">
            <itemstyle width="75%" />
            <footerstyle width="75%" />
            <itemtemplate>                                
                <cc1:UcTextBox id="TI1" Width="99%" runat="server" TextMode="MultiLine" UseDefaultStyle="false" ReadOnly="true" CssClass="TransparentText" Text='<%# ((DataRowView)Container.DataItem).Row["job_duties"]%>'></cc1:UcTextBox>
            </itemtemplate>
            <edititemtemplate>      
                <cc1:UcTextBox ID="TE1" runat="server" ColumnName="job_duties" RequiredField="True" TextMode="MultiLine" Rows="6"
                    Width="100%"  Text='<%# ((DataRowView)Container.DataItem).Row["job_duties"]%>'></cc1:UcTextBox>
            </edititemtemplate>
            <footertemplate>                                   
                <cc1:UcTextBox ID="TF1" runat="server" ColumnName="job_duties" DbDataType="String" Width="100%" TextMode="MultiLine" Rows="6" RequiredField="true"></cc1:UcTextBox>                  
            </footertemplate>
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
