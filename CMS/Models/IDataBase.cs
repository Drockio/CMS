using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    public interface IDataBase
    {
        string GetDefaultConnectionString();
        bool TestConnection(string connectionString);
        void ExecuteNonQueryStoredProc(string storedProc, List<SqlParameter> sqlParams, string connectionString);
        DataTable GetDTFromStoredProc(string storedProc, List<SqlParameter> sqlParams, string connectionString);
        int ExecuteStoredProcReturnScalar(string storedProc, List<SqlParameter> sqlParams, string connectionString);
    }
}