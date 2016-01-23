<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapLeftMenu.aspx.cs" Inherits="Setup_MapLeftMenu" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<html>
<head runat="server">
    <title>Left Window</title>
    <link href="mainframe.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.color.js" type="text/javascript"></script>
    <script type="text/javascript" src="Js/LeftWindowScript.js"></script>
    <script type="text/javascript">
        function SetOperateType(a, b) {
            WsSetup.SetOperateType(a, b, setOK, f_wserror);
        }

        function setOK() {
            alert("设置成功");
        }

        var newWindow;//定义一个窗口，有利于窗口间的通讯
        function SetOperate(a) {
            
            WsSetup.SetOperateType(0, a, setHand, f_wserror);
           
        }
        function setHand() {
            if (!newWindow || newWindow.closed) {
                var width = 800;
                var height = 600;
                var left = parseInt((screen.availWidth / 2) - (width / 2));//屏幕居中
                var top = parseInt((screen.availHeight / 2) - (height / 2));
                var windowFeatures = "width=" + width + ",height=" + height + ",status,resizable,left=" + left + ",top=" + top + "screenX=" + left + ",screenY=" + top;
                newWindow = window.open('../../Default2.aspx', "subWind", windowFeatures);
            } else {
                // window is already open, so bring it to the front
                newWindow.focus();
            }
        }

        function ShowRoute(cmdid, whid, fromfloornum) {           
            //改变右下方块的内容，即调用MapWh.aspx文件，构建最大的仓库表格，具体表格分布是由仓库编号和楼层编号共同决定的，因为每个仓库每个楼层的格局不一样
            window.parent.window.frames[2].window.location.href = "MapWh.aspx?WhId=" + whid + "&FloorNum=" + fromfloornum;           

            //选择任务的时候同时显示任务路径
            window.parent.window.frames[2].window.ShowRoute(cmdid);
            
            //在选择任务的时候仓库下拉列表也会跟着改变
            window.parent.window.frames[1].window.ResetWh(whid, fromfloornum);
        }
        
        function DeleteCmd(a, whId, floorNum) {
            WsSetup.DeleteCmd(a, deleteOK, f_wserror);
            window.parent.window.frames[1].window.SetFloorChange();
            //WsSetup.GetAsrvList(whId, floorNum, SetAsrvList, f_wserror);//通过数据库提取相应仓库楼层的小车列表，均表示：如果执行成功则执行SetAsrvList函数内容，若执行出错则f_wserror报错
        }

        function deleteOK() {
            window.location.href = window.location.href;            
        }
        
    </script>
</head>
<body style="overflow: hidden;" onload="return window_onload();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="~/Setup/WsSetup.asmx" />
        </Services>
    </asp:ScriptManager>
    <table border="0" cellpadding="0" cellspacing="0" style="table-layout: fixed; height: 100%;
        width: 100%;">
        <tr>
            <td align="center" style="height: 100%;" id="tdMain">
                <table width="100%;height:100%;display:inline;table-layout:fixed;" id="tbMain" border="0"
                    cellpadding="0" cellspacing="0">
                    <tr onclick="show('QxTeam');" class="parent">
                        <td>
                            <span style="margin-left: 40px;">等待执行任务</span>
                        </td>
                    </tr>
                    <tr id="TrQxTeamDiv" class="TrShow">
                        <td>
                            <div class="DivTrv">
                                <div style="background-image: url(images/leftmenutop.png); background-repeat: repeat-x;
                                    height: 28px; width: 100%;">
                                </div>
                                <div class="showTree">
                                    <ul>
                                        <asp:PlaceHolder ID="PHTaskWait" runat="server"></asp:PlaceHolder>
                                    </ul>
                                </div>
                                <div style="background-image: url(images/leftmenubottom.png); background-repeat: repeat-x;
                                    height: 28px; width: 100%; margin: 0 0 0 0;">
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr onclick="show('95598Task')" class="parent">
                        <td>
                            <span style="margin-left: 40px;">已执行任务</span>
                        </td>
                    </tr>
                    <tr id="Tr95598TaskDiv" class="TrHide">
                        <td>
                            <div class="DivTrv">
                                <div style="background-image: url(images/leftmenutop.png); background-repeat: repeat-x;
                                    height: 28px; width: 100%;">
                                </div>
                                <div class="showTree">
                                    <ul>
                                        <asp:PlaceHolder ID="PHTaskEnd" runat="server"></asp:PlaceHolder>
                                    </ul>
                                </div>
                                <div style="background-image: url(images/leftmenubottom.png); background-repeat: repeat-x;
                                    height: 28px; width: 100%; margin: 0 0 0 0;">
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div style="display: none;">
        <iframe id="tempIframe" runat="server" frameborder="0" name="tempIframe" scrolling="auto"
            style="width: 100%; height: 100%"></iframe>
    </div>
    </form>
</body>
</html>
