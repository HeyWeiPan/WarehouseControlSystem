<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcSysMessageList.ascx.cs"
    Inherits="Public_UcSysMessageList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<script type="text/javascript">
    function ShowDjLinkDetail(detailUrl)
    {
        detailUrl = detailUrl.replace(/&/g, '%26'); 
        rtn = window.showModalDialog(detailUrl + "", '', "dialogHeight:700px;dialogWidth:1000px;center:1;edge:1;help:0;resizable:0;scroll:0;status:0;");
    }
</script>
<table style="width: 100%; margin: 0,0,0,0; padding: 0,0,0,0; border: 0 0 0 0;" cellspacing="0"
    cellpadding="0" border="0">
    <tr>
        <td>
            <ul class="ul_one ul_two">
                <asp:Repeater ID="RptRemindList" runat="server" Visible="false">
                    <ItemTemplate>
                        <li>
                            <img src="images/one_04.jpg" alt="" />
                            <%# ((DataRowView)Container.DataItem).Row["msg_date"]%>                               

                            <asp:HyperLink ID="HyperLink" NavigateUrl='<%# ((DataRowView)Container.DataItem).Row["page_url"] %>'
                                Text='<%# ((DataRowView)Container.DataItem).Row["title"] %>'
                                runat="server">HyperLink</asp:HyperLink>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </td>
    </tr>
</table>
