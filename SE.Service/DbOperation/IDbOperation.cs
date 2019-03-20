using System.Collections.Generic;
using System.Threading.Tasks;

namespace SE.Service.DbOperation
{
    public interface IDbOperation
    {
        List<T> RunQuery<T>(string query);
        Task<List<T>> RunQueryAsync<T>(string query);
    }
}
