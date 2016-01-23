<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DialogFrame.aspx.cs" Inherits="DialogFrame" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin: 0;">
    <iframe src="<%=Request.Params["DialogUrl"] %>" id="DialogWindow" width="100%" height="100%"
        frameborder="0" scrolling="no"></iframe>
</body>
</html>
