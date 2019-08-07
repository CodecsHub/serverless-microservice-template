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
            Data = new List<Activity>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public List<Activity> Data { get; set; }
    }
}
