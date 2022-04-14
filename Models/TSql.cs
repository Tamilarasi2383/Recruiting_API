using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Web;
using System.IO;

namespace Recruiting_API.Models
{
    public class TSql
    {
        SqlConnection sqlCon;
        DbConnection _dbcon;
        public TSql()
        {
            sqlCon = new DbConnection().getConnection();
            _dbcon = new DbConnection();
        }

        public int doInsert(string[] arQueries)
        {
            int recordsAffected = 0;

            for (int i = 0; i < arQueries.Length; i++)
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = arQueries[i];
                recordsAffected = sqlCmd.ExecuteNonQuery();
            }
            return recordsAffected;
        }

        public int doInsert(List<string> arQueries)
        {
            int recordsAffected = 0;

            for (int i = 0; i < arQueries.Count; i++)
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = arQueries[i];
                recordsAffected = sqlCmd.ExecuteNonQuery();
            }

            return recordsAffected;
        }

        public int doInsert(string Queries)
        {
            try
            {
                int recordsAffected = 0;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = Queries;
                recordsAffected = sqlCmd.ExecuteNonQuery();
                return recordsAffected;
            }
            catch (Exception E)
            {
                var path = HttpContext.Current.Server.MapPath("~/error");
                var str = E.Message.ToString();
                _dbcon.getquery(Queries);
                string text = E.Message.ToString() +"  "+E.InnerException.ToString() + "  " + Queries;
                byte[] data = Encoding.ASCII.GetBytes(text);
                string newFileName = Guid.NewGuid() + ".txt";
                File.WriteAllBytes(Path.Combine(path, newFileName), data);

                return 0;
            }
        }

        public int doInsert(string Queries, bool canCloseConn)
        {
            try
            {

                int recordsAffected = 0;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = Queries;
                recordsAffected = sqlCmd.ExecuteNonQuery();
                if (canCloseConn)
                {
                    //sqlCon.Close();
                }

                return recordsAffected;
            }
            catch (Exception E)
            {
                //var path = HttpContext.Current.Server.MapPath("~/error"); ;
                //_dbcon.getquery(Queries);
                //string text = E.Message.ToString() + Queries;
                //byte[] data = Encoding.ASCII.GetBytes(text);
                //string newFileName = Guid.NewGuid() + ".txt";
                //File.WriteAllBytes(Path.Combine(path, newFileName), data);

                return 0;
            }
        }

        public SqlDataReader doRead(string strQuery)
        {
            try
            {

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = strQuery;
                return sqlCmd.ExecuteReader();
            }
            catch (Exception E)
            {
                //var path = HttpContext.Current.Server.MapPath("~/error"); ;
                //_dbcon.getquery(strQuery);
                //string text = E.Message.ToString() + strQuery;
                //byte[] data = Encoding.ASCII.GetBytes(text);
                //string newFileName = Guid.NewGuid() + ".txt";
                //File.WriteAllBytes(Path.Combine(path, newFileName), data);

                throw E;
            }
        }

        public jsonArray errorReturn(jsonArray _er)
        {
            return _er;
        }

        public int getNextSequence(string strSeqName)
        {
            int sequenceNo = 0;
            int nextSeqNo = 0;
            string strQuery = "SELECT NextSequenceNo FROM Sequence WHERE SequenceName='" + strSeqName + "'";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandText = strQuery;
            sequenceNo = Convert.ToInt32(sqlCmd.ExecuteScalar());
            nextSeqNo = sequenceNo + 1;
            strQuery = "Update Sequence set NextSequenceNo=" + nextSeqNo + " where SequenceName='" + strSeqName + "'";
            sqlCmd.CommandText = strQuery;
            int recordsAffected = sqlCmd.ExecuteNonQuery();
            return sequenceNo;
        }


        public void closeConnection()
        {
            DbConnection _co = new DbConnection();
            _co.CloseConnection();
        }
        

    }

    public class CloseSQLConnection
    {
        public CloseSQLConnection()
        {
            DbConnection _dbcon = new DbConnection();
            _dbcon.CloseConnection();
        }
    }
}