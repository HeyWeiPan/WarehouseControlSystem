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

public partial class UploadFile_UcUserAttachment : UserControlBase
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
    /// 附件的标题
    /// </summary>
    private string _Title = "";
    public string Title
    {
        get { return _Title; }
        set { _Title = value; }
    }
             
    private bool CheckAttachmentInput()
    {                
        PageBase page = ((PageBase)this.Page);

        RM rmMs = new RM(ResourceFile.Msg);
        Int64 iLength = UpdFile.PostedFile.InputStream.Length;
        Int64 maxLength = Fn.ToInt(ConfigurationManager.AppSettings.Get("UploadFileSize"));
        maxLength = maxLength == 0 ? FileHelper.MaxFileSize : maxLength;
        int size = (int)(maxLength / 1024 / 1024);

        if (iLength == 0)
        {
            page.Alert(rmMs["UPLOAD_FILE_EMPTY_ERROR"]);
            return false;
        }

        if (iLength > maxLength) 
        {
            page.Alert(string.Format(rmMs["UPLOAD_FILE_SIZE_LIMIT"], size + "M"));
            return false;
        }
        
        return true;
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        LnkFile.Text = "";
        LnkFile.NavigateUrl = "";
        LnkFile.Visible = false;      

        BtnUpload.Visible = false;
        BtnDelete.Visible = false;        

        if (AddRight)
        {
            BtnUpload.Visible = true;
        }

        if (DeleteRight)
        {
            BtnDelete.Visible = true;
        }

        if (this.Visible && ApplicationId != 0 && InstanceId != 0)
        {
            DataSet ds = FileHelper.GetFileList(ApplicationId, InstanceId, Version, CreateUserId);

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return;

            string sFileName = Fn.ToString(ds.Tables[0].Rows[0]["friendly_name"]);

            LnkFile.Visible = true;
            LnkFile.Text = string.IsNullOrEmpty(Title) == true ? sFileName : Title;
            LnkFile.NavigateUrl = Fn.ToString(ds.Tables[0].Rows[0]["GetFileLink"]);
        }
    }

    protected void BtnUpload_Click(object sender, EventArgs e)
    {
        PageBase page = ((PageBase)this.Page);

        bool b = CheckAttachmentInput();
        if (!b)
            return;

        //上传文件
        try
        {
            String sFileName = UpdFile.PostedFile.FileName;
            sFileName = sFileName.Substring(sFileName.LastIndexOf(@"\") + 1);

            Int64 iLength = UpdFile.PostedFile.InputStream.Length;

            String sContentType = UpdFile.PostedFile.ContentType;
            Byte[] byteContent = new Byte[iLength];

            UpdFile.PostedFile.InputStream.Read(byteContent, 0, Fn.ToInt(iLength));

            //确保实例只能上传一个附件
            FileHelper.DeleteFile(ApplicationId,InstanceId);

            FileHelper.InsertFileContent(ApplicationId,
                    InstanceId,
                    ApplicationId,
                    sFileName,
                    sFileName,
                    "",
                    sContentType,
                    "",
                    iLength,
                    CurrentUser.UserID,
                    byteContent);     

            page.RegisterRefreshScript();//注册刷新脚本
        }
        catch (Exception exp)
        {
            page.Alert(exp.Message);
        }
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        FileHelper.DeleteFile(ApplicationId, InstanceId);
    }
}
