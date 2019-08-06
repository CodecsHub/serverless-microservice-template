using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerlessMicroservice.API.Utilities
{
    public class ApplicationInformation
    {

        /// <summary>
        /// Details of the application itself
        /// </summary>
        // @todo:   Create web assembly info add like desktop information
        public string ApplicationName { get; set; }
        public string ApplicationDescription { get; set; }
        public string ReleaseNumber { get; set; }

        public int VersionMajor { get; set; }
        public int VersionMinor { get; set; }
        public int VersionPatch { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }

        public string VersionNumber
        {
            get
            {
                return $"{ VersionMajor }.{ VersionMinor }.{ VersionPatch }";
            }
        }
    }
}
