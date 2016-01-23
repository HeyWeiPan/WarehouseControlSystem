<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcUserPay.ascx.cs" Inherits="HR_UserProfile_UcUserPay" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived.HR" Namespace="EntpClass.WebControlLib.Derived.HR"
    TagPrefix="cc3" %>
<table id="tblData" cellspacing="0" cellpadding="0" width="100%" border="0" style="table-layout: fixed;
    height: 50px;">
    <colgroup>
        <col class="TdLabel" width="10%" />
        <col align="left" width="24%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="23%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="23%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="L1" runat="server" ColumnName="payset_name"></cc1:UcLabel>
        </td>
        <td>
            <cc3:UcDdlPaySet ID="DdlPaySet" runat="server" Width="100%">
            </cc3:UcDdlPaySet>
        </td>
        <td>
            <cc1:UcLabel ID="L2" ColumnName="start_date" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcDatePicker ID="D1" runat="server" Width="100%" ColumnName="pay_start_date"
                ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true" AllowInsert="false" AllowUpdate="false"></cc1:UcDatePicker>
        </td>
        <td>
            <cc1:UcLabel ID="L3" ColumnName="end_date" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcDatePicker ID="D2" runat="server" Width="100%" ColumnName="pay_end_date" ReadOnlyWhenInsert="true"
                ReadOnlyWhenUpdate="true" AllowInsert="false" AllowUpdate="false"></cc1:UcDatePicker>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="LblPayCategory" runat="server" ColumnName="pay_category"></cc1:UcLabel></td>
        <td>
            <cc2:UcDdlValue ID="DrpPayCategory" runat="server" Width="100%" ValueSetCode="pay_category"
                ColumnName="pay_category">
            </cc2:UcDdlValue></td>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel1" ColumnName="cost_company_id" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlCompany ID="UcDdlCostCompany2" Width="100%" ColumnName="cost_company_id"
                runat="server">
            </cc2:UcDdlCompany>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel2" ColumnName="tax_company_id" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlCompany ID="UcDdlTaxCompany1" Width="100%" ColumnName="tax_company_id"
                runat="server">
            </cc2:UcDdlCompany></td>
    </tr>
</table>
