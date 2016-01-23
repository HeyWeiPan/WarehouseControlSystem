using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using EntpClass.BizLogic.Setup;
using EntpClass.Common;
using System.Collections;
using EntpClass.WebControlLib;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

public partial class Setup_FileFolderDetail : SetUpDetailPageBase<FileFolder>
{
    private string ParentID
    {
        get { return Fn.ToString(Request.QueryString["ParentID"]); }
    }

    private string ParentName
    {
        get { return Fn.ToString(Request.QueryString["ParentName"]); }
    }

    private bool AddNodeRight
    {
        get { return Fn.ToBoolean(Request.QueryString["AddNodeRight"]); }
    }

    protected override void OnPageModeChanged(PageModeChangedEventArgs e)
    {
        base.OnPageModeChanged(e);

        if (e.NewPageMode == PageMode.Add)
        {
            HidParentID.Value = ParentID;
            TxtParentName.Text = ParentName;
        }
    }
}
