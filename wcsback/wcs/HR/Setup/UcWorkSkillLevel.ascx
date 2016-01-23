<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcWorkSkillLevel.ascx.cs"
    Inherits="HR_Setup_UcWorkSkillLevel" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Import Namespace="EntpClass.Common" %>
<%@ Import Namespace="System.Data" %>
<cc1:UcGridView ID="GrdList" Width="100%" runat="server" AutoGenerateColumns="False"
    DataKeyNames="workskill_level_id">
    <Columns>
        <asp:TemplateField HeaderText="workskill_level_number">
            <itemstyle width="8%" />
            <footerstyle width="8%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["workskill_level_number"]%>
            </itemtemplate>
            <edititemtemplate>                   
                 <cc1:UcTextBox ID="T21" runat="server" ColumnName="workskill_level_number" DbDataType="String" Width="100%"  RequiredField="true" Text='<%# ((DataRowView)Container.DataItem).Row["workskill_level_number"] %>'></cc1:UcTextBox>
            </edititemtemplate>
            <footertemplate>                                   
                <cc1:UcTextBox ID="T22" runat="server" ColumnName="workskill_level_number" DbDataType="String" Width="100%"  RequiredField="true"></cc1:UcTextBox>                  
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="workskill_level_description">
            <itemstyle width="65%" />
            <footerstyle width="65%" />
            <itemtemplate>                 
                 <cc1:UcTextBox id="T3" Width="100%" runat="server" UseDefaultStyle="false" ReadOnly="true" TextMode="MultiLine" Rows="6" CssClass="TransparentText"
                 style="word-break:break-all;word-wrap:break-word;" Text='<%# ((DataRowView)Container.DataItem).Row["workskill_level_description"]%>'></cc1:UcTextBox>                                
            </itemtemplate>
            <edititemtemplate>                   
                 <cc1:UcTextBox ID="T31" runat="server" ColumnName="workskill_level_description" DbDataType="String" Width="100%"  RequiredField="true" Rows="6" Text='<%# ((DataRowView)Container.DataItem).Row["workskill_level_description"] %>' TextMode="MultiLine"></cc1:UcTextBox>
            </edititemtemplate>
            <footertemplate>                                   
                <cc1:UcTextBox ID="T32" runat="server" ColumnName="workskill_level_description" DbDataType="String" Width="100%"  RequiredField="true" TextMode="MultiLine" Rows="6"></cc1:UcTextBox>                  
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="score_from">
            <itemstyle width="6%" />
            <footerstyle width="6%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["score_from"]%>
            </itemtemplate>
            <edititemtemplate>                   
                 <cc1:UcTextBox ID="T41" runat="server" ColumnName="score_from" DbDataType="Decimal" Width="100%"  RequiredField="true" Text='<%# ((DataRowView)Container.DataItem).Row["score_from"] %>'></cc1:UcTextBox>
            </edititemtemplate>
            <footertemplate>                                   
                <cc1:UcTextBox ID="T42" runat="server" ColumnName="score_from" DbDataType="Decimal" Width="100%"  RequiredField="true"></cc1:UcTextBox>                  
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="score_to">
            <itemstyle width="6%" />
            <footerstyle width="6%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["score_to"]%>
            </itemtemplate>
            <edititemtemplate>                   
                 <cc1:UcTextBox ID="T51" runat="server" ColumnName="score_to" DbDataType="decimal" Width="100%"  RequiredField="true" Text='<%# ((DataRowView)Container.DataItem).Row["score_to"] %>'></cc1:UcTextBox>
            </edititemtemplate>
            <footertemplate>                                   
                <cc1:UcTextBox ID="T52" runat="server" ColumnName="score_to" DbDataType="decimal" Width="100%"  RequiredField="true"></cc1:UcTextBox>                  
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="adjust_score">
            <itemstyle width="6%" />
            <footerstyle width="6%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["adjust_score"]%>
            </itemtemplate>
            <edititemtemplate>                   
                 <cc1:UcTextBox ID="T61" runat="server" ColumnName="adjust_score" DbDataType="decimal" Width="100%"  RequiredField="true" Text='<%# ((DataRowView)Container.DataItem).Row["adjust_score"] %>'></cc1:UcTextBox>
            </edititemtemplate>
            <footertemplate>                                   
                <cc1:UcTextBox ID="T62" runat="server" ColumnName="adjust_score" DbDataType="decimal" Width="100%"  RequiredField="true"></cc1:UcTextBox>                  
            </footertemplate>
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
