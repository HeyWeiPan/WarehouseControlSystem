<%@ Page Language="C#" AutoEventWireup="false" CodeFile="Home.aspx.cs" Inherits="Home" %>

<%@ Register Src="~/Home/UcTopTitle.ascx" TagName="UcTopTitle" TagPrefix="uc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="Home/style.css" rel="stylesheet" type="text/css" />
    <link href="Home/mainframe.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc2:UcTopTitle ID="UcTopTitle1" runat="server" />
        <table width="100%" style="height: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="80" valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="Home/images/index_2.jpg">
                        <tr>
                            <td background="Home/images/login_top.jpg" class="img1">
                                <table width="100%" height="80" border="0" cellpadding="0" cellspacing="0" background="Home/images/index_3.jpg"
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
                <td align="center" background="Home/images/login-middle.jpg" bgcolor="#FFFFFF" class="img1">
                    <table width="420" height="232" cellpadding="0" cellspacing="0" style="border:0 0 0 0;">
                        <tr>
                            <td align="center" valign="middle" background="images/login_win.gif">
                                <span style="font-size: large"><a href="/jrjxc/Default.aspx">久瑞进销存</a></span><br />
                                <span style="font-size: large"><a href="/rbjxc/Default.aspx">瑞北进销存</a></span>
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
