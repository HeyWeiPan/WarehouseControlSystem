<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterDetailNoTitle.master"
    AutoEventWireup="true" CodeFile="Scope.aspx.cs" Inherits="CommonUI_WebForm_Scope"
    Title="Untitled Page" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="C1" ContentPlaceHolderID="C1" runat="Server">
    <asp:PlaceHolder ID="P1" runat="server"></asp:PlaceHolder>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="C2" runat="Server">
    <div id="BtnList" style="display: block; text-align: center; width: 100%;">
        
            <asp:LinkButton ID="BtnOK" runat="server" Text="²éÕÒ" OnClick="BtnOK_Click" OnClientClick="window.returnValue='REFRESH';"></asp:LinkButton>
            <asp:LinkButton ID="BtnCancel" runat="server" Text="È¡Ïû" OnClientClick="window.close();"></asp:LinkButton>
    </div>
</asp:Content>
