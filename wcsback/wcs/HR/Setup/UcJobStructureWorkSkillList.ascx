<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcJobStructureWorkSkillList.ascx.cs"
    Inherits="HR_Setup_UcJobStructureWorkSkillList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Import Namespace="EntpClass.Common" %>
<%@ Import Namespace="System.Data" %>
<cc1:UcGridView ID="GrdProfessinal" Width="100%" runat="server" AutoGenerateColumns="False"
    DataKeyNames="map_id" Visible="false">
    <Columns>
        <asp:TemplateField HeaderText="professional_quality_name">
            <itemstyle width="15%" />
            <footerstyle width="15%" />
            <itemtemplate>                                  
                 <cc1:UcLinkButton ID="PL" runat="server" 
                    Text='<%# ((DataRowView)Container.DataItem).Row["workskill_name"]%>'     
                    a ='<%# ((DataRowView)Container.DataItem).Row["workskill_id"]%>' 
                    OnClientClick ="ShowWorkSkill('VIEW',this.a);window.event.cancelBubble = true;return false;"></cc1:UcLinkButton>                         
            </itemtemplate>
            <edititemtemplate> 
                <cc1:UcDropDownList ID="P1" runat="server" Width="100%" DataTextField="workskill_name" AutoPostBack="true"                      
                    DataValueField="workskill_id" IsInsertItem="true" AutoBindData="true" AllowCache="true" OnSelectedIndexChanged="DdlWorkSkill_SelectedIndexChanged"                    
                    ColumnName="workskill_id" RequiredField="true" SqlText='<%# GetWorkSkillSql() %>'>                 
                </cc1:UcDropDownList>
            </edititemtemplate>
            <footertemplate> 
                <cc1:UcDropDownList ID="P2" runat="server" Width="100%" DataTextField="workskill_name" AutoPostBack="true"
                    DataValueField="workskill_id" IsInsertItem="true" AutoBindData="true" AllowCache="true" OnSelectedIndexChanged="DdlWorkSkill_SelectedIndexChanged"
                    ColumnName="workskill_id" RequiredField="true" SqlText='<%# GetWorkSkillSql() %>'>                  
                </cc1:UcDropDownList>
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="professional_quality_define">
            <itemstyle width="30%" />
            <footerstyle width="30%" />
            <itemtemplate>
                <cc1:UcTextBox id="P7" Width="100%" runat="server" UseDefaultStyle="false" ReadOnly="true" TextMode="MultiLine" CssClass="TransparentText"
                 style="word-break:break-all;word-wrap:break-word;" Text='<%# ((DataRowView)Container.DataItem).Row["skill"]%>'></cc1:UcTextBox>                                                 
            </itemtemplate>
            <edititemtemplate></edititemtemplate>
            <footertemplate></footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="quality_level_description">
            <itemstyle width="42%" />
            <footerstyle width="42%" />
            <itemtemplate>
                <cc1:UcTextBox id="P6" Width="100%" runat="server" UseDefaultStyle="false" ReadOnly="true" TextMode="MultiLine" CssClass="TransparentText"
                 style="word-break:break-all;word-wrap:break-word;" Text='<%# ((DataRowView)Container.DataItem).Row["workskill_level_description"]%>'></cc1:UcTextBox>                                                 
            </itemtemplate>
            <edititemtemplate> 
                <cc1:UcDropDownList ID="P4" runat="server" Width="100%" DataTextField="workskill_level_description"
                    DataValueField="workskill_level_id" IsInsertItem="true" AutoBindData="false" ColumnName="workskill_level_id">
                </cc1:UcDropDownList>
            </edititemtemplate>
            <footertemplate> 
                <cc1:UcDropDownList ID="P5" runat="server" Width="100%" DataTextField="workskill_level_description"
                    DataValueField="workskill_level_id" IsInsertItem="true" AutoBindData="false" ColumnName="workskill_level_id">
                </cc1:UcDropDownList>
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="score">
            <itemstyle width="6%" />
            <footerstyle width="6%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["score"]%>
            </itemtemplate>
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
<cc1:UcGridView ID="GrdKnowledge" Width="100%" runat="server" AutoGenerateColumns="False"
    DataKeyNames="map_id" Visible="false">
    <Columns>
        <asp:TemplateField HeaderText="professional_knowledge_name">
            <itemstyle width="15%" />
            <footerstyle width="15%" />
            <itemtemplate>                 
                 <cc1:UcLinkButton ID="KL" runat="server"
                    Text='<%# ((DataRowView)Container.DataItem).Row["workskill_name"]%>'     
                    a ='<%# ((DataRowView)Container.DataItem).Row["workskill_id"]%>'        
                    OnClientClick ="ShowWorkSkill('VIEW',this.a);window.event.cancelBubble = true;return false;"></cc1:UcLinkButton>
            </itemtemplate>
            <edititemtemplate> 
                <cc1:UcDropDownList ID="K1" runat="server" Width="100%" DataTextField="workskill_name" AutoPostBack="true"                     
                    DataValueField="workskill_id" IsInsertItem="true" AutoBindData="true" AllowCache="true" OnSelectedIndexChanged="DdlWorkSkill_SelectedIndexChanged"                    
                    ColumnName="workskill_id" RequiredField="true" SqlText='<%# GetWorkSkillSql() %>'>                 
                </cc1:UcDropDownList>
            </edititemtemplate>
            <footertemplate> 
                <cc1:UcDropDownList ID="K2" runat="server" Width="100%" DataTextField="workskill_name" AutoPostBack="true"
                    DataValueField="workskill_id" IsInsertItem="true" AutoBindData="true" AllowCache="true" OnSelectedIndexChanged="DdlWorkSkill_SelectedIndexChanged"
                    ColumnName="workskill_id" RequiredField="true" SqlText='<%# GetWorkSkillSql() %>'>                  
                </cc1:UcDropDownList>
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="professional_knowledge_define">
            <itemstyle width="30%" />
            <footerstyle width="30%" />
            <itemtemplate>
                <cc1:UcTextBox id="K7" Width="100%" runat="server" UseDefaultStyle="false" ReadOnly="true" TextMode="MultiLine" CssClass="TransparentText"
                 style="word-break:break-all;word-wrap:break-word;" Text='<%# ((DataRowView)Container.DataItem).Row["skill"]%>'></cc1:UcTextBox>                                                 
            </itemtemplate>
            <edititemtemplate></edititemtemplate>
            <footertemplate></footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="knowledge_level_description">
            <itemstyle width="42%" />
            <footerstyle width="42%" />
            <itemtemplate>
                <cc1:UcTextBox id="K6" Width="100%" runat="server" UseDefaultStyle="false" ReadOnly="true" TextMode="MultiLine" CssClass="TransparentText"
                 style="word-break:break-all;word-wrap:break-word;" Text='<%# ((DataRowView)Container.DataItem).Row["workskill_level_description"]%>'></cc1:UcTextBox>                                                 
            </itemtemplate>
            <edititemtemplate> 
                <cc1:UcDropDownList ID="K4" runat="server" Width="100%" DataTextField="workskill_level_description"
                    DataValueField="workskill_level_id" IsInsertItem="true" AutoBindData="false" ColumnName="workskill_level_id">
                </cc1:UcDropDownList>
            </edititemtemplate>
            <footertemplate> 
                <cc1:UcDropDownList ID="K5" runat="server" Width="100%" DataTextField="workskill_level_description"
                    DataValueField="workskill_level_id" IsInsertItem="true" AutoBindData="false" ColumnName="workskill_level_id">
                </cc1:UcDropDownList>
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="score">
            <itemstyle width="6%" />
            <footerstyle width="6%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["score"]%>
            </itemtemplate>
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
<cc1:UcGridView ID="GrdSkill" Width="100%" runat="server" AutoGenerateColumns="False"
    DataKeyNames="map_id" Visible="false">
    <Columns>
        <asp:TemplateField HeaderText="professional_skill_name">
            <itemstyle width="15%" />
            <footerstyle width="15%" />
            <itemtemplate>                 
                 <cc1:UcLinkButton ID="SL" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["workskill_name"]%>'     
                    a ='<%# ((DataRowView)Container.DataItem).Row["workskill_id"]%>'        
                    OnClientClick ="ShowWorkSkill('VIEW',this.a);window.event.cancelBubble = true;return false;"></cc1:UcLinkButton>
            </itemtemplate>
            <edititemtemplate> 
                <cc1:UcDropDownList ID="S1" runat="server" Width="100%" DataTextField="workskill_name" AutoPostBack="true"                     
                    DataValueField="workskill_id" IsInsertItem="true" AutoBindData="true" AllowCache="true" OnSelectedIndexChanged="DdlWorkSkill_SelectedIndexChanged"                    
                    ColumnName="workskill_id" RequiredField="true" SqlText='<%# GetWorkSkillSql() %>'>                 
                </cc1:UcDropDownList>
            </edititemtemplate>
            <footertemplate> 
                <cc1:UcDropDownList ID="S2" runat="server" Width="100%" DataTextField="workskill_name" AutoPostBack="true"
                    DataValueField="workskill_id" IsInsertItem="true" AutoBindData="true" AllowCache="true" OnSelectedIndexChanged="DdlWorkSkill_SelectedIndexChanged"
                    ColumnName="workskill_id" RequiredField="true" SqlText='<%# GetWorkSkillSql() %>'>                  
                </cc1:UcDropDownList>
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="professional_skill_define">
            <itemstyle width="30%" />
            <footerstyle width="30%" />
            <itemtemplate>
                <cc1:UcTextBox id="S7" Width="100%" runat="server" UseDefaultStyle="false" ReadOnly="true" TextMode="MultiLine" CssClass="TransparentText"
                 style="word-break:break-all;word-wrap:break-word;" Text='<%# ((DataRowView)Container.DataItem).Row["skill"]%>'></cc1:UcTextBox>                                                 
            </itemtemplate>
            <edititemtemplate></edititemtemplate>
            <footertemplate></footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="skill_level_description">
            <itemstyle width="42%" />
            <footerstyle width="42%" />
            <itemtemplate>
                <cc1:UcTextBox id="S6" Width="100%" runat="server" UseDefaultStyle="false" ReadOnly="true" TextMode="MultiLine" CssClass="TransparentText"
                 style="word-break:break-all;word-wrap:break-word;" Text='<%# ((DataRowView)Container.DataItem).Row["workskill_level_description"]%>'></cc1:UcTextBox>                                                 
            </itemtemplate>
            <edititemtemplate> 
                <cc1:UcDropDownList ID="S4" runat="server" Width="100%" DataTextField="workskill_level_description"
                    DataValueField="workskill_level_id" IsInsertItem="true" AutoBindData="false" ColumnName="workskill_level_id">
                </cc1:UcDropDownList>
            </edititemtemplate>
            <footertemplate> 
                <cc1:UcDropDownList ID="S5" runat="server" Width="100%" DataTextField="workskill_level_description"
                    DataValueField="workskill_level_id" IsInsertItem="true" AutoBindData="false" ColumnName="workskill_level_id">
                </cc1:UcDropDownList>
            </footertemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="score">
            <itemstyle width="6%" />
            <footerstyle width="6%" />
            <itemtemplate>
                 <%# ((DataRowView)Container.DataItem).Row["score"]%>
            </itemtemplate>
        </asp:TemplateField>
    </Columns>
</cc1:UcGridView>
