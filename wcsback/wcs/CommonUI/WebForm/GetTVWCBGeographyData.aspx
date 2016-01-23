<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetTVWCBGeographyData.aspx.cs" Inherits="CommonUI_WebForm_GetTVWCBGeographyData" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <cc1:UcTreeView ID="UcTVGeography" runat="server" ExpandLevel="2"></cc1:UcTreeView>
    </form>
</body>
</html>
