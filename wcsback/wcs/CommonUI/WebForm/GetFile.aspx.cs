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

public partial class CommonUI_WebForm_GetFile : System.Web.UI.Page
{    
    private void RenderFile(string fileGUID)
    {
        DataView dtvFile = FileHelper.GetFileByID(fileGUID).Tables[0].DefaultView;
        string fileName = Fn.ToString(dtvFile[0]["FRIENDLY_NAME"]).Trim();
        string ext = FileHelper.GetFileExtension(fileName);
        string origionalFileName = Fn.ToString(dtvFile[0]["ATTACHMENT_NAME"]);

        if (ext == string.Empty || ext != FileHelper.GetFileExtension(origionalFileName))
        {
            fileName = fileName + FileHelper.GetFileExtension(origionalFileName);
        }

        Response.AppendHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName));
        Response.ContentType = Fn.ToString(dtvFile[0]["CONTENT_TYPE"]);
        //Response.OutputStream.Write(Convert.ChangeType(dtvFile[0]["CONTENT"], Byte[]), 0, Fn.ToInt(dtvFile[0]["CONTENT_SIZE"]));
        Response.OutputStream.Write((Byte[])dtvFile[0]["CONTENT"], 0, Fn.ToInt(dtvFile[0]["CONTENT_SIZE"]));
        Response.End();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        RenderFile(GetFuncID());
    }

    protected string GetFuncID()
    {
        return Request.QueryString["FileID"];
    }
}
