<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcRoleResource.ascx.cs"
    Inherits="Security_UcRoleResource" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib" TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<cc1:UcGridView ID="GrdRoleResource" runat="server" AutoGenerateColumns="False" Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="Resource_Type">
            <itemstyle width="15%" />
            <headerstyle width="17%" />
            <edititemtemplate>
                <cc1:UcDropDownList id="DdlType" runat="server" Width="100%" DbDataType="Int32" ColumnName="resource_type" RequiredField="True" OnSelectedIndexChanged="DdlType_SelectedIndexChanged" AutoPostBack="True" SqlText='<%#  GetResourceTypeSQL %>' DataTextField="description_type" DataValueField="resource_type" AllowCache="True" AutoBindData="True" ConnectionString="ConSecurity" CacheMinutes="600"/>
            </edititemtemplate>
            <footertemplate>
                <cc1:UcDropDownList id="DdlTypeAdd" runat="server" Width="100%" DbDataType="Int32" ColumnName="resource_type" RequiredField="True" OnSelectedIndexChanged="DdlTypeAdd_SelectedIndexChanged" AutoPostBack="True" SqlText='<%#  GetResourceTypeSQL %>' DataTextField="description_type" DataValueField="resource_type"  AllowCache="True" AutoBindData="True" ConnectionString="ConSecurity" CacheMinutes="600"/>
            </footertemplate>
            <itemtemplate>
                <asp:Label id="labType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "description_type") %>'/>
            </itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Resource_interface_id">
            <itemstyle width="20%" />
            <headerstyle width="20%" />
            <edititemtemplate>
                <cc1:UcDropDownList id="DdlInterface" runat="server" Width="100%"  ColumnName="resource_interface_id"  DataValueField="resource_interface_id" DataTextField="description_interface" SqlText="select 1 resource_interface_id,1  description_interface" AutoPostBack="True" OnSelectedIndexChanged="DdlInterface_SelectedIndexChanged" RequiredField="True"/>
            </edititemtemplate>
            <footertemplate>
                <cc1:UcDropDownList id="DdlInterfaceAdd" runat="server" Width="100%" ColumnName="resource_interface_id"  DataValueField="resource_interface_id" DataTextField="description_interface" SqlText='<%#  GetResourceInterfaceSQL %>' CacheMinutes="600" ConnectionString="ConSecurity" AutoBindData="True" AutoPostBack="True" OnSelectedIndexChanged="DdlInterfaceAdd_SelectedIndexChanged" RequiredField="True"/>
            </footertemplate>
            <itemtemplate>
                <asp:Label id="LabInterface" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "description_interface") %>'/>
            </itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Set_Member_Sql">
            <itemstyle width="10%" />
            <headerstyle width="40%" />
            <edititemtemplate>
                <cc1:UcDropDownList id="DdlSetMember" runat="server" Width="100%" ColumnName="resource_value"  DataValueField="data_value" DataTextField="data_text" SqlText="select 1 data_value,1 data_text"/>
            </edititemtemplate>
            <footertemplate>
                <cc1:UcDropDownList id="DdlSetMemberAdd" runat="server" Width="100%" ColumnName="resource_value"  DataValueField="data_value" DataTextField="data_text" SqlText='<%#  GetMemberSQL %>' CacheMinutes="600" ConnectionString="ConSecurity" AutoBindData="True"/>
            </footertemplate>
            <itemtemplate>
                <asp:Label id="labSetMember" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "data_text") %>'/>
            </itemtemplate>
        </asp:TemplateField>
     </Columns>
</cc1:UcGridView>
<cc1:UcHiddenField ID="HidRoleId" runat="server" ColumnName="Role_ID" DbDataType="Int32" />
<cc1:UcHiddenField ID="HidDescription" runat="server" ColumnName="resource_description" />
