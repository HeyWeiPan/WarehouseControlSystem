<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcFileUploadList.ascx.cs"
    Inherits="UploadFile_UcFileUploadList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<cc1:UcGridView ID="GrdAttachment" runat="server" AutoGenerateColumns="False" DataKeyNames="attachment_guid"
    Width="100%" CssClass="bold1">
     <Columns>
      <%--  <asp:BoundField DataField="file_type" HeaderText="file_type">
            <itemstyle horizontalalign="Left" width="15%" />
            <headerstyle horizontalalign="Left" width="15%" />
        </asp:BoundField>--%>
        <asp:HyperLinkField DataNavigateUrlFields="GetFileLink" HeaderText="file_name" DataTextField="friendly_name"
            Target="Attachment">
            <itemstyle horizontalalign="Left" width="25%" />
            <headerstyle horizontalalign="Left" width="25%" />
        </asp:HyperLinkField>
        <asp:BoundField DataField="description" HeaderText="description">
            <itemstyle horizontalalign="Left" width="28%" />
            <headerstyle horizontalalign="Left" width="28%" />
        </asp:BoundField>
        <asp:BoundField DataField="content_size" HeaderText="content_size">
            <itemstyle horizontalalign="Left" width="8%" />
            <headerstyle horizontalalign="Left" width="8%" />
        </asp:BoundField>
        <asp:BoundField DataField="create_by" HeaderText="create_by" HtmlEncode="False">
            <itemstyle horizontalalign="Left" width="8%" />
            <headerstyle horizontalalign="Left" width="8%" />
        </asp:BoundField>
        <asp:BoundField DataField="create_date" HeaderText="create_date" DataFormatString="{0:yyyy/MM/dd}"
            HtmlEncode="False">
            <itemstyle horizontalalign="Left" width="20%" />
            <headerstyle horizontalalign="Left" width="20%" />
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
