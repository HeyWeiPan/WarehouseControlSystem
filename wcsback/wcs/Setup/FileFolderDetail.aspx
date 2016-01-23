<%@ Page Language="C#"  MasterPageFile="~/CommonUI/MasterPage/MasterSetupDetail.master" AutoEventWireup="true" CodeFile="FileFolderDetail.aspx.cs" Inherits="Setup_FileFolderDetail" %>


<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table id="tabMain" width="98%" style="font-size: 8pt; font-family: Verdana; table-layout: fixed;
        height: 100%;" cellpadding="0" cellspacing="0" align="left">
        <colgroup>
            <col class="TdLabel" width="30%" />
            <col align="left" width="60%" />
            <col align="left" width="10%" />
        </colgroup>
        <tr>
            <td>
                <cc1:UcLabel ID="Lab2" runat="server" ColumnName="folder_name" Width="100%"></cc1:UcLabel>
            </td>
            <td>
                <cc1:UcTextBox ID="TxtDaleiCode" runat="server" ColumnName="folder_name" Width="100%"
                    RequiredField="True"></cc1:UcTextBox></td>
            <td>
            </td>
        </tr>   
      
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel2" runat="server" ColumnName="parent_name" Width="100%"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="TxtParentName" runat="server" Width="100%" ColumnName="folder_parent_name"
                    AllowInsert="false" AllowUpdate="false" ReadOnlyWhenInsert="True" ReadOnlyWhenUpdate="True"></cc1:UcTextBox>
            </td>
            <td>
            </td>
        </tr>        
        <tr>
            <td>
                <cc1:UcLabel ID="L6" runat="server" ColumnName="Show_Order"></cc1:UcLabel></td>
            <td>
                <cc1:UcTextBox ID="TxtShowOrder" runat="server" ColumnName="Show_Order" RequiredField="True"
                    Width="100%" DbDataType="Int32"></cc1:UcTextBox></td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:UcLabel ID="UcLabel4" runat="server" ColumnName="enable_flag"></cc1:UcLabel></td>
            <td>
                <cc1:UcCheckBox ID="ChkEnableFlag" runat="server" ColumnName="enable_flag" /></td>
            <td>
            </td>
        </tr>
    </table>
    <cc1:UcHiddenField ID="HidParentID" runat="server" ColumnName="folder_pid" AllowUpdate="false"
        DbDataType="int32" />
     <cc1:UcHiddenField ID="HidFolderGuid" runat="server" ColumnName="folder_guid" AllowUpdate="false"
        InsertExpression="newid()" />
</asp:Content>
