using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.IO;


namespace Recruiting_API.Models
{
    class DbConnection
    {
        //private static String _sqlConstring = "Data Source=(local);Initial Catalog=RecruitingApp_DB;Integrated Security=True;pooling=true;max pool size=10000;";

        //private static String _sqlConstring = "Data Source=198.71.226.2;Initial Catalog=RecruitingApp_TestingDB;Integrated Security=False;pooling=true;max pool size=10000;User ID=Administrator;Password=Reset@123";
        private static String _sqlConstring = "Data Source=198.71.226.2;Initial Catalog=RecruitingApp_DB;Integrated Security=False;pooling=true;max pool size=10000;User ID=Administrator;Password=Reset@123";

        public static int conn_counter;
        static SqlConnection SqlConn;
        public static string _erquery;
        public static string userid;

        public SqlConnection getConnection()
        {
            try
            {
                SqlConn = new SqlConnection(_sqlConstring);
                if (SqlConn == null)
                {
                    SqlConn.Open();
                    //var path = HttpContext.Current.Server.MapPath("~/error_coo"); ;
                    //conn_counter++;
                    //byte[] data = Encoding.ASCII.GetBytes("Count :" + conn_counter.ToString() + " - ID :" + userid);
                    //string newFileName = Guid.NewGuid() + ".txt";
                    //File.WriteAllBytes(Path.Combine(path, newFileName), data);
                    return SqlConn;
                }
                else
                {
                    if (SqlConn.State == ConnectionState.Closed)
                    {
                        //var path = HttpContext.Current.Server.MapPath("~/error_coo"); ;
                        //conn_counter++;
                        //byte[] data = Encoding.ASCII.GetBytes("Count :" + conn_counter.ToString() + " - ID :" + userid);
                        //string newFileName = Guid.NewGuid() + ".txt";
                        //File.WriteAllBytes(Path.Combine(path, newFileName), data);
                        SqlConn.Open();
                    }
                }
                return SqlConn;
            }
            catch (Exception Ex)
            {
                //var path = HttpContext.Current.Server.MapPath("~/error"); ;

                //string text = Ex.Message.ToString() + _erquery;
                //byte[] data = Encoding.ASCII.GetBytes(text);
                //string newFileName = Guid.NewGuid() + ".txt";
                //File.WriteAllBytes(Path.Combine(path, newFileName), data);
                if (SqlConn.State == ConnectionState.Open)
                {
                    SqlConn.Close();
                }

                String SS = Ex.Message;
                throw Ex;
            }
        }
        public SqlConnection testConnection()
        {
            try
            {
                SqlConn = new SqlConnection(_sqlConstring);
                if (SqlConn == null)
                {
                    SqlConn.Open();
                    return SqlConn;
                }
                else
                {
                    if (SqlConn.State == ConnectionState.Closed)
                        SqlConn.Open();
                    return SqlConn;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        // this method to close a current connection
        public void CloseConnection()
        {
            SqlConn = new SqlConnection(_sqlConstring);
            try
            {
                SqlConn.Close();
            }
            catch (Exception Ex)
            {
                String St = Ex.Message;
            }
        }
        public void returnConnection(SqlConnection sqlCon)
        {

        }

        public void getquery(string _qs)
        {
            _erquery = _qs;

        }

        public void getuserid(string id)
        {
            userid = id;
        }

    }
}