using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Warehouse.Comm;
using System.Text;
using System.Timers;

namespace mapself
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                
                //load wh data
                string sql1;
                sql1 = "select wh_id,wh_name from wcs.wcs.wcs_wh";
                DataTable dt1 = SQLConnaction.QuerySQL(sql1).Tables[0];
                // Add data to DdlWh
                DdlWh.DataSource = dt1;
                DdlWh.DataTextField = "wh_name";
                DdlWh.DataValueField = "wh_id";
                DdlWh.DataBind();
                //  load floor data
                string sql2;
                sql2 = "select wh_id,floor_num,floor_id from wcs.wcs.wcs_floor where wh_id=1";
                DataTable dt2 = SQLConnaction.QuerySQL(sql2).Tables[0];
                DdlFloorNum.DataSource = dt2;
                DdlFloorNum.DataTextField = "floor_num";
                DdlFloorNum.DataValueField = "floor_num";
                DdlFloorNum.DataBind();
            }
        }

        protected void DdlWh_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  load floor data
            DdlFloorNum.Items.Clear();
            string sql3;
            sql3 = "select wh_id,floor_num from wcs.wcs.wcs_floor";
            DataTable dt2 = SQLConnaction.QuerySQL(sql3).Tables[0];
            for(int i=0;i<dt2.Rows.Count;i++)
            {
                
                   if(dt2.Rows[i][0].ToString()==DdlWh.SelectedValue)
                   {
                       string floorNum = dt2.Rows[i]["floor_num"].ToString();
                       DdlFloorNum.Items.Add(new ListItem(floorNum,floorNum));
                   }               
            }
        }
      
        }
        
    }
