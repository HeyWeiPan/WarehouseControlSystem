<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterMainWindow.master" AutoEventWireup="true" CodeFile="UserMemberType.aspx.cs" Inherits="HR_Setup_UserMemberType" Title="Untitled Page" %>

<%@ Register Src="UcUserMemberTypeList.ascx" TagName="UcUserMemberTypeList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
    <uc1:UcUserMemberTypeList ID="UcUserMemberTypeList1" runat="server" />
</asp:Content>

