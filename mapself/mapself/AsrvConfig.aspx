<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsrvConfig.aspx.cs" Inherits="mapself.AsrvConfig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>配置界面</title>
</head>
<body>
    <form id="form1" runat="server">
        <a href="Default.aspx">返回模拟界面</a>
    <div id="config">
    <span style="font-size:large;color:blue;">小车固定参数</span><br />
        货道单位距离：
        <asp:TextBox ReadOnly="true" ID="hdDistance" runat="server" Text="38.1972" Width="50px"></asp:TextBox>r
        <br />
        巷道单位距离：
        <asp:TextBox ReadOnly="true" ID="xdDistance" runat="server" Text="61.9693" Width="50px"></asp:TextBox>r
        <br />
        空载时最大速度：
        <asp:TextBox ReadOnly="true" ID="emptyMaxSpeed" runat="server" Text="50" Width="50px"></asp:TextBox>r/s
        <br />
        载货时最大速度：
        <asp:TextBox ReadOnly="true" ID="FullMaxSpeed" runat="server" Text="31.5" Width="50px"></asp:TextBox>r/s
        <br /><br /><br />

        <span style="font-size:large;color:blue;">配置小车移动参数</span><br />
        加速度：
        <asp:TextBox ID="addSpeed" runat="server" Text="15" Width="50px"></asp:TextBox>r/s2
        <br />
        第一减速度：
        <asp:TextBox ID="reduceSpeed1" runat="server" Text="30" Width="50px"></asp:TextBox>r/s2
        <br />
        第二减速度：
        <asp:TextBox ID="reduceSpeed2" runat="server" Text="30" Width="50px"></asp:TextBox>r/s2
        <br />
        第三减速度：
        <asp:TextBox ID="reduceSpeed3" runat="server" Text="30" Width="50px"></asp:TextBox>r/s2
        <br /><br /><br />
    </div>
    </form>
</body>
</html>
