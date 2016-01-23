<%@ Page Title="" Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterSetupDetail.master"
    AutoEventWireup="true" CodeFile="WflStateDetail.aspx.cs" Inherits="Security_WflState_WflStateDetail" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="server">
    <%--<script type="text/javascript">
       
        function hidRoleId() {
            debugger;
            var ddlAssignType = document.getElementById('<%=DdlAssignType.ClientID %>');
            if (ddlAssignType.value == "user") {
                document.getElementById('TrRoleId').style.visibility = 'hidden';
            }
            else {
                document.getElementById('TrRoleId').style.visibility = 'visible';
            }
        }
        
    </script>--%>
    <table style="width: 100%; font-size: 11px; table-layout: fixed;" cellpadding="0"
        cellspacing="0">
        <colgroup>
            <col class="TdLabel" width="25%" />
            <col align="left" width="75%" />
        </colgroup>
        <tr style="height: 40px;">
            <td>
                <cc1:UcLabel ID="L1" runat="server" ColumnName="State_code" Width="100%"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtStateCode" runat="server" ColumnName="State_code" ReadOnlyWhenUpdate="true"
                    AllowUpdate="false" Width="100%" RequiredField="true"></cc1:UcTextBox>
            </td>
        </tr>
        <tr style="height: 40px;">
            <td>
                <cc1:UcLabel ID="L2" runat="server" ColumnName="state_name_cn" Width="100%"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtStateNameCn" runat="server" ColumnName="state_name_cn" Width="100%"
                    RequiredField="true"></cc1:UcTextBox>
            </td>
        </tr>
        <tr style="height: 40px;">
            <td>
                <cc1:UcLabel ID="UcLabel1" runat="server" ColumnName="state_name_en" Width="100%"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtStateNameEn" runat="server" ColumnName="state_name_en" Width="100%"
                    RequiredField="true"></cc1:UcTextBox>
            </td>
        </tr>
        <tr style="height: 40px;">
            <td>
                <cc1:UcLabel ID="L6" runat="server" ColumnName="assign_type" Width="100%"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcDropDownList ID="DdlAssignType" runat="server" ColumnName="assign_type" DataValueField="assign_type"
                    Width="100%" DataTextField="assign_type" IsInsertItem="false" RequiredField="true"
                    AutoPostBack="true" AutoBindData="false"  OnSelectedIndexChanged="DdlAssignType_SelectedIndexChanged">
                    <asp:ListItem Value="user">user</asp:ListItem>
                    <asp:ListItem Value="function">function</asp:ListItem>
                    <asp:ListItem Value="NoOperation">无需操作</asp:ListItem>
                </cc1:UcDropDownList>
                <cc1:UcTextBox ID="TxtAssignType" runat="server" ColumnName="assign_type_name" Width="100%"
                    AllowInsert="false" AllowUpdate="false"></cc1:UcTextBox>
            </td>
        </tr>
        <tr id="TrAssignTo" runat="server" clientidmode="Static" style="height: 40px;">
            <td>
                <cc1:UcLabel ID="LbAssignTo" runat="server" ColumnName="assignto_function" Width="100%"></cc1:UcLabel>
            </td>
            <td>
                <cc2:UcDdlDBElement ID="DdlAssignto" ColumnName="assignto_function" runat="server"
                    ApplicationId="6000000" Width="100%">
                </cc2:UcDdlDBElement>               

                <cc1:UcTextBox ID="TxtAssignto" runat="server" ColumnName="element_name" Width="100%"
                    AllowInsert="false" AllowUpdate="false"></cc1:UcTextBox>
                <cc2:UcWebComboUser ID="DdlAssigntoId" ColumnName="assignto_user_id" runat="server"
                    Width="100%" />
                <cc1:UcTextBox ID="TxtAssigntoId" runat="server" ColumnName="native_name" Width="100%"
                    AllowInsert="false" AllowUpdate="false"></cc1:UcTextBox>
            </td>
        </tr>
        <tr id="TrRoleId" style="height: 40px;" runat="server" clientidmode="Static">
            <td>
                <cc1:UcLabel ID="LbRoleID" runat="server" ColumnName="role_id" Width="100%"></cc1:UcLabel>
            </td>
            <td>
                <cc2:UcWebComboRole ID="WebComboRole" runat="server" ColumnName="role_id" Width="100%" />
                <cc1:UcTextBox ID="TxtRoleId" runat="server" ColumnName="role_name" Width="100%"
                    AllowInsert="false" AllowUpdate="false"></cc1:UcTextBox>
            </td>
        </tr>        
    </table>
</asp:Content>
