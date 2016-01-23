<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AsrvPic.aspx.cs" Inherits="WCS_asrv_AsrvPic" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">

        function window_onload() {
            if (document.body.scrollHeight > 0) {
                parent.document.all("IfraSubWindow").height = document.body.scrollHeight + 40;
            }

            var rack = window.location.toString().getQuery("Rack");

            var img1 = document.getElementById("imgAsrv1");
            var img2 = document.getElementById("imgAsrv2");

            if (rack == "x") {
                img1.style.display = "inline";
                img2.style.display = "none";
            }

            if (rack == "y") {
                img1.style.display = "none";
                img2.style.display = "inline";
            }

        }


        String.prototype.getQuery = function (name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = this.substr(this.indexOf("\?") + 1).match(reg);
            if (r != null) return unescape(r[2]);

            return null;
        }


    </script>

    <style>

       #imgAsrv1 tr td img{
            width:337px;
            height:489px;
        }

       
       #imgAsrv2 tr td img{
            width:480px;
            height:340px;
        }


    </style>
</head>
<body style="margin: 0,0,0,0; border: 0,0,0,0; padding: 0,0,0,0; background-color: #EBF2FC;"
    onload="return window_onload();">
    <form id="form1" runat="server">
        <div>

            <table style="display: none" id="imgAsrv1">
                <tr>
                    <td>
                        <img src="xx.png" title="货道X移动X" /></td>
                    <td>
                        <img src="xy.png" title="货道X移动Y" /></td>
                </tr>
            </table>


            <table style="display: none" id="imgAsrv2">
                <tr>
                    <td>
                        <img src="yx.png" title="货道Y移动X" /></td>
                    <td>
                        <img src="yy.png" title="货道Y移动Y" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
