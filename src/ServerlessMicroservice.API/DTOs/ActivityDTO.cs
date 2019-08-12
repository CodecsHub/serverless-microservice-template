using ServerlessMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerlessMicroservice.API.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    public class ActivityDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ApplicationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ActionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ApplicationUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ActivityRemarks { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int RowVersionNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateTimeLog { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// 
        /// </summary>
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
