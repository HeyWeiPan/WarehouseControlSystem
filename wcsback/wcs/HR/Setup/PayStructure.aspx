<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterMainWindow.master"
    AutoEventWireup="false" CodeFile="PayStructure.aspx.cs" Inherits="HR_Setup_PayStructure"
    Title="Untitled Page" %>

<%@ Register Src="UcPayStructureList.ascx" TagName="UcPayStructureList" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <uc1:UcPayStructureList id="UcPayStructureList1" runat="server">
    </uc1:UcPayStructureList>
</asp:Content>
