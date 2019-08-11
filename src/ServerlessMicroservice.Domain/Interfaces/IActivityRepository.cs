using ServerlessMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessMicroservice.Domain.Interfaces
{
    public interface IActivityRepository : IBaseRepositories<Activity>
    {
        Task<Activity> GetByIdAsync(long id);
        //Task<IEnumerable<Activity>> GetByIdAsync(long id);
        Task<IEnumerable<Activity>> GetAllAsync();
        Task<Activity> AddAsync(Activity entity);
    }
}
