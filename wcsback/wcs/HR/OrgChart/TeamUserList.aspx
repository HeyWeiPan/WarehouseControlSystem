<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeamUserList.aspx.cs" Inherits="HR_OrgChart_TeamUserList" %>

<%@ Register Src="UcTeamUserList.ascx" TagName="UcTeamUserList" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body style="margin: 0;">
    <form id="form1" runat="server">
        <uc1:UcTeamUserList ID="UcTeamUserList1" runat="server" />
    </form>
</body>
</html>
