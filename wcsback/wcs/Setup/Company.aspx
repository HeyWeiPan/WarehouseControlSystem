<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterMainWindow.master" AutoEventWireup="true" CodeFile="Company.aspx.cs" Inherits="Setup_Company" Title="Untitled Page" %>

<%@ Register Src="UcCompany.ascx" TagName="UcCompany" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
    <uc1:UcCompany ID="UcCompany1" runat="server" />
</asp:Content>

