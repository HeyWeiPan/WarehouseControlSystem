<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileServiceList.aspx.cs" Inherits="UploadFile_FileServiceList" %>

<%@ Register Src="UcFileServiceList.ascx" TagName="UcFileServiceList" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        function window_onload() {
            AutoSetHeight();            
        }

        function AutoSetHeight() {
            if (document.body.scrollHeight > 0) {
                parent.document.all("IfraFileUp").height = document.body.scrollHeight + 40;
            }
        }
        // ]]>
    </script>
</head>
<body style="margin: 0,0,0,0; border: 0,0,0,0; padding: 0,0,0,0;background-color: #EBF2FC;" onload="return window_onload();">
    <form id="form1" runat="server">
    <uc1:UcFileServiceList ID="UcFileServiceList1" runat="server" />
    </form>
</body>
</html>
