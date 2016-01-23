<%@ Page Title="" Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterSetupDetail.master" AutoEventWireup="true" CodeFile="FloorDetail.aspx.cs" Inherits="WCS_wh_FloorDetail" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table style="table-layout: fixed; width: 100%;">
        <colgroup>
            
            <col width="10%" />
            <col width="15%" />
            <col width="10%" />
            <col width="15%" />
            <col width="10%" />
            <col width="15%" />
            <col width="10%" />
            <col width="15%" />
        </colgroup>
        <tr>
            <td>
                <cc1:UcLabel ID="Lb1" runat="server" ColumnName="floor_num"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtCode" runat="server" ColumnName="floor_num" Width="100%" RequiredField="true" DbDataType="Int32"></cc1:UcTextBox>

            </td>
            <td>
                <cc1:UcLabel ID="UcLabel1" runat="server" ColumnName="floor_code"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox1" runat="server" ColumnName="floor_code" Width="100%" RequiredField="true"></cc1:UcTextBox>

            </td>
            <td>
                <cc1:UcLabel ID="UcLabel8" runat="server" ColumnName="floor_description"></cc1:UcLabel>
            </td>
            <td colspan="3">
                <cc1:UcTextBox ID="UcTextBox7" runat="server" ColumnName="floor_description" Width="100%"></cc1:UcTextBox>

            </td>
        </tr>


    </table>

    <table style="width: 100%; table-layout: fixed; margin: 10px,0,0,0; padding: 0,0,0,0; border: 0 0 0 0;"
        cellpadding="0" cellspacing="0">
        <tr style="height: 20px;">
            <td>
                <cc1:UcHyperLink ID="LnkCell" runat="server" ColumnName="TabCell" ShowStyle="TabBlue"
                    Target="IfraSubWindow">
                </cc1:UcHyperLink>
            </td>
        </tr>
        <tr align="left" valign="top" id="TabIfra" runat="server" style="display: inline;">
            <td valign="top" class="ContainerBorder" style="margin: 0,0,0,0; padding: 0,0,0,0;">
                <iframe style="width: 100%; background-color: #EBF2FC;" frameborder="0"
                    runat="server" scrolling="auto" name="IfraSubWindow" id="IfraSubWindow"></iframe>
            </td>
        </tr>
    </table>


</asp:Content>

