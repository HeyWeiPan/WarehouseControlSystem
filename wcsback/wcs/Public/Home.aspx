<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Public_Home"
    EnableViewState="false" %>

<%--<%@ Register Src="UcHomeTab.ascx" TagName="UcHomeTab" TagPrefix="uc3" %>--%>
<%@ Register Src="../Home/Notification/UcNotification.ascx" TagName="UcNotification"
    TagPrefix="uc4" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../CommonUI/ZTree/js/jquery-1.4.4.min.js"></script>
    <link href="../Home/style/reset_css.css" type="text/css" rel="stylesheet" />
    <link href="homepage.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        body
        {
            background: #f3f3f3 url(../Home/images/div_bg3.gif) repeat-x left top;
        }
    </style>
    <script type="text/javascript">

        function PageTrans(s, b) {


            ShowLeftWindow(b);
            window.parent.frames[2].window.location.href = s;
        }

        function ShowLeftWindow(b) {
            window.parent.frames[0].document.getElementById("aApp").click();
            window.parent.frames[1].document.getElementById("BtnSync").value = b;
            window.parent.frames[1].document.getElementById("BtnSync").click();

        }

        function ShowMsg(v) {
            window.location.href = "MessageReceive.aspx?KeyValue=" + v;
            window.parent.frames[0].window.MsgLinkClick();
        }

        function MsgMore() {
            window.parent.frames[0].document.getElementById("aMsg").click();
        }
    
    </script>
</head>
<body onload="loadRemind()">
    <form id="form1" runat="server">
    <div style="margin: 0 auto; width: 100%; display: block; text-align: center;">
        <div id="content">
            <div id="tonggao">
                <h3>
                    通告</h3>
                <ul>
                    <asp:PlaceHolder ID="PHNotice" runat="server"></asp:PlaceHolder>
                </ul>
                <span class="more">
                    <asp:LinkButton ID="More" runat="server" OnClick="More_Click" OnClientClick="PageTrans('../Home/Notification/NotificationList.aspx',5900130)">更多</asp:LinkButton></span>
                <span class="bg_bom"></span><span class="bom_bg"></span><span class="bg_top"></span>
            </div>
            <!-- tonggao结束 -->
            <div id="content_right">
                <div id="daiban">
                    <h3>
                        <img src="../Home/images/icon14.png" />待办事宜</h3>
                    <div>
                        <div id="divRemind" style="width: 100%; height: 100%">
                            &nbsp;
                        </div>
                    </div>
                </div>
                <!-- daiban结束 -->
                <div id="shouchang">
                    <h3>
                        <img src="../Home/images/icon13.png" />我的收藏</h3>
                    <div>
                        <ul>
                            <asp:PlaceHolder ID="PHFavorate" runat="server"></asp:PlaceHolder>
                        </ul>
                    </div>
                </div>
                <!-- shouchang结束 -->
                <div id="msg">
                    <h3>
                        <img src="../Home/images/icon15.png" />消息中心</h3>
                    <div>
                        <ul>
                            <asp:PlaceHolder ID="PHMsg" runat="server"></asp:PlaceHolder>
                        </ul>
                    </div>
                    <span class="more"><a href="javascript:MsgMore();">更多</a></span>
                </div>
                <!-- msg结束 -->
                <span class="clear"></span>
                <!-- 清除浮动 -->
                <span class="bg_bom"></span><span class="bg_top"></span>
            </div>
            <!-- content_right结束 -->
            <span class="clear"></span>
            <!-- 清除浮动 -->
        </div>
    </div>
    <!-- content结束 -->
    </form>
    
</body>
</html>
