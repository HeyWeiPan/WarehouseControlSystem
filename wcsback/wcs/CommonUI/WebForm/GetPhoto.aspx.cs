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

public partial class CommonUI_WebForm_GetPhoto : Page
{
    protected override bool SupportAutoEvents
    {
        get
        {
            return false;
        }
    }

    private string PhotoGuid
    {
        get
        {
            return Fn.ToString(Request.QueryString["PhotoGuid"]);
        }
    }

    private void RenderFile(string photoGuid)
    {
        DataSet ds = PhotoHelper.GetPhotoById(PhotoGuid);
        DataView dtvPhoto = ds.Tables[0].DefaultView;

        string photoName = Fn.ToString(dtvPhoto[0]["photo_name"]).Trim();

        Response.AppendHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(photoName));
        Response.ContentType = Fn.ToString(dtvPhoto[0]["content_type"]);
        Response.OutputStream.Write((Byte[])dtvPhoto[0]["content"], 0, Fn.ToInt(dtvPhoto[0]["content_size"]));
        Response.End();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        RenderFile(PhotoGuid);
    }    
}
