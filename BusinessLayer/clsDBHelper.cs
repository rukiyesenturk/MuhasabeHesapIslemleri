using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsDBHelper
    {
        private const string connString = @"Data Source=DESKTOP-OC83AQT;Initial Catalog = Accountancy; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public SqlDataReader getSqldatareader(string query)
        {
            //string connString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            // var connString =ConnectionStrings["dbconnection"].ConnectionString;
            //var connString = ConfigurationManager.AppSettings["dbconnection"];
            SqlDataReader dr = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }
            return dr;
        }
        public DataSet getDataset(string query)
        {
            // ConnectionStringSettings rval2= ConnSettings;
            //string rr = getKey();
            // string connString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            // string myConfigKeyValue = ConfigurationManager.AppSettings["dbconnection"];
            // var connString = ConfigurationManager.AppSettings["dbconnection"];
            //var connString = ConfigurationManager.AppSettings["dbconnection"];
            SqlConnection conn = new SqlConnection(connString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            ///conn.Open();
            da.Fill(ds);
            ///conn.Close();
            return ds;
        }
    }
}
