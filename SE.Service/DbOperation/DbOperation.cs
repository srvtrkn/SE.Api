using Dapper;
using SE.DataObjects;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SE.Service.DbOperation
{
    public class DbOperation : IDbOperation
    {
        private readonly IDbConnection _db;
        public DbOperation(IOptions<ConnectionString> connectionString)
        {
            _db = new MySqlConnection(connectionString.Value.MySqlConnectionString);
        }
        public List<T> RunQuery<T>(string query)
        {
            var result = _db.Query<T>(query).ToList();
            _db.Close();
            return result;
        }
        public async Task<List<T>> RunQueryAsync<T>(string query)
        {
            var result = await _db.QueryAsync<T>(query, null, null, 60, CommandType.Text);
            _db.Close();
            return result.ToList();
        }
    }
}
