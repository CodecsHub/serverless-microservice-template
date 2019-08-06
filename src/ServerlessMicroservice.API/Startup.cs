using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ServerlessMicroservice.API
{
    public class Startup
    {
        //@referrence: https://exceptionnotfound.net/using-dapper-asynchronously-in-asp-net-core-2-1/
        private readonly IHostingEnvironment _environment;
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();

        }
    }
}
