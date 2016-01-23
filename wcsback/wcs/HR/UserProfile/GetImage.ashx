<%@ WebHandler Language="C#" Class="GetImage" %>

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
using System.IO;
using System.Drawing;

using EntpClass.Common;
using EntpClass.BizLogic.HR.UserProfile;

public class GetImage : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        byte[] bytes;
        string userId = context.Request.Params["UserId"];
        int thumbnail = Fn.ToInt(context.Request.Params["Thumbnail"]);

        if (String.IsNullOrEmpty(userId))
            return;

        //Thumbnail
        //-1:缩略图
        //0:正常图
        if (thumbnail == -1)
            bytes = PhotoHelper.GetUserPhotoThumbnail(userId);
        else
            bytes = PhotoHelper.GetUserPhoto(userId);                

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

