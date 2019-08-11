using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessMicroservice.Domain.Shared
{
    /// <summary>
    /// The generic class use to data look up list
    /// to all other classe entity/model of the class.
    /// </summary>
    public partial class BaseEntity
    {

        public Int64 Id { get; set; }
        public int RowVersionNumber { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool IsActive { get; set; }

    }
}
