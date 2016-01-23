<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcFileUpload.ascx.cs"
    Inherits="UploadFile_UcFileUpload" %>
<%@ Register Src="UcFileUploadList.ascx" TagName="UcFileUploadList" TagPrefix="uc1" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<table style="width: 100%; table-layout: fixed;" border="0">
    <colgroup>
        <col width="20%" align="left" />
        <col width="80%" align="left" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel CssClass="bold1" ID="UcLabel9" runat="server" ColumnName="file_name"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtAttachmentFileName" runat="server" Width="95%" ColumnName="file_name"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel CssClass="bold1" ID="LabFileType" runat="server" ColumnName="File_type"></cc1:UcLabel></td>
        <td>
            <cc1:UcDropDownList ID="DrpFileType" runat="server" Width="80%" DataValueField="function_id"
                ColumnName="File_type" DataTextField="function_name" IsInsertItem="True" RequiredField="True">
            </cc1:UcDropDownList></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel CssClass="bold1" ID="UcLabel7" runat="server" ColumnName="Attachment"></cc1:UcLabel>
        </td>
        <td>
            <asp:FileUpload ID="UpdFile" runat="server" Width="95%" Height="22px" />
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel CssClass="bold1" ID="UcLabel10" runat="server" ColumnName="DESCRIPTION"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtAttachmentDescription" runat="server" Width="95%" Rows="3"
                TextMode="MultiLine"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td align="left">
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
            <uc1:UcFileUploadList ID="UcFileUploadList1" runat="server"></uc1:UcFileUploadList>
        </td>
    </tr>
</table>
