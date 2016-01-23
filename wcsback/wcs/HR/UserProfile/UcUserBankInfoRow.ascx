<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserBankInfoRow.ascx.cs"
    Inherits="HR_UserProfile_UcUserBankInfoRow" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived.HR" Namespace="EntpClass.WebControlLib.Derived.HR"
    TagPrefix="cc3" %>
<table id="tblData" cellspacing="0" cellpadding="0" width="100%" border="0" style="table-layout: fixed;">
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
            <cc1:UcLabel ID="UcLabel1" runat="server" ColumnName="BANK_NAME"></cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlValue ID="DdlBankName" runat="server" Width="100%" ValueSetCode="USER_BANK_NAME"
                RequiredField="true" ColumnName="BANK_NAME">
            </cc2:UcDdlValue>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel4" runat="server" ColumnName="branch_bank_name"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtBranchBankName" ColumnName="branch_bank_name" runat="server" Width="100%">
            </cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel3" runat="server" ColumnName="bankcard_usetype"></cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlValue ID="DdlBankCardUseType" runat="server" Width="100%" ValueSetCode="bankcard_usetype"
                RequiredField="true" ColumnName="bankcard_usetype">
            </cc2:UcDdlValue>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L1" runat="server" ColumnName="BANKBOOK_ACCOUNT"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtBankBookAccount" ColumnName="BANKBOOK_ACCOUNT" runat="server"
                Width="100%">
            </cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L2" ColumnName="BANKCARD_ACCOUNT" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtBankCardAccount" ColumnName="BANKCARD_ACCOUNT" runat="server"
                Width="100%">
            </cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel2" ColumnName="BANKCARD_CODE" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtBankcardCode" ColumnName="BANKCARD_CODE" runat="server" Width="100%">
            </cc1:UcTextBox>
        </td>
    </tr>
</table>
<cc1:UcHiddenField ID="HidUserID" ColumnName="USER_ID" runat="server" />
