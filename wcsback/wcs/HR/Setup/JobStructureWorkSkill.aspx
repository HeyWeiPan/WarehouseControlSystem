<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JobStructureWorkSkill.aspx.cs"
    Inherits="HR_Setup_JobStructureWorkSkill" %>

<%@ Register Src="UcJobStructureWorkSkillList.ascx" TagName="UcJobStructureWorkSkillList"
    TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Untitled Page</title>

    <script language="javascript" type="text/javascript">
        // <!CDATA[
        function window_onload() 
        {                             
            if(document.body.scrollHeight > 0){ 
                parent.document.all("IfraSubWindow").height = document.body.scrollHeight + 10;                                
            }                          
        }
        // ]]>
    </script>
</head>
<body style="margin: 0,0,0,0; border: 0,0,0,0; padding: 0,0,0,0;" onload="return window_onload();">
    <form id="form1" runat="server">
        <uc1:UcJobStructureWorkSkillList ID="UcJobStructureWorkSkillList1" runat="server" />
    </form>
</body>
</html>
