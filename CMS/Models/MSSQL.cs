using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    public class MSSQL : IDataBase
    {
        public string GetDefaultConnectionString()
        {
            return ConfigurationManager.AppSettings["sql_conn"];
        }

        public bool TestConnection(string connectionString)
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            return false;
        }

        public void ExecuteNonQueryStoredProc(string storedProc, List<SqlParameter> sqlParams, string connectionString)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(storedProc, conn))
            {
                foreach (SqlParameter param in sqlParams)
                {
                    cmd.Parameters.Add(param);
                }

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetDTFromStoredProc(string storedProc, List<SqlParameter> sqlParams, string connectionString)
        {
            var ds = new DataSet();
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(storedProc, conn))
            {
                foreach (SqlParameter param in sqlParams)
                {
                    cmd.Parameters.Add(param);
                }

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                var adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
            }
            return ds.Tables[0];
        }

        public int ExecuteStoredProcReturnScalar(string storedProc, List<SqlParameter> sqlParams, string connectionString)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(storedProc, conn))
            {
                foreach (SqlParameter param in sqlParams)
                {
                    cmd.Parameters.Add(param);
                }

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    var newId = cmd.ExecuteScalar();
                    return (int)newId;
                }
                catch (Exception e)
                {
                    //TODO Log error
                    return -1;
                }
            }
        }

    }
}