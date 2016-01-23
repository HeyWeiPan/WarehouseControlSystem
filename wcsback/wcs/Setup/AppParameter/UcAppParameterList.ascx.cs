using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EntpClass.Common;
using EntpClass.WebUI;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.Setup;

public partial class Setup_AppParameter_AppParameterList : GridControlBase<AppParameter>
{
    public int ModuleID
    {
        get
        {
            object obj2 = this.ViewState["ModuleID"];
            if (obj2 != null)
            {
                return (int)obj2;
            }

            return 0;
        }
        set
        {
            this.ViewState["ModuleID"] = value;
        }
    }

    protected override bool SupportAutoEvents
    {
        get
        {
            return false;
        }
    }

    protected override GridView GetGridViewControl()
    {
        return GrdParameterList;
    }

    protected override DataSet GetGridDataSet()
    {
        DataSet ds = AppParameter.GetAppParameterListByModuleID(ModuleID);

        return ds;
    }

    protected override void SetParameter(GridControlParameter p)
    {
        p.AddRight = false;
        p.EditRight = true;
        p.DeleteRight = false;
        p.DialogMode = true;
    }

    protected override void SetDialogWindowParameter(ref DialogWindow w)
    {
        base.SetDialogWindowParameter(ref w);
        w.Url = UrlHelper.UrlBase + ("/Setup/AppParameter/AppParameterSettingDetail.aspx");
        w.Width = 500;
        w.Height = 250;
    }
}