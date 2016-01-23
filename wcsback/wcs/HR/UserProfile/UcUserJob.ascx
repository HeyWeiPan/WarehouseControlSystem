<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcUserJob.ascx.cs" Inherits="HR_UserProfile_UcUserJob" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived.HR" Namespace="EntpClass.WebControlLib.Derived.HR"
    TagPrefix="cc3" %>
<table id="tblData" cellspacing="0" cellpadding="0" width="100%" border="0" style="table-layout: fixed;
    height: 100%;">
    <colgroup>
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
        <col class="TdLabel" width="10%" />
        <col align="left" width="15%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="L1" runat="server" ColumnName="job_code"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtJobCode" ColumnName="job_code" runat="server" Width="100%"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L2" ColumnName="job_type" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="T1" ColumnName="job_type" runat="server" Width="100%" ReadOnlyWhenInsert="True"
                ReadOnlyWhenUpdate="True" AllowInsert="false" AllowUpdate="false"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L3" ColumnName="job_function" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="T3" ColumnName="job_function" runat="server" Width="100%" ReadOnlyWhenInsert="True"
                ReadOnlyWhenUpdate="True" AllowInsert="false" AllowUpdate="false">
            </cc1:UcTextBox></td>
        <td>
            <cc1:UcLabel ID="L9" ColumnName="job_family" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="T4" ColumnName="job_family" runat="server" Width="100%" ReadOnlyWhenInsert="True"
                ReadOnlyWhenUpdate="True" AllowInsert="false" AllowUpdate="false"> 
            </cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L6" ColumnName="job_title" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="T6" ColumnName="job_title" runat="server" Width="100%" ReadOnlyWhenInsert="True"
                ReadOnlyWhenUpdate="True" AllowInsert="false" AllowUpdate="false"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L5" ColumnName="job_level" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="T5" ColumnName="job_level" runat="server" Width="100%" ReadOnlyWhenInsert="True"
                ReadOnlyWhenUpdate="True" AllowInsert="false" AllowUpdate="false"></cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L4" ColumnName="pay_grade" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="T7" ColumnName="pay_grade" runat="server" Width="100%" ReadOnlyWhenInsert="True"
                ReadOnlyWhenUpdate="True" AllowInsert="false" AllowUpdate="false">
            </cc1:UcTextBox>
        </td>
    </tr>
    <%--   <tr>
        <td>
            <cc1:UcLabel ID="L8" ColumnName="pay_min" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="T8" ColumnName="pay_min" runat="server" Width="100%" ReadOnlyWhenInsert="True"
                ReadOnlyWhenUpdate="True" AllowInsert="false" AllowUpdate="false">
            </cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L11" ColumnName="pay_mid" runat="server">
            </cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="T11" ColumnName="pay_mid" runat="server" Width="100%" ReadOnlyWhenInsert="True"
                ReadOnlyWhenUpdate="True" AllowInsert="false" AllowUpdate="false">
            </cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L12" ColumnName="pay_max" runat="server">
            </cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="T12" ColumnName="pay_max" runat="server" Width="100%" ReadOnlyWhenInsert="True"
                ReadOnlyWhenUpdate="True" AllowInsert="false" AllowUpdate="false">
            </cc1:UcTextBox>
        </td>
        <td>
            <cc1:UcLabel ID="L13" runat="server">
            </cc1:UcLabel></td>
        <td>
        </td>
    </tr>   --%>
</table>
