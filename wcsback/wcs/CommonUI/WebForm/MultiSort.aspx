<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterDetail.master" AutoEventWireup="true" CodeFile="MultiSort.aspx.cs" Inherits="CommonUI_WebForm_MultiSort" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>

<asp:Content ID="C1" ContentPlaceHolderID="C1" runat="Server">
    <table style="width: 100%; height: 100%; table-layout: fixed;">
        <colgroup>
            <col width="39%" />
            <col width="12%" />
            <col width="49%" />
        </colgroup>
        <tr>
            <td valign="top">
                <asp:ListBox ID="listAllSortColumn" style="margin-top:20px; margin-left:40px;" 
                    runat="server" Width="140px" Height="277px" />
            </td>
            <td style="text-align:center;">
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="=&gt;" Width="49px" />
                <br />
                <asp:Button ID="btnRemoveAll" runat="server" Text="&lt;=" onclick="btnRemove_Click" Width="49px" />
            </td>
            <td valign="top">
                <div style="border: solid 1px black; height:260px; margin-top:20px; margin-left:20px;">
                    <asp:Repeater ID="repeaterSort" runat="server">
                        <ItemTemplate>
                            <table style="font-size: 9pt; width:100%; table-layout:fixed;">
                                <tr>
                                    <td style="width:50%">
                                        <asp:Label ID="lblSort" runat="server" ToolTip='<%# DataBinder.Eval(Container.DataItem, "SortColumnValue") %>'
                                            Text='<%# DataBinder.Eval(Container.DataItem, "SortColumn") %>' />
                                    </td>
                                    <td style="width:25%">
                                        <cc1:UcRadioButton ID="radUp" Checked='<%# DataBinder.Eval(Container.DataItem, "Up") %>'
                                            GroupName="sort" runat="server" Text="asc" ToolTip="asc" />
                                    </td>
                                    <td style="width:25%">
                                        <asp:RadioButton ID="radDown" Checked='<%# DataBinder.Eval(Container.DataItem, "Down") %>'
                                            GroupName="sort" runat="server" Text="desc" ToolTip="desc" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="C2" runat="Server">
    <cc1:UcButton ID="BtnOK" runat="server" Width="60px" ColumnName="Search" OnClick="BtnOK_Click">
    </cc1:UcButton>
    <cc1:UcButton ID="BtnCancel" runat="server" Width="60px" ColumnName="Cancel" OnClientClick="window.close();">
    </cc1:UcButton>
</asp:Content>
