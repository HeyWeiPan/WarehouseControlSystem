using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Configuration;
using System.Collections;
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
using EntpClass.BizLogic.Security;
using EntpClass.BizLogic.WorkFlow;

public partial class CommonUI_UserControl_UcWflVersionCompare : UserControlBase
{
    private DataSet ds = null;

    private string FunctionID
    {
        get { return Request.QueryString["FunctionID"]; }
    }

    private string CurrentBakID
    {
        get
        {
            return Fn.ToString(Request.QueryString["CurBakID"]);
        }
    }

    private string CurrentVersion
    {
        get
        {
            string currentVersion = Fn.ToString(Request.QueryString["CurVersion"]);
            if (currentVersion != string.Empty)
                currentVersion = currentVersion.Substring(1);

            return Fn.ToString(currentVersion);
        }
    }

    private int PreviousVersion
    {
        get
        {
            return (int)ViewState["PreviousVersion"];
        }
        set
        {
            ViewState["PreviousVersion"] = value;
        }
    }

    private bool IsShowAllModification
    {
        get
        {
            if (ViewState["IsShowAllModification"] == null)
                return true;

            return (bool)ViewState["IsShowAllModification"];
        }
        set
        {
            ViewState["IsShowAllModification"] = value;
        }
    }

    private string BakFormPath
    {
        get { return Request.QueryString["BakFormPath"]; }
    }

    private string VersionCompareProcName
    {
        get { return Request.QueryString["VersionCompareProcName"]; }
    }

    private string VersionCompareAllProcName
    {
        get { return Request.QueryString["VersionCompareAllProcName"];}
    }

    private DataSet GetVersionCompareList()
    {
        string proc = VersionCompareProcName;

        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pCurrentBakID", DbType.String, CurrentBakID);
        db.AddInParameter(cmd, "pCurrentVersion", DbType.String, CurrentVersion);

        return db.ExecuteDataSet(cmd);
    }

    private DataSet GetVersionCompareAllList()
    {
        string proc = VersionCompareAllProcName;

        Database db = DatabaseFactory.CreateDatabase(ScrConst.ConnectionName);
        DbCommand cmd = db.GetStoredProcCommand(proc);
        db.AddInParameter(cmd, "pCurrentBakID", DbType.String, CurrentBakID);
        db.AddInParameter(cmd, "pCurrentVersion", DbType.String, CurrentVersion);

        return db.ExecuteDataSet(cmd);
    }

    private void RegeditBackUpDetail()
    {
        if (!this.Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegeditBackUpDetail"))
        {
            DialogWindow dw = new DialogWindow();
            dw.Url = UrlHelper.UrlBase + BakFormPath;
            dw.AddUrlClientObjectParameter("Mode", "mode");
            dw.AddUrlClientObjectParameter("KeyValue", "keyvalue");
            dw.AddUrlClientObjectParameter("Version", "version");
            dw.AddUrlParameter("FunctionID", FunctionID);
            dw.Width = 1000;
            dw.Height = 700;

            StringBuilder s = new StringBuilder(100);

            s.Append("function ShowBakForm(mode,keyvalue,version)");
            s.Append("{");
            s.Append(dw.GetShowModalDialogScript());
            s.Append("}");

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegeditBackUpDetail", s.ToString().Trim(), true);
        }
    }

    public string GetColumnName(object columnName)
    {
        RM rm = new RM(ResourceFile.Database);

        return rm[Fn.ToString(columnName)];
    }    

    protected override bool SupportAutoEvents
    {
        get
        {
            return false;
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        LnkCurrentVersion.Text = InstanceProcess.VERSIONSTRING + CurrentVersion;
        LnkCurrentVersion.NavigateUrl = string.Format("javascript:ShowBakForm('VIEW','{0}','{1}')", CurrentBakID, CurrentVersion);

        if (!IsPostBack)
        {
            if (CurrentVersion != string.Empty && CurrentVersion != "1")
            {
                if (string.IsNullOrEmpty(VersionCompareProcName))
                    return;

                DataSet ds = GetVersionCompareList();
                if (ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0)
                    return;

                string previousBakID = Fn.ToString(ds.Tables[0].Rows[0]["Previous_Bak_Id"]);
                int previousVersion = Fn.ToInt(CurrentVersion) - 1;

                LnkPreviousVersion.Text = InstanceProcess.VERSIONSTRING + previousVersion.ToString();
                LnkPreviousVersion.NavigateUrl = string.Format("javascript:ShowBakForm('VIEW','{0}','{1}')", previousBakID, previousVersion);

                GrdList.DataSource = ds;
                GrdList.DataBind();
            }

            LnkShowAllModification.ColumnName = "Show_All_Modification";
        }

        LstVersionComparer.ItemDataBound += new DataListItemEventHandler(LstVersionComparer_ItemDataBound);
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        RegeditBackUpDetail();

        int currentVersion = Fn.ToInt(CurrentVersion);
        if (currentVersion == 2)
        {
            LnkShowAllModification.Visible = false;
            return;
        }
    }

    protected void LnkShowAllModification_Click(object sender, EventArgs e)
    {
        if (!IsShowAllModification)
        {
            IsShowAllModification = true;
            LstVersionComparer.Visible = false;
            LnkShowAllModification.ColumnName = "Show_All_Modification";
            return;
        }

        if (ds == null)
        {
            if (string.IsNullOrEmpty(VersionCompareProcName))
                return;

            ds = GetVersionCompareAllList();
        }

        if (ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0)
        {
            LstVersionComparer.Visible = false;
            return;
        }

        int currentVersion = Fn.ToInt(CurrentVersion);
        int[] numbers = new int[currentVersion - 2];
        for (int i = 0; i < currentVersion - 2; i++)
        {
            numbers[i] = i;
        }

        PreviousVersion = currentVersion - 1;

        LstVersionComparer.Visible = true;
        LstVersionComparer.DataSource = numbers;
        LstVersionComparer.DataBind();

        LnkShowAllModification.ColumnName = "Hide_All_Modification";
        IsShowAllModification = false;
    }

    void LstVersionComparer_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        UcGridView grdList = (UcGridView)e.Item.FindControl("GrdList");
        UcHyperLink LnkCurrentVersion = (UcHyperLink)e.Item.FindControl("LnkCurrentVersion");
        UcHyperLink LnkPreviousVersion = (UcHyperLink)e.Item.FindControl("LnkPreviousVersion");
        UcLabel LabCurrentVersion = (UcLabel)e.Item.FindControl("LabCurrentVersion");
        UcLabel LabPreviousVersion = (UcLabel)e.Item.FindControl("LabPreviousVersion");

        DataTable dtAllList = ds.Tables[0];
        DataTable dtTemp = dtAllList.Clone();
        DataRow[] drs = dtAllList.Select("current_Version = " + PreviousVersion);
        if (drs.Length > 0)
        {
            for (int i = 0; i < drs.Length; i++)
            {
                dtTemp.ImportRow(drs[i]);
            }

            grdList.DataSource = dtTemp;
            grdList.DataBind();

            string currentBakID = Fn.ToString(drs[0]["current_bak_ID"]);
            string previousBakID = Fn.ToString(drs[0]["Previous_Bak_Id"]);

            LnkCurrentVersion.Text = InstanceProcess.VERSIONSTRING + (PreviousVersion);
            LnkCurrentVersion.NavigateUrl = string.Format("javascript:ShowBakForm('VIEW','{0}','{1}')", currentBakID, PreviousVersion);

            LnkPreviousVersion.Text = InstanceProcess.VERSIONSTRING + (PreviousVersion - 1);
            LnkPreviousVersion.NavigateUrl = string.Format("javascript:ShowBakForm('VIEW','{0}','{1}')", previousBakID, (PreviousVersion - 1));
        }
        else
        {
            grdList.Visible = false;
            LnkCurrentVersion.Visible = false;
            LnkPreviousVersion.Visible = false;
            LabCurrentVersion.Visible = false;
            LabPreviousVersion.Visible = false;
        }

        PreviousVersion = PreviousVersion - 1;
    }
}
