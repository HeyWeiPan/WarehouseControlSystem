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
    /// ��Ҫ��ʾ������
    /// </summary>
    private string BarCode
    {
        get
        {
            return Fn.ToString(Request.QueryString["BarCode"]);
        }
    }

    /// <summary>
    /// �Ƿ���ʾ�����ַ�
    /// </summary>
    private bool DrawChar
    {
        get
        {
            return Fn.ToBoolean(Request.QueryString["DrawChar"],true);
        }
    }

    /// <summary>
    /// �Ƿ���������ʾ�հ�����
    /// </summary>
    private bool AddBlankZone
    {
        get
        {
            return Fn.ToBoolean(Request.QueryString["AddBlankZone"], true);
        }
    }
}
