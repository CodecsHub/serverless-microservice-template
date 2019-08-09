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

        public IList<Activity> Activity { get; set; } = new List<Activity>(); // one to many (activity many but one user)
        // see <c>Activity.cs<c>
    }
}
