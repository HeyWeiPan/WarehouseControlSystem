<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcFileServiceUpload.ascx.cs"
    Inherits="UploadFile_UcFileServiceUpload" %>
<%@ Register Src="UcFileServiceUploadList.ascx" TagName="UcFileServiceUploadList"
    TagPrefix="uc1" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<table style="width: 100%; table-layout: fixed;" border="0">
    <colgroup>
        <col width="20%" align="left" />
        <col width="80%" align="left" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel9" runat="server" ColumnName="file_name"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtAttachmentFileName" runat="server" Width="95%" ColumnName="file_name"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="LblFolderName" runat="server" ColumnName="folder_name"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcDropDownList ID="DdlFolderId" runat="server" Width="150px" DataTextField="folder_name"
                ColumnName="folder_name" DataValueField="folder_id" IsInsertItem="true" AutoBindData="false"
                RequiredField="true" />
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="LblSecurityLevelName" runat="server" ColumnName="security_level_name"></cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlFileSecurityLevel ID="DdlSecurityLevelId" runat="server" RequiredField="true"
                Width="150px" />
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel7" runat="server" ColumnName="Attachment"></cc1:UcLabel>
        </td>
        <td>
            <asp:FileUpload ID="UpdFile" runat="server" Width="95%" Height="22px" />
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="UcLabel10" runat="server" ColumnName="DESCRIPTION"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtAttachmentDescription" runat="server" Width="95%" Rows="3"
                TextMode="MultiLine"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td align="left">
            &nbsp;
        </td>
        <td align="right">
            <cc1:UcButton ID="BtnUpload" runat="server" ColumnName="UploadFile" OnClick="BtnUpload_Click"
                ValidationGroup="FileUpload" />
        </td>
    </tr>
</table>
<table style="width: 100%; table-layout: fixed;" border="0">
    <tr>
        <td align="center" valign="top" style="height: 100%;">
            <uc1:UcFileServiceUploadList ID="UcFileUploadList1" runat="server"></uc1:UcFileServiceUploadList>
        </td>
    </tr>
</table>
