<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapWh.aspx.cs" Inherits="WCS_map_MapWh" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache, must-revalidate">
    <meta http-equiv="expires" content="0">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="Js/jquery-smartMenu.js"></script>
    <link href="smartMenu.css" rel="stylesheet" />
    <style type="text/css">
        #TablebillList td {
            width: 30px;
            height: 30px;
            cursor: pointer;
            table-layout: fixed;
            text-align: center;
        }

        #TablebillList tr {
            height: 30px;
            table-layout: fixed;
        }


        .colorRed {
            background-color: red;
        }


        .colorBlue {
            background-color: blue;
        }

        .cellSelect {
            background-color: #FAEBD7;
            width: 100%;
            height: 100%;
            filter: alpha(Opacity=60);
            -moz-opacity: 0.5;
            opacity: 0.5;
            z-index: 100;
        }

        .lift {
            background-color: #ff6600;
            width: 30px;
            height: 30px;
        }

        .xd {
            background-color: #c5da01;
            width: 30px;
            height: 30px;
        }

        .hd {
            background-color: #CA8EFF;
            width: 30px;
            height: 30px;
        }

        .cell {
            background-color: #72cfd7;
            width: 30px;
            height: 30px;
        }

        .un {
            background-color: #d4d4d4;
            width: 30px;
            height: 30px;
        }

        .cd {
            background-color: #F8F82A;
            width: 30px;
            height: 30px;
        }

        #tabDesc td {
            width: 30px;
            height: 30px;
        }

        .floatFont {
            position: relative;
            top: -20px;
            font-weight: bold;
        }
    </style>
</head>
<body style="overflow-y: hidden;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/Setup/WsSetup.asmx" />
            </Services>
        </asp:ScriptManager>
        <div style="padding: 10px 0 0 10px; height: 650px; overflow-y: auto;">
            <table id="tabDesc">
                <tr>
                    <td class="lift"></td>
                    <td style="width: 30px;">电梯
                    </td>
                    <td class="hd"></td>
                    <td style="width: 80px;">货道（有货）
                    </td>
                    <td class="cell"></td>
                    <td style="width: 80px;">货道（无货）
                    </td>
                    <td class="xd"></td>
                    <td style="width: 30px;">巷道
                    </td>
                    <td class="cd"></td>
                    <td style="width: 50px;">充电站
                    </td>
                    <td class="un"></td>
                    <td style="width: 50px;">不可用
                    </td>
                </tr>
            </table>
            <table border="0" id="TablebillList" style="table-layout: fixed;">
                <tbody>
                    <asp:PlaceHolder ID="PH1" runat="server"></asp:PlaceHolder>
                </tbody>
            </table>
        </div>

    </form>
    <script type="text/javascript">

        var MyInterval = setInterval("WhInterval()", 1000);
        var colorList = new Array("Black", "Red", "Blue", "Green", "Yellow", "Orange");


        loadXML = function (xmlString) {
            var xmlDoc = null;
            //判断浏览器的类型
            //支持IE浏览器 
            if (!window.DOMParser && window.ActiveXObject) {   //window.DOMParser 判断是否是非ie浏览器
                var xmlDomVersions = ['MSXML.2.DOMDocument.6.0', 'MSXML.2.DOMDocument.3.0', 'Microsoft.XMLDOM'];
                for (var i = 0; i < xmlDomVersions.length; i++) {
                    try {
                        xmlDoc = new ActiveXObject(xmlDomVersions[i]);
                        xmlDoc.async = false;
                        xmlDoc.loadXML(xmlString); //loadXML方法载入xml字符串
                        break;
                    } catch (e) {
                    }
                }
            }
                //支持Mozilla浏览器
            else if (window.DOMParser && document.implementation && document.implementation.createDocument) {
                try {
                    /* DOMParser 对象解析 XML 文本并返回一个 XML Document 对象。
                    * 要使用 DOMParser，使用不带参数的构造函数来实例化它，然后调用其 parseFromString() 方法
                    * parseFromString(text, contentType) 参数text:要解析的 XML 标记 参数contentType文本的内容类型
                    * 可能是 "text/xml" 、"application/xml" 或 "application/xhtml+xml" 中的一个。注意，不支持 "text/html"。
                    */
                    domParser = new DOMParser();
                    xmlDoc = domParser.parseFromString(xmlString, 'text/xml');
                } catch (e) {
                }
            }
            else {
                return null;
            }

            return xmlDoc;
        }

        //定时事件
        function WhInterval() {
            ClearAsrv(); //清理所有小车图标以及路权代码
            WsSetup.GetWhAsrvLocation(getQueryString("WhId"), getQueryString("FloorNum"), SetAsrvLocation, f_wserror); //获取小车位置以及状态
            WsSetup.GetRoadRight(getQueryString("WhId"), getQueryString("FloorNum"), SetAsrvRoadRight, f_wserror); //获取路权

        }

        var tarr = new Array();
        //设置小车位置
        function SetAsrvLocation(result) {
            var xmlDoc = loadXML(result); //提取result中返回的xml
            var elements = xmlDoc.getElementsByTagName("Table"); //路径包含的每个方块的信息
            for (var i = 0; i < elements.length; i++) {
                var cellNum = elements[i].getElementsByTagName("location")[0].firstChild.nodeValue; //获取小车坐标
                var asrvId = elements[i].getElementsByTagName("asrv_id")[0].firstChild.nodeValue; //获取小车Id
                var asrvCode = elements[i].getElementsByTagName("asrv_code")[0].firstChild.nodeValue; //获取小车Code
                var errorFlag = elements[i].getElementsByTagName("error_flag")[0].firstChild.nodeValue; //小车是否出错
                var inFlag = 0;
                for (var j = 0; j < tarr.length; j++) {
                    if (tarr[j] == asrvCode) {
                        inFlag = -1;
                        break;
                    }
                }

                if (inFlag == 0) {
                    tarr[i] = asrvCode + "," + colorList[i];

                }


                var desc = "<div class=\"floatFont\" style=\"color:" + colorList[i] + "\" >" + asrvCode + "</div>";
                if (errorFlag == "0") {
                    document.getElementById(cellNum).innerHTML = "<img src=\"images\\teamfree.png\" title='" + asrvCode + "' asrvId='" + asrvId + "' asrvCode='" + asrvCode + "' width='30px' height='30px' onclick=\"javascript:ShowAsrvStatus(this.asrvId,this.asrvCode);return false;\" />" + desc;
                }
                else {
                    document.getElementById(cellNum).innerHTML = "<img src=\"images\\teambusy.png\" title='" + asrvCode + "' asrvId='" + asrvId + "' asrvCode='" + asrvCode + "'   width='30px' height='30px' onclick=\"javascript:ShowAsrvStatus(this.asrvId,this.asrvCode);return false;\" />" + desc;
                }

            }
        }



        //设置路权
        function SetAsrvRoadRight(result) {
            var xmlDoc = loadXML(result); //提取result中返回的xml
            var elements = xmlDoc.getElementsByTagName("Table"); //路径包含的每个方块的信息



            for (var i = 0; i < elements.length; i++) {
                var cellNum = elements[i].getElementsByTagName("cell_num")[0].firstChild.nodeValue; //获取坐标
                var asrvCode = elements[i].getElementsByTagName("asrv_code")[0].firstChild.nodeValue; //获取小车Code

                var cc = "";
                for (var j = 0; j < tarr.length; j++) {
                    var at = tarr[j].split(',');

                    if (asrvCode == at[0]) {
                        cc = at[1];
                        break;
                    }
                }


                if (document.getElementById(cellNum).innerHTML == "")
                    document.getElementById(cellNum).innerHTML = "<img src=\"images\\token.png\" width=\"30px\" height=\"30px\" />"
                    + "<div class=\"floatFont\" style=\"color:" + cc + "\" >" + asrvCode + "</div>";


            }

        }

        //弹出小车状态窗口
        function ShowAsrvStatus(asrvId, asrvCode) {

            var returnValue = window.showModalDialog("/WCS/CommonUI/WebForm/DialogFrame.aspx?DialogUrl=/WCS/WCS/MAP/AsrvStatus.aspx?AsrvId=" + asrvId + "%26AsrvCode=" + escape(f_escape(asrvCode)), '', "dialogHeight:400px;dialogWidth:600px;center:1;edge:1;help:0;resizable:0;scroll:0;status:0;");
        }


        function ClearAsrv() {

            //var imgs = document.getElementsByTagName("img");

            //for (var i = 0; i < imgs.length; i++) {
            //    var parentNode = imgs[i].parentNode;

            //    parentNode.innerHTML = "";
            //}

            //ClearRoute();


            var $cell = $("#TablebillList tbody tr td");
            var cell;
            var str;
            for (var i = 0; i < $cell.length; i++) {
                cell = $cell[i];
                cell.innerHTML = "";
            }

        }


        var startId;
        var endId;

        function ShowRoute(cmdId) {
            //window.parent.window.frames[2].window.location.href = "MapWh.aspx?WhId=" + whId + "&FloorNum=" + fromFloorNum;
            WsSetup.GetAsrvRoute(cmdId, ShowRouteResult, f_wserror);
        }




        function ShowRouteResult(result) {//result即为db.ExecuteDataSet(cmd).GetXml()，即ShowRoute的返回值

            ClearRoute(); //先清除掉页面内已显示的路径

            var xmlDoc = loadXML(result); //提取result中返回的xml
            var elements = xmlDoc.getElementsByTagName("Table"); //路径包含的每个方块的信息

            if (elements.length == 0) {
                alert("找不到可用路径！");
                return;
            }

            for (var i = 0; i < elements.length; i++) {
                var cell = elements[i].getElementsByTagName("cell_num")[0].firstChild.nodeValue; //循环遍历每一个小方格
                SetRoute(cell);
            }

        }

        //只是定义一种样式，显示路径时用
        var xTable = "<table style=\"width:100%;height:100%;table-layout:fixed;\" border=\"4\" cellpadding=\"0\" cellspacing=\"0\" ><tr><td style=\"width:100%;height:100%;\"></td></tr></table>";

        function SetRoute(cellId) {

            var cell = document.getElementById(cellId);
            if (cell.innerHTML == "") {
                cell.innerHTML = xTable;
            } else { cell.innerHTML = ""; } //这个else情况存在吗？不存在吧……嗯，不存在！无用代码
        }

        function ClearRoute() {
            var $cell = $("#TablebillList tbody tr td"); //JQuery语言，表示所有的小方块
            var cell;
            var str;
            for (var i = 0; i < $cell.length; i++) {
                cell = $cell[i];

                if (!AsrvInThisCell(cell.id))//如果小车不在这个小方块内，则清除样式
                    cell.innerHTML = "";
            }

        }

        function AsrvInThisCell(id) {//判断小车是否在此ID的小方块内，若在，返回TRUE
            var $img = $("#TablebillList tbody tr td img"); //遍历每一个有图像属性的小方块

            var b = false;

            var parentId;
            for (var i = 0; i < $img.length; i++) {
                parentId = $img[i].parentNode.id;

                if (parentId == id) {
                    b = true;
                    break;
                }
            }

            return b;
        }



        function getQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }



    </script>
</body>
</html>
