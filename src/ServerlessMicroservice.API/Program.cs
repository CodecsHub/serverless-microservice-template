using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace ServerlessMicroservice.API
{
    /// <summary>
    ///
    /// </summary>
    public class Program
    {
        /// <summary>
        /// @todo: https://asp.net-hacker.rocks/2018/09/24/customizing-aspnetcore-02-configuration.html refactor
        /// </summary>
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? ""}.json", optional: true)
        .AddEnvironmentVariables()
        .Build();

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.WithProperty("App Name", "Serilog Web App Sample")
                    //  .MinimumLevel.Debug()
                    //  .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    //  .WriteTo.ApplicationInsights("sdafsadfasdf")
                // .WriteTo
                //    .ApplicationInsights(TelemetryConfiguration.Active, TelemetryConverter.Traces)
                .CreateLogger();

            try
            {
                Log.Information("Getting the motors running...");

                BuildWebHost(args).Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>()

                   .UseConfiguration(Configuration)
                   .UseSerilog()
                   .UseKestrel(options =>
                   {
                       options.Listen(IPAddress.Loopback, 5000);
                       options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                       {
                           // Will study about the use https request certificate
                           //listenOptions.UseHttps("certificate.pfx", "topsecret");
                       });
                   })
                   .Build();

    }
}
