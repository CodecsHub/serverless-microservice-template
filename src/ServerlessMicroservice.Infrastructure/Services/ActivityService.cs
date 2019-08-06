using ServerlessMicroservice.Domain.Entities;
using ServerlessMicroservice.Infrastructure.Contracts;
using ServerlessMicroservice.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessMicroservice.Infrastructure.Services
{
    public class ActivityService : IActivityService
    {

        private readonly IActivityRepository _activityRepository;

        public ActivityService()
        {

        }

        public Task AddAsync(ActivityRequest productRequest)
        {
            throw new NotImplementedException();
        }

        public Task<ActivityResponse> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ActivityResponse> GetAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
