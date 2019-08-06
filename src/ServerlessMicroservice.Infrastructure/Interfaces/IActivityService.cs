using ServerlessMicroservice.Domain.Entities;
using ServerlessMicroservice.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessMicroservice.Infrastructure.Interfaces
{
    public interface IActivityService
    {
        Task<ActivityResponse> GetAsync(long id);
        Task<ActivityResponse> GetAllAsync();
        Task AddAsync(ActivityRequest activityRequest);

    }
}
