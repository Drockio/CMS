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
            //TODO: Piers Implement!
            //Steps
            //Install MySQL - Search for MySQL Workbench - remember your connection information - Document it!
            //Go to web.config and set up your connection string for mysql (change the value for mysql_conn).  This might help:  http://www.connectionstrings.com/mysql/
            //Implement (write the code for) TestConnection first.
            //create stored procedures similar to the Microsoft SQL ones.
            //Write code SIMILAR to what is in MSSSQL.cs.  (try to use the 'using' statements)
            //WAIT!  Do this with Oracle

            throw new NotImplementedException();
        }

        public void ExecuteNonQueryStoredProc(string storedProc, List<SqlParameter> sqlParams, string connectionString)
        {
            //TODO: Piers Implement!
            throw new NotImplementedException();
        }

        public DataTable GetDTFromStoredProc(string storedProc, List<SqlParameter> sqlParams, string connectionString)
        {
            //TODO: Piers Implement!
            throw new NotImplementedException();
        }

        public int ExecuteStoredProcReturnScalar(string storedProc, List<SqlParameter> sqlParams, string connectionString)
        {
            //TODO: Piers Implement!
            throw new NotImplementedException();
        }
    }
}