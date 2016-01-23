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

using EntpClass.Common;
using EntpClass.WebControlLib;
using EntpClass.BizLogic.Setup;

public partial class CommonUI_WebForm_GetTVWCBGeographyData : Page
{
    protected override bool SupportAutoEvents
    {
        get
        {
            return false;
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        Response.Expires = 60;

        UcTVGeography.NodeBinding += new EventHandler<TreeNodeBindingEventArgs>(UcTVGeography_NodeBinding);
        UcTVGeography.BindData(GetDataSource(), "GEO_ID", "GEO_PID", "", "");

        Response.Write(UcTVGeography.ToXML());
        Response.End();
    }   
   
    void UcTVGeography_NodeBinding(object sender, EntpClass.WebControlLib.TreeNodeBindingEventArgs e)
    {
        string geoId = Fn.ToString(e.Row["geo_id"]);
        string geoName = Fn.ToString(e.Row["text"]);

        e.Node.NodeData = geoId;
        e.Node.Text = geoName;                
    }

    private DataTable GetDataSource()
    {
        DataSet ds = Geography.GetGeographyTreeData(Geography.CHINAID, Geography.CHINAID);
        return ds.Tables[0];
    }
}
