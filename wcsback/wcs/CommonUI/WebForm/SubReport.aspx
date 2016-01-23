<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubReport.aspx.cs" Inherits="Jxc_Report_SubReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:UcDropDownList ID="DdlExportType" runat="server"  AutoBindData="false" SqlText="">           
            <asp:ListItem Value="EXCEL">EXCEL</asp:ListItem>
            <asp:ListItem Value="WORD">WORD</asp:ListItem>
            <asp:ListItem Value="PDF">PDF</asp:ListItem>
        </cc1:UcDropDownList>
        <cc1:UcButton ID="btnExport" runat="server" onclick="btnExport_Click" Text="导出" />
    </div>
    </form>
</body>
</html>
