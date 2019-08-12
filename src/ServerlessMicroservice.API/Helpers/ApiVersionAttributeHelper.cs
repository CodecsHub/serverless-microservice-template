using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerlessMicroservice.API.Helpers
{
    /// <summary>
    ///
    /// </summary>
    public class ApiVersionAttributeHelper : Attribute
    {
        /// <summary>
        ///
        /// </summary>
        public List<string> Versions { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="version"></param>
        public ApiVersionAttributeHelper(string version)
        {
            Versions = new List<string>();
            Versions.Add(version);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="versions"></param>
        public ApiVersionAttributeHelper(params string[] versions)
        {
            Versions = versions.ToList();
        }
    }
}
