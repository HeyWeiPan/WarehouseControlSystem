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
using System.Drawing;
using System.Drawing.Imaging;
using EntpClass.Common;

public partial class GetBarCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Drawing.Image a = Code128Rendering.MakeBarcodeImage(BarCode, DrawChar, AddBlankZone);
        a.Save(Response.OutputStream, ImageFormat.Gif);
    }

    /// <summary>
    /// 需要显示的条码
    /// </summary>
    private string BarCode
    {
        get
        {
            return Fn.ToString(Request.QueryString["BarCode"]);
        }
    }

    /// <summary>
    /// 是否显示条码字符
    /// </summary>
    private bool DrawChar
    {
        get
        {
            return Fn.ToBoolean(Request.QueryString["DrawChar"],true);
        }
    }

    /// <summary>
    /// 是否在两边显示空白区域
    /// </summary>
    private bool AddBlankZone
    {
        get
        {
            return Fn.ToBoolean(Request.QueryString["AddBlankZone"], true);
        }
    }
}
