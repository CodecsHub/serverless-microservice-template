using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServerlessMicroservice.API.Controllers;
using ServerlessMicroservice.API.Extensions;
using ServerlessMicroservice.API.Helpers;
using ServerlessMicroservice.API.Utilities;
using ServerlessMicroservice.Domain.Interfaces;
using ServerlessMicroservice.Infrastructure.Interfaces;
using ServerlessMicroservice.Infrastructure.Repositories;
using ServerlessMicroservice.Infrastructure.Services;

namespace ServerlessMicroservice.API
{
    /// <summary>
    ///
    /// </summary>
    public class Startup
    {
        //@referrence: https://exceptionnotfound.net/using-dapper-asynchronously-in-asp-net-core-2-1/
        private readonly IHostingEnvironment _environment;
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;

        /// <summary>
        ///
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="configuration"></param>
        /// <param name="loggerFactory"></param>
        public Startup(IHostingEnvironment environment, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _environment = environment;
            _configuration = configuration;
            _loggerFactory = loggerFactory;

            var builder = new ConfigurationBuilder()
                        .SetBasePath(_environment.ContentRootPath)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{_environment.EnvironmentName}.json", optional: true)
                        .AddEnvironmentVariables();
                //if (_environment.IsDevelopment())
                //{
                //    builder.AddUserSecrets<Startup>();
                //}

            _configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        ///
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // @description: control the dependecy in the logger or else it will slow down the application
            // @todo: refactor the loggin services
            // @url: https://weblog.west-wind.com/posts/2018/Dec/31/Dont-let-ASPNET-Core-Default-Console-Logging-Slow-your-App-down
            services.AddLogging(config =>
            {
                // clear out default configuration
                config.ClearProviders();

                config.AddConfiguration(_configuration.GetSection("Logging"));
                config.AddDebug();
                config.AddEventSourceLogger();
                // @fix database issue on azure https://stackoverflow.com/questions/52050167/how-to-override-local-connection-string-with-azure-connection-string
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == EnvironmentName.Development)
                {
                    config.AddConsole();
                }
            });

            services.AddMvc(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;

                // basd on tutorial can be used but in the intelense it will deprecated
                //config.InputFormatters.Add(new XmlSerializerInputFormatter());
                //config.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                // config.OutputFormatters.Add(new JsonInputFormatter());
                //@todo: extend the content negation
                //@referrence: https://code-maze.com/content-negotiation-dotnet-core/
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddSwaggerGen(SwaggerHelper.ConfigureSwaggerGen);


            // Add application services.
            services.AddTransient<IActivityService, ActivityService>();
            services.AddTransient<IActivityRepository, ActivityMsSqlRepository>();

            // referrences
            // https://www.hanselman.com/blog/ASPNETCoreRESTfulWebAPIVersioningMadeEasy.aspx
            // https://dzone.com/articles/api-versioning-in-net-core
            // https://koukia.ca/api-versioning-in-asp-net-core-2-0-1b55970aa29d
            // https://neelbhatt.com/2018/04/21/api-versioning-in-net-core/
            // https://dotnetcoretutorials.com/2017/01/17/api-versioning-asp-net-core/
            services.AddApiVersioning(optionVersioning =>
            {
                optionVersioning.ReportApiVersions = true;
                optionVersioning.AssumeDefaultVersionWhenUnspecified = true;
                optionVersioning.DefaultApiVersion = new ApiVersion(1, 0);

                //We can allow clients to request a specific API version by media type.
                //This option can be enabled by adding below line in the API versioning options in the ConfigureService method:
                optionVersioning.ApiVersionReader = new MediaTypeApiVersionReader();

                // Uncomment this line to enable only the api version header
                //Once you enable this, Query string approach would not work.
                //optionVersioning.ApiVersionReader = new HeaderApiVersionReader("x-api-version");

                // Doesnt need to redeclare the ApiVersion attribute on each controller name
                optionVersioning.Conventions.Controller<V1Controller>().HasApiVersion(new ApiVersion(1, 0));
                optionVersioning.Conventions.Controller<ActivityController>().HasApiVersion(new ApiVersion(2, 0));


                // use [MapToApiVersion("1.0")] after httpget/httppost in the controller for mapping specific method
            });
            // <c>nameof<c> operator. This assumes that the the section in the JSON file matches the name of the class object representing it.
            // Additionally, it serves as a reason to keep the names matching
            // @url: https://davidpine.net/blog/asp-net-core-configuration/
            services.Configure<ApplicationInformation>(_configuration.GetSection(nameof(ApplicationInformation)));
            services.Configure<ConnectionStrings>(_configuration.GetSection(nameof(ConnectionStrings)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        ///
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days.
                //You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseExceptionHandler();
            }

            //<summary>
            // @title:  Custom Global Error Trapping
            // @description: Custom error helper class base on http request error try/catch statement
            //              also to globalize the location of Try/Catch statement with clean controller
            // @see: Servces/ExtensionExceptionMiddleware.cs
            // @see: Herlper/ExceptionMiddleware.cs
            // @see: Model/UtitlityErrorDetails.cs
            // @url: https://jack-vanlightly.com/blog/2017/8/23/api-series-part-2-swagger
            //@todo: visit the other custom microservice develop at ms00003 and ms00004 to check if this method is working
            //</summary>
            //app.ConfigureCustomExceptionMiddleware();
            app.UseMiddleware<StackifyMiddleware.RequestTracerMiddleware>();

            app.UseMiddleware<SerilogRequestLogger>()
            app.UseStaticFiles();
            app.UseSwagger(SwaggerHelper.ConfigureSwagger);
            app.UseSwaggerUI(SwaggerHelper.ConfigureSwaggerUI);

            // force the request to use https traffic
            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
