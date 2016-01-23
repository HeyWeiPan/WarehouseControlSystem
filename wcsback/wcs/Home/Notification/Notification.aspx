<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterSetupDetail.master"
    AutoEventWireup="false" CodeFile="Notification.aspx.cs" Inherits="Home_Notification_Notification"
    Title="Untitled Page" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="~/UploadFile/UcUserAttachment.ascx" TagName="UcUserAttachment"
    TagPrefix="uc1" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">

    <script type="text/javascript" language="javascript">
        function FCKeditor_OnComplete( editorInstance )
        {          	  	        
            if(PageMode=='View')
            {	         
                editorInstance.ToolbarSet.Collapse() ;
                   
                var oDOM = editorInstance.EditorDocument ;
                var oBody = oDOM.body;	                
                oBody.contentEditable = false 	  	
                
                var a = document.getElementById(FCKeditor1);				                
                a.contentEditable = false;                               
            }                            
        }
        function onClientSave()
        {                  
            var oEditor = FCKeditorAPI.GetInstance(FCKeditor1) ;
            var bIsWysiwyg = ( oEditor.EditMode == FCK_EDITMODE_WYSIWYG ) ;
            if(bIsWysiwyg) return true;           
            
            oEditor.SwitchEditMode();
            return false;
        }
    </script>

    <table width="100%" style="display: inline; table-layout: fixed;" cellpadding="0"
        cellspacing="0">
        <colgroup>
            <col class="TdLabel" width="10%" />
            <col align="left" width="24%" />
            <col class="TdLabel" width="10%" />
            <col align="left" width="25%" />
            <col class="TdLabel" width="10%" />
            <col align="left" width="25%" />
        </colgroup>
        <tr id="trIssue" runat="server">
            <td>
                <cc1:UcLabel ID="L1" ColumnName="issue_by" runat="server"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtLeaveFormCode" runat="server" Width="100%" ColumnName="issue_by"
                    ReadOnlyWhenInsert="true" ReadOnlyWhenUpdate="true" AllowInsert="false" AllowUpdate="false"></cc1:UcTextBox>
            </td>
            <td>
                <cc1:UcLabel ID="LA" runat="server" ColumnName="set_top_flag"></cc1:UcLabel>
            </td>
            <td>
                <cc2:UcDdlYesNo ID="DrpSetTopFlag" ColumnName="set_top_flag" runat="server" RequiredField="true"
                    Width="100%">
                </cc2:UcDdlYesNo>
            </td>
        </tr>
        <tr id="trPause" runat="server">
            <td>
                <cc1:UcLabel ID="L6" runat="server" ColumnName="issue_date"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcDatePicker ID="DtpIssueDate" ColumnName="issue_date" RequiredField="true"
                    Width="100%" runat="server" />
            </td>
            <td>
                <cc1:UcLabel ID="L7" runat="server" ColumnName="pause_date"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcDatePicker ID="DtpPauseDate" ColumnName="pause_date" RequiredField="true"
                    Width="100%" runat="server" />
            </td>
            <td>
                <cc1:UcLabel ID="LL" runat="server" ColumnName="attachment_notify_flag"></cc1:UcLabel>
            </td>
            <td>
                <cc2:UcDdlYesNo ID="DrpAttachmentNotifyFlag" ColumnName="attachment_notify_flag"
                    runat="server" RequiredField="true" Width="100%" AutoPostBack="True">
                </cc2:UcDdlYesNo>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="L8" ColumnName="title" runat="server" />
            </td>
            <td colspan="5">
                <cc1:UcTextBox ID="TxtTilte" ColumnName="title" RequiredField="true" Width="100%"
                    runat="server" />
            </td>
        </tr>
        <tr id="trIfraFile" runat="server">
            <td valign="top">
                <cc1:UcLabel ID="L9" runat="server" ColumnName="Attachment"></cc1:UcLabel>
            </td>
            <td colspan="5">
                <uc1:UcUserAttachment ID="UcUserAttachment1" runat="server"></uc1:UcUserAttachment>
            </td>
        </tr>
        <tr id="trContent1" runat="server">
            <td valign="top" colspan="6">
                <cc1:UcLabel ID="L4" runat="server" ColumnName="content"></cc1:UcLabel></td>
        </tr>
        <tr id="trContent2" runat="server">
            <td colspan="6">
                <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Width="100%" Height="475px">
                </FCKeditorV2:FCKeditor>
            </td>
        </tr>
    </table>
</asp:Content>
