<%@ WebHandler Language="C#" Class="GetReport" %>

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

using EntpClass.WebUI;

public class GetReport : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        //byte[] bytes;
        //string reportPath = context.Request.Params["ReportPath"];

        //if (String.IsNullOrEmpty(reportPath))
        //    return;

        //ReportHelper report = new ReportHelper(reportPath);
        //report.MimeType = "image/tiff";
        //report.Format = "IMAGE";
        ////bytes = report.GetReportStream();

        //context.Response.ClearContent();
        //context.Response.ClearHeaders();                      
        ////context.Response.AppendHeader("content-disposition", "attachment;filename=1");
        ////context.Response.ContentType = "application/octet-stream";
        //context.Response.ContentType = "application/x-img";
        //if (bytes != null)
        //{
        //    context.Response.OutputStream.Write(bytes, 0, bytes.Length);
        //    //context.Response.AppendHeader("Content-Length ", bytes.Length.ToString());   
        //    //context.Response.BinaryWrite(bytes);
        //}
        //context.Response.Flush();
        //context.Response.End();
    }

    public bool IsReusable
    {
        get { return true; }
    }
}

