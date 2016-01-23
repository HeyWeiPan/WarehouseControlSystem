<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterMainWindow.master"
    AutoEventWireup="true" CodeFile="TeamTree.aspx.cs" Inherits="HR_OrgChart_TeamTree"
    Title="Untitled Page" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="../WsHR.asmx" />
        </Services>
    </asp:ScriptManager>

    <script src="Js/ContextMenu.js" type="text/javascript"></script>

    <script src="Js/TeamTreeNode.js" type="text/javascript"></script>    
    <table style="margin: 0,0,0,0; padding: 0,0,0,0; border: 0,0,0,0; width: 100%; height: 99%;
        table-layout: fixed;">
        <colgroup>
            <col width="25%" />
            <col width="75%" />
        </colgroup>
        <tr>
            <td>
                <cc1:UcTreeView ID='TVOrg' Height="98%" Width="100%" runat="server" SelectExpands='true'
                    ExpandLevel='2' OnContextMenuClientScript="ContextMenu.ShowContextMenu();"></cc1:UcTreeView></td>
            <td>
                <iframe id="IfraSubWindow" runat="server" frameborder="0" name="IfraSubWindow" scrolling="auto"
                    style="width: 100%; height: 100%"></iframe>
            </td>
        </tr>
    </table>
    <a id="A1" runat="server" href="about:blank" target="IfraSubWindow"></a>
</asp:Content>
