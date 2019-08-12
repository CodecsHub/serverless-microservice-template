using Microsoft.AspNetCore.Builder;
using ServerlessMicroservice.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerlessMicroservice.API.Extensions
{
    //<summary>
    // @title:  Custom Global Error Trapping
    // @see: <root> startup.cs
    //</summary>
    /// <summary>
    /// 
    /// </summary>
    public static class ExtensionExceptionMiddleware
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
