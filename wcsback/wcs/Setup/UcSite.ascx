<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UcSite.ascx.cs" Inherits="Setup_UcSite" %>
<%@ Register Assembly="EntpClass.WebControlLib.Derived" Namespace="EntpClass.WebControlLib.Derived"
    TagPrefix="cc2" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>

<script type="text/javascript">
        function onProvinceChange(obj){
            if(obj==undefined||obj[obj.selectedIndex].value==""){return;}
            var provinceId = obj[obj.selectedIndex].value;
            WsSetup.GetCityList(provinceId, onSetCityList,f_wserror);
        } 
        function onSetCityList(result){
            var ddlCityId = "<%=DdlCity.ClientID%>"
            f_bindXML(document.getElementById(ddlCityId),result,'CITY','CITY_ID',null,true);            
        }
</script>

<table style="font-size: 9pt; font-family: 宋体; height: 100%; table-layout: fixed;"
    width="100%">
    <colgroup>
        <col class="TdLabel" width="20%" />
        <col align="left" width="60%" />
    </colgroup>
    <tr>
        <td>
            <cc1:UcLabel ID="L1" runat="server" ColumnName="site_name"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtSiteName" runat="server" ColumnName="site_name" Width="100%"
                RequiredField="True"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L2" runat="server" ColumnName="province_id"></cc1:UcLabel>
        </td>
        <td>
            <cc2:UcDdlProvince ID="DdlProvince" runat="server" RequiredField="True" Width="65%"
                OnClientChange="onProvinceChange(this);return false;">
            </cc2:UcDdlProvince>
            <cc1:UcTextBox ID="TxtProvince" runat="server" ColumnName="province_name" Width="100%"
                EnableViewState="false" AllowInsert="False" AllowUpdate="False"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L3" runat="server" ColumnName="city_id"></cc1:UcLabel></td>
        <td>
            <cc2:UcDdlCity ID="DdlCity" runat="server" RequiredField="True" Width="65%" AllowInsert="false"
                AllowUpdate="false">
            </cc2:UcDdlCity>
            <cc1:UcTextBox ID="TxtCity" runat="server" ColumnName="city_name" Width="100%" AllowInsert="False"
                AllowUpdate="False"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L4" runat="server" ColumnName="site_address"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtSiteAddress" runat="server" ColumnName="site_address" Width="100%"></cc1:UcTextBox></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L5" runat="server" ColumnName="zip_code"></cc1:UcLabel></td>
        <td>
            <cc1:UcTextBox ID="TxtZipCode" runat="server" ColumnName="zip_code" Width="65%"></cc1:UcTextBox></td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L6" runat="server" ColumnName="phone"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtPhone" runat="server" ColumnName="phone" Width="65%"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L7" runat="server" ColumnName="fax"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtFax" runat="server" ColumnName="fax" Width="65%"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L9" runat="server" ColumnName="show_order"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcTextBox ID="TxtShowOrder" runat="server" ColumnName="show_order" Width="65%"
                DbDataType="Int32" RequiredField="true"></cc1:UcTextBox>
        </td>
    </tr>
    <tr>
        <td>
            <cc1:UcLabel ID="L8" runat="server" ColumnName="enable_flag"></cc1:UcLabel>
        </td>
        <td>
            <cc1:UcCheckBox ID="ChkEnableFlag" runat="server" ColumnName="enable_flag" DbDataType="Int32">
            </cc1:UcCheckBox>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td style="width: 60%; height: 20px">
        </td>
    </tr>
</table>
