<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcDSSWflProcess.ascx.cs"
    Inherits="UcDSSWflProcess" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<cc1:UcHyperLink ID="TabProcess" runat="server" ColumnName="ProcessInfo" ShowStyle="TabBlue"
    Target="" ResourceFileType="UI" Width="100px"></cc1:UcHyperLink>
<table width="100%" class="ContainerBorder" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td style="padding: 0 0 0 0;">
            <cc1:UcGridView ID="GrdActivity" runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Actions">
                        <HeaderStyle Width="25%" CssClass="TdHead" />
                        <ItemTemplate>
                            <asp:Label ID="LblOperation" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Operation_Name")  %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:RadioButtonList ID="RblOperation" runat="server" DataTextField="operation_name"
                                DataValueField="operation_code" RepeatColumns="1">
                            </asp:RadioButtonList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Conditions">
                        <HeaderStyle Width="45%" CssClass="TdHead" />
                        <ItemTemplate>
                            <cc1:UcTextBox ID="UcTextBox1" Width="100%" CssClass="TransparentText" ReadOnly="true"
                                UseDefaultStyle="false" runat="server" ForeColor="#4A3C8C" TextMode="MultiLine"
                                Text='<%# DataBinder.Eval(Container.DataItem, "Remark") %>'></cc1:UcTextBox>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <cc1:UcTextBox ID="TxtRemark" runat="server" Rows="6" Text='<%# DataBinder.Eval(Container.DataItem, "Remark") %>'
                                TextMode="MultiLine" Width="98%"></cc1:UcTextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Current_State">
                        <HeaderStyle Width="10%" CssClass="TdHead" />
                        <ItemTemplate>
                           <%# DataBinder.Eval(Container.DataItem, "from_state_name") %>
                        </ItemTemplate>                       
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="Action_By">
                        <HeaderStyle Width="15%" CssClass="TdHead" />
                        <ItemTemplate>
                            <asp:Label ID="LblActivityBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Operator_name") %>'></asp:Label>
                            <br />
                            <asp:Label ID="LblActivityDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SDate","{0:yyyy/MM/dd HH:mm}") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <table style="height: 90px; width: 100%;">
                                <tr>
                                    <td valign="middle">
                                        <cc1:UcButton ID="BtnSubmit" InsureClickOnce="true" UseSubmitBehavior="false" runat="server"
                                            Width="80px" ColumnName="Submit" OnClick="BtnSubmit_Click" />
                                    </td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </cc1:UcGridView>
        </td>
    </tr>
</table>
<asp:HiddenField ID="HidForwardPerson" runat="server" />
