<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JDList.aspx.cs" Inherits="HR_Setup_JDList" %>

<%@ Register Src="UcJDResponsibilityList.ascx" TagName="UcJDResponsibilityList" TagPrefix="uc1" %>
<%@ Register Src="UcJDQualificationList.ascx" TagName="UcJDQualificationList" TagPrefix="uc2" %>
<%@ Register Src="UcJDWorkConditionList.ascx" TagName="UcJDWorkConditionList" TagPrefix="uc3" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script language="javascript" type="text/javascript">
        // <!CDATA[
        function window_onload() 
        {                             
            if(document.body.scrollHeight > 0){ 
                parent.document.all("IfraSubWindow").height = document.body.scrollHeight + 20;                                
            }                          
        }
        // ]]>
    </script>

</head>
<body style="margin: 0,0,0,0; border: 0,0,0,0; padding: 0,0,0,0;" onload="return window_onload();">
    <form id="form1" runat="server">
        <uc1:UcJDResponsibilityList ID="UcJDResponsibilityList1" runat="server" />
        <uc2:UcJDQualificationList ID="UcJDQualificationList1" runat="server" />
        <uc3:UcJDWorkConditionList ID="UcJDWorkConditionList1" runat="server" />
    </form>
</body>
</html>
