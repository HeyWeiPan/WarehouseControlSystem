<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcTopBanner.ascx.cs" Inherits="Home_UcTopBanner" %>
<%@ Register Src="TopLink.ascx" TagName="TopLink" TagPrefix="uc1" %>
<link href="style.css" rel="stylesheet" type="text/css" />
<table width="100%" style="height: 74px; background-image: url(images/index_2.jpg)"
    border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td style="background-image: url(images/index_1_notitle.jpg);" class="img1">
            <table width="100%" style="height: 74px; background-image: url(images/index_3.jpg);"
                border="0" cellpadding="0" cellspacing="0" class="img2">
                <tr>
                    <td style="width: 42%; height: 25px" align="right" valign="top">
                        &nbsp;</td>
                    <td style="width: 58%;" align="right" valign="top">
                        <%--<uc1:TopLink ID="TopLink1" runat="server" />--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right" valign="top" style="padding-right: 10px">
                        <table width="250" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="left">
                                    <%--<img src="images/font.gif">--%>
                                </td>
                                <td align="right">
                                    <asp:ImageButton ID="BtnLogout" ImageUrl="images/button5.cn.gif" BorderStyle="none"
                                        runat="server" OnClick="BtnLogout_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
