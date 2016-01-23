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

public partial class CommonUI_WebForm_SelectWeek : System.Web.UI.Page
{  
    /// <summary>
    /// 指定要填写的 Text 的框.
    /// </summary>
    private string m_textboxname = "";

    /// <summary>
    /// 指定要填写的 Value 的框.
    /// </summary>
    private string m_valueboxname = "";

    /// <summary>
    /// 指定填写的 Value 值的类型。
    /// 0 -- yyyy-week (如：2004-30)
    /// 1 -- yyyy-MM-dd
    /// </summary>
    private int m_type = 0;

    /// <summary>
    /// Text 的返回显示格式。
    /// </summary>
    private string m_textformat = "";
  
    private void SetMultiLanguage()
    {
        this.lblMonth1.Text = "Jan";
        this.lblMonth2.Text = "Feb";
        this.lblMonth3.Text = "Mar";
        this.lblMonth4.Text = "Apr";
        this.lblMonth5.Text = "May";
        this.lblMonth6.Text = "Jun";
        this.lblMonth7.Text = "Jul";
        this.lblMonth8.Text = "Aug";
        this.lblMonth9.Text = "Sep";
        this.lblMonth10.Text = "Oct";
        this.lblMonth11.Text = "Nov";
        this.lblMonth12.Text = "Dec";

        this.lnkClear.Text = "Clear";
        this.m_textformat = "{0} year {1} week";
    }

    /// <summary>
    /// 获取传入的值。
    /// 创建人  ：万海滨
    /// 创建日期：2004-09-15
    /// </summary>
    private void GetQueryString()
    {
        this.m_textboxname = Request.QueryString["text"];
        this.m_valueboxname = Request.QueryString["value"];
        this.m_type = Convert.ToInt32(Request.QueryString["type"]);
    }

    /// <summary>
    /// 生成当年的所有 Week。
    /// 创建人  ：万海滨
    /// 创建日期：2004-09-15
    /// </summary>
    /// <param name="year">指定的年。</param>
    private void CreateWeeks(int year)
    {
        DateTime date;
        int month = 1;
        int week = 1;
        int weektotal = 1;
        LinkButton lnkWeek;
        string text;
        string value;

        date = new DateTime(year, 1, 1);
        date = date.AddDays((7 - (int)date.DayOfWeek) % 7);

        while (date.Year == year)
        {
            if (date.Month != month)
            {
                for (int i = week; i < 6; i++)
                {
                    lnkWeek = (LinkButton)this.FindControl("lnkWeek" + month.ToString() + week.ToString());
                    lnkWeek.Visible = false;
                    lnkWeek.ToolTip = "";
                }
                month = date.Month;
                week = 1;
            }

            lnkWeek = (LinkButton)this.FindControl("lnkWeek" + month.ToString() + week.ToString());
            lnkWeek.Visible = true;
            lnkWeek.Text = date.Day.ToString();
            lnkWeek.ToolTip = date.ToString("yyyy-MM-dd");
            text = String.Format(this.m_textformat, year, weektotal);
            if (this.m_type == 0)
            {
                value = year.ToString() + "-" + weektotal.ToString("00");
            }
            else
            {
                value = lnkWeek.ToolTip;
            }
            lnkWeek.Attributes.Add("onclick", "javascript:return SelectClick('" + this.m_textboxname + "', '" + this.m_valueboxname + "', '" + text + "', '" + value + "', '" + lnkWeek.ToolTip + "')");

            week += 1;
            weektotal += 1;
            date = date.AddDays(7);
        }
        for (int i = week; i < 6; i++)
        {
            lnkWeek = (LinkButton)this.FindControl("lnkWeek" + month.ToString() + week.ToString());
            lnkWeek.Visible = false;
            lnkWeek.ToolTip = "";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // 设置多语种。

        SetMultiLanguage();

        // 获取传入的值。

        GetQueryString();

        if (!this.IsPostBack)
        {
            // 获取年份。

            lblYear.Text = Request.QueryString["year"];
            if (lblYear.Text.Equals(""))
            {
                lblYear.Text = DateTime.Now.Year.ToString();
            }

            // 生成当年的所有 Week。

            CreateWeeks(Convert.ToInt32(lblYear.Text));

            lnkClear.Attributes.Add("onclick", "javascript:return SelectClick('" + this.m_textboxname + "', '" + this.m_valueboxname + "', '', '', '')");
        }
    }

    protected void btnPrev_Click(object sender, System.EventArgs e)
    {
        int year;

        year = Convert.ToInt32(lblYear.Text) - 1;
        lblYear.Text = year.ToString();

        CreateWeeks(year);
    }

    protected void btnNext_Click(object sender, System.EventArgs e)
    {
        int year;

        year = Convert.ToInt32(lblYear.Text) + 1;
        lblYear.Text = year.ToString();

        CreateWeeks(year);
    }        
}
