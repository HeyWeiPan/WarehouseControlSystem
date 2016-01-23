<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="mapself.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>模拟界面</title>
    
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">

        var timeStop;
        function xxx()
        {

            var DdlFloor = document.getElementById("DdlFloorNum");
            var DdlWh = document.getElementById("DdlWh");

            var selectFloor = DdlFloor.options[DdlFloor.selectedIndex].value;
            var selectWh = DdlWh.options[DdlWh.selectedIndex].value;


            var http = new ActiveXObject("Microsoft.XMLHTTP");
            http.open("Get", "gethtml.aspx?WhId=" + selectWh + "&FloorNum=" + selectFloor, false);
            http.send();
            document.getElementById("newTable").innerHTML = http.responseText;

            
        }

        function yyy()
        {

            document.getElementById("test").value = testNum;
            testNum++;
            var DdlFloor = document.getElementById("DdlFloorNum");
            var DdlWh = document.getElementById("DdlWh");

            var selectFloor = DdlFloor.options[DdlFloor.selectedIndex].value;
            var selectWh = DdlWh.options[DdlWh.selectedIndex].value;


            /*var http = new ActiveXObject("Microsoft.XMLHTTP");
            http.open("Get", "getNewhtml.aspx?WhId=" + selectWh + "&FloorNum=" + selectFloor + "&t="+testNum.toString(), false);
            http.send();
            document.getElementById("newTable").innerHTML = http.responseText;

            var http2 = new ActiveXObject("Microsoft.XMLHTTP");
            http2.open("Get", "getNewhtml.aspx?asrv_move_id" + "&t=" + testNum.toString(), false);
            http2.send();
            document.getElementById("asrv_move_id").value = http2.responseText;

            var http3 = new ActiveXObject("Microsoft.XMLHTTP");
            http3.open("Get", "getNewhtml.aspx?realX" + "&t=" + testNum.toString(), false);
            http3.send();
            document.getElementById("realX").value = http3.responseText;

            var http4 = new ActiveXObject("Microsoft.XMLHTTP");
            http4.open("Get", "getNewhtml.aspx?realY" + "&t=" + testNum.toString(), false);
            http4.send();
            document.getElementById("realY").value = http4.responseText;*/
        }
        var testNum = 0;
        function mystart()
        { 
            var http6 = new ActiveXObject("Microsoft.XMLHTTP");
            http6.open("Get", "getNewhtml.aspx?init" + "&t=" + testNum.toString(), false);
            http6.send();
            document.getElementById("init").value = http6.responseText;

            timeStop = setInterval("yyy()", 1000);
        }
        

    </script>
<style type="text/css">
    div#mainMap{float:left;}
</style>

</head>
<body>
    <form id="form1" runat="server">
    <div id="mainMap" >

 <span>仓库编号  </span>
    <asp:DropDownList ID="DdlWh" runat="server" Width="8%"  OnSelectedIndexChanged="DdlWh_SelectedIndexChanged" AutoPostBack="true" ClientIDMode="Static"></asp:DropDownList>
 <span>楼层编号  </span>
    <asp:DropDownList ID="DdlFloorNum"  runat="server" Width="8%" ClientIDMode="Static"></asp:DropDownList>

    <input type="button" onclick="xxx()" value="查看仓库模型" />
        <a href="AsrvConfig.aspx">配置中心</a>  

        <br />
        当前执行任务小车编号：
        <input type="text" id="asrv_move_id" value="" style="width:auto" />
        <br />
        当前小车X坐标：
        <input type="text" id="realX" value="" style="width:inherit" />
        <br />
        当前小车Y坐标：
        <input type="text" id="realY" value=""style="width:initial" />
        <br />
        <input type="button" onclick="clearInterval(timeStop)" value="stop" />
        <input type="button" onclick="mystart()" value="start" />
        <input type="text" id="test" value="" />
        <input type="hidden" id="init" value="" />

    <table>
            <tr>
                <td class="lift">
                </td>
                <td style="width: 50px;">
                    电梯
                </td>
                <td class="hd">
                </td>
                <td style="width: 100px;">
                    货道（有货）
                </td>
                <td class="cell">
                </td>
                <td style="width: 100px;">
                    货道（无货）
                </td>
                <td class="xd">
                </td>
                <td style="width: 50px;">
                    巷道
                </td>
                <td class="cd">
                </td>
                <td style="width: 50px;">
                    充电站
                </td>
                <td class="un" >
                </td>
                <td style="width: 50px;">
                    不可用
                </td>
            </tr>
        </table>   
    <div id="newTable">
      </div>
    </div>


    </form>
</body>
</html>