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

public partial class Home_UpdateUserPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Wizard1_ActiveStepChanged(object sender, EventArgs e)
    {
        this.Label1.Text = this.DropDownList1.SelectedItem.ToString();
        this.Label2.Text = this.DropDownList2.SelectedItem.ToString();
        string path="C:\\certreq.txt";
        System.IO.FileInfo theFile = new System.IO.FileInfo(path);

        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment: filename=" + theFile.Name);
        Response.AddHeader("Content-Length",theFile.Length.ToString());
        Response.ContentType = "application/octet-stream";
        Response.WriteFile(theFile.FullName);
        Response.End();
    }
}
