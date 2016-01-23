<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapWhSetup.aspx.cs" Inherits="WCS_map_MapWhSetup" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="../map/Js/jquery-smartMenu.js"></script>
    <link href="../map/smartMenu.css" rel="stylesheet" />
    <style type="text/css">
        #TablebillList td {
            width: 30px;
            height: 30px;
            cursor: pointer;
            table-layout: fixed;
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
            /*background-repeat:no-repeat;*/
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
            /*background:url(箭头/2.png) center no-repeat #CA8EFF;*/

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

        .top {
            background:url(箭头/1.png) center no-repeat;
            width: 30px;
            height: 30px;
        }
        .down {
            background:url(箭头/2.png) center no-repeat;
            width: 30px;
            height: 30px;
        }
        .left {
            background:url(箭头/3.png) center no-repeat;
            width: 30px;
            height: 30px;
        }
        .right {
            background:url(箭头/4.png) center no-repeat;
            width: 30px;
            height: 30px;
        }
        .topdown{background:url(箭头/5.png) center no-repeat;width:30px;height:30px;}
        .leftdown{background:url(箭头/6.png) center no-repeat;width:30px;height:30px;}
        .rightdown{background:url(箭头/7.png) center no-repeat;width:30px;height:30px;}
        .righttop{background:url(箭头/8.png) center no-repeat;width:30px;height:30px;}
        .lefttop{background:url(箭头/9.png) center no-repeat;width:30px;height:30px;}
        .leftright{background:url(箭头/10.png) center no-repeat;width:30px;height:30px;}
        .topdownleft{background:url(箭头/11.png) center no-repeat;width:30px;height:30px;}
        .topdownright{background:url(箭头/12.png) center no-repeat;width:30px;height:30px;}
        .leftrighttop{background:url(箭头/13.png) center no-repeat;width:30px;height:30px;}
        .leftrightdown{background:url(箭头/14.png) center no-repeat;width:30px;height:30px;}
        .topdownleftright{background:url(箭头/15.png) center no-repeat;width:30px;height:30px;}
        .no{width:30px;height:30px;}

        #tabDesc td {
            width: 30px;
            height: 30px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 10px 0 0 10px; height: 700px; overflow-y: auto;">
            <table id="tabDesc">
                <tr>
                    <td style="background:url(箭头/1.png) no-repeat center;width: 100px;">上</td> 
                    <td style="width:10px"></td>
                    <td style="background:url(箭头/2.png) no-repeat center;width: 100px;">下</td> 
                    <td style="width:10px"></td>
                    <td style="background:url(箭头/3.png) no-repeat center;width: 100px;">左</td> 
                    <td style="width:10px"></td>
                    <td style="background:url(箭头/4.png) no-repeat center;width: 100px;">右</td> 
                    <td style="width:10px"></td>
                    <td style="background:url(箭头/5.png) no-repeat center;width: 100px;">上下</td>
                    <td style="width:10px"></td>
                    <td style="background:url(箭头/6.png) no-repeat center;width: 100px;">左下</td> 
                    <td style="width:10px"></td>
                    <td style="background:url(箭头/7.png) no-repeat center;width: 100px;">右下</td>      
                </tr>
                <tr>
                    <td style="background:url(箭头/8.png) no-repeat center;width: 100px;">右上</td> 
                    <td style="width:10px"></td>
                    <td style="background:url(箭头/9.png) no-repeat center;width: 100px;">左上</td> 
                    <td style="width:10px"></td>
                    <td style="background:url(箭头/10.png) no-repeat center;width: 100px;">左右</td> 
                    <td style="width:10px"></td>
                    <td style="background:url(箭头/11.png) no-repeat center;width: 100px;">上下左</td> 
                    <td style="width:10px"></td>
                    <td style="background:url(箭头/12.png) no-repeat center;width: 100px;">上下右</td> 
                    <td style="width:10px"></td>
                    <td style="background:url(箭头/13.png) no-repeat center;width: 100px;">左右上</td> 
                    <td style="width:10px"></td>
                    <td style="background:url(箭头/14.png) no-repeat center;width: 100px;">左右下</td> 
                    <td style="width:10px"></td>
                    <td style="background:url(箭头/15.png) no-repeat center;width: 130px;">上下左右</td>
                   
                </tr>
            </table>
            <table border="0" id="TablebillList" style="table-layout: fixed;">
                <tbody>
                    <asp:PlaceHolder ID="PH1" runat="server"></asp:PlaceHolder>
                </tbody>
            </table>
        </div>
        <cc1:UcHiddenField ID="HidValue" runat="server" Value="" ClientIDMode="Static" RenderToClient="true" />

    </form>

    <script type="text/javascript">

        var startId;
        var endId;

        $(document).ready(function () {
            $("#TablebillList tbody tr td").attr("select", "0");
            //把每一格的select属性改为0，即都未选中
            $("#TablebillList tbody tr td").bind("mousedown", (function (e) {
                //鼠标按下，即准备设置选取的格子
                if (e.which == 1) {//1表示按下左键
                    startId = e.target.id;
                }

                if (e.which == 3) {//3表示按下右键
                    var opertionn = {
                        name: "",
                        offsetX: 2,
                        offsetY: 2,
                        textLimit: 10,
                        beforeShow: $.noop,
                        afterShow: $.noop
                    };
                    var imageMenuData = [
            [{
                text: "上",//text为上的话，样式就为top的样式                
                func: function () {
                    SetCellType("1",'top');
                }
            }, {
                text: "下",
                func: function () {
                    SetCellType("2",'down');
                }
            },
             {
                 text: "左",
                 func: function () {
                     SetCellType("3",'left');
                 }
             },
            {
                text: "右",
                func: function () {
                    SetCellType("4",'right');
                }
            },
            {
                text: "上下",
                func: function () {
                    SetCellType("5", 'topdown');
                }
            },
            {
                text: "左下",
                func: function () {
                    SetCellType("6", 'leftdown');
                }
            }, {
                text: "右下",
                func: function () {
                    SetCellType("7", 'rightdown');
                }
            },
            {
                text: "右上",
                func: function () {
                    SetCellType("8", 'righttop');
                }
            },
            {
                text: "左上",
                func: function () {
                    SetCellType("9", 'lefttop');
                }
            },
            {
                text: "左右",
                func: function () {
                    SetCellType("10", 'leftright');
                }
            },
            {
                text: "上下左",
                func: function () {
                    SetCellType("11", 'topdownleft');
                }
            },
            {
                text: "上下右",
                func: function () {
                    SetCellType("12", 'topdownright');
                }
            },
            {
                text: "左右上",
                func: function () {
                    SetCellType("13", 'leftrighttop');
                }
            },
            {
                text: "左右下",
                func: function () {
                    SetCellType("14", 'leftrightdown');
                }
            },
            {
                text: "上下左右",
                func: function () {
                    SetCellType("15", 'topdownleftright');
                }
            }
            ]

                    ];
                    //oTable.$('td.td_selected').removeClass('td_selected');
                    if ($(e.target).hasClass('td_selected')) {
                        $(e.target).removeClass('td_selected');
                    } else {
                        $(e.target).addClass('td_selected');
                    }
                    $(this).smartMenu(imageMenuData, opertionn);
                }
            }));


            $("#TablebillList tbody tr td").bind("mousemove", function (e) {

                //目标id，即当前鼠标所在的id
                endId = e.target.id;


                if (endId == null || startId == null)
                    return;

                GetSelectCells();

                var cells = ids.split(",");
                ResetBG();
                var cell;
                for (var i = 0; i < cells.length; i++) {//遍历选取的长方形区域，将样式设置为divHtml，即用特定样式标志出来
                    if (cells[i] == "")
                        continue;
                    
                    cell = document.getElementById(cells[i]);

                    if (cell.innerHTML == "") {
                        cell.innerHTML = divHtml;
                    }

                }

            }


            );

            $("#TablebillList tbody tr td").bind("mouseup", function (e) {
                //鼠标松开，即表示选取结束，所以清空选取的起始位置和结束位置坐标信息，等待下一次鼠标按下选取新的
                endId = e.target.id;
                //当前鼠标松开时所在位置的id即为target

                startId = null;
                endId = null;

            });


        });

        var ids;
        var divHtml = "<div class=\"cellSelect\"></div>";

        function SetCellType(a,b) {
            var cells = ids.split(",");//以，为标志分离后，cells即为选中的一个一个小格位置坐标
            var cell;
            for (var i = 0; i < cells.length; i++) {
                if (cells[i] == "")
                    continue;
                cell = document.getElementById(cells[i]);
                //cell.className = a;
                //cell.c = b;                               
                cell.celltype = a;
                //cell.direction = a;
                cell.innerHTML = "<span id=" + cells[i] + " class="+b+"></span>";
                //SetCellType("un", "4");表示将选中的格子的类名设为un，即设置为不可用的CSS样式，数字4与type类型相对应，也表示不可用样式
            }
        }


        function ResetBG() {
            //将网格内所有的格子样式清空

            var $cells = $("#TablebillList tbody tr td");


            var cell;

            for (var i = 0; i < $cells.length; i++) {
                cell = $cells[i];

                cell.innerHTML="";


            }
        }

        function GetSelectCells() {//确定ids的内容，即为设置过程中选中的小格信息


            ids = '';
            var x1 = parseInt(startId.split('.')[0]);//起始位置的x坐标值
            var y1 = parseInt(startId.split('.')[1]);//起始位置的y坐标值
            var x2 = parseInt(endId.split('.')[0]);//结束位置的x坐标值
            var y2 = parseInt(endId.split('.')[1]);//结束位置的y坐标值

            var x_start = x1 < x2 ? x1 : x2;
            var x_end = x1 > x2 ? x1 : x2;

            var y_start = y1 < y2 ? y1 : y2;
            var y_end = y1 > y2 ? y1 : y2;

            var x = x_start;
            var y;

            while (x < (x_end + 1)) {//从最小的坐标到最大的坐标循环，即遍历整个选取的长方形区域
                y = y_start;
                while (y < (y_end + 1)) {
                    ids += ',' + x.toString() + '.' + y.toString();//ids为整个选取的长方形区域网格的坐标值，形式为(1.1;1.2,1.3……）
                    y = y + 1;
                }
                x = x + 1;
            }


        }

        function GetTableXml() {//将所有小格的信息做成XML表格，类似为：
            //<NewDataSet>
            //<Table>
            //<CellNum></CellNum>
            //<CellType></CellType>
            //</Table>
            //</NewDataSet>

            var tab = document.getElementById("TablebillList");
            var xmlStr = "<NewDataSet>";

            for (var i = 0; i < tab.rows.length; i++) {//遍历行

                for (var j = 0; j < tab.rows[i].cells.length; j++) {//遍历每行中每一列，即每个小格
                    xmlStr += "<Table>";
                    xmlStr += "<CellNum>" + f_toxmlstr(tab.rows[i].cells[j].id) + "</CellNum>";
                    xmlStr += "<CellDirection>" + f_toxmlstr(tab.rows[i].cells[j].celltype) + "</CellDirection>";
                    xmlStr += "</Table>";
                }

            }
            xmlStr += "</NewDataSet>";

            return escape(xmlStr);//加密返回

        }

        

    </script>
</body>
</html>