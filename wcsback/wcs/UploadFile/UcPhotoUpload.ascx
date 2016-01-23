<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcPhotoUpload.ascx.cs"
    Inherits="UploadFile_UcPhotoUpload" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>

<script type="text/javascript" language="javascript">      
</script>

<style type="text/css">
img{border: 1px solid bule;}
</style>
<table style="width: 100%; table-layout: fixed;" border="0">
    <colgroup>
        <col width="20%" align="left" />
        <col width="60%" align="left" />
        <col width="20%" align="left" />
    </colgroup>
    <tr>
        <td>
        </td>
        <td align="center" valign="middle">
            <img id="Img" runat="server" alt="" ondblclick="showOriginalImg();" width="180" height="180"
                src="GetThumbnail.ashx" />
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td colspan="3" align="center">
            <cc1:UcHyperLink ID="LnkDownLoadPhoto" runat="server" Visible="false"></cc1:UcHyperLink>
        </td>
    </tr>
    <%--  <tr>
        <td>
           <cc1:UcLabel ID="L2" runat="server" ColumnName="photo_name"></cc1:UcLabel>
        </td>
        <td>
           <cc1:UcTextBox ID="TxtPhotoName" runat="server" Width="95%"></cc1:UcTextBox>
        </td>
        <td>
            </td>
    </tr>--%>
    <tr>
        <td>
            <cc1:UcLabel ID="L4" runat="server" ColumnName="photo"></cc1:UcLabel>
        </td>
        <td colspan="2">
            <asp:FileUpload ID="UpdFile" runat="server" Width="100%" Height="22px" />
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td colspan="2" align="right" valign="bottom">
            <cc1:UcButton ID="BtnUpload" runat="server" ColumnName="UploadFile" OnClick="BtnUpload_Click"
                ValidationGroup="FileUpload" />
            <cc1:UcButton ID="BtnDelete" runat="server" ColumnName="Delete" OnClick="BtnDelete_Click"
                Width="70px" /></td>
    </tr>
    <%-- <tr>
        <td>
            <cc1:UcLabel ID="L5" runat="server" ColumnName="description"></cc1:UcLabel>
        </td>
        <td colspan="2">
            <cc1:UcTextBox ID="TxtDescription" runat="server" Width="95%" Rows="3" TextMode="MultiLine"></cc1:UcTextBox>
        </td>
    </tr>--%>
</table>
