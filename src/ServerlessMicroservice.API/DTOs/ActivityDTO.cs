using ServerlessMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerlessMicroservice.API.DTOs
{
    public class ActivityDTO
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int ApplicationId { get; set; }
        public int ActionId { get; set; }
        public string ApplicationUrl { get; set; }
        public string ActivityRemarks { get; set; }
        public int RowVersionNumber { get; set; }
        public DateTime DateTimeLog { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public static ActivityDTO FromActivity(Activity entity)
        {
            return new ActivityDTO()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                ApplicationId = entity.ApplicationId,
                ActionId = entity.ActionId,
                ApplicationUrl = entity.ApplicationUrl,
                ActivityRemarks = entity.ActivityRemarks,
                RowVersionNumber = entity.RowVersionNumber,
                DateCreated = entity.DateCreated,
                DateUpdated = entity.DateUpdated
            };
        }
    }
}
