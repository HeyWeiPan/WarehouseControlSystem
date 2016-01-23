<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RC.aspx.cs" Inherits="WCS_asrv_RC" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">

        function AutoUnAtuoClick(btn) {

            var autoFlag = btn.autoflag;
            var asrvId = getQueryString("AsrvId");
            if (autoFlag == 0) {
                btn.value = "自动";
                btn.autoflag = "-1";
                WsSetup.SendAsrvCmd(asrvId, "auto", SendSucess, f_wserror);
            }
            else {
                btn.value = "手动";
                btn.autoflag = "0";
                WsSetup.SendAsrvCmd(asrvId, "unauto", SendSucess, f_wserror);
            }

            var btns = document.getElementsByTagName("input");
            for (var i = 0; i < btns.length; i++) {
                if (btns[i].id != "AutoUnAtuo" && btns[i].id != "BtnClose" && btns[i].id != "FastStop" && btns[i].id != "Faster" && btns[i].id != "Slow") {
                    if (btns[i].type == "submit") {
                        if (autoFlag == 0)
                            btns[i].disabled = true;
                        else
                            btns[i].disabled = false;
                    }
                }
            }

        }



        function SendSucess(result) {
            if (result != "")
                alert(result);
        }

        function getQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }


        function BtnClcik(a) {
            SetBtnText();
            var asrvId = getQueryString("AsrvId");
            WsSetup.SendAsrvCmd(asrvId, a, SendSucess, f_wserror);
        }


        function ForwardBackClcik(a) {
            SetBtnText();
            var asrvId = getQueryString("AsrvId");
            var btn = document.getElementById(a);
            var stopflag = btn.stopflag;

            if (stopflag == 0) {
                WsSetup.SendAsrvCmd(asrvId, a, SendSucess, f_wserror);
                if (a == "Forward")
                    btn.value = "前进中";

                if (a == "Back")
                    btn.value = "后退中";

                btn.stopflag = "-1";

            } else {

                WsSetup.SendAsrvCmd(asrvId, "Stop", SendSucess, f_wserror);
                btn.stopflag = "0";
            }



        }

        function FNClick() {

            if (document.getElementById("Faster").disabled == true)
                document.getElementById("Faster").disabled = false;
            else
                document.getElementById("Faster").disabled = true;


            if (document.getElementById("Slow").disabled == true)
                document.getElementById("Slow").disabled = false;
            else
                document.getElementById("Slow").disabled = true;

        }

        function SetBtnText() {
            document.getElementById("Forward").value = "前";
            document.getElementById("Back").value = "后";
        }

        function OnLogin(s, b) {


            if (s == 1) {
                document.getElementById(b).className = "btn_hover";
            } else {
                document.getElementById(b).className = "btn";
            }

        }

    </script>
    <style type="text/css">
        body
        {
            background-color: Gray;
        }
        
        .btn
        {
            width: 94px;
            height: 30px;
            font-size: 14px;
            text-align: center;
            color: #193634;
            background: url(btn_login.png) no-repeat left top;
            border: 0;
            text-decoration: none;
            cursor: pointer;
        }
        
        
        .btn_hover
        {
            width: 94px;
            height: 30px;
            font-size: 14px;
            color: White;
            text-align: center;
            background: url(login_btn.png) no-repeat left top;
            border: 0;
            text-decoration: none;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="~/Setup/WsSetup.asmx" />
        </Services>
    </asp:ScriptManager>
    <table style="table-layout: fixed; width: 100%;">
        <colgroup>
            <col width="33%" />
            <col width="33%" />
            <col width="34%" />
        </colgroup>
        <tr>
            <td>
                <asp:Button ID="AutoUnAtuo" runat="server" Text="手动" ClientIDMode="Static" OnClientClick="AutoUnAtuoClick(this);return false;"
                    autoflag="0" CssClass="btn" onmouseover="OnLogin(1,this.id);" onmouseout="OnLogin(2,this.id);" />
            </td>
            <td>
            </td>
            <td>
                <asp:Button ID="FastStop" runat="server" Text="急停" ClientIDMode="Static" OnClientClick="BtnClcik(this.id);return false;"
                    CssClass="btn" onmouseover="OnLogin(1,this.id);" onmouseout="OnLogin(2,this.id);" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="Up" runat="server" Text="升" ClientIDMode="Static" OnClientClick="BtnClcik(this.id);return false;"
                    CssClass="btn" onmouseover="OnLogin(1,this.id);" onmouseout="OnLogin(2,this.id);" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Back" runat="server" Text="后" ClientIDMode="Static" OnClientClick="ForwardBackClcik(this.id);return false;"
                    stopflag="0" CssClass="btn" onmouseover="OnLogin(1,this.id);" onmouseout="OnLogin(2,this.id);" />
            </td>
            <td>
                <asp:Button ID="Turn" runat="server" Text="转弯" ClientIDMode="Static" OnClientClick="BtnClcik(this.id);return false;"
                    CssClass="btn" onmouseover="OnLogin(1,this.id);" onmouseout="OnLogin(2,this.id);" />
            </td>
            <td>
                <asp:Button ID="Forward" runat="server" Text="前" ClientIDMode="Static" OnClientClick="ForwardBackClcik(this.id);return false;"
                    stopflag="0" CssClass="btn" onmouseover="OnLogin(1,this.id);" onmouseout="OnLogin(2,this.id);" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="Down" runat="server" Text="降" ClientIDMode="Static" OnClientClick="BtnClcik(this.id);return false;"
                    CssClass="btn" onmouseover="OnLogin(1,this.id);" onmouseout="OnLogin(2,this.id);" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="FN" runat="server" Text="FN" ClientIDMode="Static" OnClientClick="FNClick();return false;"
                    CssClass="btn" onmouseover="OnLogin(1,this.id);" onmouseout="OnLogin(2,this.id);" />
            </td>
            <td>
                <asp:Button ID="Faster" runat="server" Text="加速" ClientIDMode="Static" disabled="true"
                    OnClientClick="BtnClcik(this.id);return false;" CssClass="btn" onmouseover="OnLogin(1,this.id);"
                    onmouseout="OnLogin(2,this.id);" />
            </td>
            <td>
                <asp:Button ID="Slow" runat="server" Text="减速" ClientIDMode="Static" disabled="true"
                    OnClientClick="BtnClcik(this.id);return false;" CssClass="btn" onmouseover="OnLogin(1,this.id);"
                    onmouseout="OnLogin(2,this.id);" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
