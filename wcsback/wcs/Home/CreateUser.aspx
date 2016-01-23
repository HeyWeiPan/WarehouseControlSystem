<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterMainWindow.master"
    AutoEventWireup="true" CodeFile="CreateUser.aspx.cs" Inherits="Home_CreateUser"
    Title="Untitled Page" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <div style="text-align: center;">
        <cc1:UcCreateUserWizard ID="CreateUserWizard1" runat="server" CellPadding="0" CellSpacing="0"
            RequireEmail="true" Width="100%" OnCreatedUser="CreateUserWizard1_CreatedUser"
            OnCreatingUser="CreateUserWizard1_CreatingUser">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="Createuserwizardstep1" runat="server">
                    <ContentTemplate>
                        <table style="font-size: 9pt; font-family: ËÎÌו; table-layout: fixed; height: 100%;
                            width: 100%;">
                            <colgroup>
                                <col width="4%" />
                                <col width="16%" align="right" />
                                <col width="15%" align="left" />
                                <col width="16%" align="left" />
                                <col width="4%" />
                            </colgroup>
                            <tr>
                                <td align="center" colspan="5">
                                    Sign Up for Your New Account</td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <cc1:UcLabel ID="LEngFirstName" runat="server" AssociatedControlID="EngFirstName"
                                        ColumnName="eng_first_name"></cc1:UcLabel>
                                </td>
                                <td>
                                    <cc1:UcTextBox ID="EngFirstName" runat="server" Width="100%"></cc1:UcTextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <cc1:UcLabel ID="LabEngMidName" runat="server" AssociatedControlID="EngMidName" ColumnName="eng_mid_name"></cc1:UcLabel></td>
                                <td>
                                    <cc1:UcTextBox ID="EngMidName" runat="server" Width="100%"></cc1:UcTextBox></td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <cc1:UcLabel ID="LabEngLastName" runat="server" AssociatedControlID="EngLastName"
                                        ColumnName="eng_last_name"></cc1:UcLabel></td>
                                <td>
                                    <cc1:UcTextBox ID="EngLastName" runat="server" Width="100%"></cc1:UcTextBox></td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <cc1:UcLabel ID="LabNativeName" runat="server" AssociatedControlID="NativeName" ColumnName="native_name"></cc1:UcLabel></td>
                                <td>
                                    <cc1:UcTextBox ID="NativeName" runat="server" Width="100%"></cc1:UcTextBox></td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <cc1:UcLabel ID="LabLoginName" runat="server" ColumnName="login_name" AssociatedControlID="UserName"></cc1:UcLabel></td>
                                <td>
                                    <cc1:UcTextBox ID="UserName" runat="server" ColumnName="login_name" RequiredField="True"
                                        Width="100%"></cc1:UcTextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <cc1:UcLabel ID="LabEmail" runat="server" AssociatedControlID="Email" ColumnName="email"></cc1:UcLabel></td>
                                <td>
                                    <cc1:UcTextBox ID="Email" runat="server" Width="100%" ColumnName="email" RequiredField="True"></cc1:UcTextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                        ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <cc1:UcLabel ID="LabPassword" runat="server" AssociatedControlID="Password" ColumnName="password"></cc1:UcLabel></td>
                                <td>
                                    <cc1:UcTextBox ID="Password" runat="server" ColumnName="password" TextMode="Password"
                                        Width="100%" RequiredField="True"></cc1:UcTextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <cc1:UcLabel ID="LabConfirmPassword" runat="server" AssociatedControlID="ConfirmPassword"
                                        ColumnName="Confirm_Password"></cc1:UcLabel></td>
                                <td>
                                    <cc1:UcTextBox ID="ConfirmPassword" runat="server" ColumnName="Confirm_Password"
                                        TextMode="Password" Width="100%" RequiredField="True"></cc1:UcTextBox></td>
                                <td>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                        ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required."
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <cc1:UcLabel ID="LabPhoneText" runat="server" AssociatedControlID="Phone" ColumnName="phone_text"></cc1:UcLabel></td>
                                <td>
                                    <cc1:UcTextBox ID="Phone" runat="server" Width="100%"></cc1:UcTextBox></td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <cc1:UcLabel ID="LabOfficeMobile" runat="server" AssociatedControlID="OfficeMobile"
                                        ColumnName="office_mobile"></cc1:UcLabel></td>
                                <td>
                                    <cc1:UcTextBox ID="OfficeMobile" runat="server" Width="100%"></cc1:UcTextBox></td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <cc1:UcLabel ID="LabFaxNum" runat="server" AssociatedControlID="Fax" ColumnName="fax_num"></cc1:UcLabel></td>
                                <td>
                                    <cc1:UcTextBox ID="Fax" runat="server" Width="100%"></cc1:UcTextBox></td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <cc1:UcLabel ID="LabRemark" runat="server" AssociatedControlID="Remark" ColumnName="remark"></cc1:UcLabel></td>
                                <td colspan="2">
                                    <cc1:UcTextBox ID="Remark" runat="server" Width="100%" TextMode="MultiLine"></cc1:UcTextBox></td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                                <td colspan="2">
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                        ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                        ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                                <td style="color: red" colspan="2">
                                    <asp:Literal ID="LabErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                       <%-- <asp:CheckBox ID="SubscribeCheckBox" runat="server" Checked="True" Text="Send   me   a   monthly   newsletter." />
                        <br />
                        <asp:CheckBox ID="ShareInfoCheckBox" runat="server" Checked="True" Text="Share   my   information   with   partner   sites." />--%>
                    </ContentTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                    <ContentTemplate>
                        <table border="0">
                            <tr>
                                <td align="center" colspan="2">
                                    Complete</td>
                            </tr>
                            <tr>
                                <td>
                                    Your account has been successfully created.</td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue"
                                        Text="Continue" ValidationGroup="CreateUserWizard1" OnClick="ContinueButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CompleteWizardStep>
            </WizardSteps>
        </cc1:UcCreateUserWizard>
    </div>
</asp:Content>
