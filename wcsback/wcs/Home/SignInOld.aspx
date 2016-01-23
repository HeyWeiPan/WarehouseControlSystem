<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignInOld.aspx.cs" Inherits="Home_SignIn" %>

<%@ Register Src="UcTopTitle.ascx" TagName="UcTopTitle" TagPrefix="uc2" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Src="TopLink.ascx" TagName="TopLink" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignIn Page</title>
    <link href="../Home/mainframe.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
    <!--
    if (top.location != self.location)
    {
    top.location = self.location;
    }
    //-->
    </script>

    <link href="../Home/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc2:UcTopTitle ID="UcTopTitle1" runat="server" />
        <table width="100%" style="height: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="80" valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="images/index_2.jpg">
                        <tr>
                            <td background="images/login_top.jpg" class="img1">
                                <table width="100%" height="80" border="0" cellpadding="0" cellspacing="0" background="images/index_3.jpg"
                                    class="img2">
                                    <tr>
                                        <td width="42%" height="35" align="right" valign="top">
                                           
                                        </td>
                                        <td width="58%" align="right" valign="top">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="right" valign="top" style="padding-right: 100px">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" background="images/login-middle.jpg" bgcolor="#FFFFFF" class="img1">
                    <table width="420" height="280" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="center" valign="bottom" background="images/login_win.gif">
                                <cc1:UcLogin ID="L1" runat="server" DestinationPageUrl="~/Default.aspx" OnValidateNumAuthenticate="L1_ValidateNumAuthenticate"
                                    OnLoggingIn="L1_LoggingIn">
                                    <LayoutTemplate>
                                        <table width="380px" border="0" cellspacing="0" cellpadding="0" valign="bottom">
                                            <colgroup>
                                                <col width="80px" style="padding-left: 45px;" />
                                                <col width="230px" style="padding-left: 5px;" />
                                                <col width="70px" />
                                            </colgroup>
                                            <tr style="display: inline;">
                                                <td style="height: 16px;" class="bold1">
                                                    <cc1:UcLabel ID="UserNameLabel" runat="server" ColumnName="UserName" ResourceFileType="UI"
                                                        AssociatedControlID="UserName" Width="73" CssClass="bold1" />
                                                </td>
                                                <td valign="middle" style="height: 16px; width: 290px;">
                                                    <asp:TextBox ID="UserName" runat="server" CssClass="input_login" TabIndex="10" Width="90%"></asp:TextBox><asp:RequiredFieldValidator
                                                        ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required."
                                                        ToolTip="User Name is required." ValidationGroup="Login1">*
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 16px;" class="bold1">
                                                    <cc1:UcLabel ID="PasswordLabel" runat="server" ColumnName="Password" ResourceFileType="UI"
                                                        AssociatedControlID="Password" Width="100%" CssClass="bold1" />
                                                </td>
                                                <td valign="middle" style="height: 16px; width: 290px;">
                                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="input_login"
                                                        TabIndex="11" Width="90%"></asp:TextBox><asp:RequiredFieldValidator ID="PasswordRequired"
                                                            runat="server" ControlToValidate="Password" ErrorMessage="Password is required."
                                                            ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator></td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <cc1:UcLabel ID="ValidateNumLbl" runat="server" AssociatedControlID="ValidateNum"
                                                        ColumnName="ValidateNum" ResourceFileType="UI" CssClass="bold1" Width="100%"
                                                        Visible="False" />
                                                </td>
                                                <td style="width: 290px">
                                                    <asp:TextBox ID="ValidateNum" runat="server" CssClass="input_login" MaxLength="4"
                                                        TabIndex="12" Visible="False" Width="90%"></asp:TextBox><asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="ValidateNum" ErrorMessage="ValidateNum is required."
                                                            ToolTip="ValidateNum is required." ValidationGroup="Login1" Visible="False">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <cc1:UcValidateNum ID="UcValidateNum1" runat="server" Visible="False">
                                                    </cc1:UcValidateNum>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px">
                                                </td>
                                                <td valign="top" style="height: 22px; width: 290px;">
                                                    <asp:RadioButton ID="RadChinese" runat="server" GroupName="language" Text="中文" Width="66px"
                                                        Checked="True" />
                                                    <asp:RadioButton ID="RadEnglish" runat="server" GroupName="language" Text="English"
                                                        Width="82px" />
                                                </td>
                                                <td valign="top" style="width: 111px; height: 24px;">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 20%">
                                                </td>
                                                <td colspan="2" class="bold1">
                                                    <asp:CheckBox ID="RememberMe" Visible="false" runat="server" Text="Remember me next time." />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 40px;">
                                                </td>
                                                <td style="height: 40px;" valign="middle" colspan="2">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ImageUrl="Images/login_btn1.gif" ID="LoginButton" CommandName="Login"
                                                                    Width="74px" Height="25px" runat="server" ValidationGroup="Login1" TabIndex="13" />
                                                            </td>
                                                            <td>
                                                                <%-- <a href="ForgetPassword.aspx" style="text-decoration: underline;">Forget Password</a>                                                --%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr id="trBlank" runat="server">
                                                <td colspan="3" style="height: 15px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 15px;" class="bold1">
                                                    &nbsp;</td>
                                                <td colspan="2" style="height: 15px">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </cc1:UcLogin>
                            </td>
                           
                        </tr>
                       <%-- <tr style="height: 50px;">
                        </tr>--%>
                         
                        <tr >
                            <td valign="middle"> 
                            <div  style="width:80%; text-align:center; margin-top:15px">
                                <a><img src="Notification/images/new.gif"/></a>
                                <a href="Downloads/IE浏览器的设置.doc" style="text-decoration: underline;">IE浏览器的设置</a>
                            </div> 
                            </td>
                        </tr>
                        </table>

                </td>
            </tr>
            <tr>
                <td height="60" align="center" valign="bottom">
                    <table width="98%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="1" colspan="2" bgcolor="#999999">
                            </td>
                        </tr>
                        <tr>
                            <td class="black1" align="left">
                                &copy; 2008 EntpClass</td>
                            <td class="padding_content">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
