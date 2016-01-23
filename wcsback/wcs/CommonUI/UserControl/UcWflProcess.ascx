<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcWflProcess.ascx.cs"
    Inherits="CommonUI_UserControl_UcWflProcess" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<cc1:UcGridView ID="GrdProcess" runat="server" Width="100%" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField HeaderText="Status">
            <itemstyle width="15%" />
            <itemtemplate>
                <%# ((DataRowView)Container.DataItem).Row["from_state_name"]%>        
            </itemtemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="operation_name">
            <edititemtemplate>
                <asp:RadioButtonList ID="RblOperation" runat="server" DataTextField="operation_name" DataValueField="operation_code" RepeatColumns="1">
                </asp:RadioButtonList>                      
             </edititemtemplate>
            <itemtemplate>                       
                 <%# ((DataRowView)Container.DataItem).Row["operation_name"]%>   
                 <cc1:UcHiddenField ID="HidWflStateId" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["from_state_id"]%>' />    
            </itemtemplate>
            <itemstyle width="15%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remark">
            <edititemtemplate>
                <asp:PlaceHolder ID="PHExtendEdit" runat="server"></asp:PlaceHolder>
                <cc1:UcTextBox id="TxtRemarkEdit" Width="100%" runat="server" style="word-break:break-all;word-wrap:break-word;" TextMode="MultiLine" Rows="4" Text='<%# ((DataRowView)Container.DataItem).Row["Remark"]%>'></cc1:UcTextBox>                                
            </edititemtemplate>
            <itemtemplate>
                <asp:PlaceHolder ID="PHExtendView" runat="server"></asp:PlaceHolder>
                <cc1:UcTextBox id="TxtRemarkItem" Width="99%" runat="server" TextMode="MultiLine" UseDefaultStyle="false" ReadOnly="true" Rows="4" Height="50px" CssClass="TransparentText" Text='<%# ((DataRowView)Container.DataItem).Row["Remark"]%>'></cc1:UcTextBox>                             
            </itemtemplate>
            <itemstyle width="50%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Action_By">
            <edititemtemplate>
                <table style="WIDTH: 100%">
                    <tbody>
                        <tr>
                            <td valign="middle" align="center">
                                <cc1:UcButton id="BtnSubmit" Width="80px" runat="server" ColumnName="Submit" InsureClickOnce="True" UseSubmitBehavior="false" OnClick="BtnSubmit_Click"></cc1:UcButton>                                
                            </td>
                        </tr>
                     </tbody>
                 </table>
            </edititemtemplate>
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["Operator_name"]%>                                         
                <br />
                 <%# string.Format("{0:yyyy/MM/dd HH:mm}", ((DataRowView)Container.DataItem).Row["SDate"])%>                               
            </itemtemplate>
            <itemstyle width="20%" />
        </asp:TemplateField>
    </Columns>
    <RowStyle BackColor="#EBF2FC" />
    <AlternatingRowStyle BackColor="#EBF2FC" />
    <EditRowStyle BackColor="#EBF2FC" />
</cc1:UcGridView>
