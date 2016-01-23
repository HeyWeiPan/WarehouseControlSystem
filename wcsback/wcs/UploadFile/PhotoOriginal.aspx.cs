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

public partial class UploadFile_PhotoOriginal : PageBase
{
    private int UserId
    {
        get
        {
            return Fn.ToInt(Request.QueryString["UserId"]);
        }
    }

    public override void SetPageInfo(ref PageParameter p)
    {
        return;
    }

    protected override bool SupportAutoEvents
    {
        get
        {
            return false;
        }
    }    

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        if (!IsPostBack)
        {
            Random r = new Random();
            Img.Src = string.Format("GetThumbnail.ashx?Thumbnail=0&UserId={0}&Id={1}", UserId, r.Next());
            Img.Attributes["onload"] = "onImgLoad(this);";
        }
    }
}
