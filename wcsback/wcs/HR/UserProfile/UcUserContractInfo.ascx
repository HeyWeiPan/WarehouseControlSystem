<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserContractInfo.ascx.cs"
    Inherits="HR_UserProfile_UcUserContractInfo" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
    <%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>

<table width="100%;height:100%;" style="display: inline; table-layout: fixed;" cellpadding="0"
    cellspacing="0">
    <colgroup>
        <col class="TdLabel" width="120px" />
        <col align="left" />
        <col class="TdLabel" width="120px" />
        <col align="left" />
          <col class="TdLabel" width="120px" />
        <col align="left" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel9" runat="server" ColumnName="contract_company_id"></cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlCompany ID="ddlcontractcompid" RequiredField="true" ColumnName="contract_company_id"
                runat="server" Width="100%">
            </cc2:UcDdlCompany>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel10" runat="server" ColumnName="replace_user_id"></cc1:UcLabel>
        </td>
        <td>
            <cc2:UcWebComboUser ID="WcbReplaceUserID" ColumnName="replace_user_id" Visible="false"
                AutoPostBack="true" runat="server" Width="100%" />
            <cc1:UcTextBox ID="TxtReplaceUserName" runat="server" AllowInsert="False" AllowUpdate="False"
                ReadOnlyWhenInsert="True" ColumnName="replace_user_name" ReadOnlyWhenUpdate="True"
                Width="100%"></cc1:UcTextBox>
        </td>
         <td>
            <cc1:UcLabel ID="UcLabel1" ColumnName="unemployed_num" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtUnemployedNum" ColumnName="unemployed_num" runat="server" Width="100%"></cc1:UcTextBox>
        </td>
    </tr>
</table>