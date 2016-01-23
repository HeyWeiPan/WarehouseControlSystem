<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleUser.aspx.cs" Inherits="Security_RoleUser" %>

<%@ Register Src="~/Security/UcRoleUser.ascx" TagName="UcRoleUser" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="margin: 0px;">
    <form id="form1" runat="server">
        <uc1:UcRoleUser ID="Uc1" runat="server"></uc1:UcRoleUser>
    </form>
</body>
</html>
