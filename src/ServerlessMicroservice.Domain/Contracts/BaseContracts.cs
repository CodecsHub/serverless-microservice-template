﻿using System;

namespace ServerlessMicroservice.Domain.Contracts
{
    public  class BaseContracts
    {
        public DateTime Log { get; protected set; } = DateTime.UtcNow;

        public int Code { get; set; }

        public string Message { get; set; }
        public string Description { get; set; }
    }
}
