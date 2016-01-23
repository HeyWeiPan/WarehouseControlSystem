<%@ Page Title="" Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterSetupDetail.master" AutoEventWireup="true" CodeFile="WHDetail.aspx.cs" Inherits="WCS_wh_WHDetail" %>


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
                <cc1:UcLabel ID="Lb1" runat="server" ColumnName="wh_code"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtCode" runat="server" ColumnName="wh_code" Width="100%" RequiredField="true"></cc1:UcTextBox>

            </td>
            <td>
                <cc1:UcLabel ID="UcLabel1" runat="server" ColumnName="wh_name"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox1" runat="server" ColumnName="wh_name" Width="100%" RequiredField="true"></cc1:UcTextBox>

            </td>
            <td>
                <cc1:UcLabel ID="UcLabel3" runat="server" ColumnName="rack_margin"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox2" runat="server" ColumnName="rack_margin" Width="100%" DbDataType="Int32" RequiredField="true"></cc1:UcTextBox>

            </td>
            <td>
                <cc1:UcLabel ID="UcLabel2" runat="server" ColumnName="aisle_margin"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox3" runat="server" ColumnName="aisle_margin" Width="100%" DbDataType="Int32" RequiredField="true"></cc1:UcTextBox>

            </td>
        </tr>
        <tr>

            <td>
                <cc1:UcLabel ID="UcLabel4" runat="server" ColumnName="cell_width"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox4" runat="server" ColumnName="cell_width" Width="100%" DbDataType="Int32" RequiredField="true"></cc1:UcTextBox>

            </td>
            <td>
                <cc1:UcLabel ID="UcLabel5" runat="server" ColumnName="cell_depth"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox5" runat="server" ColumnName="cell_depth" Width="100%" DbDataType="Int32" RequiredField="true"></cc1:UcTextBox>

            </td>
            <td>
                <cc1:UcLabel ID="UcLabel6" runat="server" ColumnName="cell_margin"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox6" runat="server" ColumnName="cell_margin" Width="100%" DbDataType="Int32" RequiredField="true"></cc1:UcTextBox>

            </td>
            <td>
                <cc1:UcLabel ID="UcLabel12" runat="server" ColumnName="rack_direction"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcDropDownList ID="DdlRack" runat="server" Width="100%" ColumnName="rack_direction" RequiredField="true">
                    <asp:ListItem Value="" Text=""></asp:ListItem>
                    <asp:ListItem Value="x" Text="x"></asp:ListItem>
                    <asp:ListItem Value="y" Text="y"></asp:ListItem>
                </cc1:UcDropDownList>

            </td>

        </tr>
        <tr>

            <td>
                <cc1:UcLabel ID="UcLabel8" runat="server" ColumnName="x_num_from"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox7" runat="server" ColumnName="x_num_from" Width="100%" DbDataType="Int32" RequiredField="true"></cc1:UcTextBox>

            </td>
            <td>
                <cc1:UcLabel ID="UcLabel9" runat="server" ColumnName="x_num_to"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox8" runat="server" ColumnName="x_num_to" Width="100%" DbDataType="Int32" RequiredField="true"></cc1:UcTextBox>

            </td>
            <td>
                <cc1:UcLabel ID="UcLabel10" runat="server" ColumnName="y_num_from"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox9" runat="server" ColumnName="y_num_from" Width="100%" DbDataType="Int32" RequiredField="true"></cc1:UcTextBox>

            </td>
            <td>
                <cc1:UcLabel ID="UcLabel11" runat="server" ColumnName="y_num_to"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox10" runat="server" ColumnName="y_num_to" Width="100%" DbDataType="Int32" RequiredField="true"></cc1:UcTextBox>

            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel13" runat="server" ColumnName="ip_adress"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox11" runat="server" ColumnName="ip_adress" Width="100%" RequiredField="true"></cc1:UcTextBox>

            </td>
            <td>
                <cc1:UcLabel ID="UcLabel14" runat="server" ColumnName="port"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox12" runat="server" ColumnName="port" Width="100%" DbDataType="Int32" RequiredField="true"></cc1:UcTextBox>

            </td>
            
            <td>
                <cc1:UcLabel ID="UcLabel7" runat="server" ColumnName="enable_flag"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcCheckBox ID="CbEnable" runat="server" ColumnName="enable_Flag" />

            </td>

        </tr>

    </table>

    <table style="width: 100%; table-layout: fixed; margin: 10px,0,0,0; padding: 0,0,0,0; border: 0 0 0 0;"
        cellpadding="0" cellspacing="0">
        <tr style="height: 20px;">
            <td>
                <cc1:UcHyperLink ID="LnkFloor" runat="server" ColumnName="TabFloor" ShowStyle="TabBlue"
                    Target="IfraSubWindow">
                </cc1:UcHyperLink>
                <cc1:UcHyperLink ID="LnkLift" runat="server" ColumnName="TabLift" ShowStyle="TabBlue"
                    Target="IfraSubWindow">
                </cc1:UcHyperLink>
                <cc1:UcHyperLink ID="LnkAsrv" runat="server" ColumnName="TabAsrv" ShowStyle="TabBlue"
                    Target="IfraSubWindow">
                </cc1:UcHyperLink>
                <cc1:UcHiddenField ID="HidSelectedTab" runat="server" RenderToClient="true"></cc1:UcHiddenField>
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

