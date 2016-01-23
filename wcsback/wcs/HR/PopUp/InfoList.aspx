<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterDetail.master"
    AutoEventWireup="true" CodeFile="InfoList.aspx.cs" Inherits="HR_PopUp_InfoList"
    Title="Untitled Page" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table id="tabMain" style="font-size: 9pt; font-family: 宋体; width: 100%; height: 24px;
        table-layout: fixed;">
        <colgroup>
            <col class="TdLabel" width="10%" />
            <col align="left" width="40%" />
            <col class="TdLabel" width="10%" />
            <col align="left" width="40%" />
        </colgroup>
        <tr>
            <td colspan="4">
                <cc1:UcGridView ID="GVInfoList" runat="server" AutoGenerateColumns="False" Width="100%"
                    DataKeyNames="line" ShowNoRecordsMessage="True">
                    <Columns>
                        <asp:BoundField DataField="description" HeaderText="description" />
                    </Columns>
                </cc1:UcGridView>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C2" runat="Server">
    <table class="BottomCTb" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <cc1:UcLabel ID="LblInfo" runat="server" />
            </td>
            <td align="right">
                <cc1:UcButton ID="BtnClose" runat="server" OnClientClick="window.returnValue ='closed';window.close();return false;"
                    ColumnName="OK" Width="56px" />
            </td>
        </tr>
    </table>
</asp:Content>
