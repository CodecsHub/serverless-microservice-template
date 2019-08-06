using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerlessMicroservice.API.Utilities
{
    public class ConnectionStrings
    {
        // @todo:   Add regex, versioning and descriptive comment the same like Models input/output documentation

        /// <summary>
        /// The Primary or main connection string intended  for read, write and read/write
        /// </summary>
        public string DatabaseConnectionRead { get; set; }
        public string DatabaseConnectionWrite { get; set; }
        public string DatabaseConnectionReadWrite { get; set; }
    }
}
