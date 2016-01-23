<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleFunctionOperationCheckBox.aspx.cs"
    Inherits="Security_RoleFunctionOperationCheckBox" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="margin: 0;">
    <form id="form1" runat="server">
        <table style="display: inline; width: 100%; height: 57px; table-layout: fixed;">
            <tr>
                <td colspan="3">
                    <asp:CheckBoxList ID="ChkListOperation" runat="server" RepeatDirection="Horizontal"
                        RepeatColumns="6" DataValueField="Operation_ID" DataTextField="Operation_Name"
                        Height="18px" />
                    <asp:Label ID="LabState" runat="server" Width="100%" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td align="right">
                    <cc1:UcButton ID="BtnSave" runat="server" ColumnName="Save" OnClick="BtnSave_Click"
                        OnClientClick='window.returnValue="refresh";' Width="70px" />
                    &nbsp; &nbsp; &nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
