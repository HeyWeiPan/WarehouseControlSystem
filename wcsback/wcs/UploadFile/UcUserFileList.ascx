<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserFileList.ascx.cs"
    Inherits="UploadFile_UcUserFileList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<cc1:UcGridView ID="GrdAttachment" runat="server" AutoGenerateColumns="False" DataKeyNames="attachment_guid"  
    Width="100%" >
    <Columns>
        <%-- <asp:BoundField DataField="file_type" HeaderText="file_type"
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>--%>
        <asp:HyperLinkField DataNavigateUrlFields="GetFileLink" HeaderText="file_name" DataTextField="friendly_name"
            Target="Attachment">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Left" Width="25%" />
        </asp:HyperLinkField>
        <asp:BoundField DataField="description" HeaderText="description">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Left" Width="25%" />
        </asp:BoundField>
        <asp:BoundField DataField="content_size" HeaderText="content_size">
            <ItemStyle HorizontalAlign="Right" />
            <HeaderStyle HorizontalAlign="Right" Width="10%" />
        </asp:BoundField>
        <asp:BoundField DataField="create_by" HeaderText="create_by" HtmlEncode="False">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Left" Width="10%" />
        </asp:BoundField>
        <asp:BoundField DataField="create_date" HeaderText="create_date" DataFormatString="{0:yyyy/MM/dd}"
            HtmlEncode="False">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Left" Width="20%" />
        </asp:BoundField>
    </Columns>
</cc1:UcGridView>
