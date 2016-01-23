<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterMainWindow.master"
    AutoEventWireup="true" CodeFile="CacheList.aspx.cs" Inherits="CacheList"
    Title="Untitled Page" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Cache Key"></asp:Label>
    <asp:TextBox ID="TxtKey" runat="server" Width="150px"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="Cache Value"></asp:Label>
    <asp:TextBox ID="TxtValue" runat="server" Width="150px"></asp:TextBox>
    <asp:Button ID="BtnRefresh" runat="server" Text="Search" Width="80px" OnClick="BtnRefresh_Click" /><asp:Button
        ID="BtnDeleteList" runat="server" Text="Delete" Width="80px" OnClick="BtnDeleteList_Click" /><asp:Button
            ID="BtnRemove" runat="server" Text="Delete All" Width="80px" Style="margin-left: 20px"
            OnClick="BtnRemove_Click" /><br />
    <br />
    <cc1:UcGridView ID="GrdList" runat="server" AutoGenerateColumns="False" Width="100%"
        OnClientRowDblClick="" AllowPaging="True" OnPageIndexChanging="GrdList_PageIndexChanging"
        DataKeyNames="CacheKey" OnRowDeleting="GrdList_RowDeleting" ShowNoRecordsMessage="True">
        <columns>
                <asp:CommandField ShowDeleteButton="True" >
                    <headerstyle width="10%" />
                </asp:CommandField>
                        <asp:BoundField DataField="CacheKey" HeaderText="CacheKey" HtmlEncode="False">                            
                        </asp:BoundField>                        
                        <asp:BoundField DataField="CacheValue" HeaderText="CacheValue" HtmlEncode="False">
                        </asp:BoundField>    
						</columns>
    </cc1:UcGridView>
</asp:Content>
