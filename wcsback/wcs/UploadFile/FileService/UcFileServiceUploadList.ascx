<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcFileServiceUploadList.ascx.cs"
    Inherits="UploadFile_UcFileServiceUploadList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<cc1:UcGridView ID="GrdAttachment" runat="server" AutoGenerateColumns="False" DataKeyNames="file_guid"
    Width="100%" CssClass="bold1">
    <Columns>
        <%--  <asp:BoundField DataField="file_type" HeaderText="file_type">
            <itemstyle horizontalalign="Left" width="15%" />
            <headerstyle horizontalalign="Left" width="15%" />
        </asp:BoundField>--%>
        <asp:HyperLinkField DataNavigateUrlFields="GetFileLink" HeaderText="file_name" DataTextField="friendly_name"
            Target="Attachment">
            <ItemStyle HorizontalAlign="Left" Width="25%" />
            <HeaderStyle HorizontalAlign="Left" Width="25%" />
        </asp:HyperLinkField>
        <asp:BoundField DataField="description" HeaderText="description">
            <ItemStyle HorizontalAlign="Left" Width="28%" />
            <HeaderStyle HorizontalAlign="Left" Width="28%" />
        </asp:BoundField>
        <asp:BoundField DataField="content_size" HeaderText="content_size">
            <ItemStyle HorizontalAlign="Left" Width="8%" />
            <HeaderStyle HorizontalAlign="Left" Width="8%" />
        </asp:BoundField>
        <asp:BoundField DataField="create_by" HeaderText="create_by" HtmlEncode="False">
            <ItemStyle HorizontalAlign="Left" Width="10%" />
            <HeaderStyle HorizontalAlign="Left" Width="10%" />
        </asp:BoundField>
        <asp:BoundField DataField="create_date" HeaderText="create_date" DataFormatString="{0:yyyy/MM/dd}"
            HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Width="20%" />
            <HeaderStyle HorizontalAlign="Left" Width="20%" />
        </asp:BoundField>
        <%-- <asp:BoundField DataField="audit_user" HeaderText="audit_user" HtmlEncode="False">
            <itemstyle horizontalalign="Left" width="8%" />
            <headerstyle horizontalalign="Left" width="8%" />
        </asp:BoundField>
        <asp:BoundField DataField="audit_date" HeaderText="audit_date" DataFormatString="{0:yyyy/MM/dd}"
            HtmlEncode="False">
            <itemstyle horizontalalign="Left" width="10%" />
            <headerstyle horizontalalign="Left" width="10%" />
        </asp:BoundField>--%>
    </Columns>
</cc1:UcGridView>
