<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserContract.aspx.cs" Inherits="HR_UserProfile_UserContract" %>

<%@ Register Src="UcUserDimission.ascx" TagName="UcUserDimission" TagPrefix="uc2" %>
<%@ Register Src="UcUserContract.ascx" TagName="UcUserContract" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script language="javascript" type="text/javascript">
        // <!CDATA[
      
        function window_onload() 
        {                                                  
            if(document.body.scrollHeight > 0){ 
                parent.document.all("IfraSubWindow").height = document.body.scrollHeight + 30 ;                                
            }                                                   
        }
        // ]]>
    </script>

</head>
<body style="margin: 0,0,0,0; border: 0,0,0,0; padding: 0,0,0,0; background-color: #EBF2FC;"
    onload="return window_onload();">
    <form id="form1" runat="server">
        <uc1:UcUserContract ID="UcUserContract1" runat="server" />
        <uc2:UcUserDimission ID="UcUserDimission1" runat="server" />
    </form>
</body>
</html>
