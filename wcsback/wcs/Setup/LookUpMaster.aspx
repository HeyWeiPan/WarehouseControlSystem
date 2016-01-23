<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterMainWindow.master"
    AutoEventWireup="true" CodeFile="LookUpMaster.aspx.cs" Inherits="Setup_LookUpMaster"
    Title="Untitled Page" %>

<%@ Register Src="UcLookUpList.ascx" TagName="UcLookUpList" TagPrefix="uc1" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table width="100%" style="margin: 0 0 0 0; padding: 0 0 0 0; border: 0 0 0 0; height: 100%;"
        cellpadding="0" cellspacing="0">
        <tr>
            <td style="height: 25px;">
                <cc2:UcDdlValueSet ID="DrpValueSetCode" runat="server" Width="245px" AutoPostBack="True" ColumnName="valueset_code"
                    OnSelectedIndexChanged="DrpValueSetCode_SelectedIndexChanged">
                </cc2:UcDdlValueSet>
                <cc1:UcButton ID="BtnView" runat="server" ColumnName="View" OnClick="BtnView_Click">
                </cc1:UcButton>
            </td>
        </tr>
        <tr valign="top" align="left">
            <td style="margin: 0 0 0 0; padding: 0 0 0 0; border: 0 0 0 0;">               
                <uc1:UcLookUpList ID="UcLookUpList1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
