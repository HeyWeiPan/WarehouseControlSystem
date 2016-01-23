<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterMainWindow.master"
    AutoEventWireup="false" CodeFile="CostCenter.aspx.cs" Inherits="HR_Setup_CostCenter"
    Title="Untitled Page" %>

<%@ Register Src="UcCostCenterList.ascx" TagName="UcCostCenterList" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <uc1:UcCostCenterList ID="UcCostCenterList1" runat="server" />
</asp:Content>
