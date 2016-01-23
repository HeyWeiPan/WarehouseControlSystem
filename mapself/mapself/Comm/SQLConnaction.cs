using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace Warehouse.Comm
{
    public class SQLConnaction
    {
        public static string constr = System.Configuration.ConfigurationManager.AppSettings["Sqlconnection"].ToString();

        public static int ExecuteSQL(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        
        
        }
        
     public static DataSet QuerySQL(string SQLString)
      {
         using (SqlConnection connection = new SqlConnection(constr))
         {
            DataSet ds = new DataSet();
            connection.Open();
            SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
            command.Fill(ds, "ds");
            return ds;
         }
      }

    }
}