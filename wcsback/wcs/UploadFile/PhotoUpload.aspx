<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterDetail.master"
    AutoEventWireup="true" CodeFile="PhotoUpload.aspx.cs" Inherits="UploadFile_PhotoUpload"
    Title="Untitled Page" %>

<%@ Register Src="UcPhotoUpload.ascx" TagName="UcPhotoUpload" TagPrefix="uc1" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <uc1:UcPhotoUpload ID="UcPhotoUpload1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C2" runat="Server">
    <cc1:UcButton ID="BtnClose" runat="server" ColumnName="Close" Width="53px" OnClientClick="window.close();return false;" />
</asp:Content>
