<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterSetupDetail.master"
    AutoEventWireup="true" CodeFile="UserDetail.aspx.cs" Inherits="HR_UserProfile_UserDetail"
    Title="Untitled Page" %>
<%@ Register Src="UcUserTabGroup.ascx" TagName="UcUserTabGroup" TagPrefix="uc6" %>
<%@ Register Src="UcUser.ascx" TagName="UcUser" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table style="width: 100%; height: 100%; table-layout: fixed;">
        <tr style="height: 200px;">
            <td>
                <uc1:UcUser ID="UcUser1" runat="server" />
            </td>
        </tr>
        <tr valign="top" align="left" id="trTabGroups" runat="server">
            <td>
                <uc6:UcUserTabGroup ID="UcUserTabGroup1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
