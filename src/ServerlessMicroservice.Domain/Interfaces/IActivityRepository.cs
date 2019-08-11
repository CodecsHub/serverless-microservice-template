using ServerlessMicroservice.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerlessMicroservice.Domain.Interfaces
{
    public interface IActivityRepository : IBaseRepositories<Activity>
    {
        // comment for referrences on previous usage
        Task<Activity> GetByIdData(long id);
        //Task<Activity> AddAsync(Activity entity);
    }
}
