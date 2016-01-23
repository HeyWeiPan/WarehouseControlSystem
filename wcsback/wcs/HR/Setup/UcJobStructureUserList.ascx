<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcJobStructureUserList.ascx.cs"
    Inherits="HR_Setup_UcJobStructureUserList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Import Namespace="EntpClass.Common" %>
<%@ Import Namespace="System.Data" %>
<cc1:UcGridView ID="GrdList" Width="100%" runat="server" AutoGenerateColumns="False"
    DataKeyNames="user_guid">
    <Columns>
        <asp:TemplateField HeaderText="user_number">
            <itemstyle width="8%" />            
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["user_number"]%>
            </itemtemplate>
            <footertemplate>  
                 <cc2:UcWebComboUser id="WcbUser" Width="100%" runat="server" ColumnName="User_ID" RequiredField="True"  CssClass="CssRequired"></cc2:UcWebComboUser>    
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="native_name">
            <itemstyle width="8%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["native_name"]%>
            </itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="primary_team_name">
            <itemstyle width="12%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["primary_team_name"]%>
            </itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="user_type_id">
            <itemstyle width="8%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["user_type_id"]%>
            </itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="user_status_code">
            <itemstyle width="8%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["user_status_code"]%>
            </itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="direct_line">
            <itemstyle width="12%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["direct_line"]%>
            </itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="phone_ext">
            <itemstyle width="10%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["phone_ext"]%>
            </itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="office_mobile">
            <itemstyle width="11%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["office_mobile"]%>
            </itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="company_email">
            <itemstyle width="11%" />
            <itemtemplate>
                  <%# ((DataRowView)Container.DataItem).Row["company_email"]%>
            </itemtemplate>
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
