<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterDetail.master"
    AutoEventWireup="true" CodeFile="PhotoOriginal.aspx.cs" Inherits="UploadFile_PhotoOriginal"
    Title="Untitled Page" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">

    <script type="text/javascript" language="javascript">      
        function onImgLoad(img)
        {                        
            img.onload = null;            
            var re = /px/g;
            var height = window.dialogHeight.replace(re,"");
            var width = window.dialogWidth.replace(re,"");

            if(height < img.height && width < img.width)
            {
                window.dialogHeight  = img.height + "px";
                window.dialogWidth  = img.width + "px";            
            }
        }        
    </script>

    <style type="text/css">
img{border: 1px solid bule;}
</style>
    <table style="width: 100%; height: 100%; table-layout: fixed;" border="0">
        <tr>
            <td align="center" valign="top">
                <img id="Img" runat="server" alt="" src="GetThumbnail.ashx" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C2" runat="Server">
    <cc1:UcButton ID="BtnClose" runat="server" ColumnName="Close" Width="53px" OnClientClick="window.close();return false;" />
</asp:Content>
