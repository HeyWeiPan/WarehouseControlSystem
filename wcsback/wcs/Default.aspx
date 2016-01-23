<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<frameset id="a" rows="95,*" cols="*" frameborder="NO" border="0" framespacing="0">
  <frame src="Home/TopWindow.aspx" name="topFrame" scrolling="NO">
  <frameset id="b" rows="*" cols="0,*" framespacing="1" frameborder="no" border="0">
    <frame src="Home/LeftWindow.aspx" name="leftFrame" scrolling="NO"  >
    <frameset id="c" rows="0,*"  frameborder="NO" border="0" framespacing="0"> 
        <frame src="blank.htm" name="MainWindow">
        <frame src="Public/Home.aspx" name="HomeWindow">
    </frameset>
  </frameset>
</frameset>
<noframes>
    <body>
    </body>
</noframes>
</html>
