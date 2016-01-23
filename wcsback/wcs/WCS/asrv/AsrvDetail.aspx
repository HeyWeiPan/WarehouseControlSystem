<%@ Page Title="" Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterSetupDetail.master"
    AutoEventWireup="true" CodeFile="AsrvDetail.aspx.cs" Inherits="WCS_asrv_AsrvDetail" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="~/Setup/WsSetup.asmx" />
        </Services>
    </asp:ScriptManager>
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
                <cc1:UcLabel ID="Lb1" runat="server" ColumnName="asrv_code"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtCode" runat="server" ColumnName="asrv_code" Width="100%" RequiredField="true"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel3" runat="server" ColumnName="wh_code"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcDropDownList ID="DdlWh" runat="server" Width="100%" IsInsertItem="true" RequiredField="true"
                    SqlText="select wh_id,wh_code+'--'+wh_name wh_code from wcs_wh where enable_flag=-1"
                    DataValueField="wh_id" DataTextField="wh_code" ColumnName="wh_id" AutoBindData="true"
                    OnClientChange="SetWhChange(this);">
                </cc1:UcDropDownList>
                <cc1:UcLinkButton ID="LnkWh" runat="server" Font-Size="13px" ForeColor="Blue"></cc1:UcLinkButton>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel20" runat="server" ColumnName="rack_direction"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtRack" runat="server" ColumnName="rack_direction" Width="100%"
                    ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true" ClientIDMode="Static"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel1" runat="server" ColumnName="enter_direction"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcDropDownList ID="UcDropDownList1" runat="server" Width="100%" RequiredField="true"
                    ColumnName="enter_direction">
                    <asp:ListItem Value="" Text=""></asp:ListItem>
                    <asp:ListItem Value="1" Text="正方向"></asp:ListItem>
                    <asp:ListItem Value="0" Text="负方向"></asp:ListItem>
                </cc1:UcDropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel2" runat="server" ColumnName="xf_1"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtXF1" runat="server" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"
                    Width="100%" ColumnName="xf_1"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel4" runat="server" ColumnName="xb_1"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox1" runat="server" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"
                    Width="100%" ColumnName="xb_1"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel5" runat="server" ColumnName="yf_1"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox2" runat="server" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"
                    Width="100%" ColumnName="yf_1"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel6" runat="server" ColumnName="yb_1"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox3" runat="server" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"
                    Width="100%" ColumnName="yb_1"></cc1:UcTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel8" runat="server" ColumnName="xf_2"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox4" runat="server" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"
                    Width="100%" ColumnName="xf_2"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel9" runat="server" ColumnName="xb_2"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox5" runat="server" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"
                    Width="100%" ColumnName="xb_2"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel10" runat="server" ColumnName="yf_2"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox6" runat="server" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"
                    Width="100%" ColumnName="yf_2"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel11" runat="server" ColumnName="yb_2"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox7" runat="server" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"
                    Width="100%" ColumnName="yb_2"></cc1:UcTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel12" runat="server" ColumnName="xf_3"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox8" runat="server" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"
                    Width="100%" ColumnName="xf_3"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel13" runat="server" ColumnName="xb_3"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox9" runat="server" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"
                    Width="100%" ColumnName="xb_3"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel14" runat="server" ColumnName="yf_3"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox10" runat="server" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"
                    Width="100%" ColumnName="yf_3"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel15" runat="server" ColumnName="yb_3"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox11" runat="server" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"
                    Width="100%" ColumnName="yb_3"></cc1:UcTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel16" runat="server" ColumnName="xf_4"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox12" runat="server" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"
                    Width="100%" ColumnName="xf_4"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel17" runat="server" ColumnName="xb_4"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox13" runat="server" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"
                    Width="100%" ColumnName="xb_4"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel18" runat="server" ColumnName="yf_4"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox14" runat="server" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"
                    Width="100%" ColumnName="yf_4"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel19" runat="server" ColumnName="yb_4"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox15" runat="server" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"
                    Width="100%" ColumnName="yb_4"></cc1:UcTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel22" runat="server" ColumnName="battery_type"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox16" runat="server" Width="100%" ColumnName="battery_type"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel23" runat="server" ColumnName="acp_ah"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox17" runat="server" Width="100%" ColumnName="acp_ah"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel24" runat="server" ColumnName="discharge_v"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox18" runat="server" Width="100%" ColumnName="discharge_v"
                    DbDataType="Int32"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel25" runat="server" ColumnName="charging_v"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox19" runat="server" Width="100%" ColumnName="charging_v"
                    DbDataType="Int32"></cc1:UcTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel21" runat="server" ColumnName="mac_adress"></cc1:UcLabel>
            </td>
            <td colspan="7">
                <cc1:UcTextBox ID="TxtMac" runat="server" ColumnName="mac_adress" Width="100%" RequiredField="true"></cc1:UcTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel26" runat="server" ColumnName="x_num"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox20" runat="server" Width="100%" ColumnName="x_num" DbDataType="Int32"
                    RequiredField="true"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel27" runat="server" ColumnName="y_num"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox21" runat="server" Width="100%" ColumnName="y_num" DbDataType="Int32"
                    RequiredField="true"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel28" runat="server" ColumnName="floor_num"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="UcTextBox22" runat="server" Width="100%" ColumnName="floor_num"
                    DbDataType="Int32" RequiredField="true"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="UcLabel7" runat="server" ColumnName="enable_flag"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcCheckBox ID="CbEnable" runat="server" ColumnName="enable_Flag" />
            </td>
        </tr>
    </table>
    <table style="width: 100%; table-layout: fixed; margin: 10px,0,0,0; padding: 0,0,0,0;
        border: 0 0 0 0;" cellpadding="0" cellspacing="0">
        <tr style="height: 20px;">
            <td>
                <cc1:UcHyperLink ID="LnkAsrvPic" runat="server" ColumnName="TabAsrvPic" ShowStyle="TabBlue"
                    Target="IfraSubWindow" ClientIDMode="Static">
                </cc1:UcHyperLink>
                <cc1:UcHyperLink ID="LnkAsrvStatus" runat="server" ColumnName="TabAsrvStatus" ShowStyle="TabBlue"
                    Target="IfraSubWindow">
                </cc1:UcHyperLink>
                <cc1:UcHiddenField ID="HidSelectedTab" runat="server" RenderToClient="true"></cc1:UcHiddenField>
            </td>
        </tr>
        <tr align="left" valign="top" id="TabIfra" runat="server" style="display: inline;">
            <td valign="top" class="ContainerBorder" style="margin: 0,0,0,0; padding: 0,0,0,0;">
                <iframe style="width: 100%; background-color: #EBF2FC; height: 350px;" frameborder="0"
                    runat="server" scrolling="auto" name="IfraSubWindow" id="IfraSubWindow"></iframe>
            </td>
        </tr>
    </table>
    <script type="text/javascript">

        function SetWhChange(DdlWh) {
            var whId = DdlWh.options[DdlWh.selectedIndex].value;

            WsSetup.GetWhRack(whId, SetRack, f_wserror);
        }

        function SetRack(result) {
            var rack = document.getElementById("TxtRack");
            rack.value = result;

            var lnkPic = document.getElementById("LnkAsrvPic");
            lnkPic.href = "AsrvPic.aspx?Rack=" + result

            lnkPic.click();
        }





    </script>
</asp:Content>
