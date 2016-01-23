<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcTeamUserList.ascx.cs"
    Inherits="HR_OrgChart_UcTeamUserList" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="EntpClass.Common" %>
<table width="100%;display:inline;" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <cc1:UcLinkButton ID="LnkTeam" runat="server"></cc1:UcLinkButton>
            <cc1:UcLabel ID="Lab" runat="server"></cc1:UcLabel>
            <cc1:UcLinkButton ID="LnkTeamLeader" runat="server"></cc1:UcLinkButton>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcGridView ID="GrdTeamUserList" runat="server" DataKeyNames="map_id" AutoGenerateColumns="False"
                Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="user_number">
                        <edititemtemplate>   
                           <%# ((DataRowView)Container.DataItem).Row["user_number"]%>                              
                        </edititemtemplate>
                        <itemtemplate>   
                            <cc1:UcLinkButton ID="L21" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "user_number") %>'     
                            title ='<%# DataBinder.Eval(Container.DataItem, "user_guid") %>'           
                            OnClientClick ="ShowUser('VIEW',this.title);window.event.cancelBubble = true;return false;"></cc1:UcLinkButton>                         
                        </itemtemplate>
                        <footerstyle width="8%" />
                        <itemstyle width="8%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="user_name">
                        <edititemtemplate>        
                            <%# ((DataRowView)Container.DataItem).Row["user_name"]%>
                        </edititemtemplate>
                        <footertemplate>  
                              <cc2:UcWebComboUser ID="WcbUser" runat="server" ColumnName="user_id" 
                              CssClass="CssRequired" RequiredField="True" Width="110%" IncludeInactiveUser="True"/>        
                        </footertemplate>
                        <itemtemplate>
                            <%# ((DataRowView)Container.DataItem).Row["user_name"]%>
                        </itemtemplate>
                        <footerstyle width="24%" />
                        <itemstyle width="24%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="gender_code">
                        <edititemtemplate> 
                            <%# DataBinder.Eval(Container.DataItem, "gender_code") %>                 
                        </edititemtemplate>
                        <itemtemplate> 
                            <%# DataBinder.Eval(Container.DataItem, "gender_code") %>                            
                        </itemtemplate>
                        <footerstyle width="7%" />
                        <itemstyle width="7%"  horizontalalign="Center"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="start_date">
                        <edititemtemplate> 
                            <cc1:UcDatePicker ID="DpkStartDateEdit" runat="server" ColumnName="start_date" Text='<%# ((DataRowView)Container.DataItem).Row["start_date"]%>' RequiredField="True" Width="100%"></cc1:UcDatePicker>             
                        </edititemtemplate>
                        <itemtemplate> 
                            <%# DataBinder.Eval(Container.DataItem, "start_date") %>                            
                        </itemtemplate>
                        <footertemplate>  
                            <cc1:UcDatePicker ID="DpkStartDateFoot" runat="server" ColumnName="start_date" Width="100%" RequiredField="True"></cc1:UcDatePicker>             
                        </footertemplate>
                        <footerstyle width="18%" horizontalalign="Center" />
                        <itemstyle width="18%"  horizontalalign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="end_date">
                        <edititemtemplate> 
                            <cc1:UcDatePicker ID="DpkEndDateEdit" runat="server" ColumnName="end_date"  Text='<%# ((DataRowView)Container.DataItem).Row["end_date"]%>' Width="100%"></cc1:UcDatePicker>         
                        </edititemtemplate>
                        <itemtemplate> 
                            <%# DataBinder.Eval(Container.DataItem, "end_date") %>                            
                        </itemtemplate>
                        <footertemplate>  
                            <cc1:UcDatePicker ID="DpkEndDateFoot" runat="server" ColumnName="end_date" Width="100%"></cc1:UcDatePicker>
                        </footertemplate>
                        <footerstyle width="18%" horizontalalign="Center" />
                        <itemstyle width="18%"  horizontalalign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="primary_team_flag" SortExpression="primary_flag">
                        <footerstyle width="12%" horizontalalign="Center" />
                        <itemstyle width="12%"  horizontalalign="Center" />
                        <edititemtemplate>
                           <cc1:UcCheckBox ID="Chk1" runat="server" Width="100%"  ColumnName="primary_flag" Checked='<%# Fn.ToBoolean(DataBinder.Eval(Container.DataItem, "primary_flag")) %>'/>
                        </edititemtemplate>
                        <footertemplate>
                            <cc1:UcCheckBox ID="Chk2" runat="server" Width="100%"   ColumnName="primary_flag" Checked="false" />
                        </footertemplate>
                        <itemtemplate>
                            <cc1:UcCheckBox ID="Chk3" runat="server" Width="100%"  ColumnName="primary_flag" Checked='<%# Fn.ToBoolean(DataBinder.Eval(Container.DataItem, "primary_flag")) %>'  Enabled="false"/>
                        </itemtemplate>
                    </asp:TemplateField>
                </Columns>
            </cc1:UcGridView>
        </td>
    </tr>
</table>
