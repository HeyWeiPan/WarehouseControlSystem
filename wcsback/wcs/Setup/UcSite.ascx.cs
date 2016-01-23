using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.Setup;

public partial class Setup_UcSite : UserControlBase
{            
    public override void InitializeEvents()
    {
        PageBase page = (PageBase)this.Parent.Page;

        page.PreSetControlValue += new EventHandler<SetControlValueEventArgs>(page_PreSetControlValue);
        page.PageModeChanged += new EventHandler<PageModeChangedEventArgs>(page_PageModeChanged);
        page.CheckRequired += new CancelEventHandler(page_CheckRequired);        
    } 
  
    void page_PreSetControlValue(object sender, SetControlValueEventArgs e)
    {
        if (e.CurrentPageMode == PageMode.Edit || e.CurrentPageMode == PageMode.Add)
        {
            string provinceId = Fn.ToString(e.DbRowData["province_id"]);
            if (provinceId != "" && provinceId != null)
            {
                DataSet ds = Geography.GetCityList(provinceId);
                DdlCity.SelectedValue = null;
                DdlCity.DataSource = ds;
                DdlCity.DataBind();
            }
        }
    }

    void page_CheckRequired(object sender, CancelEventArgs e)
    {
        PageBase page = (PageBase)this.Page;
        Hashtable dataControlCollection = page.DataControlCollection;
        IWebDataControl ddlCityId = Fn.GetControlByColumnName(dataControlCollection, "city_id");
        string cityId = Request.Params[ddlCityId.UniqueID];
        ddlCityId.RequiredField = false;

        UcHiddenField HidCityId = new UcHiddenField();
        HidCityId.ID = "HidCityId";
        HidCityId.ColumnName = "city_id";
        HidCityId.RequiredField = true;
        HidCityId.Value = cityId;
        page.AddControl(HidCityId);
    }

    void page_PageModeChanged(object sender, PageModeChangedEventArgs e)
    {
        DdlProvince.Visible = true;
        DdlCity.Visible = true;

        TxtProvince.Visible = false;
        TxtCity.Visible = false;

        if (e.NewPageMode == PageMode.View)
        {
            DdlProvince.Visible = false;
            DdlCity.Visible = false;

            TxtProvince.Visible = true;
            TxtCity.Visible = true;
        }
    }   
}