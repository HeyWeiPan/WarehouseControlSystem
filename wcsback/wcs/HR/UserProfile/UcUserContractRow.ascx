<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserContractRow.ascx.cs"
    Inherits="HR_UserProfile_UcUserContractRow" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived.HR" Namespace="EntpClass.WebControlLib.Derived.HR"
    TagPrefix="cc3" %>
<table id="tblData" cellspacing="0" cellpadding="0" width="100%" border="0">
    <colgroup>
        <col class="TdLabel" width="10%" />
        <col align="left" width="14%" />
        <col class="TdLabel" width="13%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="14%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="14%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel3" runat="server" ColumnName="contract_num"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="UcTextBox1" ColumnName="contract_num" runat="server" AllowInsert="true"
                AllowUpdate="false" ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true" InsertExpression="'TMP0001'"
                Width="100%">
            </cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L2" runat="server" ColumnName="user_type_id"></cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlUserType ID="UcDdlUserType1" runat="server" RequiredField="True" Width="100%">
            </cc2:UcDdlUserType>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel5" runat="server" ColumnName="user_status_code"></cc1:UcLabel>
        </td>
        <td>
            <cc3:UcDdlUserStatus ID="UcDdlUserStatus1" ColumnName="user_status_code" runat="server"
                RequiredField="True" Width="100%">
            </cc3:UcDdlUserStatus>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel12" runat="server" ColumnName="hr_service_month"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtHRServiceYear" ColumnName="hr_service_month" ReadOnlyWhenInsert="true"
                ReadOnlyWhenUpdate="true" AllowInsert="false" AllowUpdate="false" runat="server"
                Width="100%">
            </cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel1" runat="server" ColumnName="contract_start_date"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcDatePicker ID="DtpContractStartDate" ColumnName="contract_start_date" runat="server"
                Width="100%" RequiredField="true"></cc1:UcDatePicker>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel10" runat="server" ColumnName="CONTRACT_NOENDDATE_FLAG"></cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlYesNo ID="DrpNoEndDateFlag" Width="100%" runat="server" ColumnName="CONTRACT_NOENDDATE_FLAG"
                DefaultValue="0" AutoPostBack="true" OnSelectedIndexChanged="UcDdlYesNo1_SelectedIndexChanged"
                RequiredField="True">
            </cc2:UcDdlYesNo>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel11" ColumnName="contract_month" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtContractMonth" ColumnName="contract_month" RequiredField="true"
                runat="server" Width="100%" DbDataType="Int32"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel2" ColumnName="contract_end_date" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcDatePicker ID="DtpContractEndDate" runat="server" ColumnName="contract_end_date"
                ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true" Width="100%"></cc1:UcDatePicker>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel4" ColumnName="probation_month" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="UcTextBox4" ColumnName="probation_month" runat="server" Width="100%"
                DbDataType="Int32"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel6" ColumnName="probation_end_date" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcDatePicker ID="UcDatePicker1" runat="server" ColumnName="probation_end_date"
                ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true" Width="100%"></cc1:UcDatePicker>
        </td>
        <td>
            <cc1:UcLabel ID="L3" ColumnName="contract_company_id" runat="server">
            </cc1:UcLabel>
        </td>
        <td colspan="3">
            <cc2:UcDdlCompany ID="DrpCompanyID" RequiredField="true" ColumnName="contract_company_id"
                runat="server" Width="100%">
            </cc2:UcDdlCompany>
            <cc1:UcTextBox ID="TxtCompanyName" ColumnName="contract_company_name" runat="server"
                Width="100%"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel9" ColumnName="remark" runat="server">
            </cc1:UcLabel>
        </td>
        <td colspan="7">
            <cc1:UcTextBox ID="UcTextBox3" ColumnName="remark" runat="server" Width="100%" Rows="3"
                TextMode="MultiLine"></cc1:UcTextBox>
        </td>
    </tr>
</table>
<cc1:UcHiddenField ID="HidUserID" ColumnName="USER_ID" runat="server" />
