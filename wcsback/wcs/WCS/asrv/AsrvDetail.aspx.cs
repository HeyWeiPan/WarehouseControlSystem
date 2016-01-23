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



public partial class WCS_asrv_AsrvDetail : SetUpDetailPageBase<WCSAsrv>
{
    public string WhId
    {
        get { return Fn.ToString(Request.QueryString["WhId"]); }
    }

    public string Rack
    {
        get { return Fn.ToString(Request.QueryString["Rack"]); }
    }

    private string DefaultTabColumnName
    {
        get { return Fn.ToString(Request.QueryString["DefaultTab"]); }
    }

    public UcHyperLink GetFirstTab()
    {


        if (LnkAsrvPic.Visible)
            return LnkAsrvPic;
        else if (LnkAsrvStatus.Visible)
            return LnkAsrvStatus;
        else
            return null;
    }
    private UcHyperLink GetCurrentTab()
    {
        string defaultTabColumnName = string.Empty;

        if (!string.IsNullOrEmpty(HidSelectedTab.Value))
        {
            defaultTabColumnName = HidSelectedTab.Value;
        }
        else
        {
            defaultTabColumnName = DefaultTabColumnName;
        }

        if (!string.IsNullOrEmpty(defaultTabColumnName))
        {
            UcHyperLink lnk = null;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is UcHyperLink)
                {
                    lnk = ctrl as UcHyperLink;

                    if (lnk.ColumnName == defaultTabColumnName || lnk.ClientID == defaultTabColumnName)
                    {
                        if (lnk.Visible)
                        {
                            return lnk;
                        }
                        else
                        {
                            return GetFirstTab();
                        }
                    }
                }
            }
        }

        return GetFirstTab();
    }
    UcButton _btnRemoteControl;
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        _btnRemoteControl = new UcButton();
        _btnRemoteControl.ID = "_btnRemoteControl";
        _btnRemoteControl.ColumnName = "RemoteControl";
        _btnRemoteControl.Width = Unit.Pixel(70);
        _btnRemoteControl.OnClientClick = "ShowRemoteControl();return false;";
        base.AddButtonBarControl(_btnRemoteControl);
    }

    private void RegditLnkScript()
    {
        if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegditLnkScript"))
        {
            StringBuilder s = new StringBuilder(1000);

            s.Append("function switchTab(oSelectedTab,columnName,HidSelectedTab)");
            s.Append("{");
            s.Append("document.getElementById(HidSelectedTab).value=oSelectedTab.id;");//保存客户端每次点击TabId

            s.AppendFormat("var TabIfra = document.getElementById('{0}');", TabIfra.ClientID);
            s.Append("TabIfra.style.display='none';");
            s.Append("switch(columnName.toLowerCase())");
            s.Append("{");

            s.Append("case 'tabasrvpic':");
            s.Append("case 'tabasrvstatus':");
            s.Append("TabIfra.style.display='inline';");
            s.Append("document.all('IfraSubWindow').height='100%';");
            s.Append("break;");
            s.Append("}");
            s.Append("}");

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegditLnkScript", s.ToString(), true);
        }
    }


    public void RenderRemoteControlScript()
    {
        if (!ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RenderRemoteControlScript"))
        {
            StringBuilder s = new StringBuilder();
            DialogWindow dw = new DialogWindow();
            dw.Url = UrlHelper.UrlBase + "/WCS/ASRV/RC.aspx";
            dw.DisplayScrollBar = false;
            dw.Width = 400;
            dw.Height = 500;

            dw.AddUrlParameter("AsrvId", KeyValue);
            s.Append("function ShowRemoteControl()");
            s.Append("{");
            s.AppendFormat("var returnValue={0};", dw.GetShowModalDialogScript("returnValue"));
            s.Append("}\n");



            ClientScript.RegisterClientScriptBlock(typeof(string), "RenderRemoteControlScript", s.ToString(), true);
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        bool isEdit = false;
        if (CurrentPageMode == PageMode.Add || CurrentPageMode == PageMode.Edit)
        {
            isEdit = true;
        }

        DdlWh.Visible = isEdit;
        LnkWh.Visible = !isEdit;

        RegditLnkScript();
        if (WhId != "")
            DdlWh.Text = WhId;


        if (Rack != "")
            TxtRack.Text = Rack;


        _btnRemoteControl.Visible = !isEdit;

        LnkAsrvStatus.NavigateUrl = "";

        LnkAsrvPic.NavigateUrl = string.Format("AsrvPic.aspx?Rack={0}", RowData["rack_direction"]);
        if (isEdit)
        {

            LnkAsrvStatus.Visible = false;

            if (CurrentPageMode == PageMode.Add)
                LnkAsrvPic.NavigateUrl = string.Format("AsrvPic.aspx?Rack={0}", Rack);



        }
        else
        {
            RenderRemoteControlScript();
            RegditDetailScript();
            LnkAsrvStatus.Visible = true;
            LnkAsrvStatus.NavigateUrl = string.Format("AsrvStatus.aspx?AsrvId={0}", KeyValue);


        }
        UcHyperLink LnkCurrent = GetCurrentTab();
        if (LnkCurrent == null) { IfraSubWindow.Visible = false; return; }
        AttachClientEvent("windowonload", "window", "onload", string.Format("document.getElementById('{0}').click();", LnkCurrent.ClientID));
    }

    public override void SetControlValue(DBRowBase r)
    {
        base.SetControlValue(r);
        LnkWh.Text = Fn.ToString(r["wh_desc"]);
        LnkWh.OnClientClick = string.Format("ShowWh('VIEW','{0}');return false;", r["wh_id"]);

        LnkAsrvStatus.Attributes.Add("onclick", string.Format("setSelectedTab(this);switchTab(this,'{0}','{1}');", LnkAsrvStatus.ColumnName, LnkAsrvStatus.ClientID));
        LnkAsrvPic.Attributes.Add("onclick", string.Format("setSelectedTab(this);switchTab(this,'{0}','{1}');", LnkAsrvPic.ColumnName, LnkAsrvPic.ClientID));


    }


    public void RegditDetailScript()
    {
        if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegditDetailScript"))
        {
            StringBuilder s = new StringBuilder(1000);
            WCSWH w = new WCSWH();
            DialogWindow dw = w.DetailDialogWindow;
            s.Append(PageBase.GetShowDialogWindowClientFunction(dw, "ShowWh"));

            ClientScript.RegisterClientScriptBlock(this.GetType(), "RegditDetailScript", s.ToString(), true);

        }
    }



}