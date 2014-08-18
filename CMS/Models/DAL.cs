using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace CMS.Models
{
    public class DAL
    {
        //get the appropriate IDataBase object based on database type
        public static IDataBase DBBase {
            get {
                switch(ConfigurationManager.AppSettings["DBType"])
                {
                    case "my_sql":
                        return new CMS.Models.MySQL();

                    default:
                        return new CMS.Models.MSSQL(); 
                }
            }
        }

        public static string DefaultConnectionString {
            get { return DBBase.GetDefaultConnectionString(); }
        }

        public static void ExecuteNonQueryStoredProc(string storedProc, List<SqlParameter> sqlParams)
        {
            ExecuteNonQueryStoredProc(storedProc, sqlParams, DefaultConnectionString);
        }

        public static void ExecuteNonQueryStoredProc(string storedProc, List<SqlParameter> sqlParams, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                connectionString = DefaultConnectionString;

            DBBase.ExecuteNonQueryStoredProc(storedProc, sqlParams, connectionString);
        }

        static public int ExecuteStoredProcReturnScalar(string storedProc, List<SqlParameter> sqlParams)
        {
            return ExecuteStoredProcReturnScalar(storedProc, sqlParams, DefaultConnectionString);
        }

        static public int ExecuteStoredProcReturnScalar(string storedProc, List<SqlParameter> sqlParams, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                connectionString = DefaultConnectionString;

            return DBBase.ExecuteStoredProcReturnScalar(storedProc, sqlParams, connectionString);
        }

        static public bool TestConnection()
        {
            return TestConnection(DefaultConnectionString);
        }

        static public bool TestConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                connectionString = DefaultConnectionString;

            return DBBase.TestConnection(connectionString);
        }

        static public DataTable GetDTFromStoredProc(string storedProc, List<SqlParameter> sqlParams)
        {
            return GetDTFromStoredProc(storedProc, sqlParams, DefaultConnectionString);
        }

        static public DataTable GetDTFromStoredProc(string storedProc, List<SqlParameter> sqlParams, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                connectionString = DefaultConnectionString;

            return DBBase.GetDTFromStoredProc(storedProc, sqlParams, connectionString);
        }
    }
}