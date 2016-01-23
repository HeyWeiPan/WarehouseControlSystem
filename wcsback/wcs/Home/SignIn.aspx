<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="HomeV2_SignIn" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>WCS测试系统</title>
    <link href="style/reset_css.css" type="text/css" rel="stylesheet" />
    <link href="style/login.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="js/jquery.js"></script>
    <script language="javascript" type="text/javascript">

        function OnLogin(s) {


            if (s == 1) {
                $("#L1_LoginButton").removeClass("btn").addClass("btn_hover");
            } else {
                $("#L1_LoginButton").removeClass("btn_hover").addClass("btn");
            }

        }



        if (top.location != self.location) {
            top.location = self.location;
        }
    
    

    </script>
</head>
<body style="font-size: 14px; font-family: 黑体; color: White;">
    <div id="bodybg">
        <img src="images/login_body_bg.jpg" class="stretch" alt="" />
    </div>
    <div id="login_window">
        <div id="logo" style="height:119px;">
       
        </div>
        <!-- logo结束 -->
        <div id="form">
            <h1>
                <img src="images/txt.png" alt="四向穿梭车控制系统" /></h1>
            <form action="" method="post" runat="server">
            <cc1:UcLogin ID="L1" runat="server" DestinationPageUrl="~/Default.aspx" OnValidateNumAuthenticate="L1_ValidateNumAuthenticate"
                OnLoggingIn="L1_LoggingIn">
                <LayoutTemplate>
                    用户名:
                    <asp:TextBox ID="UserName" runat="server" CssClass="input" TabIndex="10"></asp:TextBox>
                    &nbsp; 密 &nbsp; 码:
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="input" TabIndex="11"></asp:TextBox>
                    <p>
                        <asp:CheckBox ID="Cb1" runat="server" /><strong>记住用户名</strong>
                        <asp:Button runat="server" ID="LoginButton" CommandName="Login" Text="登录" CssClass="btn"
                            onmouseover="OnLogin(1);" onmouseout="OnLogin(2);" />
                    </p>
                </LayoutTemplate>
            </cc1:UcLogin>
            </form>
        </div>
        <!-- form结束 -->
    </div>
    <!-- login_window结束 -->
</body>
</html>
