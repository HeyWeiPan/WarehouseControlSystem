using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Warehouse.Comm;

namespace mapself
{
    public partial class test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sqltoken = "select * from wcs.wcs.wcs_cmd_Breakdown where cmd_id =" + "777" + " and cmd_type='TOKEN'";
            DataTable dttoken = SQLConnaction.QuerySQL(sqltoken).Tables[0];

            byte[] sqlcmd_token_bytelist = new byte[100];
            sqlcmd_token_bytelist = (byte[])dttoken.Rows[0]["cmd_b_code"];

            int startNum = 0;
            
            int j = 0;
            for (j = 0; j < sqlcmd_token_bytelist.Length; j++)
            {
                if (sqlcmd_token_bytelist[j] == 0x5A && sqlcmd_token_bytelist[j + 1] == 0xA5)
                {
                    startNum = j + 5;
                }
                else { continue; }
            }

            string temp_token = "" + sqlcmd_token_bytelist[startNum].ToString();
        }
    }
}