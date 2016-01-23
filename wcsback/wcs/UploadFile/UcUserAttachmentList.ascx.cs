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

using EntpClass.WebUI;
using EntpClass.Common;
using EntpClass.WebControlLib;

public partial class UploadFile_UcUserAttachmentList : UserControlBase
{
    /// <summary>
    /// ApplicationID
    /// </summary>
    private int _ApplicationId;
    public int ApplicationId
    {
        get { return _ApplicationId; }
        set { _ApplicationId = value; }
    }

    /// <summary>
    /// 文件存放的文件目录的Id
    /// 预留文档管理中使用,如果实现文档管理,默认为 ApplicationID
    /// </summary>
    private int _FolderId;
    public int FolderId
    {
        get
        {
           // _FolderId = _FolderId;

            return _FolderId;
        }
        set { _FolderId = value; }
    }

    /// <summary>
    /// 实例Id
    /// </summary>
    private int _InstanceId;
    public int InstanceId
    {
        get { return _InstanceId; }
        set { _InstanceId = value; }
    }

    /// <summary>
    /// 文件的版本
    /// 预留文档管理中使用,默认为空
    /// </summary>
    private string _Version = "";
    public string Version
    {
        get { return _Version; }
        set { _Version = value; }
    }

    /// <summary>
    /// 文件上传用户
    /// </summary>
    private int _CreateUserId = CurrentUser.UserID;
    public int CreateUserId
    {
        get { return _CreateUserId; }
        set { _CreateUserId = value; }
    }

    ///// <summary>
    ///// 是否显示文件类型列
    ///// </summary>
    //private bool _ShowFileType = false;
    //public bool ShowFileType
    //{
    //    get { return _ShowFileType; }
    //    set { _ShowFileType = value; }
    //}

    /// <summary>
    /// 上传权限
    /// </summary>
    private bool _AddRight = true;
    public bool AddRight
    {
        get { return _AddRight; }
        set { _AddRight = value; }
    }

    /// <summary>
    /// 删除权限
    /// </summary>
    private bool _DeleteRight = true;
    public bool DeleteRight
    {
        get { return _DeleteRight; }
        set { _DeleteRight = value; }
    }

    /// <summary>
    /// 验证每一文件是否可以删除的存储过程
    /// </summary>
    private string _CheckDeleteProc = "";
    public string CheckDeleteProc
    {
        get { return _CheckDeleteProc; }
        set { _CheckDeleteProc = value; }
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
            dw.AddUrlParameter("InstanceId", Fn.ToString(InstanceId));
            dw.AddUrlParameter("FolderId", Fn.ToString(FolderId));
            dw.AddUrlParameter("Version", Version);
            dw.AddUrlParameter("DeleteRight", DeleteRight.ToString());
            dw.AddUrlParameter("CheckDeleteProc", CheckDeleteProc);
            dw.Width = 700;
            dw.Height = 490;

            StringBuilder s = new StringBuilder();

            s.Append("function onAddAttachmentClick()");
            s.Append("{");
            s.Append("var returnValue = '';" + dw.GetShowModalDialogScript("returnValue"));
            s.Append("if(returnValue =='REFRESH'){return true;}");
            s.Append("window.event.cancelBubble = true;return false;");
            s.Append("}");

            page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegeditAddAttachmentScript", s.ToString(), true);
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        BtnNew.Visible = false;

        if (AddRight)
        {
            BtnNew.Visible = true;
        }

        if (this.Visible)
        {
            RegeditAddAttachmentScript();
            BtnNew.OnClientClick = "if(!onAddAttachmentClick()){return false;}";
        }

        if (this.Visible && ApplicationId != 0 && InstanceId != 0)
        {
            DataSet ds = FileHelper.GetFileList(ApplicationId, InstanceId, Version, CreateUserId);

            RptList.Visible = true;
            RptList.DataSource = ds;
            RptList.DataBind();
        }
    }
}
