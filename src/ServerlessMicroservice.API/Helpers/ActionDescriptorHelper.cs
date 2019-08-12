using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerlessMicroservice.API.Helpers
{
    // @title: Fixed Swagger Generator
    // @see: <root>/Startup.cs (ConfigureSwaggerGen();)
    /// <summary>
    ///
    /// </summary>
    public static class ActionDescriptorHelper
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="actionDescriptor"></param>
        /// <returns></returns>
        public static ApiVersionModel GetApiVersion(this ActionDescriptor actionDescriptor)
        {

            return actionDescriptor?.Properties
              .Where((kvp) => ((Type)kvp.Key).Equals(typeof(ApiVersionModel)))
              .Select(kvp => kvp.Value as ApiVersionModel).FirstOrDefault();
        }
    }
}
