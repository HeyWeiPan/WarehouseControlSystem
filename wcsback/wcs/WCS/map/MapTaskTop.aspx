<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapTaskTop.aspx.cs" Inherits="WCS_map_MapTaskTop" %>


<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

</head>
<body style="margin: 0 0 0 0;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="WsSetup" runat="server">
            <Services>
                <asp:ServiceReference Path="~/Setup/WsSetup.asmx" />
            </Services>
        </asp:ScriptManager>
        <div style="padding-left: 15px;">
            <table id="tabBottom" style="width: 100%;">
                <colgroup>
                    <col width="3%" />
                    <col width="6%" />
                    <col width="3%" />
                    <col width="6%" />
                    <col width="3%" />
                    <col width="6%" />
                    <col width="3%" />
                    <col width="6%" />
                    <col width="3%" />
                    <col width="6%" />
                    <col width="3%" />
                    <col width="6%" />
                    <col width="3%" />
                    <col width="6%" />
                    <col width="3%" />
                    <col width="6%" />
                    <col width="3%" />
                    <col width="6%" />
                    <col width="3%" />
                    <col width="16%" />

                </colgroup>
                <tr>
                    <td>
                        <cc1:UcLabel ID="LArsvName" ColumnName="wh_code" runat="server"></cc1:UcLabel>

                    </td>
                    <td>
                        <cc1:UcDropDownList ID="DdlWh" OnClientChange="SetWhChange();" runat="server" Width="100%" ConnectionString="ConHR" SqlText="select wh_id,wh_code+'--'+wh_name wh_code from wcs_wh order by wh_code" DataTextField="wh_code" DataValueField="wh_id" AutoBindData="true" ClientIDMode="Static"></cc1:UcDropDownList>

                    </td>
                    <td>
                        <cc1:UcLabel ID="LabModeSwitch" ColumnName="mode_switch" runat="server"></cc1:UcLabel>

                    </td>
                    <td>
                        <cc1:UcDropDownList ID="DdlModeSwitch" OnClientChange="SetModeChange();" runat="server" Width="100%" ConnectionString="ConHR" 
                            SqlText="select wh_mode_id = null,wh_mode_name = null from wcs_wh_mode union select wh_mode_id,wh_mode_name from wcs_wh_mode" DataTextField="wh_mode_name" DataValueField="wh_mode_id" AutoBindData="true" ClientIDMode="Static">
                        </cc1:UcDropDownList>
                    </td>
                    <td>
                        <cc1:UcLabel ID="LabTokenStrategy" ColumnName="token_strategy" runat="server"></cc1:UcLabel>

                    </td>
                    <td>
                        <cc1:UcDropDownList ID="DdlTokenStrategy" runat="server" Width="100%" ConnectionString="ConHR" SqlText="select token_strategy_id,token_strategy_name from wcs_token_strategy" DataTextField="token_strategy_name" DataValueField="token_strategy_id" AutoBindData="true" ClientIDMode="Static">
                        </cc1:UcDropDownList>
                    </td>

                    <td>
                        <cc1:UcLabel ID="UcLabel2" ColumnName="floor_num" runat="server"></cc1:UcLabel>

                    </td>
                    <td>
                        <cc1:UcDropDownList ID="DdlFloorNum" ClientIDMode="Static" runat="server" Width="100%" OnClientChange="SetFloorChange();"></cc1:UcDropDownList>

                    </td>
                    <td>
                        <cc1:UcLabel ID="UcLabel1" ColumnName="asrv_code" runat="server"></cc1:UcLabel>

                    </td>
                    <td>
                        <cc1:UcDropDownList ID="DdlAsrv" runat="server" Width="100%" ConnectionString="ConHR" DataTextField="token_strategy_name" DataValueField="token_strategy_id" AutoBindData="true" ClientIDMode="Static"></cc1:UcDropDownList>

                    </td>
                    <td>
                        <cc1:UcLabel ID="UcLabel5" ColumnName="target_floor" runat="server"></cc1:UcLabel>

                    </td>
                    <td>
                        <cc1:UcDropDownList ID="DdlToFloor" ClientIDMode="Static" runat="server" Width="100%" RequiredField="true"></cc1:UcDropDownList>

                    </td>

                </tr>
                <tr>
                    <td>
                        <cc1:UcLabel ID="UcLabel6" ColumnName="task_type_id" runat="server"></cc1:UcLabel>

                    </td>
                    <td>
                        <cc1:UcDropDownList ID="DdlTaskType" ClientIDMode="Static" runat="server" Width="100%" RequiredField="true">
                            <asp:ListItem Value="0" Text="充电"></asp:ListItem>
                            <asp:ListItem Value="1" Text="取货"></asp:ListItem>
                            <asp:ListItem Value="2" Text="卸货"></asp:ListItem>
                        </cc1:UcDropDownList>

                    </td>
                    <td>
                        <cc1:UcLabel ID="LblFromXNum" ColumnName="from_x_num" runat="server"></cc1:UcLabel>

                    </td>
                    <td>
                        <cc1:UcTextBox ID="TxtFromXNum" runat="server" Width="100%" ClientIDMode="Static"></cc1:UcTextBox>

                    </td>
                    <td>
                        <cc1:UcLabel ID="LblFromYNum" ColumnName="from_y_num" runat="server"></cc1:UcLabel>

                    </td>
                    <td>
                        <cc1:UcTextBox ID="TxtFromYNum" runat="server" Width="100%" ClientIDMode="Static"></cc1:UcTextBox>

                    </td>

                    <td>
                        <cc1:UcLabel ID="UcLabel3" ColumnName="to_x_num" runat="server"></cc1:UcLabel>

                    </td>
                    <td>
                        <cc1:UcTextBox ID="TxtXnum" runat="server" Width="100%" RequiredField="true" ClientIDMode="Static"></cc1:UcTextBox>

                    </td>
                    <td>
                        <cc1:UcLabel ID="UcLabel4" ColumnName="to_y_num" runat="server"></cc1:UcLabel>

                    </td>
                    <td>
                        <cc1:UcTextBox ID="TxtYnum" runat="server" Width="100%" RequiredField="true" ClientIDMode="Static"></cc1:UcTextBox>

                    </td>



                    <td>
                        <cc1:UcButton ID="BtnSaveTask" Text="提交任务" runat="server" OnClientClick="SaveTask();return false;" />

                    </td>
                    <td>
                        <cc1:UcButton ID="UcButton1" Text="设置令牌" runat="server" OnClientClick="SetToken();return false;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <cc1:UcButton ID="BtnStart" Text="开始" runat="server" OnClick="BtnStart_Click"  />
                    </td>
                    <td>
                        <cc1:UcButton ID="BtnStop" Text="结束" runat="server" OnClick="BtnStop_Click"  />
                    </td>
                </tr>
            </table>

        </div>

    </form>
        <script type="text/javascript">


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


            window.onload = on_load;

            function on_load() {
                SetWhChange();
            }
            //根据仓库代码改变后续的楼层、小车编号、任务类型等
            function SetWhChange() {
                var ddl = document.getElementById("DdlWh");
                var selectWh = ddl.options[ddl.selectedIndex].value;
                WsSetup.GetFloorList(selectWh, SetFloorList, f_wserror);//此类函数在WsSetUp.cs文件中查看，通过语句<asp:ServiceReference Path="~/Setup/WsSetup.asmx" />找到文件
            }

            //重新设置仓库
            function ResetWh(whId, floorNum) {
                var ddl = document.getElementById("DdlWh");
                ddl.options.value = whId;
                WsSetup.GetFloorList(whId, SetFloorList, f_wserror);//此类函数在WsSetUp.cs文件中查看，通过语句<asp:ServiceReference Path="~/Setup/WsSetup.asmx" />找到文件
            }

            function SetFloorList(result) {
                SetDdlValue("DdlFloorNum", result);//此函数用以更新下拉列表中内容，此处对象为起点位置楼层编号
                SetDdlValue("DdlToFloor", result);//目标楼层下拉列表中选中项

                var DdlFloor = document.getElementById("DdlFloorNum");//楼层下拉列表中选中项
                if (DdlFloor.length > 0) {
                    SetFloorChange();
                }


            }

            function SetFloorChange() {
                var DdlFloor = document.getElementById("DdlFloorNum");
                var selectFloor = DdlFloor.options[DdlFloor.selectedIndex].value;

                var DdlWh = document.getElementById("DdlWh");
                var selectWh = DdlWh.options[DdlWh.selectedIndex].value;

                //改变右下方块的内容，即调用MapWh.aspx文件，构建最大的仓库表格，具体表格分布是由仓库编号和楼层编号共同决定的，因为每个仓库每个楼层的格局不一样
                window.parent.window.frames[2].window.location.href = "MapWh.aspx?WhId=" + selectWh + "&FloorNum=" + selectFloor;

                WsSetup.GetAsrvList(selectWh, selectFloor, SetAsrvList, f_wserror);//通过数据库提取相应仓库楼层的小车列表，均表示：如果执行成功则执行SetAsrvList函数内容，若执行出错则f_wserror报错
            }


            //根据每个仓库每个楼层的小车编号不同，更新对应的小车下拉列表
            function SetAsrvList(result) {
                SetDdlValue("DdlAsrv", result);
            }

            function SetDdlValue(id, value) {
                var ddlObj = document.getElementById(id);//获取对象

                if (ddlObj.length > 0)

                    delOption(id);//先删除所有的，之后在添加           

                //ddlObj.setAttribute("SqlText", "select asrv_id,asrv_code from wcs_asrv where wh_id = " + ddlWh + " and floor_num = " + ddlFloorNum + " and has_task_flag = 0")

                var optText = new Array();

                var optValue = new Array();

                var xmlDoc = loadXML(value);

                //table就是网格中所有的信息
                var elements = xmlDoc.getElementsByTagName("Table");

                for (var i = 0; i < elements.length; i++) {
                    var i_text = elements[i].getElementsByTagName("text")[0].firstChild.nodeValue;//text为显示到页面上的内容
                    var i_value = elements[i].getElementsByTagName("value")[0].firstChild.nodeValue;//value为代码编写中需要的内容
                    optText[i] = i_text;
                    optValue[i] = i_value;
                }




                var oOption = null;

                for (var i = 0; i < optText.length; i++) {//添加每一个选项

                    oOption = new Option(optText[i], optValue[i]);

                    ddlObj.options.add(oOption);

                }
            }


            function delOption(id) {

                var ddlObj = document.getElementById(id);//获取对象

                for (var i = ddlObj.length - 1; i >= 0; i--) {

                    ddlObj.remove(i);//firefox不支持ddlCurSelectKey.options.remove(),IE两种均支持

                }

            }


            function SaveTask() {

                var ddlWh = document.getElementById("DdlWh"); //仓库下拉列表中的各个选项内容
                var ddlFloor = document.getElementById("DdlToFloor");
                var ddlAsrv = document.getElementById("DdlAsrv");

                var whId = "";
                var floorId = "";
                var asrvId = "";
                //读取选中值
                if (ddlWh.length > 0) {

                    var whId = ddlWh.options[ddlWh.selectedIndex].value;
                }

                if (ddlFloor.length > 0) {
                    var floorId = ddlFloor.options[ddlFloor.selectedIndex].value;
                }
                if (ddlAsrv.length > 0) {
                    var asrvId = ddlAsrv.options[ddlAsrv.selectedIndex].value;
                }
                var fromXNum = document.getElementById("TxtFromXNum").value;
                var fromyNum = document.getElementById("TxtFromYNum").value;
                var xNum = document.getElementById("TxtXnum").value;
                var yNum = document.getElementById("TxtYnum").value;
                var ddlTaskType = document.getElementById("DdlTaskType");//任务类型下拉列表，取货还是存货
                var taskTypeId = ddlTaskType.options[ddlTaskType.selectedIndex].value;

                if (whId == "") {
                    alert("请选择仓库");
                    return;
                }

                if (floorId == "") {
                    alert("请选择目标楼层");
                    return;
                }

                if (asrvId == "") {
                    alert("当前仓库小车正在任务中,或者还没有小车");
                    return;
                }

                if (xNum == "") {
                    alert("请填写X坐标");
                    return;
                }

                if (yNum == "") {
                    alert("请填写Y坐标");
                    return;
                }

                WsSetup.SaveAsrvTask(whId, asrvId, floorId, fromXNum, fromyNum, xNum, yNum, taskTypeId, TaskSaved, f_wserror);
                //计算路径，若有可用路径，则返回路径任务ID，执行TaskSaved函数，若没有可用路径，返回错误

            }

            //设置令牌
            function SetToken() {
                WsSetup.SetRoadRight(result, f_wserror);
            }

            function result() {
                alert("设置成功！");
            }

            function TaskSaved(result) {//result即为SaveAsrvTask的返回值
                if (result == "error") {
                    alert("找不到可用路径！");
                }
                else {
                    alert("保存成功！");
                    SetWhChange(document.getElementById("DdlWh"));
                    window.parent.window.frames[2].window.ShowRoute(result);
                    //根据返回的任务ID显示可用路线，此函数在MapWh.aspx中定义
                }
                window.parent.window.frames[0].window.location.href = "MapLeftMenu.aspx";//刷新左侧等待任务列表
            }

            //修改仓库模式
            function SetModeChange() {
                var ddlWh = document.getElementById("DdlWh"); //仓库下拉列表中的各个选项内容
                var DdlModeSwitch = document.getElementById("DdlModeSwitch"); //模式切换下拉列表中的各个选项内容
                var whId = ddlWh.options[ddlWh.selectedIndex].value;
                var modeId = DdlModeSwitch.options[DdlModeSwitch.selectedIndex].value;

                WsSetup.UpdWhMode(whId, modeId, ModeChange, f_wserror);
            }

            function ModeChange() {

            }




    </script>
</body>
</html>
