<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetHistroyChildNodes.aspx.cs"
    Inherits="Home_GetHistroyChildNodes" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <cc1:UcTreeView ID="UcTreeList" runat="server"></cc1:UcTreeView>
    </form>
</body>
</html>
