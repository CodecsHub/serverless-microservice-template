using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessMicroservice.Domain.Shared
{
    /// <summary>
    /// The generic class use to data look up list 
    /// to all other classe entity/model of the class.
    /// </summary>
    public abstract class BaseEntity
    {
        private DateTime _dateCreated;
        private DateTime _dateUpdated;


        public Int64 Id { get; set; }
        public int RowVersionNumber { get; set; }
        public DateTime DateTimeLog { get; protected set; } = DateTime.UtcNow;

        public DateTime DateCreated
        {
            get => _dateCreated;
            set => _dateCreated = DateTimeLog;
        }

        public DateTime DateUpdated
        {
            get => _dateUpdated;
            set => _dateUpdated = DateTimeLog;
        }
    }
}
