using ServerlessMicroservice.Domain.Contracts;
using ServerlessMicroservice.Domain.Entities;
using ServerlessMicroservice.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerlessMicroservice.Infrastructure.Services
{
    public class ActivityService : IActivityService
    {

        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task AddAsync(ActivityRequest activityRequest)
        {
            ActivityResponse activityResponse = new ActivityResponse();
            Activity activity = new Activity()
            {
                UserId = activityRequest.UserId,
                ApplicationId = activityRequest.ApplicationId,
                ActionId = activityRequest.ActionId,
                ApplicationUrl = activityRequest.ApplicationUrl,
                // @todo: fix date time log entry, by default right now, it will save base on application
               // DateTimeLog = activityRequest.DateTimeLog,
                ActivityRemarks = activityRequest.ActivityRemarks
            };

            await _activityRepository.AddAsync(activity);

        }

        public async Task<ActivityResponse> GetAllAsync()
        {
            ActivityResponse activityResponse = new ActivityResponse();
            IEnumerable<Activity> activity = await _activityRepository.GetAllAsync();

            if (activity.ToList().Count == 0)
            {
                activityResponse.Message = "Activities not found.";
               // activityResponse.StatusCode = 404;
            }
            else
            {
                //activityResponse.StatusCode = 200;
                activityResponse.Message = activity.ToList().Count + " actvity is found.";
                activityResponse.ReturnData.AddRange(activity);
            }

            return activityResponse;
        }

        public async Task<ActivityResponse> GetAsync(long id)
        {
            ActivityResponse activityResponse = new ActivityResponse();
            var activity = await _activityRepository.GetByIdAsync(id);
            //IEnumerable<Activity> activity = await _activityRepository.GetByIdAsync(id);

            if (activity == null)
            {
                //activityResponse.StatusCode = 404;
                activityResponse.Message = "Activity not found.";
            }
            else
            {
                //activityResponse.StatusCode = 200;
                activityResponse.Message = "1 actvity is found.";
                activityResponse.ReturnData.Add(activity);
            }

            return activityResponse;
        }
    }
}
