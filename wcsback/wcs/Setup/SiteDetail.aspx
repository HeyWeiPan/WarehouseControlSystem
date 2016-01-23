<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterSetupDetail.master" AutoEventWireup="true" CodeFile="SiteDetail.aspx.cs" Inherits="Setup_SiteDetail" Title="Untitled Page" %>

<%@ Register Src="UcSite.ascx" TagName="UcSite" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="WsSetup.asmx" />
        </Services>
    </asp:ScriptManager>
    <uc1:UcSite id="UcSite1" runat="server">
    </uc1:UcSite>
</asp:Content>

