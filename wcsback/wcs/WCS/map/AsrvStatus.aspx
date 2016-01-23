<%@ Page Title="" Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterDetail.master"
    AutoEventWireup="true" CodeFile="AsrvStatus.aspx.cs" Inherits="WCS_map_AsrvStatus" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table style="width: 100%; table-layout: fixed; margin: 10px,0,0,0; padding: 0,0,0,0;
        border: 0 0 0 0;" cellpadding="0" cellspacing="0">
        <tr style="height: 20px;">
            <td>
                <cc1:UcHyperLink ID="LnkAsrvStatus" runat="server" ColumnName="TabAsrvStatus" ShowStyle="TabBlue"
                    Target="IfraSubWindow" ClientIDMode="Static">
                </cc1:UcHyperLink>
            </td>
        </tr>
        <tr align="left" valign="top" id="TabIfra" runat="server" style="display: inline;">
            <td valign="top" class="ContainerBorder" style="margin: 0,0,0,0; padding: 0,0,0,0;">
                <table width="100%">
                    <colgroup>
                        <col width="25%" />
                        <col width="25%" />
                        <col width="25%" />
                        <col width="25%" />
                    </colgroup>
                    <tr>
                        <td>
                            <cc1:UcLabel ID="L1" runat="server"></cc1:UcLabel>
                        </td>
                        <td>
                            <cc1:UcLabel ID="L2" runat="server"></cc1:UcLabel>
                        </td>
                        <td>
                            <cc1:UcLabel ID="L3" runat="server"></cc1:UcLabel>
                        </td>
                        <td>
                            <cc1:UcLabel ID="L4" runat="server"></cc1:UcLabel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:UcLabel ID="L5" runat="server"></cc1:UcLabel>
                        </td>
                        <td>
                            <cc1:UcLabel ID="L6" runat="server"></cc1:UcLabel>
                        </td>
                        <td>
                            <cc1:UcLabel ID="L7" runat="server"></cc1:UcLabel>
                        </td>
                        <td>
                            <cc1:UcLabel ID="L8" runat="server"></cc1:UcLabel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:UcLabel ID="L9" runat="server"></cc1:UcLabel>
                        </td>
                        <td>
                            <cc1:UcLabel ID="L10" runat="server"></cc1:UcLabel>
                        </td>
                        <td>
                            <cc1:UcLabel ID="L11" runat="server"></cc1:UcLabel>
                        </td>
                        <td>
                            <cc1:UcLabel ID="L12" runat="server"></cc1:UcLabel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table style="width: 100%; table-layout: fixed; margin: 10px,0,0,0; padding: 0,0,0,0;
        border: 0 0 0 0;" cellpadding="0" cellspacing="0">
        <tr style="height: 20px;">
            <td>
                <cc1:UcHyperLink ID="LnkError" runat="server" ColumnName="TabAsrvError" ShowStyle="TabBlue"
                    Target="IfraSubWindow" ClientIDMode="Static">
                </cc1:UcHyperLink>
            </td>
        </tr>
        <tr align="left" valign="top" id="Tr1" runat="server" style="display: inline;">
            <td valign="top" class="ContainerBorder" style="margin: 0,0,0,0; padding: 0,0,0,0;">
                <table width="100%">
                    <colgroup>
                        <col width="25%" />
                        <col width="25%" />
                        <col width="25%" />
                        <col width="25%" />
                    </colgroup>
                    <tr>
                        <td>
                            <cc1:UcLabel ID="E1" runat="server"></cc1:UcLabel>
                        </td>
                        <td>
                            <cc1:UcLabel ID="E2" runat="server"></cc1:UcLabel>
                        </td>
                        <td>
                            <cc1:UcLabel ID="E3" runat="server"></cc1:UcLabel>
                        </td>
                        <td>
                            <cc1:UcLabel ID="E4" runat="server"></cc1:UcLabel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:UcLabel ID="E5" runat="server"></cc1:UcLabel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C2" runat="Server">
</asp:Content>
