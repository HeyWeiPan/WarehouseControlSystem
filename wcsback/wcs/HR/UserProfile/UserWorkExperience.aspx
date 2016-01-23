<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserWorkExperience.aspx.cs"
    Inherits="HR_UserProfile_UserWorkExperience" %>

<%@ Register Src="UcUserPositionTransferList.ascx" TagName="UcUserPositionTransferList"
    TagPrefix="uc1" %>
<%@ Register Src="UcUserWorkExperienceList.ascx" TagName="UcUserWorkExperienceList"
    TagPrefix="uc2" %>
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
        <uc1:UcUserPositionTransferList ID="UcUserPositionTransferList1" runat="server"></uc1:UcUserPositionTransferList>
        <uc2:UcUserWorkExperienceList ID="UcUserWorkExperienceList1" runat="server"></uc2:UcUserWorkExperienceList>
    </form>
</body>
</html>
