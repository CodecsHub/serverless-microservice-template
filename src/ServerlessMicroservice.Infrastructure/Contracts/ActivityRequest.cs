﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessMicroservice.Infrastructure.Contracts
{
    public class ActivityRequest
    {
        public int UserId { get; set; }
        public int ApplicationId { get; set; }
        public int ActionId { get; set; }
        public string ApplicationUrl { get; set; }
        public string ActivityRemarks { get; set; }
    }
}
