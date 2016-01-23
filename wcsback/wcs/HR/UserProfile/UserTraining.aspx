<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserTraining.aspx.cs" Inherits="HR_UserProfile_UserTraining" %>

<%@ Register Src="UcUserTraining.ascx" TagName="UcUserTraining" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script language="javascript" type="text/javascript">
        // <!CDATA[
      
        function window_onload() 
        {                                                    
            if(document.body.scrollHeight > 0){ 
                parent.document.all("IfraSubWindow").height = document.body.scrollHeight + 15 ;                                
            }                                                   
        }
        // ]]>
    </script>

</head>
<body style="margin: 0,0,0,0; border: 0,0,0,0; padding: 0,0,0,0; background-color: #EBF2FC;"
    onload="return window_onload();">
    <form id="form1" runat="server">
        <uc1:UcUserTraining ID="UcUserTraining1" runat="server" CurrentCompanyFlag="-1" />
        <uc1:UcUserTraining ID="UcUserTraining2" runat="server" CurrentCompanyFlag="0"/>
    </form>
</body>
</html>
