using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using EntpClass.Common;
using EntpClass.WebUI;

public partial class CommonUI_WebForm_MultiSort : DialogPageBase
{
    public override void SetPageInfo(ref PageParameter p)
    {
        return;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        if (IsPostBack)
        {
            this.FillRadioButtonValue();
        }
        else
        {
            //绑定左侧 列
            string[] allSortColumn;
            string[] columns;
            string columnName;

            if (Fn.ToLength(AllSortColumns) != 0)
            {
                allSortColumn = AllSortColumns.Split('|');

                for (int i = 0; i < allSortColumn.Length; i++)
                {
                    if (Fn.ToLength(allSortColumn[i]) != 0)
                    {
                        //allSortColumn[i] 格式为 Columnname:SortExpression|(列名和表达式不相等)  或 :SortExpression|
                        columns = allSortColumn[i].Split(':');
                        if (columns.Length == 2)
                        {
                            if (Fn.ToLength(columns[0]) != 0)
                                columnName = columns[0];//Columnname
                            else
                                columnName = columns[1];//SortExpression

                            ListItem item = new ListItem();
                            item.Text = new RM(ResourceFile.Database).GetString(columnName.Replace("T.", ""));
                            item.Value = columns[1].Replace("'",@"\'"); //value中会有dbo.GetUserName(user_id,'cn'),需要把'替换为\',浏览器会进行encode
                            this.listAllSortColumn.Items.Add(item);
                        }
                    }
                }
            }

            #region 还原用户上次选择的列          

            if (Fn.ToLength(MultiSortColumns) != 0)
            {
                string[] multiSortColumn;
                string[] multiSubSortColumn;
                bool up = false;
                bool down = false;

                DataTable dt = new DataTable();
                dt.Columns.Add("SortColumn", typeof(string));
                dt.Columns.Add("SortColumnValue", typeof(string));
                dt.Columns.Add("Up", typeof(bool));
                dt.Columns.Add("Down", typeof(bool));

                multiSortColumn = MultiSortColumns.Split('|');

                for (int i = 0; i < multiSortColumn.Length; i++)
                {
                    up = false;
                    down = false;

                    if (Fn.ToLength(multiSortColumn[i]) != 0)
                    {
                        multiSubSortColumn = multiSortColumn[i].Split(' ');
                        if (multiSubSortColumn != null)
                        {
                            //multiSortColumn[0];  //列
                            //multiSortColumn[1];  //顺序
                            if (multiSubSortColumn[1] == "asc")
                                up = true;
                            else if (multiSubSortColumn[1] == "desc")
                                down = true;

                            dt.Rows.Add(new object[] 
                                { 
                                    new RM(ResourceFile.Database).GetString(FindSortColumnName(multiSubSortColumn[0])),
                                    multiSubSortColumn[0].Replace("'",@"\'"),
                                    up,
                                    down 
                                });
                        }
                    }
                }

                SortColumnsState = dt;

                this.repeaterSort.DataSource = dt;
                this.repeaterSort.DataBind();
            }

            #endregion
        }
    }
    /// <summary>
    /// 根据排序值，从AllSortColumn中返回对应的名称
    /// </summary>
    /// <param name="sortColumnValue"></param>
    /// <returns></returns>
    private string FindSortColumnName(string sortColumnValue)
    {
        string[] columns = null;
        string columnName = string.Empty;

        string [] allSortColumns = AllSortColumns.Split('|');
        for (int i = 0; i < allSortColumns.Length; i++)
        {
             //allSortColumn[i] 格式为 Columnname:SortExpression|(列名和表达式不相等)  或 :SortExpression|
            columns = allSortColumns[i].Split(':');
            if (columns.Length == 2)
            {
                if (Fn.ToLength(columns[0]) != 0)
                    columnName = columns[0];//Columnname
                else
                    columnName = columns[1];//SortExpression

                if (sortColumnValue.ToLower() == columns[1].ToLower())
                {
                    return columnName.Replace("T.","");
                }
            }
        }

        return string.Empty;        
    }

    /// <summary>
    /// 反填RadioButton状态
    /// </summary>
    private void FillRadioButtonValue()
    {
        if (SortColumnsState != null)
        {
            for (int i = 0; i < this.repeaterSort.Items.Count; i++)
            {
                Label lblSort = this.repeaterSort.Items[i].FindControl("lblSort") as Label;
                if (lblSort != null)
                {
                    DataRow[] dr = SortColumnsState.Select(string.Format("SortColumn='{0}'", lblSort.Text));
                    if (dr != null)
                    {
                        RadioButton radUp = this.repeaterSort.Items[i].FindControl("radUp") as RadioButton;
                        if (radUp != null && radUp.Checked)
                        {
                            dr[0]["Up"] = true;
                            continue;
                        }

                        RadioButton radDown = this.repeaterSort.Items[i].FindControl("radDown") as RadioButton;
                        if (radDown != null && radDown.Checked)
                        {
                            dr[0]["Down"] = true;
                            continue;
                        }
                    }
                }
            }
        }
    }

    public DataTable SortColumnsState
    {
        get
        {
            return ViewState["SortColumnsState"] as DataTable;
        }
        set
        {
            ViewState["SortColumnsState"] = value;
        }
    }

    private string AllSortColumns
    {
        get
        {
            //SetUpListPageBase会传入 HttpUtility.UrlEncode的字符串，防止，传入''
            return HttpUtility.UrlDecode(Fn.ToString(this.Page.Request.QueryString["AllSortColumns"]));
        }
    }


    private int PageFunctionID
    {
        get
        {
            return Fn.ToInt(this.Page.Request.QueryString["PageFunctionID"]);
        }
    }

    private string _multiSortColumns = string.Empty;

    private string MultiSortColumns
    {
        get
        {
            if (Fn.ToLength(this._multiSortColumns) == 0)
            {

                //如果未传入
                _multiSortColumns = HttpUtility.UrlDecode( Fn.ToString(this.Page.Request.QueryString["MultiSortColumns"]));

            }

            return _multiSortColumns;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (this.listAllSortColumn.SelectedIndex == -1)
            return;

        //当前选中的文本
        string text = this.listAllSortColumn.SelectedItem.Text;
        //当前选中的值
        string value = this.listAllSortColumn.SelectedItem.Value;

        DataTable dt = new DataTable();

        //如果状态为空，注册一个DataTable
        if (SortColumnsState == null)
        {
            dt.Columns.Add("SortColumn", typeof(string));
            dt.Columns.Add("SortColumnValue", typeof(string));
            dt.Columns.Add("Up", typeof(bool));
            dt.Columns.Add("Down", typeof(bool));
            dt.Rows.Add(new object[] { text, value, true, false });

            SortColumnsState = dt;
        }
        else
        {
            //验证行不能超过三个
            dt = (SortColumnsState as DataTable);
            if (dt.Rows.Count >= 3)
            {
                Alert("多项排序不能超过三列");
                return;
            }

            //判断重复项
            DataRow[] drs = dt.Select(string.Format("SortColumn='{0}'", text));
            if (drs != null && drs.Length > 0)
            {
                Alert(text + "已存在，不能重复添加");
            }
            else
            {
                dt.Rows.Add(new object[] { text, value, true, false });
            }
        }

        this.repeaterSort.DataSource = dt;
        this.repeaterSort.DataBind();

    }

    protected void BtnOK_Click(object sender, EventArgs e)
    {


        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < this.repeaterSort.Items.Count; i++)
        {
            Label lblSort = this.repeaterSort.Items[i].FindControl("lblSort") as Label;
            if (lblSort != null)
            {
                sb.Append(lblSort.ToolTip);
            }

            RadioButton radUp = this.repeaterSort.Items[i].FindControl("radUp") as RadioButton;
            if (radUp != null && radUp.Checked)
            {
                sb.Append(" ");
                sb.Append(radUp.ToolTip);
            }

            RadioButton radDown = this.repeaterSort.Items[i].FindControl("radDown") as RadioButton;
            if (radDown != null && radDown.Checked)
            {
                sb.Append(" ");
                sb.Append(radDown.ToolTip);

            }

            if (i < this.repeaterSort.Items.Count - 1)
            {
                sb.Append("|");
            }
        }

        //dbo.GetUserName(T.pass_user_id,&#39;cn&#39;) asc|dbo.GetUserName,因为有多个逗号，使用|分隔，框架会将|最终替换为逗号
        string s = string.Format("var sortColumns = new Object();sortColumns.ordersql ='{0}';window.returnValue=sortColumns;window.close()", sb.ToString());
        this.Page.ClientScript.RegisterStartupScript(GetType(), "RefreshScript", s, true);



    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        this.SortColumnsState = null;
        this.repeaterSort.DataSource = null;
        this.repeaterSort.DataBind();
    }


  
}

