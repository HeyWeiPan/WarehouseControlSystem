<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCOperationBtnGroup.ascx.cs"
    Inherits="CommonUI_UserControl_UCOperationBtnGroup" %>
<%@ Register Assembly="EntpClass.WebControlLib" Namespace="EntpClass.WebControlLib"
    TagPrefix="cc1" %>
<cc1:UcButton ID="BtnSubmit" runat="server" ColumnName="Submit" Width="70px" OnClick="BtnSubmit_Click"
    UseSubmitBehavior="False" OnClientClick="window.returnValue='REFRESH';" InsureClickOnce="True" />