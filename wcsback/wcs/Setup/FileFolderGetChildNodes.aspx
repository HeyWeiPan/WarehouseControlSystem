<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileFolderGetChildNodes.aspx.cs"
    Inherits="Setup_FileFolderGetChildNodes" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <cc1:UcTreeView ID="Trv1" runat="server" SelectExpands='true' ExpandLevel='2' OnContextMenuClientScript="showContextMenu();"></cc1:UcTreeView>
    </form>
</body>
</html>
