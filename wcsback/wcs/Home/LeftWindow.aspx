<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeftWindow.aspx.cs" Inherits="Home_LeftWindow" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Left Window</title>
    <link href="../Home/style/reset_css.css" type="text/css" rel="stylesheet" />
    <link href="../Home/style/homepage.css" type="text/css" rel="stylesheet" />
    <link href="../Home/style/LeftWindow.css" type="text/css" rel="stylesheet" />
    <link href="../CommonUI/ZTree/css/zTreeStyle/zTreeStyle.css" type="text/css" rel="stylesheet" />

    <style type="text/css">
        .tree {
            display: none;
            overflow: auto;
        }

        .ztree {
            margin-left: -10px;
        }


            .ztree * {
                font-size: 11px;
            }

        #add ul li .rIcon {
            background-image: url(../CommonUI/js/ZTree/css/zTreeStyle/img/diy/2.png) !important; /* FF IE7 */
            background-repeat: no-repeat;
            _filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src='../CommonUI/ZTree/css/zTreeStyle/img/diy/2.png'); /* IE6 */
            _ background-image: none; /* IE6 */
        }

        #move ul li .rIcon {
            background-image: url(../CommonUI/js/ZTree/css/zTreeStyle/img/diy/9.png) !important; /* FF IE7 */
            background-repeat: no-repeat;
            _filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src='../CommonUI/ZTree/css/zTreeStyle/img/diy/9.png'); /* IE6 */
            _ background-image: none; /* IE6 */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="WsHome.asmx" />
            </Services>
        </asp:ScriptManager>
        <div id="divShow">
            <div class="form">
                <asp:TextBox ID="Txt" runat="server" CssClass="input" onkeydown="return txt_keydown();"></asp:TextBox>
                <asp:Button ID="BtnSearch" runat="server" Text="²éÕÒ" CssClass="btns" onmouseover="BtnMouse(1);"
                    onmouseout="BtnMouse(2);" OnClientClick="GetSearchFunction();return false;" UseSubmitBehavior="false" />
            </div>

            <div id="sidebar_nav">
                <div class="tree" id="menuTree" style="padding-left: 10px;">
                    <ul id="treeMenu" class="ztree"></ul>
                </div>

                <a href="javascript:resizeMenu();"><span class="btn_jiantou"></span></a>
            </div>
        </div>
        <div id="divHidden" style="width: 16px; height: 100%; display: none;">
            <a href="javascript:resizeMenu();"><span class="btn_jiantou"></span></a>
        </div>
        <cc1:UcHiddenField ID="HidUserID" ClientIDMode="Static" runat="server" RenderToClient="true" />
        <cc1:UcHiddenField ID="HidStatus" ClientIDMode="Static" runat="server" RenderToClient="true" Value="0" />
        <div style="display: none;">
            <input type="button" id="BtnSync" onclick="sync(this.value)"
                value="0" />
        </div>
    </form>
    <script lang="ja" type="text/javascript" src="../CommonUI/ZTree/js/jquery-1.4.4.min.js"></script>
    <script lang="ja" type="text/javascript" src="../CommonUI/ZTree/js/jquery.ztree.core-3.5.js"></script>
    <script lang="ja" type="text/javascript" src="LeftWindow_new.js"></script>

</body>
</html>
