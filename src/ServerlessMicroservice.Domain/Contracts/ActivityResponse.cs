using ServerlessMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessMicroservice.Domain.Contracts
{
    public class ActivityResponse : BaseContracts
    {
        // @todo: convert from list to hashset for better performance
        public ActivityResponse()
        {
            Data = new List<Activity>();
        }

        public List<Activity> Data { get; set; }

    }
}
