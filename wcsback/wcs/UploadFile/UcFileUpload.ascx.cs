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

public partial class UploadFile_UcFileUpload : UserControlBase
{
    private int ApplicationId
    {
        get
        {
            return Fn.ToInt(Request.QueryString["ApplicationId"]);
        }
    }   

    private int FolderId
    {
        get
        {
            return Fn.ToInt(Request.QueryString["FolderId"]);
        }
    }

    private int InstanceId
    {
        get
        {
            return Fn.ToInt(Request.QueryString["InstanceId"]);
        }
    }

    private string Version
    {
        get
        {
            return Fn.ToString(Request.QueryString["Version"]);
        }
    }

    private string CreateUserId
    {
        get
        {
            return Fn.ToString(Request.QueryString["CreateUserId"]);
        }
    }

    private bool ShowFileType
    {
        get
        {            
            return Fn.ToBoolean(Request.QueryString["ShowFileType"]);
        }
    }

    private string GetFileTypeSql()
    {
        string sql
            = " SELECT function_id,function_name_" + DBSetting.MultiLanguageSuffix + " function_name"
            + " FROM scr_function where function_pid = " + FolderId
            + " AND delete_flag = 0 AND enable_flag = -1"
            + " ORDER BY show_order,function_id";

        return sql;
    }

    private bool CheckAttachmentInput()
    { 
        //TxtAttachmentFileName
        PageBase page = ((PageBase)this.Page);

        RM rmMs = new RM(ResourceFile.Msg);
        RM rmDb = new RM(ResourceFile.Msg);
        Int64 iLength = UpdFile.PostedFile.InputStream.Length;
        Int64 maxLength = Fn.ToInt(ConfigurationManager.AppSettings.Get("UploadFileSize"));
        maxLength = maxLength == 0 ? FileHelper.MaxFileSize : maxLength;
        int size = (int)(maxLength / 1024 / 1024);

        if (ShowFileType)
        {
            if (string.IsNullOrEmpty(DrpFileType.Text))
            {
                page.Alert(rmMs["PleaseInput"] + rmDb[DrpFileType.ColumnName]);
                return false;
            }
        }

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

        if (string.IsNullOrEmpty(TxtAttachmentFileName.Text) && TxtAttachmentFileName.RequiredField)
        {
            page.Alert(rmMs["PleaseInput"] + rmDb[TxtAttachmentFileName.ColumnName]);
            return false;
        }

        return true;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (!IsPostBack)
        {
            DrpFileType.SqlText = GetFileTypeSql();
            DrpFileType.DataBind();

            UcFileUploadList1.SetGridData();            
        }

        if (!ShowFileType)
        {
            LabFileType.Visible = false;
            DrpFileType.Visible = false;
        }
        else
        {
            LabFileType.Visible = true;
            DrpFileType.Visible = true;
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

            String sFileFriendlyName = this.TxtAttachmentFileName.Text;
            if (sFileFriendlyName.Length == 0)
            {
                sFileFriendlyName = sFileName;
            }

            int folderId = ShowFileType == true ? Fn.ToInt(DrpFileType.Text) : FolderId;

            FileHelper.InsertFileContent(ApplicationId,
                    InstanceId,
                    folderId,
                    sFileName,
                    sFileFriendlyName,
                    TxtAttachmentDescription.Text,
                    sContentType,
                    Version,
                    iLength,
                    CurrentUser.UserID,
                    byteContent);

            //清空当前数据
            TxtAttachmentFileName.Text = "";
            TxtAttachmentDescription.Text = "";

            UcFileUploadList1.SetGridData();

            page.RegisterRefreshScript();//注册刷新脚本
        }
        catch (Exception exp)
        {
            page.Alert(exp.Message);
        }
    }   
}
