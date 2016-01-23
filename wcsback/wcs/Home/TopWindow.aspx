<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TopWindow.aspx.cs" Inherits="Home_TopWindow" %>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>ͷ��</title>
    <link href="style/reset_css.css" type="text/css" rel="stylesheet" />
    <link href="style/homepage.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="js/jquery.js"></script>
    <!--[if lte IE 6]>
    <script language="javascript" type="text/javascript" src="js/png.js"></script>
    <script language="javascript" type="text/javascript">
        PNG.fix('#logo h1,#logo img,#menu img');
    </script>
    <![endif]-->
    <script language="javascript" type="text/javascript" src="TopWindowScript.js"></script>
</head>
<body>
    <form runat="server">
        <asp:ScriptManager ID="WsHome" runat="server">
            <Services>
                <asp:ServiceReference Path="~/HOME/WsHome.asmx" />
            </Services>
        </asp:ScriptManager>
        <div id="header">
            <div id="header_bg">
                <div id="logo">
              
                    <h1>�����󳵿���ϵͳ</h1>
                </div>
                <!-- logo���� -->
                <div id="user_zt">
                    ��ӭ����<asp:Label ID="LName" runat="server"></asp:Label>��<asp:LinkButton ID="Logout"
                        runat="server" CssClass="zx" OnClientClick="LogOut();">ע��</asp:LinkButton>
                </div>
                <!-- user_zt���� -->
                <div id="menu">
                    <ul>
                        <li id="homeLink"><a id="aHome" href="javascript:ShowHomePage();">
                            <img src="images/icon05.png" alt="ͼƬ����" />
                            ��ҳ</a></li>
                        <li id="appLink" class="change"><a id="aApp" href="javascript:ShowApplication();">
                            <img src="images/icon04.png" alt="ͼƬ����" />
                            Ӧ��</a></li>
                        <li id="ctrlLink" class="change"><a id="aCtrl" href="javascript:ShowCtrl();">
                            <span style="background: url(images/iconmap.png) no-repeat left center; width: 20px; height: 20px;"></span>
                            <span style="height: 16px;">��������</span> </a></li>
                        <li id="msgLink"><a id="aMsg" href="javascript:ShowMessage();">
                            <img src="images/icon03.png" alt="ͼƬ����" />
                            ��Ϣ</a></li>                         
                        <li id="conLink"><a id="aCon" href="javascript:ShowFavorate();">
                            <img src="images/icon01.png" alt="ͼƬ����" />
                            ���òֿ�</a></li>
                        <li id="trafficLink"><a id="aTraffic" href="javascript:ShowTraffic();">
                        <img src="images/icon02.png" alt="ͼƬ����" />
                        ��ͨ����</a></li>
                    </ul>
                    <span class="clear"></span>
                </div>
                <!-- menu���� -->
                <span class="clear"></span>
            </div>
        </div>
        <!-- header���� -->
    </form>
    <%--  <script type="text/javascript" src="../signalr/hubs"></script>
    <script type="text/javascript" src="EntpClass.MessageNofityTicker.js"></script>--%>
</body>
</html>
