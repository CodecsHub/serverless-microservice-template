using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerlessMicroservice.API.Utilities
{
    /// <summary>
    ///
    /// </summary>
    public class ApplicationInformation
    {




        // @todo:   Create web assembly info add like desktop information

        /// <summary>
        /// Details of the application itself
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ApplicationDescription { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ReleaseNumber { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int VersionMajor { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int VersionMinor { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int VersionPatch { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string DateCreated { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string DateUpdated { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string VersionNumber
        {
            get
            {
                return $"{ VersionMajor }.{ VersionMinor }.{ VersionPatch }";
            }
        }
    }
}
