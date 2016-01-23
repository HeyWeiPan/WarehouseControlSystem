<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcWflProcessBak.ascx.cs"
    Inherits="CommonUI_UserControl_UcWflProcessBak" %>
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
            </itemtemplate>
            <itemstyle width="15%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remark">
            <edititemtemplate>
                <cc1:UcTextBox id="TxtRemarkEdit" Width="100%" runat="server" style="word-break:break-all;word-wrap:break-word;" TextMode="MultiLine" Rows="4" Text='<%# ((DataRowView)Container.DataItem).Row["Remark"]%>'></cc1:UcTextBox>                
            </edititemtemplate>
            <itemtemplate>
                <cc1:UcTextBox id="TxtRemarkAdd" Width="99%" runat="server" TextMode="MultiLine" UseDefaultStyle="false" ReadOnly="true" Rows="4" Height="50px" CssClass="TransparentText" Text='<%# ((DataRowView)Container.DataItem).Row["Remark"]%>'></cc1:UcTextBox>             
            </itemtemplate>
            <itemstyle width="45%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Action_By">
            <edititemtemplate>
                <table style="WIDTH: 100%">
                    <tbody>
                        <tr>
                            <td valign="middle" align="center">
                                <cc1:UcButton id="BtnSubmit" Width="80px" runat="server" ColumnName="Submit" OnClick="BtnSubmit_Click"></cc1:UcButton>                                
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
            <itemstyle width="15%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Version">
            <edititemtemplate>
                <cc1:UcHyperLink ID="HEdit" runat="server" Rows="4" TextMode="MultiLine" 
                Text='<%# ((DataRowView)Container.DataItem).Row["Version"]%>' NavigateUrl = <%# GetNavigateUrl( ((DataRowView)Container.DataItem).Row["BAK_ID"],((DataRowView)Container.DataItem).Row["Version"] ) %>/>            
            </edititemtemplate>            
            <itemtemplate>
                <cc1:UcHyperLink ID="HAdd" Width="99%" Rows="4"  ReadOnly="true" UseDefaultStyle="false" runat="server" TextMode="MultiLine" 
                Text='<%# ((DataRowView)Container.DataItem).Row["Version"]%>'  NavigateUrl = <%# GetNavigateUrl( ((DataRowView)Container.DataItem).Row["BAK_ID"],((DataRowView)Container.DataItem).Row["Version"] ) %>/>            
            </itemtemplate>
            <itemstyle width="15%" />
        </asp:TemplateField>
    </Columns>
    <RowStyle BackColor="#EBF2FC" />
    <AlternatingRowStyle BackColor="#EBF2FC" />
    <EditRowStyle BackColor="#EBF2FC" />
</cc1:UcGridView>
