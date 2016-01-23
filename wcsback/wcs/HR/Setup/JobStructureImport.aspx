<%@ Page Language="C#" MasterPageFile="~/CommonUI/MasterPage/MasterDetail.master"
    AutoEventWireup="false" CodeFile="JobStructureImport.aspx.cs" Inherits="HR_Setup_JobStructureImport"
    Title="Untitled Page" %>

<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" runat="Server">
    <table style="width: 100%; table-layout: fixed;" border="0">
        <colgroup>
            <col width="20%" align="left" />
            <col width="60%" align="left" />
            <col width="20%" align="left" />
        </colgroup>
        <tr>
            <td>
                <cc1:UcLabel ID="L4" runat="server" ColumnName="excel_file_name"></cc1:UcLabel>
            </td>
            <td>
                <asp:FileUpload ID="UpdFile" runat="server" Width="95%" Height="22px" />
            </td>
            <td align="left" valign="bottom">
                <cc1:UcButton ID="BtnImport" runat="server" ColumnName="Import" UseSubmitBehavior="false" InsureClickOnce="true"
                    Width="70px" OnClick="BtnImport_Click" OnClientClick="window.returnValue='REFRESH';" /></td>
        </tr>
        <tr>
            <td colspan="3">
                <cc1:UcGridView ID="GrdList" runat="server" DataKeyNames="job_structure_id" AutoGenerateColumns="False"
                    Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="job_code">
                            <itemstyle width="10%" />
                            <itemtemplate>
                                <cc1:UcLabel ID="LabJobCode" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["job_code"]%>' a='<%# ((DataRowView)Container.DataItem).Row["pOut"]%>'/>                                
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="job_type">
                            <itemstyle width="10%" />
                            <itemtemplate>
                                 <%# ((DataRowView)Container.DataItem).Row["job_type"]%>
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="job_function">
                            <itemstyle width="10%" />
                            <itemtemplate>
                                 <%# ((DataRowView)Container.DataItem).Row["job_function"]%>
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="job_family">
                            <itemstyle width="11%" />
                            <itemtemplate>
                                 <%# ((DataRowView)Container.DataItem).Row["job_family"]%>
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="job_level">
                            <itemstyle width="10%" />
                            <itemtemplate>
                                 <%# ((DataRowView)Container.DataItem).Row["job_level"]%>
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="job_title">
                            <itemstyle width="10%" />
                            <itemtemplate>
                                 <%# ((DataRowView)Container.DataItem).Row["job_title"]%>
                            </itemtemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="job_summary">
                            <itemstyle width="30%" />
                            <itemtemplate>
                                 <%# ((DataRowView)Container.DataItem).Row["job_summary"]%>
                            </itemtemplate>
                        </asp:TemplateField>
                    </Columns>                    
                </cc1:UcGridView>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C2" runat="Server">
    <cc1:UcButton ID="BtnClose" runat="server" ColumnName="Close" Width="53px" OnClientClick="window.close();return false;" />
</asp:Content>
