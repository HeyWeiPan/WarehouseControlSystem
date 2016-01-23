<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserContact.ascx.cs"
    Inherits="HR_UserProfile_UcUserContact" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<table id="tblData" cellspacing="0" cellpadding="0" width="100%" border="0" style="table-layout: fixed;
    height: 100%;">
    <colgroup>
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="L1" runat="server" ColumnName="site_id"></cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlSite ID="DrpSite" runat="server" Width="100%" RequiredField="True">
            </cc2:UcDdlSite></td>
        <td>
            <cc1:UcLabel ID="L2" ColumnName="phone" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtSitePhone" ColumnName="site_phone" AllowUpdate="false" AllowInsert="false"
                ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true" runat="server" Width="70%"></cc1:UcTextBox><cc1:UcTextBox
                    ID="TxtPhoneExt" ColumnName="phone_ext" runat="server" Width="29%"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L3" ColumnName="direct_line" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtDirectLine" ColumnName="direct_line" runat="server" Width="100%">
            </cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="L9" ColumnName="office_mobile" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtOfficeMobile" ColumnName="office_mobile" runat="server" Width="100%">
            </cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L5" ColumnName="Site_address" runat="server">
            </cc1:UcLabel>
        </td>
        <td colspan="3">
            <cc1:UcTextBox ID="TxtSiteAddress" ColumnName="Site_address" runat="server" Width="100%"
                ReadOnlyWhenInsert="True" ReadOnlyWhenUpdate="True" AllowInsert="false" AllowUpdate="false"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L6" ColumnName="zip_code" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtSiteZipCode" ColumnName="site_zip_code" runat="server" Width="100%"
                ReadOnlyWhenInsert="True" ReadOnlyWhenUpdate="True" AllowInsert="false" AllowUpdate="false"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L4" ColumnName="fax" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtFax" ColumnName="fax" runat="server" Width="100%">
            </cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L8" ColumnName="Company_Email" runat="server">
            </cc1:UcLabel>
        </td>
        <td colspan="3">
            <cc1:UcTextBox ID="TxtCompEmail" ColumnName="Company_Email" runat="server" Width="100%">
            </cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel1" ColumnName="personal_Email" runat="server">
            </cc1:UcLabel>
        </td>
        <td colspan="3">
            <cc1:UcTextBox ID="TxtPersonalEmail" ColumnName="personal_Email" runat="server" Width="100%">
            </cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L10" ColumnName="Remark" runat="server">
            </cc1:UcLabel>
        </td>
        <td colspan="7">
            <cc1:UcTextBox ID="TxtRemark" ColumnName="Remark" Rows="3" runat="server" Width="100%"
                TextMode="MultiLine"></cc1:UcTextBox>
        </td>
    </tr>
</table>
