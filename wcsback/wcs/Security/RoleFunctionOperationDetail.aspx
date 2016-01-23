<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterDetail.master"
    AutoEventWireup="true" CodeFile="RoleFunctionOperationDetail.aspx.cs" Inherits="Security_RoleFunctionOperationDetail"
    Title="Untitled Page" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table style="table-layout: fixed; width: 100%;" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <div style="overflow: auto; width: 540px; height: 300px">
                    <cc1:UcTreeView ID="Trv" runat="server" ExpandLevel="1" onclick='onNodeclick()' />
                </div>
            </td>
        </tr>
        <tr style="height: 15px">
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 110px; display: inline; table-layout: fixed;" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td class="TabLeft">
                        </td>
                        <td class="TabBody">
                            <cc1:UcLabel ID="L1" ColumnName="Operations" ResourceFileType="UI" CssClass="" runat="server"></cc1:UcLabel>
                        </td>
                        <td class="TabRight">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="ContainerBorder">
                <iframe id="CheckDetail" runat="server" frameborder="0" name="CheckDetail" style="width: 560px;
                    height: 130px"></iframe>
            </td>
        </tr>
        <tr style="height: 0px">
            <td>
                <br />
                <br />
                <asp:HiddenField ID="HidMode" runat="server" />
                <asp:HyperLink ID="LinkFunction" runat="server" Target="CheckDetail" Width="0px">[LinkFunction]</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C2" runat="Server">
    <cc1:UcButton ID="BtnClose" runat="server" OnClientClick="window.close();" ColumnName="Close"
        Width="70px" />
</asp:Content>
