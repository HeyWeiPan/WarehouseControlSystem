<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserPersonalInfo.ascx.cs"
    Inherits="HR_UserProfile_UcUserPersonalInfo" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<table id="tblData" cellspacing="0" cellpadding="0" width="100%" border="0" style="table-layout: fixed;
    height: 100%;">
    <colgroup>
        <col class="TdLabel" width="10%" />
        <col align="left" width="14%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="16%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="14%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="16%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="L1" runat="server" ColumnName="nationality_name"></cc1:UcLabel></td>
        <td>
            <cc2:UcDdlNationality ID="DrpNationality" runat="server" Width="100%" NationalityCode="Nationality"
                ColumnName="nationality_id" DataValueField="national_id">
            </cc2:UcDdlNationality></td>
        <td>
            <cc1:UcLabel ID="UcLabel5" ColumnName="folkishness" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc2:UcDdlValue ID="UcDdlfolkishness" runat="server" Width="100%" ValueSetCode="NATIONALITY"
                ColumnName="folkishness">
            </cc2:UcDdlValue></td>
        <td>
            <cc1:UcLabel ID="UcLabel1" ColumnName="native_place" runat="server">
            </cc1:UcLabel></td>
        <td>
            <%--<cc1:UcTextBox ID="TxtNativePlace" runat="server" Width="100%" ColumnName="native_place"></cc1:UcTextBox>--%>
            <cc2:UcTreeWebComboGeography ID="WcbNativePlaceGeoID" runat="server" ColumnName="Native_Place_Geo_ID"
                Width="100%" />
            <cc1:UcTextBox ID="TxtNativePlaceGeoName" ReadOnlyWhenInsert="false" ReadOnlyWhenUpdate="false"
                AllowInsert="true" AllowUpdate="true" runat="server" ColumnName="Native_Place_Geo_Name"
                Width="100%"></cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="L3" ColumnName="marry_type" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc2:UcDdlValue ID="DrpMarryType" runat="server" Width="100%" ValueSetCode="MARRY_TYPE"
                ColumnName="marry_type">
            </cc2:UcDdlValue></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L4" ColumnName="birthday" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcDatePicker ID="DpkBirthday" runat="server" Width="100%" ColumnName="birthday"></cc1:UcDatePicker></td>
        <td>
            <cc1:UcLabel ID="UcLabel2" ColumnName="Age" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtAge" runat="server" Width="100%" ReadOnlyWhenInsert="true"
                ReadOnlyWhenUpdate="true" AllowInsert="false" AllowUpdate="false" ColumnName="Age"></cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="UcLabel9" ColumnName="birth_place_geo_id" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc2:UcTreeWebComboGeography ID="WcbBirthPlaceGeoID" runat="server" ColumnName="birth_place_geo_id"
                Width="100%" />
            <cc1:UcTextBox ID="TxtBirthPlaceGeoName" ReadOnlyWhenInsert="false" ReadOnlyWhenUpdate="false"
                AllowInsert="true" AllowUpdate="true" runat="server" ColumnName="birth_place_geo_name"
                Width="100%"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L5" ColumnName="idcard_num" runat="server">                
            </cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtIdCardNum" runat="server" Width="100%" ColumnName="idcard_num"></cc1:UcTextBox></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L14" ColumnName="height" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtHeight" runat="server" Width="100%" ColumnName="height"></cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="L15" ColumnName="user_weight" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtWeight" runat="server" Width="100%" ColumnName="weight"></cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="UcLabel3" ColumnName="HEALTH_CONDITION" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc2:UcDdlValue ID="UcDdlValue2" runat="server" Width="100%" ValueSetCode="HEALTH"
                ColumnName="HEALTH_CONDITION">
            </cc2:UcDdlValue></td>
        <td>
            <cc1:UcLabel ID="L8" ColumnName="highest_educational_background" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc2:UcDdlValue ID="DrpEducationalBackground" runat="server" Width="100%" ValueSetCode="EDUCATIONAL_BACKGROUND"
                ColumnName="highest_educational_background">
            </cc2:UcDdlValue></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L10" ColumnName="political" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc2:UcDdlValue ID="DrpPolitical" runat="server" Width="100%" ValueSetCode="POLITICAL"
                ColumnName="political">
            </cc2:UcDdlValue></td>
        <td>
            <cc1:UcLabel ID="UcLabel4" ColumnName="YOUTH_LEAGUE_JOIN_DATE" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcDatePicker ID="DtpYouthLeague" runat="server" Width="100%" ColumnName="YOUTH_LEAGUE_JOIN_DATE"></cc1:UcDatePicker></td>
        <td>
            <cc1:UcLabel ID="L11" ColumnName="political_join_date" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcDatePicker ID="DpkPoliticalJoinDate" runat="server" Width="100%" ColumnName="political_join_date"></cc1:UcDatePicker></td>
        <td>
            <cc1:UcLabel ID="L9" ColumnName="highest_ACADEMIC_DEGREE" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc2:UcDdlValue ID="DrpDegree" runat="server" Width="100%" ValueSetCode="ACADEMIC_DEGREE"
                ColumnName="highest_ACADEMIC_DEGREE">
            </cc2:UcDdlValue></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel7" ColumnName="PASSPORT" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtPassport" runat="server" Width="100%" ColumnName="PASSPORT"></cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="UcLabel8" ColumnName="PASSPORT_expire_date" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcDatePicker ID="TxtPassportExpireDate" runat="server" Width="100%" ColumnName="PASSPORT_expire_date"></cc1:UcDatePicker></td>
        <td>
            <cc1:UcLabel ID="L12" ColumnName="residence_permit_number" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtResidencePermitNumber" runat="server" Width="100%" ColumnName="residence_permit_number"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L13" ColumnName="residence_permit_expire_date" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcDatePicker ID="DpkResidencePermitExpireDate" runat="server" Width="100%" ColumnName="residence_permit_expire_date"></cc1:UcDatePicker>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L6" ColumnName="hukou_place" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc2:UcTreeWebComboGeography ID="WcbHukouGeoID" runat="server" ColumnName="HUKOU_GEO_ID"
                Width="100%" />
            <cc1:UcTextBox ID="TxtHuKouGeoName" ReadOnlyWhenInsert="false" ReadOnlyWhenUpdate="false"
                AllowInsert="true" AllowUpdate="true" runat="server" ColumnName="HUKOU_GEO_Name"
                Width="100%"></cc1:UcTextBox>
        </td>
        <td colspan="4" style="padding-left: 0px; margin-left: 0px">
            <cc1:UcTextBox ID="TxtHuKouPlace" ReadOnlyWhenInsert="false" ReadOnlyWhenUpdate="false"
                runat="server" ColumnName="HUKOU_PLACE" Width="100%"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel11" ColumnName="hukou_type" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc2:UcDdlValue ID="UcDdlValue1" runat="server" Width="100%" ValueSetCode="hukou_type"
                ColumnName="hukou_type">
            </cc2:UcDdlValue></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel6" ColumnName="PERSONAL_FILE_PLACE" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc2:UcTreeWebComboGeography ID="WcbPersonalFileGeoID" runat="server" ColumnName="PERSONAL_FILE_GEO_ID"
                Width="100%" />
            <cc1:UcTextBox ID="TxtPersonalFileGeoName" ReadOnlyWhenInsert="false" ReadOnlyWhenUpdate="false"
                AllowInsert="true" AllowUpdate="true" runat="server" ColumnName="PERSONAL_FILE_GEO_NAME"
                Width="100%"></cc1:UcTextBox>
        </td>
        <td colspan="2" style="padding-left: 0px; margin-left: 0px">
            <cc1:UcTextBox ID="TxtPersonalFilePlace" ReadOnlyWhenInsert="false" ReadOnlyWhenUpdate="false"
                runat="server" ColumnName="PERSONAL_FILE_PLACE" Width="100%"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel12" ColumnName="drive_liscence_type" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc2:UcDdlValue ID="DdlDriveLiscenceType" runat="server" Width="100%" ValueSetCode="drive_liscence_type"
                ColumnName="drive_liscence_type">
            </cc2:UcDdlValue></td>
        <td>
            <cc1:UcLabel ID="UcLabel13" ColumnName="drive_liscence_date" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcDatePicker ID="DtDriveLiscenceDate" runat="server" Width="100%" ColumnName="drive_liscence_date"></cc1:UcDatePicker></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel10" ColumnName="hr_Remark" runat="server">
            </cc1:UcLabel>
        </td>
        <td colspan="7">
            <cc1:UcTextBox ID="TxtHRRemark" ColumnName="hr_Remark" Rows="3" runat="server" Width="100%"
                TextMode="MultiLine"></cc1:UcTextBox>
        </td>
    </tr>
</table>
