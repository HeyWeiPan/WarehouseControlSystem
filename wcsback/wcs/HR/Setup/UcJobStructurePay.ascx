<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcJobStructurePay.ascx.cs"
    Inherits="HR_Setup_UcJobStructurePay" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived.HR" Namespace="EntpClass.WebControlLib.Derived.HR"
    TagPrefix="cc3" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
    <Services>
        <asp:ServiceReference Path="../WsHR.asmx" />
    </Services>
</asp:ScriptManager>

<script type="text/javascript">
function setPay(payGrade)
{
    if(payGrade == ""){
        onSetPay("<NewDataSet><Table></Table></NewDataSet>");
        return;
    }
    WsHR.GetPayStructureXml(payGrade,onSetPay,f_wserror);
}    
</script>

<table style="width: 100%; display: inline; table-layout: fixed; margin: 0 0 0 0;
    padding: 0 0 0 0;" cellpadding="0" cellspacing="0">
    <colgroup>
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="8%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="8%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="L7" runat="server" ColumnName="pay_grade"></cc1:UcLabel></td>
        <td>
            <cc3:DdlPayStructure ID="DdlPayGrade" runat="server" Width="100%" OnClientChange="setPay(this.options(this.selectedIndex).value);return false;">
            </cc3:DdlPayStructure>
            <cc1:UcTextBox ID="TxtPayGrade" runat="server" ColumnName="pay_grade" Width="100%"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L8" runat="server" ColumnName="pay_min"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtPayMin" runat="server" Width="100%" ColumnName="pay_min" DbDataType="int32"
                ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"></cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="L9" runat="server" ColumnName="pay_mid"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtPayMid" runat="server" Width="100%" ColumnName="pay_mid" DbDataType="int32"
                ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L10" runat="server" ColumnName="pay_max"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtPayMax" runat="server" Width="100%" ColumnName="pay_max" DbDataType="int32"
                ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true"></cc1:UcTextBox>
        </td>
    </tr>
</table>
