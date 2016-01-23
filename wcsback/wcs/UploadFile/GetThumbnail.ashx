<%@ WebHandler Language="C#" Class="GetThumbnail" %>

using System;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;

using EntpClass.Common;

public class GetThumbnail : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        //一:用户
        //Thumbnail
        //-1:缩略图
        //0:正常图
        int thumbnail = Fn.ToInt(context.Request.Params["Thumbnail"]);
        string userId = context.Request.Params["UserId"];
                
        //二:路径
        int width = Fn.ToInt(context.Request.Params["Width"]);
        int height = Fn.ToInt(context.Request.Params["Height"]);
        string originalImagePath = context.Request.Params["OriginalImagePath"];
        
        byte[] bytes;

        if (String.IsNullOrEmpty(userId) && String.IsNullOrEmpty(originalImagePath))
            return;

        if (!string.IsNullOrEmpty(originalImagePath))
        {
            bytes = PhotoHelper.MakeThumbnail(originalImagePath, width, height);
        }
        else
        {
            if (thumbnail == -1)
                bytes = PhotoHelper.GetUserPhotoThumbnail(userId);
            else
                bytes = PhotoHelper.GetUserPhoto(userId);
        }
        
        context.Response.ClearContent();
        context.Response.AppendHeader("content-disposition", "attachment;filename=1");
        context.Response.ContentType = "application/x-img";
        if (bytes != null)
        {
            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
        }
        context.Response.End();
    }

    public bool IsReusable
    {
        get { return true; }
    }    
}

