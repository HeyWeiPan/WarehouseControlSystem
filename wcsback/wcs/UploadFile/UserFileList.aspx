<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserFileList.aspx.cs" Inherits="UploadFile_UserFileList" %>

<%@ Register Src="UcUserFileList.ascx" TagName="UcUserFileList" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        function window_onload() {
            AutoSetHeight();
            setTimeout(AutoSetHeight,500);
        }

        function AutoSetHeight() {         
            if (document.body.scrollHeight > 0) {
                parent.document.all("IfraFileUp").height = document.body.scrollHeight + 15;
            }
        }
        // ]]>
    </script>
</head>
<body style="margin: 0,0,0,0; border: 0,0,0,0; padding: 0,0,0,0;" onload="return window_onload();">
    <form id="form1" runat="server">
    <uc1:UcUserFileList ID="UcUserFileList1" runat="server" />
    </form>
</body>
</html>
