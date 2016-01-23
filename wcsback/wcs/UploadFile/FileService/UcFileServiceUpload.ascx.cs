using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.WebUI;
using EntpClass.Common;
using System.Configuration;
using EntpClass.BizLogic.Setup;
using System.IO;
using System.IO.Compression;

public partial class UploadFile_UcFileServiceUpload : UserControlBase
{
    private static object _lockObject = new object();
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

    private string StorePackage
    {
        get
        {
            return Fn.ToString(Request.QueryString["StorePackage"]);
        }
    }

    private int StoreLinkId
    {
        get
        {
            return Fn.ToInt(Request.QueryString["StoreLinkId"]);
        }
    }

    private int TaskId
    {
        get
        {
            return Fn.ToInt(Request.QueryString["TaskId"]);
        }
    }

    private string CreateUserId
    {
        get
        {
            return Fn.ToString(Request.QueryString["CreateUserId"]);
        }
    }

    private bool ShowFolderType
    {
        get
        {
            return Fn.ToBoolean(Request.QueryString["ShowFolderType"]);
        }
    }

    /// <summary>
    /// 当ShowFolderType为true时，标时当前文件的类型
    /// </summary>
    private string FolderTypeName
    {
        get
        {
            return Fn.ToString(Request.QueryString["FolderTypeName"]);
        }
    }

    private string FolderTypeValue
    {
        get
        {
            return Fn.ToString(Request.QueryString["FolderTypeValue"]);
        }
    }

    private string GetFolderTypeSql()
    {
        string sql = string.Empty;

        if (this.FolderTypeName == "IMP")  //如果当前是PS任务
        {
            sql = "select f.folder_id,folder_name from def_file_folder f,def_dj_filetype t where f.folder_id = t.folder_id and t.dj_sys_type = '" + this.FolderTypeValue + "'";
        }
        else
        {
            sql = "select f.folder_id,folder_name from def_file_folder f where f.folder_id = '" + this.FolderId + "'";
        }
        return sql;
    }

    private bool CheckAttachmentInput()
    {
        //TxtAttachmentFileName
        PageBase page = ((PageBase)this.Page);

        RM rmMs = new RM(ResourceFile.Msg);
        RM rmDb = new RM(ResourceFile.Database);
        Int64 iLength = UpdFile.PostedFile.InputStream.Length;
        Int64 maxLength = Fn.ToInt(ConfigurationManager.AppSettings.Get("UploadFileSize"));
        maxLength = maxLength == 0 ? FileServiceHelper.MaxFileSize : maxLength;
        int size = (int)(maxLength / 1024 / 1024);

        if (ShowFolderType)
        {
            if (string.IsNullOrEmpty(this.DdlFolderId.Text))
            {
                page.Alert(rmMs["PleaseInput"] + rmDb[DdlFolderId.ColumnName]);
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
            DdlFolderId.SqlText = GetFolderTypeSql();
            DdlFolderId.DataBind();

            UcFileUploadList1.SetGridData();
        }

        if (!ShowFolderType)
        {
            LblFolderName.Visible = false;
            DdlFolderId.Visible = false;
        }
        else
        {
            LblFolderName.Visible = true;
            DdlFolderId.Visible = true;
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
            int lastPointIndex = sFileName.LastIndexOf(".");
            string fileExtension = sFileName.Substring(lastPointIndex + 1);

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

            int folderId = ShowFolderType == true ? Fn.ToInt(this.DdlFolderId.SelectedValue) : FolderId;

            string storePackage = (@"\" + DateTime.Now.ToString("yyyyMM") + @"\" + this.StorePackage);

            string physicalPath = Fn.ToString(AppParameter.GetPValue("File_Physical_Path"));
            physicalPath += storePackage;//storepackage是存储位置，即文件夹
           

            string fileGuid;
            if (FileServiceHelper.TryUpload(ApplicationId,
                    InstanceId,
                    folderId,
                    sFileName,
                    Fn.ToInt(this.DdlSecurityLevelId.SelectedValue),
                    sFileFriendlyName,
                    TxtAttachmentDescription.Text,
                    sContentType,
                    fileExtension,
                    Version,
                    storePackage,//StorePackage,'\yyyyMM\ + StorePackage',存放位置增加年月
                    StoreLinkId,
                    TaskId,
                    iLength,
                    CurrentUser.UserID,
                    out fileGuid))
            {
               

                if (UpFile(byteContent, physicalPath, fileGuid + "." + fileExtension))
                {
                    FileServiceHelper.CommitUpload(fileGuid);
                }

                //使用webservice上传文件
                //FileService.FileService s = new FileService.FileService();
                ////因为没有事务，上传成功会，再Commit
                ////上传到文件服务器时，不能使用 用户上传的文件名，使用fileguid
                ////byte [] compressData = Compress(byteContent);
                //if (s.UpFile(byteContent, physicalPath, fileGuid + "." + fileExtension))
                //{
                //    FileServiceHelper.CommitUpload(fileGuid);
                //}


            }

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

    private bool UpFile(byte[] data, string filePath, string fileName)
    {
        try
        {
            if (!Directory.Exists(filePath))
            {
                lock (_lockObject) //防止多人同时创建文件夹，double check
                {
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                }
            }
                     
            using (FileStream fs = File.Create(filePath + @"\" + fileName))
            {
               
                fs.Write(data, 0, data.Length);
            }
        }
        catch
        {
            return false;
        }

        return true;
    }

    //public byte[] Compress(byte[] data) 
    //{ 
    //    try 
    //    { 
    //        MemoryStream ms = new MemoryStream(); 
    //        Stream zipStream = null; 
    //        zipStream = new GZipStream(ms, CompressionMode.Compress, true); 
    //        zipStream.Write(data, 0, data.Length); 
    //        zipStream.Close(); 
    //        ms.Position = 0; 
    //        byte[] compressed_data = new byte[ms.Length]; 
    //        ms.Read(compressed_data, 0, int.Parse(ms.Length.ToString())); 
    //        return compressed_data; 
    //    } 
    //    catch 
    //    { 
    //        return null; 
    //    }
    //}
}
