using ServerlessMicroservice.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessMicroservice.Domain.Entities
{
    public class Activity : BaseEntity
    {
        public long  UserId { get; set; }
        public int ApplicationId { get; set; }
        public int ActionId { get; set; }
        public string ApplicationUrl { get; set; }
        public string ActivityRemarks { get; set; }
    }
}
