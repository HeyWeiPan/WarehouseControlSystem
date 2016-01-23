<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterMainWindow.master"
    AutoEventWireup="false" CodeFile="AppInformation.aspx.cs" Inherits="Setup_AppInformation"
    Title="Untitled Page" %>

<%@ Register Src="UcAppInformationTabs.ascx" TagName="UcAppInformationTabs" TagPrefix="uc1" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table id="tabLink" runat="server" style="font-size: 9pt; font-family: 宋体; table-layout: fixed;"
        border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <uc1:UcAppInformationTabs ID="UcAppInformationTabs1" runat="server" SelectedTabID="HyperAppInformation" />
            </td>
        </tr>
        <tr>
            <td class="ContainerBorder">
                <table style="width: 100%; height: 80%; table-layout: fixed;" cellpadding="0" cellspacing="0">
                    <colgroup>
                        <col class="TdLabel" width="18%" />
                        <col align="left" width="20%" />
                        <col class="TdLabel" width="11%" />
                        <col align="left" width="20%" />
                        <col class="TdLabel" width="11%" />
                        <col align="left" width="20%" />
                    </colgroup>
                    <tr>
                        <td>
                            <cc1:UcLabel ID="Uc1" runat="server" ColumnName="corp_name" /></td>
                        <td colspan="2">
                            <cc1:UcTextBox ID="TxtCorpname" runat="server" ColumnName="corp_name" Width="100%"
                                RequiredField="True" /></td>
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:UcLabel ID="Uc3" runat="server" ColumnName="address"></cc1:UcLabel></td>
                        <td colspan="3">
                            <cc1:UcTextBox ID="TxtAddress" runat="server" ColumnName="address" Width="100%" /></td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:UcLabel ID="Uc15" runat="server" ColumnName="corp_code" /></td>
                        <td colspan="2">
                            <cc1:UcTextBox ID="TxtCorpCode" runat="server" ColumnName="corp_code" Width="100%" /></td>
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:UcLabel ID="L15" runat="server" ColumnName="ZengZhiShuiHao" /></td>
                        <td colspan="3">
                            <cc1:UcTextBox ID="TxtZengZhiShuiHao" runat="server" ColumnName="ZengZhiShuiHao"
                                Width="100%" /></td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:UcLabel ID="Uc14" runat="server" ColumnName="bank_name" /></td>
                        <td colspan="2">
                            <cc1:UcTextBox ID="TxtBankName" runat="server" ColumnName="bank_name" Width="100%" /></td>
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:UcLabel ID="Uc16" runat="server" ColumnName="bank_no" /></td>
                        <td colspan="2">
                            <cc1:UcTextBox ID="TxtBankNo" runat="server" ColumnName="bank_no" Width="100%" /></td>
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:UcLabel ID="L50" runat="server" ColumnName="tel" /></td>
                        <td colspan="2">
                            <cc1:UcTextBox ID="TxtTel" runat="server" ColumnName="tel" Width="100%" /></td>
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:UcLabel ID="L51" runat="server" ColumnName="fax" /></td>
                        <td colspan="2">
                            <cc1:UcTextBox ID="Txtfax" runat="server" ColumnName="fax" Width="100%"></cc1:UcTextBox></td>
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:UcLabel ID="L52" runat="server" ColumnName="app_name" /></td>
                        <td colspan="3">
                            <cc1:UcTextBox ID="TxtAppName" runat="server" ColumnName="app_name" Width="100%"></cc1:UcTextBox></td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:UcLabel ID="L53" runat="server" ColumnName="version" /></td>
                        <td colspan="2">
                            <cc1:UcTextBox ID="TxtVersion" runat="server" ColumnName="version" Width="100%" AllowInsert="False"
                                AllowUpdate="False"></cc1:UcTextBox></td>
                        <td colspan="3">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right">
                <cc1:UcButton ID="BtnEdit" runat="server" ColumnName="EDIT" Width="70px" UseSubmitBehavior="False"
                    InsureClickOnce="True" OnClick="BtnEdit_Click" />
                <cc1:UcButton ID="BtnSave" runat="server" ColumnName="Save" Width="70px" UseSubmitBehavior="False"
                    Visible="false" OnClick="BtnSave_Click" /><cc1:UcButton ID="BtnCancel" runat="server"
                        ColumnName="Cancel" Width="70px" UseSubmitBehavior="False" InsureClickOnce="True"
                        Visible="false" OnClick="BtnCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
