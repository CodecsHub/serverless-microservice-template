using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessMicroservice.Domain.Contracts
{
    public partial class BaseContracts
    {
        public DateTime DateTimeLog { get; protected set; } = DateTime.UtcNow;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int HttpStatusCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
