using System;
using EntpClass.WebUI;
using EntpClass.BizLogic.Setup;
using EntpClass.Common;

public partial class Setup_AppParameter_UcAppParameterScope : ScopeControlBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override DbRowParameter GetParameter()
    {
        AppParameter p = new AppParameter();

        return p.Parameter; 
    }

    protected override string JoinTable(JoinTableParameters p)
    {
        return "";
    }
}