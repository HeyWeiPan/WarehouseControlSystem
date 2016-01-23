<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Home_ChangePassword" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Password</title>
</head>
<body>
    <form id="form1" runat="server">
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td align="left">
                </td>
                <td align="right">
                </td>
            </tr>
            <tr>
                <td>
                    <span id="LabChangePassword" runat="server" style="font-weight: bold; font-size: 20pt;
                        color: red; font-family: 宋体"></span>
                </td>
                <td align="right">
                </td>
            </tr>
            <tr style="height: 50px;">
                <td align="left">
                </td>
                <td align="right">
                </td>
            </tr>
        </table>
        <table cellspacing="3" style="width: 70%;" border="0" align="center">
            <tr style="background-color: #000000;">
                <td>
                    <table cellspacing="0" cellpadding="7" width="100%" border="0">
                        <tr>
                            <td colspan="2" style="background-color: #dddddd;">
                                <b><span class="parahead1"></span></b>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" colspan="2" style="background-color: #ffffff;">
                                <table cellspacing="2" cellpadding="2" border="0">
                                    <tr>
                                        <td valign="top">
                                            <cc1:UcLabel ID="LabAccount" runat="server" Text="Account" ColumnName="Account" />
                                        </td>
                                        <td valign="top">
                                            <cc1:UcTextBox ID="TxtUserName" runat="server" ReadOnly="True" Width="170px" Height="22px"></cc1:UcTextBox></td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <cc1:UcLabel ID="LabOldPassword" runat="server" Text="Old_Password" ColumnName="Old_Password" />
                                        </td>
                                        <td valign="top">
                                            <cc1:UcTextBox ID="TxtOldPassword" runat="server" TextMode="Password" Width="170px"
                                                Font-Size="Medium" Height="22px" RequiredField="true"></cc1:UcTextBox></td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <cc1:UcLabel ID="LabPassword" runat="server" Text="New Password" ColumnName="New_Password" />
                                        </td>
                                        <td valign="top">
                                            <cc1:UcTextBox ID="TxtPassword" runat="server" TextMode="Password" Width="170px"
                                                Font-Size="Medium" RequiredField="true" Height="22px"></cc1:UcTextBox></td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <cc1:UcLabel ID="LabConfirmPassword" runat="server" Text="Confirm_Password" ColumnName="Confirm_Password" />
                                        </td>
                                        <td valign="top" align="left">
                                            <cc1:UcTextBox ID="TxtConfirmPassword" runat="server" TextMode="Password" Width="170px"
                                                RequiredField="true" Font-Size="Medium" Height="22px"></cc1:UcTextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table cellspacing="4" cellpadding="8" align="center" border="0">
            <tr>
                <td align="left" style="background-color: #ffffff;">
                    <cc1:UcButton ID="BtnSave" runat="server" ColumnName="Save" Width="70px" UseSubmitBehavior="False"
                        OnClick="BtnSave_Click" Enabled="false" /></td>
            </tr>
            <tr>
                <td style="font-size: 9pt; color: red; font-family: 宋体" align="center">
                    <span id="errorMsg" runat="server"></span>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
