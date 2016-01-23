<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserAttachment.ascx.cs"
    Inherits="UploadFile_UcUserAttachment" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<table width="100%" style="display: inline; table-layout: fixed;" cellpadding="0">
    <tr>
        <td>
            <asp:FileUpload ID="UpdFile" runat="server" Width="80%" Height="22px" /><cc1:UcButton
                ID="BtnUpload" runat="server" ColumnName="UploadFile" OnClick="BtnUpload_Click"
                ValidationGroup="FileUpload" /><cc1:UcButton ID="BtnDelete" ColumnName="Delete" runat="server"
                    Width="70px" OnClick="BtnDelete_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcHyperLink ID="LnkFile" runat="server" Text='' NavigateUrl='' Target="Attachment"></cc1:UcHyperLink>
        </td>
    </tr>
</table>
