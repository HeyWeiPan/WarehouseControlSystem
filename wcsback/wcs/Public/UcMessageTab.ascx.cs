using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntpClass.Common;

public partial class Public_UcMessageTab : System.Web.UI.UserControl
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        RM rm = new RM(ResourceFile.UI);
       // this.LnkMessage.Text = rm["MessageBox"];
        this.LnkMessage.Text = "邮件系统";
      
    }

    public void SetSelectedTab(int id)
    {
        LnkMessage.CssClass = "";
    
        LnkMessage.CssClass = id == 1 ? "TabOn" : "";
      
    }
}