<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetReport.aspx.cs" Inherits="CommonUI_WebForm_GetReport" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report</title>
    <link href="~/CommonUI/MasterPage/MasterMainWindow.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="display: inline; width: 100%; height: 100%; table-layout: fixed;">
                <tr style="height: 40px;">
                    <td valign="middle">
                        <table class="TbTitle" border="0" cellspacing="0" cellpadding="0">
                            <tr class="TbTitleR1">
                                <td align="left" valign="middle">
                                    <asp:Label ID="LblTitle" CssClass="PageTitle" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr class="TbTitleR2">
                                <td style="height: 4px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <%--   <tr>
                    <td>
                        <iframe runat="server" id="IfraSubWindow" style="width: 100%; height: 100%;"></iframe>
                    </td>
                </tr>--%>
            </table>
        </div>
    </form>
</body>
</html>
