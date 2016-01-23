<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserSalary.ascx.cs"
    Inherits="HR_UserProfile_UcUserSalary" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<table id="tblData" cellspacing="0" cellpadding="0" width="100%" border="0" style="table-layout: fixed;
    height: 100%;">
    <colgroup>
        <col class="TdLabel" width="16%" />
        <col align="left" width="11%" />
        <col class="TdLabel" width="16%" />
        <col align="left" width="11%" />
        <col class="TdLabel" width="11%" />
        <col align="left" width="10%" />
        <col class="TdLabel" width="11%" />
        <col align="left" width="14%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel1" ColumnName="SOCIAL_INSURANCE_GEO_ID" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc2:UcTreeWebComboGeography ID="WcbSocialInsuranceGeoID" runat="server" ColumnName="SOCIAL_INSURANCE_GEO_ID"
                Width="100%" />
            <cc1:UcTextBox ID="TxtSocialInsuranceGeoName" ReadOnlyWhenInsert="false" ReadOnlyWhenUpdate="false"
                AllowInsert="true" AllowUpdate="true" runat="server" ColumnName="SOCIAL_INSURANCE_GEO_name"
                Width="100%"></cc1:UcTextBox>
        </td>
        <td colspan="2" style="padding-left: 0px; margin-left: 0px">
            <cc1:UcTextBox ID="TxSocialInsurancePlace" ReadOnlyWhenInsert="false" ReadOnlyWhenUpdate="false"
                runat="server" ColumnName="SOCIAL_INSURANCE_Place" Width="100%"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L5" ColumnName="SOCIAL_INSURANCE_ACCOUNT" runat="server">                
            </cc1:UcLabel>
        </td>
        <td colspan="3">
            <cc1:UcTextBox ID="TxtSocialInsuranceAccount" runat="server" Width="100%" ColumnName="SOCIAL_INSURANCE_ACCOUNT"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L4" ColumnName="SOCIAL_INSURANCE_DATE" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcDatePicker ID="DpkSIDate" runat="server" Width="100%" ColumnName="SOCIAL_INSURANCE_DATE"></cc1:UcDatePicker>
        </td>
        <td>
            <cc1:UcLabel ID="L6" ColumnName="SOCIAL_INSURANCE_DATE_COMPANY" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcDatePicker ID="DpkSIDateCompany" runat="server" Width="100%" ColumnName="SOCIAL_INSURANCE_DATE_COMPANY"></cc1:UcDatePicker>
        </td>
        <td>
            <cc1:UcLabel ID="L7" ColumnName="SOCIAL_INSURANCE_BASIC_AMOUNT" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtSIBasicAmount" runat="server" Width="100%" ColumnName="SOCIAL_INSURANCE_BASIC_AMOUNT"
                DbDataType="Decimal"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel7" ColumnName="social_insurance_company_id" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlCompany ID="DdlSICompanyID" ColumnName="social_insurance_company_id" Width="100%"
                runat="server">
            </cc2:UcDdlCompany>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel2" ColumnName="HOUSING_FUND_GEO_ID" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc2:UcTreeWebComboGeography ID="WcbHousingFundGeoID" runat="server" ColumnName="HOUSING_FUND_GEO_ID"
                Width="100%" />
            <cc1:UcTextBox ID="TxtHousingFundGeoName" ReadOnlyWhenInsert="false" ReadOnlyWhenUpdate="false"
                AllowInsert="true" AllowUpdate="true" runat="server" ColumnName="HOUSING_FUND_GEO_name"
                Width="100%"></cc1:UcTextBox>
        </td>
        <td colspan="2" style="padding-left: 0px; margin-left: 0px">
            <cc1:UcTextBox ID="TxtHousingFundPlace" ReadOnlyWhenInsert="false" ReadOnlyWhenUpdate="false"
                runat="server" ColumnName="HOUSING_FUND_Place" Width="100%"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="Uclabel3" ColumnName="HOUSING_FUND_ACCOUNT" runat="server">                
            </cc1:UcLabel>
        </td>
        <td colspan="3">
            <cc1:UcTextBox ID="TxtHousingFundAccount" runat="server" Width="100%" ColumnName="HOUSING_FUND_ACCOUNT"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="Uclabel4" ColumnName="HOUSING_FUND_DATE" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcDatePicker ID="DtpHousingFundDate" runat="server" Width="100%" ColumnName="HOUSING_FUND_DATE"></cc1:UcDatePicker>
        </td>
        <td>
            <cc1:UcLabel ID="Uclabel5" ColumnName="HOUSING_FUND_DATE_COMPANY" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcDatePicker ID="DtpHousingFundDateCmp" runat="server" Width="100%" ColumnName="HOUSING_FUND_DATE_COMPANY"></cc1:UcDatePicker>
        </td>
        <td>
            <cc1:UcLabel ID="Uclabel6" ColumnName="HOUSING_FUND_BASIC_AMOUNT" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtHousingFundBasicAmount" runat="server" Width="100%" ColumnName="HOUSING_FUND_BASIC_AMOUNT"
                DbDataType="Decimal"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel8" ColumnName="housing_fund_company_id" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlCompany ID="UcDdlHousingFundCompany" ColumnName="housing_fund_company_id"
                Width="100%" runat="server">
            </cc2:UcDdlCompany>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel9" ColumnName="salary_remark" runat="server">
            </cc1:UcLabel></td>
        <td colspan="7">
            <cc1:UcTextBox ID="TxtSalaryRemark" runat="server" Width="100%" ColumnName="salary_remark"
                TextMode="MultiLine" Rows="3"></cc1:UcTextBox>
        </td>
    </tr>
</table>
