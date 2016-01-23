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


public partial class WCS_wh_WHDetail : SetUpDetailPageBase<WCSWH>
{
    private string DefaultTabColumnName
    {
        get { return Fn.ToString(Request.QueryString["DefaultTab"]); }//查询默认值数据库，填充到网页相应位置
    }

    public UcHyperLink GetFirstTab()//根据默认值选择返回
    {


        if (LnkFloor.Visible)
            return LnkFloor;
        else if (LnkLift.Visible)
            return LnkLift;
        else if (LnkAsrv.Visible)
            return LnkAsrv;
        else
            return null;
    }
    private UcHyperLink GetCurrentTab()
    {
        string defaultTabColumnName = string.Empty;

        if (!string.IsNullOrEmpty(HidSelectedTab.Value))//HidSelectedTab在对应aspx中有定义，但不知道是啥
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

    private void RegditLnkScript()
    {
        if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegditLnkScript"))
        {
            StringBuilder s = new StringBuilder(1000);//一个大的字符串

            s.Append("function switchTab(oSelectedTab,columnName,HidSelectedTab)");
            s.Append("{");
            s.Append("document.getElementById(HidSelectedTab).value=oSelectedTab.id;");//保存客户端每次点击TabId

            s.AppendFormat("var TabIfra = document.getElementById('{0}');", TabIfra.ClientID);
            s.Append("TabIfra.style.display='none';");
            s.Append("switch(columnName.toLowerCase())");
            s.Append("{");

            s.Append("case 'tabfloor':");
            s.Append("case 'tablift':");
            s.Append("case 'tabasrv':");
            s.Append("TabIfra.style.display='inline';");
            s.Append("document.all('IfraSubWindow').height='100%';");
            s.Append("break;");
            s.Append("}");
            s.Append("}");

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegditLnkScript", s.ToString(), true);
        }
    }

    public override void SetControlValue(DBRowBase r)
    {
        base.SetControlValue(r);


        LnkFloor.Attributes.Add("onclick", string.Format("setSelectedTab(this);switchTab(this,'{0}','{1}');", LnkFloor.ColumnName, LnkFloor.ClientID));
        LnkLift.Attributes.Add("onclick", string.Format("setSelectedTab(this);switchTab(this,'{0}','{1}');", LnkLift.ColumnName, LnkLift.ClientID));
        LnkAsrv.Attributes.Add("onclick", string.Format("setSelectedTab(this);switchTab(this,'{0}','{1}');", LnkAsrv.ColumnName, LnkAsrv.ClientID));

    }


    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        bool isEdit = false;
        if (CurrentPageMode == PageMode.Add || CurrentPageMode == PageMode.Edit)
        {
            isEdit = true;
        }





        LnkLift.NavigateUrl = "";
        LnkFloor.NavigateUrl = "";
        LnkAsrv.NavigateUrl = "";
        if (isEdit)
        {

            LnkFloor.Visible = false;
            LnkLift.Visible = false;
            LnkAsrv.Visible = false;
            IfraSubWindow.Visible = false;
            IfraSubWindow.Attributes.Add("src", "");


        }
        else
        {
            RegditLnkScript();
            LnkFloor.Visible = true;
            LnkFloor.NavigateUrl = string.Format("Floor.aspx?WhId={0}", KeyValue);
            LnkLift.Visible = true;
            LnkLift.NavigateUrl = string.Format("Lift.aspx?WhId={0}", KeyValue);
            LnkAsrv.Visible = true;
            LnkAsrv.NavigateUrl = string.Format("Asrv.aspx?WhId={0}&Rack={1}", KeyValue, RowData["rack_direction"]);
        }




        UcHyperLink LnkCurrent = GetCurrentTab();
        if (LnkCurrent == null) { IfraSubWindow.Visible = false; return; }
        AttachClientEvent("windowonload", "window", "onload", string.Format("document.getElementById('{0}').click();", LnkCurrent.ClientID));
    }


}