<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FunctionDefinitionGetChildNodes.aspx.cs" Inherits="FunctionDefinitionGetChildNodes" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:uctreeview id="UcTreeMenuList" runat="server" expandlevel="1" oncontextmenuclientscript="showContextMenu();"></cc1:uctreeview>
        &nbsp;</div>
    </form>
</body>
</html>
