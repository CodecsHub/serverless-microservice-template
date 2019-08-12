using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerlessMicroservice.API.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="swaggerGenOptions"></param>
        public static void ConfigureSwaggerGen(SwaggerGenOptions swaggerGenOptions)
        {
            swaggerGenOptions.SwaggerDoc($"v1",
    new Info
    {
        Title = "Govrnanza Registry",
        Version = $"v1",
        Description = @"REST services for managing your API ecosystem

## Business Domains and Sub Domains ##
Breakdown your business into domains and sub domains in order to better manage your APIs.

## Tags ##
Create tags to help you classify your APIs on multiple dimensions or link APIs that form cross-cutting business processes

## API Management ##
Manage creation, update and deletion of the APIs in your registry. Classify your APIs by business sub domain and add tags for further classification.",
        Contact = new Contact()
        {
            Name = "Govrnanza",
            Url = "https://github.com/Vanlightly/Govrnanza"
        }
    });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="swaggerOptions"></param>
        public static void ConfigureSwagger(SwaggerOptions swaggerOptions)
        {
            swaggerOptions.RouteTemplate = "api-docs/{documentName}/swagger.json";
        }

        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="swaggerUIOptions"></param>
        public static void ConfigureSwaggerUI(SwaggerUIOptions swaggerUIOptions)
        {
            swaggerUIOptions.SwaggerEndpoint($"/api-docs/v1/swagger.json", $"V1 Docs");
            swaggerUIOptions.RoutePrefix = "api-docs";
        }
    }
}
