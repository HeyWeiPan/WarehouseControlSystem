<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Notify.aspx.cs" Inherits="Home_Notification_Notify" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script type="text/javascript" language="javascript">
        function FCKeditor_OnComplete( editorInstance )
        {          	  	        
            editorInstance.ToolbarSet.Collapse() ;
                   
            var oDOM = editorInstance.EditorDocument ;
            var oBody = oDOM.body;	            
            oBody.contentEditable = false 	  	
            
            var a = document.getElementById(FCKeditor1);				            
            a.contentEditable = false;                               
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" style="display: inline; table-layout: fixed; height: 100%;" cellpadding="0"
            cellspacing="0">
            <colgroup>
                <col class="TdLabel" width="75%" />
                <col align="left" width="25%" />
            </colgroup>
            <tr height="40px">
                <td align="center" colspan="2">
                    <cc1:UcLabel ID="TxtTitle" runat="server" Font-Size="Large"></cc1:UcLabel>
                    <hr />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" colspan="2">
                    <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Width="100%" Height="100%">
                    </FCKeditorV2:FCKeditor>
            </tr>
            <%-- <tr>
                <td>
                </td>
                <td>
                    <cc1:UcLabel ID="L1" ColumnName="issue_by" runat="server"></cc1:UcLabel>:
                    <cc1:UcTextBox ID="TxtIssueBy" runat="server" UseDefaultStyle="false" ReadOnly="true"
                        CssClass="TransparentText"></cc1:UcTextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <cc1:UcLabel ID="L6" runat="server" ColumnName="issue_date"></cc1:UcLabel>:
                    <cc1:UcDatePicker ID="DtpIssueDate" UseDefaultStyle="false" ReadOnly="true" CssClass="TransparentText"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td style="height: 20px;" colspan="2">
                </td>
            </tr>--%>
            <tr height="25px">
                <td>
                </td>
                <td align="right" style="padding-right: 25px;">
                    <cc1:UcButton ID="BtnClose" runat="server" ColumnName="Close" Width="70px" OnClientClick="window.close();return false;" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
