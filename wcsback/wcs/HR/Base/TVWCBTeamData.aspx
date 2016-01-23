<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TVWCBTeamData.aspx.cs" Inherits="HR_Base_TVWCBTeamData" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:UcTreeView ID="UcTVTeam" runat="server" ExpandLevel="2"></cc1:UcTreeView>
    
    </div>
    </form>
</body>
</html>
