using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using EntpClass.WebUI;
using EntpClass.Common;

public partial class UploadFile_UcPhotoUpload : UserControlBase
{
    private int UserId
    {
        get
        {
            return Fn.ToInt(Request.QueryString["UserId"]);
        }
    }

    private void RegeditPhotoOriginal()
    {
        PageBase page = (PageBase)this.Page;

        if (!page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RegeditPhotoOriginal"))
        {
            DialogWindow dw = new DialogWindow();
            dw.Url = UrlHelper.UrlBase + "/UploadFile/PhotoOriginal.aspx";
            dw.AddUrlParameter("UserId", Fn.ToString(UserId));
            dw.Width = 350;
            dw.Height = 350;

            Random r = new Random();
            StringBuilder s = new StringBuilder();

            s.Append("function showOriginalImg()");
            s.Append("{");
            s.Append(dw.GetShowModalDialogScript());
            s.Append("}");

            page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RegeditPhotoOriginal", s.ToString(), true);
        }
    }

    protected void BtnUpload_Click(object sender, EventArgs e)
    {
        PageBase page = ((PageBase)this.Page);

        RM rm = new RM(ResourceFile.Msg);        
        Int64 iLength = UpdFile.PostedFile.InputStream.Length;
        Int64 maxLength = Fn.ToInt(ConfigurationManager.AppSettings.Get("UploadPhotoSize"));
        maxLength = maxLength == 0 ? PhotoHelper.MaxPhotoSize : maxLength;
        int size = (int)(maxLength / 1024 / 1024);

        if (iLength == 0)
        {         
            ((PageBase)this.Page).Alert(rm["UPLOAD_FILE_EMPTY_ERROR"]);
            return;
        }
        else if (iLength > maxLength) 
        {
            page.Alert(string.Format(rm["UPLOAD_FILE_SIZE_LIMIT"], size + "M"));
            return;
        }

        string sFileName = UpdFile.PostedFile.FileName;
        sFileName = sFileName.Substring(sFileName.LastIndexOf(@"\") + 1);
        string originalImagePath = Request.PhysicalApplicationPath + "Export/" + sFileName;

        String sContentType = UpdFile.PostedFile.ContentType;
        Byte[] byteContent = new Byte[iLength];

        UpdFile.PostedFile.InputStream.Read(byteContent, 0, Fn.ToInt(iLength));
        String sPhotoName = sFileName;

        #region
        //String sPhotoName = TxtPhotoName.Text;
        //if (sPhotoName.Length == 0)
        //{
        //    sPhotoName = sFileName;
        //}
        #endregion

        //上传文件
        try
        {
            UpdFile.SaveAs(originalImagePath);

            string fileExtension = Path.GetExtension(originalImagePath).ToLower();

            if(fileExtension != ".gif" && fileExtension != ".jpg" && fileExtension != ".bmp" && fileExtension != ".png")
            {
                page.Alert(rm["UPLOAD_FILE_FORMAT"]);
                return;
            }

            byte[] thumbnailContent = PhotoHelper.MakeThumbnail(originalImagePath, Img.Width * 2, Img.Height * 2);

            string photoGuid = Guid.NewGuid().ToString();

            PhotoHelper.InsertPhotoContent(
                    UserId,
                    photoGuid,
                    sPhotoName,
                    byteContent,
                    thumbnailContent,
                    sContentType,
                    iLength,
                    "",//TxtDescription.Text,
                    CurrentUser.UserID);

            Random r = new Random();
            Img.Src = string.Format("GetThumbnail.ashx?Thumbnail=-1&UserId={0}&Id={1}", UserId, r.Next());
        }
        catch (Exception exp)
        {
            page.Alert(exp.Message);
        }
        finally
        {
            //清空当前数据
            //TxtPhotoName.Text = "";
            //TxtDescription.Text = "";
            page.RegisterRefreshScript();//注册刷新脚本
            File.Delete(originalImagePath);
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        RegeditPhotoOriginal();

        RM rm = new RM(ResourceFile.Msg);
        BtnDelete.ConfirmMessage = rm["ConfirmDeleteRow"];

        Random r = new Random();
        Img.Src = string.Format("GetThumbnail.ashx?Thumbnail=-1&UserId={0}&Id={1}", UserId, r.Next());

        DataSet ds = PhotoHelper.GetPhotoList(UserId);
        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            return;

        DataView dtvPhoto = ds.Tables[0].DefaultView;
        string photoName = Fn.ToString(dtvPhoto[0]["photo_name"]).Trim();
        string downLoadUrl = Fn.ToString(dtvPhoto[0]["GetPhotoLink"]).Trim();

        LnkDownLoadPhoto.Visible = true;
        LnkDownLoadPhoto.Text = photoName;
        LnkDownLoadPhoto.Target = "Attachment";
        LnkDownLoadPhoto.NavigateUrl = downLoadUrl;
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        PageBase page = ((PageBase)this.Page);
        PhotoHelper.DeletePhoto(Fn.ToInt(UserId));
        page.RegisterRefreshScript();//注册刷新脚本
    }
}