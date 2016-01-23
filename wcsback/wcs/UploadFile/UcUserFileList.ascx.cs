using System;
using System.Text;
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
using EntpClass.BizLogic.Security;

public partial class UploadFile_UcUserFileList : GridControlBase<Attachment>
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

    private void RegeditAddAttachmentScript()
    {
        PageBase page = this.Page as PageBase;

        //弹出文件上传的窗体
        if (!page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegeditAddAttachmentScript"))
        {
            DialogWindow dw = new DialogWindow();
            dw.Url = UrlHelper.UrlBase + "/UploadFile/FileUpload.aspx";
            dw.AddUrlParameter("ApplicationId", Fn.ToString(ApplicationId));
            dw.AddUrlParameter("FolderId", Fn.ToString(FolderId));
            dw.AddUrlParameter("InstanceId", Fn.ToString(InstanceId));
            dw.AddUrlParameter("Version", Version);
            //dw.AddUrlParameter("CreateUserId",  CreateUserId);
            dw.AddUrlParameter("DeleteRight", DeleteRight.ToString());
            // dw.AddUrlParameter("ShowFileType", ShowFileType.ToString());
            dw.AddUrlParameter("CheckDeleteProc", CheckDeleteProc);
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
        return GrdAttachment;
    }

    protected override DataSet GetGridDataSet()
    {
        //根据application_id取用户文件
        if (this.FolderId == 0)
        {
            return FileHelper.GetFileList(ApplicationId, InstanceId, Version, CreateUserId);
        }
        else
        {
            return FileHelper.GetFileListByFolder(ApplicationId, InstanceId, FolderId, Version, CreateUserId);
        }
    }

    protected override string AddNewText
    {
        get
        {
            if (ViewState["AddNewText"] == null)
            {
                return new RM(ResourceFile.UI)["ADDNEW"];
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
            bool b = FileHelper.CheckDeleteAttachment(keyValue, CheckDeleteProc);
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
