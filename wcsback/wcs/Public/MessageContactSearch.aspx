<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterDetail.master"
    AutoEventWireup="true" CodeFile="MessageContactSearch.aspx.cs" Inherits="Public_MessageContactSearch" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived.HR" Namespace="EntpClass.WebControlLib.Derived.HR"
    TagPrefix="cc3" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <script type="text/javascript">
        var s = 1;
        var tabId = "<%=GrdList.ClientID%>";
        function AutoClose() {
            if (s == 0) { window.close(); } s--;
        }
        function setAllCheckBoxSelected(obj) {
            var a = document.getElementById(tabId).getElementsByTagName('input');
            for (var i = 0; i < a.length; i++) { var e = a[i]; if (e.type == 'checkbox') { if (e.disabled) { continue; } e.checked = obj.checked; } }
        }
        function onSelect() {    
            var returnArray = new Array();
            var selectCount = 0;
            var table = document.getElementById(tabId);
            var trs = table.rows;
            for (var i = 1; i < trs.length; i++) {
                var obj = new Object();
                var trRow = trs[i];
                var chk = trRow.cells[0].children[0];
                if (typeof (chk) == "undefined" || chk.type != 'checkbox' || chk.checked == false) { continue; }
                obj.userId = trRow.getAttribute('selectedRowID');
                obj.nativeName = trRow.cells[2].innerText;          
                returnArray[selectCount] = obj;
                selectCount++;
            }

            if (selectCount == 0) {
                var id = table.selectedRowID;
                if (id != null && typeof (id) != "undefined" && id != 0) {
                    var obj = new Object(); var trRow = table.selectedrow;
                    obj.userId = table.selectedRowID;
                    obj.nativeName = table.selectedrow.cells[2].innerText;
                 
                    returnArray[0] = obj;
                }
                else {
                    alert(MsgLang.PleaseSelectRow);
                    return false;
                }
            }

            window.returnValue = returnArray; window.close();
            return false;
        }
    </script>
    <table id="tabMain" style="font-size: 9pt; font-family: 宋体; width: 100%; height: 24px;
        table-layout: fixed;">
        <colgroup>
            <col class="TdLabel" width="20%" />
            <col align="left" width="30%" />
            <col class="TdLabel" width="20%" />
            <col align="left" width="30%" />
        </colgroup>
        <tr style="height: 8px">
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="LblPrimaryTeamId" runat="server" ColumnName="primary_team_id" />
            </td>
            <td>
                <cc2:UcTreeWebComboHRTeam ID="TVListTeam" runat="server" Width="100%" ColumnName="user_id"
                    SearchFormat="{0} in (select user_id from hr_team_user where primary_Flag = -1 and delete_flag = 0 and team_id in ( select team_id from hr_team where delete_flag = 0 and lineage like HR.GetTeamLineage({1})  + '%') )"
                    SearchType="Custom" />
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="LabNativeName" runat="server" ColumnName="Native_Name" />
            </td>
            <td>
                <cc1:UcTextBox ID="TxtNativeName" runat="server" ColumnName="Native_Name" Width="100%" />
            </td>
            <td>
                <cc1:UcLabel ID="LblUserNumber" runat="server" ColumnName="user_number" />
            </td>
            <td>
                <cc1:UcTextBox ID="TxtUserNumber" runat="server" ColumnName="user_number" Width="100%" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
                <cc1:UcButton ID="BtnSearch" runat="server" ColumnName="Search" OnClick="BtnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <cc1:UcGridView ID="GrdList" runat="server" AutoGenerateColumns="False" Width="100%"
                    DataKeyNames="user_id" IsSelectable="True" ShowNoRecordsMessage="True">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <cc1:UcCheckBox ID="ChkAll" runat="server" onclick="setAllCheckBoxSelected(this);" /></HeaderTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <cc1:UcCheckBox ID="Chk" runat="server" /></ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="user_number" HeaderText="user_number" />
                        <asp:BoundField DataField="native_name" HeaderText="native_name" />
                        <asp:BoundField DataField="primary_team_name" HeaderText="primary_team_name" />
                        <asp:BoundField DataField="company_email" HeaderText="company_email" />
                    </Columns>
                </cc1:UcGridView>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C2" runat="Server">
    <cc1:UcButton ID="BtnSelect" runat="server" ColumnName="Select" Width="51px" OnClientClick="return onSelect()" />
    <cc1:UcButton ID="BtnClose" runat="server" OnClientClick="window.returnValue ='closed';window.close();return false;"
        ColumnName="Close" Width="53px" />
</asp:Content>
