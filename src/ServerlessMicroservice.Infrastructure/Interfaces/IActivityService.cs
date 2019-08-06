using ServerlessMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessMicroservice.Infrastructure.Interfaces
{
    public interface IActivityService
    {
        Task <Activity> GetByIdAsync(long id);
        Task <IEnumerable<Activity>> GetAllAsync();
        Task AddAsync(Activity product);
    }
}
