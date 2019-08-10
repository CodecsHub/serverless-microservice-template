using ServerlessMicroservice.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessMicroservice.Domain.Interfaces
{
    public interface IBaseRepositories<T> where T : BaseEntity
    {

        Task<IEnumerable<T>> GetAllData(T model, string sql);
        Task<IEnumerable<T>> GetDataBy(T model, string sql);

        Task InsertData(T model, string sql);
        Task UpdateData(T model, string sql);
        Task DeleteData(T model, string sql);

        Task<int> CountAll(string sql);
    }
}
