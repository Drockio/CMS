using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    public class MySQL : IDataBase
    {
        public string GetDefaultConnectionString()
        {
            return ConfigurationManager.AppSettings["mysql_conn"];
        }

        public bool TestConnection(string connectionString)
        {
            //TODO: Implement!
            throw new NotImplementedException();
        }

        public void ExecuteNonQueryStoredProc(string storedProc, List<SqlParameter> sqlParams, string connectionString)
        {
            //TODO: Implement!
            throw new NotImplementedException();
        }

        public DataTable GetDTFromStoredProc(string storedProc, List<SqlParameter> sqlParams, string connectionString)
        {
            //TODO: Implement!
            throw new NotImplementedException();
        }

        public int ExecuteStoredProcReturnScalar(string storedProc, List<SqlParameter> sqlParams, string connectionString)
        {
            //TODO: Implement!
            throw new NotImplementedException();
        }
    }
}