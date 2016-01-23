<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcJDQualificationList.ascx.cs"
    Inherits="HR_Setup_UcJDQualificationList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<cc1:UcGridView ID="GrdList" runat="server" DataKeyNames="map_id" AutoGenerateColumns="False"
    Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="qualifi_code">
            <itemstyle width="15%" />
            <footerstyle width="15%" />
            <itemtemplate>                                
                <%# ((DataRowView)Container.DataItem).Row["category_name"]%>
            </itemtemplate>
            <edititemtemplate>      
                 <cc1:UcDropDownList ID="P1" runat="server" Width="100%" DataTextField="category_name"                   
                    DataValueField="category_code" IsInsertItem="true" AutoBindData="true" AllowCache="true"                   
                    ColumnName="category_code" RequiredField="true" SqlText="select category_code,category_name from hr_jd_category where category_group = 'A' order by show_order">                 
                </cc1:UcDropDownList>
            </edititemtemplate>
            <footertemplate>                                   
                <cc1:UcDropDownList ID="P2" runat="server" Width="100%" DataTextField="category_name" 
                    DataValueField="category_code" IsInsertItem="true" AutoBindData="true" AllowCache="true"
                    ColumnName="category_code" RequiredField="true" SqlText="select category_code,category_name from hr_jd_category where category_group = 'A' order by show_order">                  
                </cc1:UcDropDownList>
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="qualifi_desc">
            <itemstyle width="75%" />
            <footerstyle width="75%" />
            <itemtemplate> 
                <cc1:UcTextBox id="TI2" Width="99%" runat="server" TextMode="MultiLine" UseDefaultStyle="false" ReadOnly="true" CssClass="TransparentText" Text='<%# ((DataRowView)Container.DataItem).Row["qualifi_desc"]%>'></cc1:UcTextBox>
            </itemtemplate>
            <edititemtemplate> 
                <cc1:UcTextBox ID="TE2" runat="server" ColumnName="qualifi_desc" Width="100%" DbDataType="String" TextMode="MultiLine" Rows="6"
                    RequiredField="true" Text='<%# ((DataRowView)Container.DataItem).Row["qualifi_desc"]%>'/>
            </edititemtemplate>
            <footertemplate>                                   
                <cc1:UcTextBox ID="TF2" runat="server" ColumnName="qualifi_desc" DbDataType="String" Width="100%"  TextMode="MultiLine" Rows="6" RequiredField="true"></cc1:UcTextBox>                  
            </footertemplate>
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
