using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessMicroservice.Infrastructure.Interfaces
{
    public interface IBaseRepository
    {
        Task<IEnumerable<T>> GetAllData<T>(T model, string sql);
        Task<T> GetDataBy<T>(T model, string sql);
        Task InsertData<T>(T model, string sql);
        Task UpdateData<T>(T model, string sql);
        Task DeleteData<T>(T model, string sql);
    }
}
