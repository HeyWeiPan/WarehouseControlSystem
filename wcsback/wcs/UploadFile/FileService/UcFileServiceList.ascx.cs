using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using EntpClass.BizLogic.Security;
using EntpClass.Common;
using System.Data;
using System.Text;


public partial class UploadFile_UcFileServiceList : GridControlBase<File>
{
    /// <summary>
    /// ApplicationID
    /// </summary>
    public int ApplicationId
    {
        get
        {
            string s = Fn.ToString(ViewState["ApplicationId"]);
            if (string.IsNullOrEmpty(s))
            {
                return Fn.ToInt(Request.QueryString["ApplicationId"]);
            }
            return Fn.ToInt(s);
        }
        set
        {
            ViewState["ApplicationId"] = value;
        }
    }

    /// <summary>
    /// 文件存放的文件目录的Id
    /// 预留文档管理中使用,如果实现文档管理,默认为 ApplicationID
    /// </summary>
    public int FolderId
    {
        get
        {
            int folderId = 0;
            string s = Fn.ToString(ViewState["FolderId"]);
            if (string.IsNullOrEmpty(s))
            {
                folderId = Fn.ToInt(Request.QueryString["FolderId"]);
            }
            else
            {
                folderId = Fn.ToInt(s);
            }

            return folderId;
        }
        set
        {
            ViewState["folderId"] = value;
        }
    }

    /// <summary>
    /// 实例Id
    /// </summary>
    public int InstanceId
    {
        get
        {
            string s = Fn.ToString(ViewState["InstanceId"]);
            if (string.IsNullOrEmpty(s))
            {
                return Fn.ToInt(Request.QueryString["InstanceId"]);
            }
            return Fn.ToInt(s);
        }
        set
        {
            ViewState["InstanceId"] = value;
        }
    }

    /// <summary>
    /// 文件的版本
    /// 预留文档管理中使用,默认为空
    /// </summary>
    public string Version
    {
        get
        {
            string s = Fn.ToString(ViewState["Version"]);
            if (string.IsNullOrEmpty(s))
            {
                return Fn.ToString(Request.QueryString["Version"]);
            }
            return s;
        }
        set
        {
            ViewState["Version"] = value;
        }
    }

    /// <summary>
    /// 存储包   
    /// </summary>
    public string StorePackage
    {
        get
        {
            string s = Fn.ToString(ViewState["StorePackage"]);
            if (string.IsNullOrEmpty(s))
            {
                return Fn.ToString(Request.QueryString["StorePackage"]);
            }
            return s;
        }
        set
        {
            ViewState["StorePackage"] = value;
        }
    }
    /// <summary>
    /// 关联存储id
    /// </summary>
    public int StoreLinkId
    {
        get
        {
            int i = Fn.ToInt(ViewState["StoreLinkId"]);
            if (i == 0)
            {
                return Fn.ToInt(Request.QueryString["StoreLinkId"]);
            }
            return i;
        }
        set
        {
            ViewState["StoreLinkId"] = value;
        }
    }

    /// <summary>
    /// 关联存储id
    /// </summary>
    public int TaskId
    {
        get
        {
            int i = Fn.ToInt(ViewState["TaskId"]);
            if (i == 0)
            {
                return Fn.ToInt(Request.QueryString["TaskId"]);
            }
            return i;
        }
        set
        {
            ViewState["TaskId"] = value;
        }
    }

    /// <summary>
    /// 文件上传用户
    /// </summary>
    private int CreateUserId
    {
        get
        {
            //return Fn.ToString(Request.QueryString["CreateUserId"]);
            return CurrentUser.UserID;
        }
    }

    ///// <summary>
    ///// 是否显示文件类型列
    ///// </summary>
    //public bool ShowFileType
    //{
    //    get
    //    {
    //        if (ViewState["ShowFileType"] == null)
    //        {
    //            string str = Fn.ToString(Request.QueryString["ShowFileType"]);
    //            if (string.IsNullOrEmpty(str))
    //                return true;

    //            return Fn.ToBoolean(Request.QueryString["ShowFileType"]);
    //        }
    //        return Fn.ToBoolean(ViewState["ShowFileType"]);
    //    }
    //    set
    //    {
    //        ViewState["ShowFileType"] = value;
    //    }

    //}

    /// <summary>
    /// 上传权限
    /// </summary>
    public bool AddRight
    {
        get
        {
            if (ViewState["addRight"] == null)
            {
                string addRight = Request.QueryString["AddRight"];
                if (string.IsNullOrEmpty(addRight))
                    return true;

                return Fn.ToBoolean(addRight);
            }
            return Fn.ToBoolean(ViewState["addRight"]);
        }
        set
        {
            ViewState["addRight"] = value;
        }
    }

    /// <summary>
    /// 删除权限
    /// </summary>
    public bool DeleteRight
    {
        get
        {
            if (ViewState["deleteRight"] == null)
            {
                string deleteRight = Request.QueryString["DeleteRight"];
                if (string.IsNullOrEmpty(deleteRight))
                    return true;

                return Fn.ToBoolean(deleteRight);
            }
            return Fn.ToBoolean(ViewState["deleteRight"]);
        }
        set
        {
            ViewState["deleteRight"] = value;
        }
    }

    /// <summary>
    /// 验证每一文件是否可以删除的存储过程
    /// </summary>
    public string CheckDeleteProc
    {
        get
        {
            if (ViewState["CheckDeleteProc"] == null)
            {
                return Fn.ToString(Request.QueryString["CheckDeleteProc"]);
            }
            return Fn.ToString(ViewState["CheckDeleteProc"]);
        }
        set
        {
            ViewState["CheckDeleteProc"] = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string ShowFolderType
    {
        get
        {
            string s = Fn.ToString(ViewState["ShowFolderType"]);
            if (string.IsNullOrEmpty(s))
            {
                return Fn.ToString(Request.QueryString["ShowFolderType"]);
            }
            return s;
        }
        set
        {
            ViewState["ShowFolderType"] = value;
        }
    }

    public string FolderTypeName
    {
        get
        {
            string s = Fn.ToString(ViewState["FolderTypeName"]);
            if (string.IsNullOrEmpty(s))
            {
                return Fn.ToString(Request.QueryString["FolderTypeName"]);
            }
            return s;
        }
        set
        {
            ViewState["FolderTypeName"] = value;
        }
    }

    public string FolderTypeValue
    {
        get
        {
            string s = Fn.ToString(ViewState["FolderTypeValue"]);
            if (string.IsNullOrEmpty(s))
            {
                return Fn.ToString(Request.QueryString["FolderTypeValue"]);
            }
            return s;
        }
        set
        {
            ViewState["FolderTypeValue"] = value;
        }
    }


    private void RegeditAddAttachmentScript()
    {
        PageBase page = this.Page as PageBase;

        //弹出文件上传的窗体
        if (!page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegeditAddAttachmentScript"))
        {
            DialogWindow dw = new DialogWindow();
            dw.Url = UrlHelper.UrlBase + "/UploadFile/FileService/FileServiceUpload.aspx";
            dw.AddUrlParameter("ApplicationId", Fn.ToString(ApplicationId));
            dw.AddUrlParameter("FolderId", Fn.ToString(FolderId));
            dw.AddUrlParameter("InstanceId", Fn.ToString(InstanceId));
            dw.AddUrlParameter("Version", Version);
            dw.AddUrlParameter("CreateUserId",  Fn.ToString(CreateUserId));
            dw.AddUrlParameter("DeleteRight", DeleteRight.ToString());
            dw.AddUrlParameter("ShowFolderType", ShowFolderType.ToString());
            dw.AddUrlParameter("FolderTypeName", FolderTypeName.ToString());
            dw.AddUrlParameter("FolderTypeValue", FolderTypeValue.ToString());
            dw.AddUrlParameter("CheckDeleteProc", CheckDeleteProc);
            dw.AddUrlParameter("StorePackage", StorePackage);
            dw.AddUrlParameter("StoreLinkId", StoreLinkId.ToString());
            dw.AddUrlParameter("TaskId", TaskId.ToString());
            
            dw.Width = 700;
            dw.Height = 490;

            StringBuilder s = new StringBuilder();

            s.Append("function onAddAttachmentClick()");
            s.Append("{");
            s.Append("var returnValue = '';" + dw.GetShowModalDialogScript("returnValue"));
            s.Append("if(returnValue =='REFRESH'){__doPostBack('','');}");
            s.Append("window.event.cancelBubble = true;return false;");
            s.Append("}");

            page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegeditAddAttachmentScript", s.ToString(), true);
        }
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
        GridDataLoaded = false;

        base.OnLoad(e);
    }

    protected override GridView GetGridViewControl()
    {
        return GrdFile;
    }

    protected override DataSet GetGridDataSet()
    {
        //根据application_id取用户文件
        if (this.FolderId == 0)
        {
            return FileServiceHelper.GetFileList(ApplicationId, InstanceId, "", CreateUserId);
        }
        else
        {
            return FileServiceHelper.GetFileListByFolder(ApplicationId, InstanceId, FolderId, "", CreateUserId);
        }
    }

    protected override string AddNewText
    {
        get
        {
            if (ViewState["AddNewText"] == null)
            {
                return new RM(ResourceFile.UI)["UploadNewFile"];
            }
            return Fn.ToString(ViewState["AddNewText"]);
        }
        set
        {
            ViewState["AddNewText"] = value;
        }
    }

    protected override void SetRowCommandButton(GridView gv, GridViewRowEventArgs e, GridControlParameter p, PageMode m, ref Panel container)
    {
        base.SetRowCommandButton(gv, e, p, m, ref container);

        if (e.Row.RowType == DataControlRowType.Footer && m == PageMode.View && AddRight)
        {
            LinkButton BtnNew = (LinkButton)container.Controls[1];
            BtnNew.OnClientClick = "if(!onAddAttachmentClick()){{window.event.cancelBubble = true; return false;}}";

            RegeditAddAttachmentScript();
        }
    }

    protected override void SetRowRight(GridView gv, GridViewRowEventArgs e, string keyValue, ref bool editRight, ref bool deleteRight)
    {
        base.SetRowRight(gv, e, keyValue, ref editRight, ref deleteRight);

        if (!DeleteRight)
        {
            deleteRight = false;
        }

        //删除之前,根据传递的存储过程的名字,来检查是否可以删除
        if (!string.IsNullOrEmpty(CheckDeleteProc))
        {
            bool b = FileServiceHelper.CheckDeleteAttachment(keyValue, CheckDeleteProc);
            if (!b)
            {
                deleteRight = false;
            }
        }
    }

    protected override void SetParameter(GridControlParameter p)
    {
        base.SetParameter(p);

        p.DialogMode = false;
        p.EditRight = false;

        p.AddRight = AddRight;
        p.DeleteRight = DeleteRight;
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        GrdFile.RowDataBound += new GridViewRowEventHandler(GrdFile_RowDataBound);
    }

    void GrdFile_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                e.Row.Cells[7].Text = Convert.ToDateTime(e.Row.Cells[7].Text).ToString("yyyy/MM/dd");
            }
            catch { }
        }
    }

    

    //protected override bool OnDelete(string id)
    //{
    //    //删除之前,根据传递的存储过程的名字,来检查是否可以删除
    //    if (!string.IsNullOrEmpty(CheckDeleteProc))
    //    {
    //        bool b = FileHelper.CheckDeleteAttachment(id, CheckDeleteProc);
    //        if (!b)
    //        {
    //            RM rm = new RM(ResourceFile.Msg);
    //            PageBase page = this.Page as PageBase;

    //            page.Alert(rm["DataReference"]);
    //            return false;
    //        }
    //    }

    //    return base.OnDelete(id);
    //}
}
