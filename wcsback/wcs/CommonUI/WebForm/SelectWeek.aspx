<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectWeek.aspx.cs" Inherits="CommonUI_WebForm_SelectWeek" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SelectWeek</title>

    <script language="javascript" type="text/javascript">
		<!--
		
		// 选择了某个周。
		
		function SelectClick(textbox, valuebox, weektext, weekvalue, datevalue)
		{
		    if (window.opener == null)
			{
				window.close();
				return;
			}
			if (textbox != "")
			{
				window.opener.document.all(textbox).value = weektext;
				window.opener.document.all(textbox).title = datevalue;
			}
			if (valuebox != "")
			{
				window.opener.document.all(valuebox).value = weekvalue;
			}
			window.close();
			window.opener.focus();
		}
		
		//-->
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="1">
                <tr>
                    <td>
                        <table id="Table2" style="background-color: #66BBFF" cellspacing="0" cellpadding="0"
                            width="100%" border="0">
                            <tr>
                                <td align="center" width="30">
                                    <asp:LinkButton ID="btnPrev" runat="server" OnClick="btnPrev_Click"><</asp:LinkButton></td>
                                <td align="center">
                                    <asp:Label ID="lblYear" runat="server">2007</asp:Label></td>
                                <td align="center" width="30">
                                    <asp:LinkButton ID="btnNext" runat="server" OnClick="btnNext_Click">></asp:LinkButton></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table id="Table3" cellspacing="0" cellpadding="0" width="100%" border="1">
                            <colgroup>
                                <col style="background-color: #DDDDDD" />
                                <col />
                                <col />
                                <col />
                                <col />
                                <col />
                                <col />
                            </colgroup>
                            <tr style="background-color: #DDDDDD">
                                <td align="center" width="20">
                                    &nbsp;</td>
                                <td align="center">
                                    <asp:Label ID="lblMonth1" runat="server">1月</asp:Label></td>
                                <td align="center">
                                    <asp:Label ID="lblMonth2" runat="server">2月</asp:Label></td>
                                <td align="center">
                                    <asp:Label ID="lblMonth3" runat="server">3月</asp:Label></td>
                                <td align="center">
                                    <asp:Label ID="lblMonth4" runat="server">4月</asp:Label></td>
                                <td align="center">
                                    <asp:Label ID="lblMonth5" runat="server">5月</asp:Label></td>
                                <td align="center">
                                    <asp:Label ID="lblMonth6" runat="server">6月</asp:Label></td>
                            </tr>
                            <tr>
                                <td align="center" width="20">
                                    1</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek11" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek21" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek31" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek41" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek51" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek61" runat="server">1.</asp:LinkButton>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="height: 18px" align="center" width="20">
                                    2</td>
                                <td style="height: 18px" align="center">
                                    <asp:LinkButton ID="lnkWeek12" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td style="height: 18px" align="center">
                                    <asp:LinkButton ID="lnkWeek22" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td style="height: 18px" align="center">
                                    <asp:LinkButton ID="lnkWeek32" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td style="height: 18px" align="center">
                                    <asp:LinkButton ID="lnkWeek42" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td style="height: 18px" align="center">
                                    <asp:LinkButton ID="lnkWeek52" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td style="height: 18px" align="center">
                                    <asp:LinkButton ID="lnkWeek62" runat="server">1.</asp:LinkButton>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="height: 17px" align="center" width="20">
                                    3</td>
                                <td style="height: 17px" align="center">
                                    <asp:LinkButton ID="lnkWeek13" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td style="height: 17px" align="center">
                                    <asp:LinkButton ID="lnkWeek23" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td style="height: 17px" align="center">
                                    <asp:LinkButton ID="lnkWeek33" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td style="height: 17px" align="center">
                                    <asp:LinkButton ID="lnkWeek43" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td style="height: 17px" align="center">
                                    <asp:LinkButton ID="lnkWeek53" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td style="height: 17px" align="center">
                                    <asp:LinkButton ID="lnkWeek63" runat="server">1.</asp:LinkButton>&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" width="20">
                                    4</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek14" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek24" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek34" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek44" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek54" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek64" runat="server">1.</asp:LinkButton>&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" width="20">
                                    5</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek15" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek25" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek35" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek45" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek55" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek65" runat="server">1.</asp:LinkButton>&nbsp;</td>
                            </tr>
                            <tr style="background-color: #DDDDDD">
                                <td align="center" width="20">
                                    &nbsp;</td>
                                <td align="center">
                                    <asp:Label ID="lblMonth7" runat="server">7月</asp:Label></td>
                                <td align="center">
                                    <asp:Label ID="lblMonth8" runat="server">8月</asp:Label></td>
                                <td align="center">
                                    <asp:Label ID="lblMonth9" runat="server">9月</asp:Label></td>
                                <td align="center">
                                    <asp:Label ID="lblMonth10" runat="server">10月</asp:Label></td>
                                <td align="center">
                                    <asp:Label ID="lblMonth11" runat="server">11月</asp:Label></td>
                                <td align="center">
                                    <asp:Label ID="lblMonth12" runat="server">12月</asp:Label></td>
                            </tr>
                            <tr>
                                <td align="center" width="20">
                                    1</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek71" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek81" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek91" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek101" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek111" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek121" runat="server">1.</asp:LinkButton>&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" width="20">
                                    2</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek72" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek82" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek92" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek102" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek112" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek122" runat="server">1.</asp:LinkButton>&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" width="20">
                                    3</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek73" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek83" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek93" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek103" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek113" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek123" runat="server">1.</asp:LinkButton>&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" width="20">
                                    4</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek74" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek84" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek94" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek104" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek114" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek124" runat="server">1.</asp:LinkButton>&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" width="20">
                                    5</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek75" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek85" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek95" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek105" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek115" runat="server">1.</asp:LinkButton>&nbsp;</td>
                                <td align="center">
                                    <asp:LinkButton ID="lnkWeek125" runat="server">1.</asp:LinkButton>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="td1" align="center">
                        <asp:LinkButton ID="lnkClear" runat="server">Clear</asp:LinkButton></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
