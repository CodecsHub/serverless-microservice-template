using ServerlessMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessMicroservice.Domain.Contracts
{
    public class ActivityResponse : BaseContracts
    {
        public ActivityResponse()
        {
            Data = new List<Activity>();
        }



        public List<Activity> Data { get; set; }


    }
}
