using ServerlessMicroservice.Domain.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerlessMicroservice.Domain.Interfaces
{
    public interface IBaseRepositories<T> where T : BaseEntity
    {

        Task<IEnumerable<T>> GetAllData(T model, string sql);
        Task<IEnumerable<T>> GetDataBy(T model, string sql);

        Task<T> InsertData(T model, string sql);
        Task<T> UpdateData(T model, string sql);
        Task<T> DeleteData(T model, string sql);

        Task<int> CountAll(string sql);
    }
}
