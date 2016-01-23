<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapMain.aspx.cs" Inherits="WCS_map_MapMain" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<frameset cols="400,*" frameborder="NO" border="0" framespacing="0" id="MainMap">

    <frame src="MapLeftMenu.aspx" name="leftFrame" frameborder = "0" noresize="true">
     <frameset rows="100,*" cols="*" frameborder="NO" border="0" framespacing="0" id="RightF">
        <frame src="MapTaskTop.aspx" name="TopFrame"  frameborder = "0" >
         <frame src="MapWh.aspx" name="BottomFrame"  frameborder = "0" >
      </frameset>
</frameset>
<noframes>
    <body>
    </body>
</noframes>
</html>
