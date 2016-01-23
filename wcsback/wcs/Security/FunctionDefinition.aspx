<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterMainWindow.master"
    AutoEventWireup="true" CodeFile="FunctionDefinition.aspx.cs" Inherits="Security_FunctionDefinition"
    Title="Untitled Page" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    <Services>
        <asp:ServiceReference Path="WSSecurity.asmx" />
    </Services>
</asp:ScriptManager>
<script src="Js/FunctionTree.js" type="text/javascript" ></script>


<table style="width: 100%; height: 100%">
    <tr style="height: 40px;" valign="bottom">
        <td>
            <cc1:UcButton ID="BtnView" runat="server" ColumnName="View" UseSubmitBehavior="False"
                Width="60px" OnClientClick="return viewMenu();" />
            <cc1:UcButton ID="BtnAdd" runat="server" ColumnName="Add" UseSubmitBehavior="False"
                Width="60px" OnClientClick="return addMenu();" />
            <cc1:UcButton ID="BtnEdit" runat="server" ColumnName="Edit" UseSubmitBehavior="False"
                Width="60px" OnClientClick="return editMenu();" />
            <cc1:UcButton ID="BtnCopy" runat="server" ColumnName="Copy" UseSubmitBehavior="False"
                Width="60px" OnClientClick="return copyMenu();" />
            <cc1:UcButton ID="BtnCut" runat="server" ColumnName="Cut" UseSubmitBehavior="False"
                Width="60px" OnClientClick="return cutMenu();" />
            <cc1:UcButton ID="BtnPaste" runat="server" ColumnName="Paste" UseSubmitBehavior="False"
                Width="60px" OnClientClick="return pasteMenu();" />
            <cc1:UcButton ID="BtnDelete" runat="server" ColumnName="Delete" UseSubmitBehavior="False"
                Width="60px" OnClientClick="return deleteMenu();" />
        </td>
    </tr>
    <tr style="height: 10px;">
        <td> </td>
    </tr>
    <tr valign="top">
        <td>          
            <cc1:UcTreeView ID="UcTreeMenuList" runat="server" ExpandLevel="1" OnContextMenuClientScript="showContextMenu();"></cc1:UcTreeView>           
        </td>
    </tr>
</table>
</asp:Content>
