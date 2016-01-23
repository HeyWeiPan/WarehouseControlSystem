<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserScope.ascx.cs" Inherits="HR_UserProfile_UcUserScope" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived.HR" Namespace="EntpClass.WebControlLib.Derived.HR"
    TagPrefix="cc3" %>
<div style="text-align: center;">
    <table style="width: 100%; height: 100%; table-layout: fixed;">
        <colgroup>
            <col width="17%" class="TdLabel" />
            <col width="33%" />
            <col width="17%" class="TdLabel" />
            <col width="33%" />
        </colgroup>
        <tr>
            <td>
                <cc1:UcLabel ID="LabUserNumber" runat="server" ColumnName="user_select"></cc1:UcLabel></td>
            <td colspan="3">
                <cc2:UcWebComboUser ID="WcbUser" runat="server" Width="100%" ColumnName="user_id"
                    IncludeInactiveUser="True" />
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel6" runat="server" ColumnName="primary_team_id"></cc1:UcLabel></td>
            <td colspan="3">
                <cc2:UcTreeWebComboHRTeam ID="TVListTeam" runat="server" Width="100%" ColumnName="user_id"
                    SearchFormat="{0} in (select user_id from hr_team_user where primary_Flag = -1 and delete_flag = 0 and team_id in ( select team_id from hr_team where delete_flag = 0 and lineage like HR.GetTeamLineage({1})  + '%') )"
                    SearchType="Custom" />
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="LabNativeName" runat="server" ColumnName="Native_Name"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="TxtNativeName" runat="server" ColumnName="Native_Name" Width="100%"
                    SearchType="Like"></cc1:UcTextBox></td>
            <td>
                <cc1:UcLabel ID="LE" runat="server" ColumnName="english_name"></cc1:UcLabel></td>
            <td>
                <table cellpadding="0" cellspacing="0" style="border-right: 0px; table-layout: fixed;
                    padding-right: 0px; border-top: 0px; padding-left: 0px; padding-bottom: 0px;
                    margin: 0px; border-left: 0px; padding-top: 0px; border-bottom: 0px" width="100%">
                    <tr>
                        <td>
                            <cc1:UcTextBox ID="TxtEngFirstName" runat="server" ColumnName="eng_first_name" SearchType="LikeAndCaseInsensitive"
                                Width="100%"></cc1:UcTextBox></td>
                        <td style="padding-left: 0px">
                            <cc1:UcTextBox ID="TxtEngMidName" runat="server" ColumnName="eng_mid_name" SearchType="LikeAndCaseInsensitive"
                                Width="100%"></cc1:UcTextBox></td>
                        <td>
                            <cc1:UcTextBox ID="TxtEngLastName" runat="server" ColumnName="eng_last_name" SearchType="LikeAndCaseInsensitive"
                                Width="100%"></cc1:UcTextBox></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel3" runat="server" ColumnName="user_number"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="UcTextBox3" runat="server" ColumnName="user_number" Width="100%"
                    SearchType="likeAndCaseInsensitive"></cc1:UcTextBox></td>
            <td>
                <cc1:UcLabel ID="UcLabel4" runat="server" ColumnName="cost_center"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="UcTextBox2" runat="server" ColumnName="user_id" Width="100%" SearchType="custom"
                    SearchFormat="hr.GetUserCostCenter({0})='{1}'"></cc1:UcTextBox></td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="LGender" runat="server" ColumnName="gender"></cc1:UcLabel></td>
            <td>
                <cc2:UcDdlGender ID="DrpGender" runat="server" Width="100%">
                </cc2:UcDdlGender></td>
            <td>
                <cc1:UcLabel ID="POM" runat="server" ColumnName="office_mobile"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="TxtOfficeMobile" runat="server" ColumnName="office_mobile" Width="100%"
                    SearchType="Like"></cc1:UcTextBox></td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="L10" runat="server" ColumnName="user_status"></cc1:UcLabel></td>
            <td>
                <cc3:UcDdlUserStatus ID="DrpUserStatus" runat="server" Width="100%">
                </cc3:UcDdlUserStatus></td>
            <td>
                <cc1:UcLabel ID="LUserType" runat="server" ColumnName="user_type_id"></cc1:UcLabel></td>
            <td>
                <cc2:UcDdlUserType ID="UcDdlUserType1" runat="server" Width="100%">
                </cc2:UcDdlUserType></td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel9" runat="server" ColumnName="contract_company_id"></cc1:UcLabel></td>
            <td>
                <cc2:UcDdlCompany ID="UcDdlCompany2" ColumnName="contract_company_id" runat="server"
                    Width="100%">
                </cc2:UcDdlCompany></td>
            <td>
                <cc1:UcLabel ID="UcLabel2" ColumnName="site_id" runat="server">
                </cc1:UcLabel></td>
            <td>
                <cc2:UcDdlSite ID="UcDdlSite1" runat="server" Width="100%">
                </cc2:UcDdlSite></td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel1" runat="server" ColumnName="COMPANY_Email"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="UcTextBox1" runat="server" ColumnName="COMPANY_Email" Width="100%"
                    SearchType="LikeAndCaseInsensitive"></cc1:UcTextBox></td>
            <td>
                <cc1:UcLabel ID="L" runat="server" ColumnName="enable_flag"></cc1:UcLabel></td>
            <td>
                <cc2:UcDdlYesNo ID="DrpEnableFlag" ColumnName="enable_flag" runat="server" Width="100%">
                </cc2:UcDdlYesNo>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="L7" runat="server" ColumnName="onboard_date"></cc1:UcLabel>
            </td>
            <td colspan="3">
                <cc1:UcLabel ID="L71" runat="server" ColumnName="From"></cc1:UcLabel>
                <cc1:UcDatePicker ID="Dtp71" runat="server" ColumnName="onboard_date" SearchType="EqualOrMoreThan"
                    DbDataType="Date" Width="150px"></cc1:UcDatePicker>
                <cc1:UcLabel ID="L72" runat="server" ColumnName="To"></cc1:UcLabel>
                <cc1:UcDatePicker ID="Dtp72" runat="server" ColumnName="onboard_date" SearchType="EqualOrLessThan"
                    DbDataType="Date" Width="150px"></cc1:UcDatePicker>
            </td>
        </tr>
    </table>
</div>
