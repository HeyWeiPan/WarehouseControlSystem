<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EquipmentLink.aspx.cs" Inherits="WCS_wh_EquipmentLink" %>

<%@ Register Src="UcEquipmentLink.ascx" TagName="UcEquipmentLink" TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">
        // <!CDATA[
        function window_onload() {
            if (document.body.scrollHeight > 0) {
                parent.document.all("IfraSubWindow").height = document.body.scrollHeight + 40;
            }
        }
        // ]]>
    </script>
</head>
<body style="margin: 0,0,0,0; border: 0,0,0,0; padding: 0,0,0,0; background-color: #EBF2FC;"
    onload="return window_onload();">
    <form id="form1" runat="server">
        <div>

            <uc1:UcEquipmentLink ID="UcEquipmentLink1" runat="server" />

        </div>
    </form>
</body>
</html>
