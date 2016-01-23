<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserFamilyInfo.ascx.cs"
    Inherits="HR_UserProfile_UcUserFamilyInfo" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<table id="tblData" cellspacing="0" cellpadding="0" width="100%" border="0" style="table-layout: fixed;
    height: 100%;">
    <colgroup>
        <col class="TdLabel" width="10%" />
        <col align="left" width="20" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="30%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="20%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel1" runat="server" ColumnName="residence_area"></cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlValue ID="DdlResidenceArea" runat="server" Width="100%" ValueSetCode="RESIDENCE_AREA"
                ColumnName="residence_area">
            </cc2:UcDdlValue>
        </td>
        <td>
            <cc1:UcLabel ID="L1" runat="server" ColumnName="residence_address"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtResidenceAddress" ColumnName="residence_address" runat="server"
                Width="100%">
            </cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L2" runat="server" ColumnName="residence_zip"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtResidenceZip" ColumnName="residence_zip" runat="server" Width="100%">
            </cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L4" runat="server" ColumnName="home_phone"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtHomePhone" ColumnName="home_phone" runat="server" Width="100%">
            </cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L5" runat="server" ColumnName="emergency_contact_name"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtEmergencyContactName" ColumnName="emergency_contact_name" runat="server"
                Width="100%">
            </cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L6" runat="server" ColumnName="emergency_phone"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtEmergencyPhone" ColumnName="emergency_phone" runat="server"
                Width="100%">
            </cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L10" ColumnName="personal_Remark" runat="server">
            </cc1:UcLabel>
        </td>
        <td colspan="5">
            <cc1:UcTextBox ID="TxtPersonalRemark" ColumnName="personal_Remark" Rows="3" runat="server"
                Width="100%" TextMode="MultiLine"></cc1:UcTextBox>
        </td>
    </tr>
</table>
