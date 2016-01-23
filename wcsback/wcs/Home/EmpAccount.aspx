<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmpAccount.aspx.cs" Inherits="Home_EmpAccount" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib" TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Account of Employee</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="false" EnablePartialRendering="false">
            <Services>
                <asp:ServiceReference Path="WsHome.asmx" />
            </Services>
        </asp:ScriptManager>
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td align="left">
                </td>
                <td align="right">
                </td>
            </tr>
            <tr>
                <td align="center">
                    <span style="font-weight: bold; font-size: 20pt; font-family: 宋体" id="LabAccountOfEmployee"
                        runat="server"></span>
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
                            <td valign="top" colspan="2" style="background-color: #ffffff;">
                                <table cellspacing="2" cellpadding="2" border="0">
                                    <tr>
                                        <td valign="top">
                                            <cc1:UcLabel ID="LabEmployee" runat="server" Text="Employee" ColumnName="Employee" />
                                        </td>
                                        <td valign="top" style="width: 375px">
                                            <cc2:UcWebComboUser ID="ComboUser" Width="100%" runat="server" ColumnName="User_ID"
                                                CssClass="CssRequired" RequiredField="True"></cc2:UcWebComboUser>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <cc1:UcLabel ID="LabAccount" runat="server" Text="Account" ColumnName="Account" />
                                        </td>
                                        <td valign="top" style="width: 375px">
                                            <asp:TextBox ID="TxtAccountName" runat="server" Width="170px" Height="22px" CssClass="CssRequired">
                                            </asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <cc1:UcLabel ID="LabPassword" runat="server" Text="Password" ColumnName="Password" />
                                        </td>
                                        <td valign="top" style="width: 375px">
                                            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" Width="170px" Font-Size="Medium"
                                                Height="22px" CssClass="CssRequired"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <cc1:UcLabel ID="LabConfirmPassword" runat="server" Text="Confirm_Password" ColumnName="Confirm_Password" />
                                        </td>
                                        <td valign="top" align="left" style="width: 375px">
                                            <asp:TextBox ID="TxtConfirmPassword" runat="server" TextMode="Password" Width="170px"
                                                Font-Size="Medium" Height="22px" CssClass="CssRequired"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <cc1:UcLabel ID="LabEMailAddress" runat="server" Text="EMail Address" ColumnName="EMail" />
                                        </td>
                                        <td valign="top" align="left" style="width: 375px">
                                            <asp:TextBox ID="TxtEmailAddress" runat="server" Width="374px" Height="22px">
                                            </asp:TextBox></td>
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
                        OnClick="BtnSave_Click" Enabled="false" />
                </td>
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
