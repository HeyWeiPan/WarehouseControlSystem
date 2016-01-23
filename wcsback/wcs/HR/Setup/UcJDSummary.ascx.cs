using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.Security;
using EntpClass.BizLogic.HR.Setup;

public partial class HR_Setup_UcJDSummary : UserControlBase
{
    public override void InitializeEvents()
    {
        base.InitializeEvents();

        PageBase page = (PageBase)this.Parent.Page;
        page.PageModeChanged += new EventHandler<PageModeChangedEventArgs>(page_PageModeChanged);
    }

    void page_PageModeChanged(object sender, PageModeChangedEventArgs e)
    {
        if (e.NewPageMode == PageMode.Edit)
        {
            bool responsibiliRight = RightHelper.CheckFuncRightCached(JobStructure.ResponsibilityFuncID, OperationCode.EDIT);
            TxtJobSummary.ReadOnlyWhenUpdate = !responsibiliRight;
        }
    }    
}
