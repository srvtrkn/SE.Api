using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using SE.Service.Helpers;

namespace SE.Service
{
    public class DbOperation
    {
        private static string connectionString;
        static DbOperation()
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = AppSettingsHelper.GetProperty("ConnectionString", "SqlConnectionString");
            }
        }
        private static DbConnection DB
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
        public static List<T> RunQuery<T>(string query)
        {
            var result = DB.Query<T>(query).ToList();
            DB.Close();
            return result;
        }
        public static async Task<List<T>> RunQueryAsync<T>(string query)
        {
            var result = await DB.QueryAsync<T>(query, null, null, 60, CommandType.Text);
            DB.Close();
            return result.ToList();
        }
    }
}
