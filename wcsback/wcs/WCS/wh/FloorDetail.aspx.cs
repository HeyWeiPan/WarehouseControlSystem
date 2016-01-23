using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.WebUI;
using EntpClass.BizLogic.WCS;
using System.Data;
using System.Data.Common;
using System.Text;


public partial class WCS_wh_FloorDetail : SetUpDetailPageBase<WCSFloor>
{
    public string WhId
    {
        get { return Fn.ToString(Request.QueryString["WhId"]); }
    }
    protected override void OnPreRender(EventArgs e)//应用界面-仓库管理-仓库明细-楼层明细网页
    {
        base.OnPreRender(e);
        bool isEdit = false;//“编辑”按钮未按下
        if (CurrentPageMode == PageMode.Add || CurrentPageMode == PageMode.Edit)//如果跳转到”增加“或”编辑“页面
        {
            isEdit = true;
        }





        LnkCell.NavigateUrl = "";

        if (isEdit)
        {

            LnkCell.Visible = false;//编辑时下方“格子信息”隐藏

            IfraSubWindow.Visible = false;//子窗口隐藏，哪个是子窗口？<cc1:UcHyperLink ID="LnkFloor" runat="server" ColumnName="TabFloor" ShowStyle="TabBlue"
                                                                    // Target = "IfraSubWindow" >中表示在子窗口中打开
            IfraSubWindow.Attributes.Add("src", "");


        }
        else
        {

            LnkCell.Visible = true;//显示相应楼层编号的cell分布页面
            LnkCell.NavigateUrl = string.Format("Cell.aspx?FloorId={0}", KeyValue);
            (this.Page as PageBase).AttachClientEvent("windowonload", "window", "onload", string.Format("document.getElementById('{0}').click();", LnkCell.ClientID));
        }



    }

    protected override bool OnPreSave()
    {
        UcHiddenField HidWhId = new UcHiddenField();
        HidWhId.ID = "HidDJID";
        HidWhId.ColumnName = "wh_id";
        HidWhId.Value = WhId;
        this.AddControl(HidWhId);
        return base.OnPreSave();
    }
}