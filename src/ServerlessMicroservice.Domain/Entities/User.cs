using ServerlessMicroservice.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessMicroservice.Domain.Entities
{
    public class User : BaseEntity
    {
        public string AzureId { get; set; }
        public string UserName { get; set; }
    }
}
