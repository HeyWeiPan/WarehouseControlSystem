<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcJxcDJPF.ascx.cs" Inherits="CommonUI_MasterPage_UcJxcDJPF" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<table style="display: inline; width: 100%; height: 100%;">
    <colgroup>
        <col align="right" width="10%" />
        <col align="left" width="10%" />
        <col align="left" width="13%" />
        <col align="right" width="10%" />
        <col align="left" width="10%" />
        <col align="left" width="13%" />
        <col align="right" width="10%" />
        <col align="left" width="10%" />
        <col align="left" width="13%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="LblPassUserName" ColumnName="pass_user_name" runat="server"></cc1:UcLabel>
        </td>
        <td style="padding-top:5px;">
            <cc1:UcTextBox ID="TxtF11" CssClass="TransparentText" Width="100%" UseDefaultStyle="false"
                ColumnName="pass_user_name" AllowUpdate="false" AllowInsert="false" ReadOnlyWhenInsert="true"
                ReadOnlyWhenUpdate="true" runat="server"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtF21" CssClass="TransparentText" Width="100%" UseDefaultStyle="false"
                ColumnName="pass_date" AllowUpdate="false" AllowInsert="false" ReadOnlyWhenInsert="true"
                ReadOnlyWhenUpdate="true" runat="server"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="LblF12" ColumnName="audit_user_name" runat="server"></cc1:UcLabel>
        </td>
        <td style="padding-top:5px;">
            <cc1:UcTextBox ID="TxtF12" CssClass="TransparentText" Width="100%" UseDefaultStyle="false"
                ColumnName="audit3_user_name" AllowUpdate="false" AllowInsert="false" ReadOnlyWhenInsert="true"
                ReadOnlyWhenUpdate="true" runat="server"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtF22" CssClass="TransparentText" Width="100%" UseDefaultStyle="false"
                ColumnName="audit3_date" AllowUpdate="false" AllowInsert="false" ReadOnlyWhenInsert="true"
                ReadOnlyWhenUpdate="true" runat="server"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="LblF13" ColumnName="Create_By" runat="server"></cc1:UcLabel>
        </td>
        <td style="padding-top:5px;">
            <cc1:UcTextBox ID="TxtF13" CssClass="TransparentText" Width="100%" UseDefaultStyle="false"
                ColumnName="Create_name" AllowUpdate="false" AllowInsert="false" ReadOnlyWhenInsert="true"
                ReadOnlyWhenUpdate="true" runat="server"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtF23" CssClass="TransparentText" Width="100%" UseDefaultStyle="false"
                ColumnName="create_date" AllowUpdate="false" AllowInsert="false" ReadOnlyWhenInsert="true"
                ReadOnlyWhenUpdate="true" runat="server"></cc1:UcTextBox>
        </td>
    </tr>
    <%--<tr>
        <td>
            <cc1:UcLabel ID="LblPassDate" ColumnName="pass_date" runat="server"></cc1:UcLabel>
        </td>
        <td >
           
        </td>
        <td>
            <cc1:UcLabel ID="LblF22" ColumnName="audit3_date" runat="server"></cc1:UcLabel>
        </td>
        <td >
          
        </td>
        <td>
            <cc1:UcLabel ID="LblF23" ColumnName="create_date" runat="server"></cc1:UcLabel>
        </td>
        <td >
           
        </td>
    </tr>--%>
</table>
