using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.Setup;

public partial class Setup_GeographyDetail : SetUpDetailPageBase<Geography>
{
    private string ParentID
    {
        get
        {
            //新增节点的 PID = 当前节点的 ID
            return Fn.ToString(Request.QueryString["ParentID"]);
        }
    }

    private string ParentName
    {
        get
        {                       
            //新增节点的 P_Name = 当前节点的 Name
            return Fn.ToString(Request.QueryString["ParentName"]);

            #region 
            //分割例如:中国(China)[4/4]

            //string parentName = Fn.ToString(Request.QueryString["ParentName"]);
            //int length = parentName.IndexOf("[");//中国(China)[4/4]
            //if (length > 0)
            //    parentName = parentName.Substring(0, length);

            //return parentName;
            #endregion
        }
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

    protected override bool OnPreSave()
    {
        if (ChkDelteFalg.Checked)
        {
            Hashtable controls = DataControlCollection;

            //delete_by
            UcHiddenField HidDeleteBy = new UcHiddenField();
            HidDeleteBy.ID = "HidDeleteBy";
            HidDeleteBy.ColumnName = "delete_by";
            HidDeleteBy.RequiredField = true;
            HidDeleteBy.DbDataType = DbType.Int32;
            HidDeleteBy.Value = Fn.ToString(CurrentUser.UserID);

            //delete_date
            UcHiddenField HidDeleteDate = new UcHiddenField();
            HidDeleteDate.ID = "HidDeleteDate";
            HidDeleteDate.ColumnName = "delete_date";
            HidDeleteDate.RequiredField = true;
            HidDeleteDate.DbDataType = DbType.DateTime;
            HidDeleteDate.Value = DateTime.Now.ToLongTimeString();

            AddControl(HidDeleteBy);
            AddControl(HidDeleteDate);
        }

        return base.OnPreSave();
    }    
}
