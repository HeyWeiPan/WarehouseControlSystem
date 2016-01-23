<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLeave.aspx.cs" Inherits="HR_UserProfile_UserLeave" %>

<%@ Register Src="UcUserLeave.ascx" TagName="UcUserLeave" TagPrefix="uc2" %>
<%@ Register Src="UcUserLeaveResidualList.ascx" TagName="UcUserLeaveResidualList"
    TagPrefix="uc1" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived.HR" Namespace="EntpClass.WebControlLib.Derived.HR"
    TagPrefix="cc3" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script language="javascript" type="text/javascript">
        // <!CDATA[
      
        function window_onload() 
        {                                                  
            if(document.body.scrollHeight > 0){ 
                parent.document.all("IfraSubWindow").height = document.body.scrollHeight + 10 ;                                
            }                                                   
        }
        // ]]>
    </script>

</head>
<body style="margin: 0,0,0,0; border: 0,0,0,0; padding: 0,0,0,0; background-color: #EBF2FC;"
    onload="return window_onload();">
    <form id="form1" runat="server">
        <table id="tblData" cellspacing="0" cellpadding="0" width="100%" border="0" style="table-layout: fixed;">
            <colgroup>
                <col class="TdLabel" width="10%" />
                <col align="left" width="15%" />
                <col class="TdLabel" width="10%" />
                <col align="left" width="15%" />
                <col class="TdLabel" width="10%" />
                <col align="left" width="15%" />
                <col class="TdLabel" width="10%" />
                <col align="left" width="15%" />
            </colgroup>
            <tr>
                <td>
                    <cc1:UcLabel ID="L1" runat="server" ColumnName="period_id"></cc1:UcLabel>
                </td>
                <td>
                    <cc3:UcDdlLeavePeriod ID="DrpLeavePeriod" IsInsertItem="false" runat="server" Width="100%"
                        AutoPostBack="true">
                    </cc3:UcDdlLeavePeriod>
                </td>
                <td>
                    <cc1:UcLabel ID="L2" runat="server" ColumnName="total_residual_days"></cc1:UcLabel>
                </td>
                <td>
                    <cc1:UcTextBox ID="TxtTotalResidualDays" runat="server" ReadOnly="true"></cc1:UcTextBox>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <uc1:UcUserLeaveResidualList ID="UcUserLeaveResidualList1" runat="server"></uc1:UcUserLeaveResidualList>
        <uc2:UcUserLeave ID="UcUserLeave1" runat="server" />
    </form>
</body>
</html>
