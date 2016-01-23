<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrafficSetupHead.aspx.cs" Inherits="WCS_traffic_TrafficSetupHead" %>

<!DOCTYPE html>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" defer="defer">

        window.onload = on_load;

        function on_load() {
            SetChange(document.getElementById("DdlWh"));//DdlWh：仓库编号下拉列表
        }
        //当修改了仓库编号下拉列表选项的时候才调用这个函数，未改变前只执行下列函数，形成默认表格
        function SetChange(ddl, DdlMode) {
            var selectWh = ddl.options[ddl.selectedIndex].value;
            window.parent.window.frames[1].window.location.href = "MapWhSetup.aspx?WhId=" + selectWh ;
        }//代表右上方块，要根据所选仓库编号更新，因为每个仓库的格局不一样。即在此处调用MapWhSetup.aspx文件，所选择的仓库编号参数为selectWh

        function GetTableXml() {
            var ddl = document.getElementById("DdlWh");
            var DdlMode = document.getElementById("DdlModeSwitch");
            var DdlStrategy = document.getElementById("DdlTokenStrategy");
            var whId = ddl.options[ddl.selectedIndex].value;    //获取仓库id
            var whModeId = DdlMode.options[DdlMode.selectedIndex].value;    //获取仓库模式id
            var tokenStrategyId = DdlStrategy.options[DdlStrategy.selectedIndex].value; //获取令牌策略id

            var xmlVal = window.parent.window.frames[1].window.GetTableXml();//回调函数
            //每一格的坐标信息制成xml文件，且加密返回,即包含右上方快中各个数据的xml文件
            WsSetup.UpdateCellsDirection(whId, whModeId, tokenStrategyId,xmlVal, SaveOK, f_wserror);       //在~/App_Code/WsSetup.cs中定义
            //参数：选择的仓库编号，整行表格数据，保存成功函数，错误处理
        }

        function SaveOK() {
            alert('保存成功！');
        }

        //清空仓库格子的方向
        function ClearDirection()
        {
            var ddl = document.getElementById("DdlWh");
            var whId = ddl.options[ddl.selectedIndex].value;    //获取仓库id

            if (confirm("确定要清空吗？")) {
                WsSetup.ClearCellsDirection(whId, ClearOK, f_wserror);
            }
        }

        function ClearOK()
        {
            parent.location.reload();
            alert('清理成功！');
        }
    </script>
</head>
<body style="margin: 0 0 0 0;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/Setup/WsSetup.asmx" />
            </Services>
        </asp:ScriptManager>
        <div style="padding-left: 15px;">
            <table id="tabBottom" style="width: 800px;">
                <colgroup>
                    <col width="8%" />
                    <col width="20%" />
                    <col width="8%" />
                    <col width="20%" />
                    <col width="8%" />
                    <col width="20%" />
                    <col width="10%" />
                </colgroup>
                <tr>
                    <td>
                        <cc1:UcLabel ID="LArsvName" ColumnName="wh_code" runat="server"></cc1:UcLabel>

                    </td>
                    <td>
                        <cc1:UcDropDownList ID="DdlWh" OnClientChange="SetChange(this);" runat="server" Width="100%" ConnectionString="ConHR" SqlText="select wh_id,wh_code+'--'+wh_name wh_code from wcs_wh order by wh_code" DataTextField="wh_code" DataValueField="wh_id" AutoBindData="true" ClientIDMode="Static"></cc1:UcDropDownList>

                    </td>
                    <td>
                        <cc1:UcLabel ID="LabModeSwitch" ColumnName="mode_switch" runat="server"></cc1:UcLabel>

                    </td>
                    <td>
                        <cc1:UcDropDownList ID="DdlModeSwitch" runat="server" Width="100%" ConnectionString="ConHR" SqlText="select wh_mode_id,wh_mode_name from wcs_wh_mode" DataTextField="wh_mode_name" DataValueField="wh_mode_id" AutoBindData="true" ClientIDMode="Static">
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
                        <cc1:UcButton ID="BtnSave" Text="保存设置" runat="server" OnClientClick="GetTableXml();return false;" /></td>
                    <td>
                        <cc1:UcButton ID="BtnClear" Text="清空设置" runat="server" OnClientClick="ClearDirection();return false;" /></td>
                </tr>

            </table>

        </div>

    </form>
</body>
</html>
