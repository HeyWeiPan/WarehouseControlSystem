<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcRoleUser.ascx.cs" Inherits="Security_UcRoleUser" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<cc1:UcGridView ID="GrdList" runat="server" AutoGenerateColumns="False" Width="100%">
    <Columns>
        <asp:TemplateField HeaderText="User_Number" SortExpression="User_Number">
            <itemtemplate>
                <asp:Label id="Label2" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "User_Number") %>' ></asp:Label> 
            </itemtemplate>
            <footertemplate>
                <cc1:UcLabel id="UcLabel1" runat="server" ColumnName="User_Name"></cc1:UcLabel>&nbsp; 
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="user_name">
            <edititemtemplate>
            </edititemtemplate>
            <footertemplate><cc1:UcHiddenField id="HidRoleID"  runat="server" ColumnName="Role_ID" ></cc1:UcHiddenField>
                <cc2:UcWebComboUser id="ComboUser" Width="100%" runat="server" ColumnName="User_ID" RequiredField="True" ></cc2:UcWebComboUser>
            </footertemplate>
            <itemtemplate>
                <asp:Label id="Label22" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "User_Name") %>' ></asp:Label> 
            </itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Create_Date" SortExpression="Create_Date">
            <edititemtemplate>
            </edititemtemplate>
            <itemtemplate>
                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Create_Date","{0:yyyy/MM/dd HH:mm}") %>'  id="Label11"></asp:Label>
            </itemtemplate>
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
