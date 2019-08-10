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
    public static class ExtensionExceptionMiddleware
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
