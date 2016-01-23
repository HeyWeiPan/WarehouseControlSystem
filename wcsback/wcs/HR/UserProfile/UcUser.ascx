<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUser.ascx.cs" Inherits="HR_UserProfile_UcUser" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived.HR" Namespace="EntpClass.WebControlLib.Derived.HR"
    TagPrefix="cc3" %>

<script type="text/javascript" language="javascript">
        function refreshImg(img)
        {            
            img.click();
            img.src = img.src + Math.random();
        }
</script>

<table width="100%;height:100%;" style="display: inline; table-layout: fixed; height: 180px;"
    cellpadding="0" cellspacing="0">
    <colgroup>
        <col class="TdLabel" width="120px" />
        <col align="left" />
        <col class="TdLabel" width="120px" />
        <col align="left" />
        <col class="TdLabel" width="200px" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="LabQuockSearch" ColumnName="quick_search" runat="server"></cc1:UcLabel>
            <cc1:UcLabel ID="LabUserNumberTypeName" ColumnName="User_number_type_name" runat="server"></cc1:UcLabel></td>
        <td>
            <cc2:UcWebComboUser ID="WcbSearchUser" AutoPostBack="true" runat="server" Width="100%"
                OnChange="WcbSearchUser_Change" />
            <cc3:UcDdlUserNumberType ID="DrpUserNumberType" runat="server" Width="100%">
            </cc3:UcDdlUserNumberType>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td rowspan="6" align="left" valign="top">
            <img id="Img" runat="server" style="width: 180px; height: 180px;" alt="" src="GetImage.ashx"
                ondblclick="onUploadPhoto();" />
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L1" ColumnName="User_Number" runat="server" /></td>
        <td>
            <cc1:UcTextBox ID="TxtUserNumber" ColumnName="User_Number" Width="100%" runat="server"
                ReadOnlyWhenUpdate="True" RequiredField="True" /></td>
        <td>
            <cc1:UcLabel ID="L4" runat="server" ColumnName="gender"></cc1:UcLabel></td>
        <td>
            <cc2:UcDdlGender ID="DrpGender" runat="server" RequiredField="True" Width="100%">
            </cc2:UcDdlGender>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L3" runat="server" ColumnName="Native_Name"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtNativeName" runat="server" ColumnName="Native_Name" Width="100%"
                RequiredField="True"></cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="LEngFirstName" runat="server" ColumnName="english_name"></cc1:UcLabel></td>
        <td>
            <table width="100%;" style="margin: 0,0,0,0; padding: 0,0,0,0; border: 0,0,0,0; table-layout: fixed;"
                cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <cc1:UcTextBox ID="TxtEngFirstName" RequiredField="True" runat="server" ToolTip="名"
                            ColumnName="eng_first_name" Width="100%"></cc1:UcTextBox></td>
                    <td style="padding-left: 0px;">
                        <cc1:UcTextBox ID="TxtEngMidName" runat="server" ColumnName="eng_mid_name" Width="100%"></cc1:UcTextBox></td>
                    <td>
                        <cc1:UcTextBox ID="TxtEngLastName" RequiredField="True" runat="server" ToolTip="姓"
                            ColumnName="eng_last_name" Width="100%"></cc1:UcTextBox></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel6" runat="server" ColumnName="primary_team_id"></cc1:UcLabel></td>
        <td>
            <cc2:UcTreeWebComboHRTeam ID="TVListPrimaryTeam" RequiredField="True" ColumnName="primary_team_id"
                Width="100%" AllowInsert="False" AllowUpdate="False" Visible="false" runat="server" />
            <cc1:UcTextBox ID="TxtTeamPath" runat="server" AllowInsert="False" AllowUpdate="False"
                ReadOnlyWhenInsert="True" ColumnName="team_path" ReadOnlyWhenUpdate="True" Width="100%"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel1" runat="server" ColumnName="cost_center"></cc1:UcLabel></td>
        <td>
           <%-- <cc3:DdlCostCenter ID="DdlCostCenter" runat="server" Width="100%">
            </cc3:DdlCostCenter>--%>
            <cc1:UcTextBox ID="TxtCostCenter" runat="server" AllowInsert="False" AllowUpdate="False"
                ReadOnlyWhenInsert="True" ColumnName="costcenter_name" ReadOnlyWhenUpdate="True"
                Width="100%"></cc1:UcTextBox></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel8" runat="server" ColumnName="direct_manager_name"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="UcTextBox4" runat="server" AllowInsert="False" AllowUpdate="False"
                ReadOnlyWhenInsert="True" ColumnName="direct_manager_name" ReadOnlyWhenUpdate="True"
                Width="100%"></cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="UcLabel4" runat="server" ColumnName="onboard_date"></cc1:UcLabel></td>
        <td>
            <cc1:UcDatePicker ID="UcDatePicker1" Width="100%" RequiredField="True" ColumnName="onboard_date"
                runat="server"></cc1:UcDatePicker></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L2" runat="server" ColumnName="user_type_id"></cc1:UcLabel></td>
        <td>
            <cc2:UcDdlUserType ID="UcDdlUserType1" RequiredField="True" runat="server" Width="100%">
            </cc2:UcDdlUserType>
        </td>
        <td>
            <cc1:UcLabel ID="UcLabel5" runat="server" ColumnName="user_status_code"></cc1:UcLabel></td>
        <td>
            <cc3:UcDdlUserStatus ID="UcDdlUserStatus1" ColumnName="user_status_code" runat="server"
                RequiredField="True" Width="100%">
            </cc3:UcDdlUserStatus></td>
    </tr>
   
    <tr>
        <td colspan="4">
            &nbsp;
        </td>
        <td align="right">
            <cc1:UcLinkButton ID="LnkUploadPhoto" runat="server" ColumnName="UploadPhoto"></cc1:UcLinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
    </tr>
</table>
<cc1:UcHiddenField ID="HidUserID" ColumnName="user_id" AllowInsert="true" AllowUpdate="false"
    RenderToClient="false" DbDataType="int32" runat="server" />
<cc1:UcHiddenField ID="HidLoginName" ColumnName="Login_name" AllowInsert="true" AllowUpdate="false"
    runat="server" DbDataType="string" RenderToClient="false" />
