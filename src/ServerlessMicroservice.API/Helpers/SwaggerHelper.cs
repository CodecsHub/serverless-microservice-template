﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            //<summary>
            //changes ensure that we have two swagger doc pages created
            //and ensure that the correct methods are shown on the correct do4cs.
            //</summary>
            swaggerGenOptions.DocInclusionPredicate((docName, apiDesc) =>
            {
                // start isolated fix
                // @link: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/244
                var values = apiDesc.RelativePath
                                .Split('/')
                                .Skip(2);

                apiDesc.RelativePath = "api/" + docName + "/" + string.Join("/", values);

                var versionParameter = apiDesc.ParameterDescriptions
                    .SingleOrDefault(p => p.Name == "version");

                if (versionParameter != null)
                    apiDesc.ParameterDescriptions.Remove(versionParameter);

                //end of isolated fix

                var actionApiVersionModel = apiDesc.ActionDescriptor?.GetApiVersion();
                // would mean this action is unversioned and should be included everywhere
                if (actionApiVersionModel == null)
                {
                    return true;
                }
                if (actionApiVersionModel.DeclaredApiVersions.Any())
                {
                    return actionApiVersionModel.DeclaredApiVersions.Any(v => $"v{v.ToString()}" == docName);
                }
                return actionApiVersionModel.ImplementedApiVersions.Any(v => $"v{v.ToString()}" == docName);
            });

            // Call the document controller extension class
            swaggerGenOptions.OperationFilter<ApiVersionOperationFilterHelper>();

            // fix the issues of the same routing name variable
            // @todo: add custom css and html in swagger ui
            // @link: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/390
            swaggerGenOptions.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            swaggerGenOptions.IgnoreObsoleteActions();

            swaggerGenOptions.SwaggerDoc("v1.0", new Info
            {
                Version = "v1.0",
                Title = "Microservice00001 Activity API v1.0",
                //@todo: markdown syntax in the description
                //@todo: review and revise the wordngs
                Description = @"## Business Domains and Sub Domains ##
Breakdown your business into domains and sub domains in order to better manage your APIs.

## Tags ##
Create tags to help you classify your APIs on multiple dimensions or link APIs that form cross - cutting business processes

## API Management ##
Manage creation,
                    update and deletion of the APIs in your registry.Classify your APIs by business sub domain and add tags for further classification.",

                //@todo: multiple contact person
                //@todo: load the data base on json file from appsettings
                TermsOfService = "None",
                Contact = new Contact
                {
                    Name = "Francisco S. Abayon",
                    Email = "francisco.abayon@rafi.ph",
                    Url = "https://rafi.org.ph/"
                },
                License = new License
                {
                    Name = "Use under RAFI License",
                    Url = "https://rafi.org.ph/"
                }
            });

            swaggerGenOptions.SwaggerDoc("v2.0", new Info
            {
                Version = "v2.0",
                Title = "Microservice00001 Activity API v2.0",
                Description = "The beta API in the basic mvp approach using microservices in Activty version 2",
                TermsOfService = "None",
                Contact = new Contact
                {
                    Name = "Francisco S. Abayon",
                    Email = "francisco.abayon@rafi.ph",
                    Url = "https://rafi.org.ph/"
                },
                License = new License
                {
                    Name = "Use under RAFI License",
                    Url = "https://rafi.org.ph/"
                }
            });


            // @todo: Fix the xmfile setup in the swagger
            //Set the comments path for the Swagger JSON and UI.
            // Also Right Click the project, then go to Build, and check the XML documentation File
            //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //swaggerGenOptions.IncludeXmlComments(xmlPath);
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
        /// </summary>
        /// <param name="swaggerUIOptions"></param>
        public static void ConfigureSwaggerUI(SwaggerUIOptions swaggerUIOptions)
        {
            swaggerUIOptions.SwaggerEndpoint($"/api-docs/v1.0/swagger.json", $"V1 Docs");
            swaggerUIOptions.SwaggerEndpoint($"/api-docs/v2.0/swagger.json", $"V2 Docs");
            swaggerUIOptions.RoutePrefix = "api-docs";
            swaggerUIOptions.InjectStylesheet("theme-feeling-blue-v2.css");
            //var webApiAssembly = Assembly.GetEntryAssembly();
            //var apiVersions = GetApiVersions(webApiAssembly);
            //foreach (var apiVersion in apiVersions)
            //{
            //    swaggerUIOptions.SwaggerEndpoint($"/api-docs/v{apiVersion}/swagger.json", $"V{apiVersion} Docs");
            //}
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="webApiAssembly"></param>
        /// <returns></returns>
        ///@todo: refactor the api docuementaiton with looping https://jack-vanlightly.com/blog/2017/8/23/api-series-part-2-swagger
        private static IEnumerable<string> GetApiVersions(Assembly webApiAssembly)
        {
            var apiVersion = webApiAssembly.DefinedTypes
                .Where(x => x.IsSubclassOf(typeof(Controller)) && x.GetCustomAttributes<ApiVersionAttributeHelper>().Any())
                .Select(y => y.GetCustomAttribute<ApiVersionAttributeHelper>())
                .SelectMany(v => v.Versions)
                .Distinct()
                .OrderBy(x => x);

            return apiVersion.Select(x => x.ToString());
        }


    }
}
