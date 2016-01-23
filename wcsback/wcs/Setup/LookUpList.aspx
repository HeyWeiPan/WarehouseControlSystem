<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LookUpList.aspx.cs" Inherits="Setup_LookUpList" %>

<%@ Register Src="UcLookUpList.ascx" TagName="UcLookUpList" TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server" style="margin:0 0 0 0; padding:0 0 0 0; border:0 0 0 0;">
        <uc1:UcLookUpList ID="UcLookUpList1" runat="server" />
    </form>
</body>
</html>
