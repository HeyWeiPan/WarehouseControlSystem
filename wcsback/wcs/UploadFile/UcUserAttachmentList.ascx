<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserAttachmentList.ascx.cs"
    Inherits="UploadFile_UcUserAttachmentList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<table width="100%" style="display: inline; table-layout: fixed;" cellpadding="0">
    <colgroup>
        <col class="TdLabel" width="90%" />
        <col align="left" width="10%" />
    </colgroup>
    <tr>
        <td>
            <asp:Repeater ID="RptList" runat="server">
                <ItemTemplate>
                    <cc1:UcLabel ID="L1" runat="server" ColumnName="<" ResourceFileType="UI"></cc1:UcLabel><cc1:UcHyperLink
                        ID="LnkFile" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["friendly_name"] %>'
                        NavigateUrl='<%# ((DataRowView)Container.DataItem).Row["GetFileLink"] %>' Target="Attachment"></cc1:UcHyperLink><cc1:UcLabel
                            ID="L2" runat="server" ColumnName=">" ResourceFileType="UI"></cc1:UcLabel>
                </ItemTemplate>
            </asp:Repeater>
        </td>
        <td align="right">
            <cc1:UcButton ID="BtnNew" runat="server" ColumnName="New_Attachment"  Visible="false"/>
        </td>
    </tr>
</table>
