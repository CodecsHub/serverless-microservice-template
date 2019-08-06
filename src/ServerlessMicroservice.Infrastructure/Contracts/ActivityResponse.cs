using ServerlessMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ServerlessMicroservice.Infrastructure.Contracts
{
    public class ActivityResponse
    {
        public ActivityResponse()
        {
            Activities = new List<Activity>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public List<Activity> Activities { get; set; }
    }
}
