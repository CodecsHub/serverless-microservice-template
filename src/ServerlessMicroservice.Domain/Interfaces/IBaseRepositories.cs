using ServerlessMicroservice.Domain.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerlessMicroservice.Domain.Interfaces
{
    public interface IBaseRepositories<T> where T : BaseEntity
    {

        Task<IEnumerable<T>> GetAllData();
        Task<IEnumerable<T>> GetDataBy(T model);

        Task<T> InsertData(T model);
        Task<T> UpdateData(T model);
        Task<T> DeleteData(T model);

        Task<int> CountAll();
    }
}
