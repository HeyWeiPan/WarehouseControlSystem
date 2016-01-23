<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrafficControl.aspx.cs" Inherits="WCS_TrafficControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="BtnCommon" runat="server" Width="100px" Text="普通模式" />&nbsp;
        <asp:Button ID="BtnLoop" runat="server" Width="100px" Text="循环模式" />&nbsp;
        <asp:Button ID="BtnSpecial" runat="server" Width="100px" Text="专车" />&nbsp;
        <asp:Button ID="BtnHand" runat="server" Width="100px" Text="手动" />&nbsp;
    </div>
    </form>
</body>
</html>
