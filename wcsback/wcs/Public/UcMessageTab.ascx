<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UcMessageTab.ascx.cs" Inherits="Public_UcMessageTab" %>
<style type="text/css">
    img
    {
        border: none;
    }
    ul
    {
        list-style: none;
    }
    html, body
    {
       
    }
    
    #right
    {
        float: left;
        width: 100%;
        padding: 0px 10px 0px 10px;
        background: #fff;
    }
    #right span
    {
        float: left;
        width: 100%;
        height: 25px;
        background: url(images/one_01.jpg) repeat-x;
        padding-bottom: 14px;
    }
    #right span a
    {
        float: left;
        width: 60px;
        height: 23px;
        display: block;
        line-height: 24px;
        padding-left: 0px;
        text-align: center;
        cursor: pointer;
    }
    .TabOn
    {
        background: url(images/one_02.jpg) no-repeat;
    }
    code
    {
        float: left;
        width: 100%;
        height: 45px;
        background: url(images/one_03.jpg) no-repeat 21px 35px;       
        padding-left: 15px;
    }
    code a
    {
        float: left;
        display: block;
        font-size: 14px;
        color: #025792;
        line-height: 35px;
        padding-right: 10px;
        padding-left: 20px;
    }
    .ul_one
    {
        float: left;
        width: 91%;
        height: 320px;
        overflow-y: auto;
    }
    .ul_two
    {
        height: 200px;
    }
    .ul_one li
    {
        float: left;
        width: 100%;
        height: 25px;
        overflow: hidden;
        line-height: 28px;
        border-bottom: 1px #c1d4e2 dashed;
        padding-top: 8px;
    }
    #tablethr
    {
        float: left;
        width: 100%;
    }
    #tablethr span
    {
        float: right;
        height: 69px;
        width: 10px;
    }
    #kaoqin
    {
        float: left;
        width: 100%;
        height: 69px;
        padding-top: 0px;
    }
    #kaoqin th
    {
        color: #025792;
        font-weight: normal;
        font-size: 14px;
        line-height: 29px;
        border-right: #e2e2e2 1px solid;
    }
    #kaoqin td
    {
        text-align: center;
        line-height: 29px;
        border-right: #e2e2e2 1px solid;
    }
    #kaoqin td button
    {
        width: 50px;
        height: 26px;
        line-height: 25px;
    }
    #kaoqin th button
    {
        width: 120px;
        height: 26px;
        line-height: 25px;
    }
</style>
<span>
    <asp:LinkButton ID="LnkMessage" runat="server" Text="" Visible="true" />
</span>