<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TCPTest.aspx.cs" Inherits="WCS_TCPTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="TxtReceive"  runat="server" Width="500px" TextMode="MultiLine" Rows="5"></asp:TextBox>
     <asp:Button ID="BtnClick" runat="server" Text="Click" />
    </div>
    </form>
</body>
</html>
