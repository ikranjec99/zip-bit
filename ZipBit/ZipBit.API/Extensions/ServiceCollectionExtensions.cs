using Serilog.Events;
using Serilog;
using ZipBit.API.Helpers;
using ZipBit.API.Settings;
using ZipBit.Core.Configuration;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using ZipBit.API.Providers;
using ZipBit.API.Filters;
using ZipBit.Core.DataAccess.ZipBitDb.Interfaces;
using ZipBit.Core.DataAccess.ZipBitDb.Implementations;
using ZipBit.Core.DataAccess;
using ZipBit.Core.Business.Interfaces;
using ZipBit.Core.Business.Implementations;

namespace ZipBit.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private static IServiceCollection AddBusinessLayer(this IServiceCollection services) =>
            services
                    .AddScoped<IUrlAnalyticEventHandler, UrlAnalyticEventHandler>()
                    .AddScoped<IUrlHandler, UrlHandler>();

        private static IServiceCollection AddDataAccessLayer(this IServiceCollection services) =>
            services
                .AddSingleton<IDomainRepository, DomainRepository>()
                .AddSingleton<IUrlAnalyticRepository, UrlAnalyticRepository>()
                .AddSingleton<IUrlRepository, UrlRepository>()
                .AddSingleton<ISqlLogger, SqlLogger>();

        private static IServiceCollection AddSettings(this IServiceCollection services, AppSettings appSettings)
        {
            if (appSettings is null)
                throw new ArgumentNullException(nameof(appSettings));

            if (appSettings.ZipBitConnectionString is not null)
                services.AddSingleton<IConnectionStringConfiguration>(appSettings.ZipBitConnectionString);

            services.AddSingleton<ISqlLoggerConfiguration>(appSettings.SqlLogger);
            services.AddSingleton<IZipBitConfiguration>(appSettings.ZipBit);
            /*
             * It should be done like this and read from Dockerfile as environment variable, not as AppSettings object
            services.AddSingleton<IConnectionStringConfiguration>(new ConnectionStringElement
            {
                ExampleProjectDb = Environment.GetEnvironmentVariable("DATABASE_URL_EXAMPLE")
            });
            */

            return services;
        }

        private static IServiceCollection AddSerilog(this IServiceCollection services, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override(nameof(Microsoft), LogEventLevel.Information)
                .MinimumLevel.Override(nameof(System), LogEventLevel.Information)
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .Destructure.With<NullIgnoringDestructuringPolicy>()
                .CreateLogger();

            return services;
        }

        public static void AddServices(this IServiceCollection services, IConfiguration configuration, AppSettings appSettings)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Contact = new OpenApiContact
                    {
                        Name = "Ivan Kranjec"
                    },
                    Title = "Zip Bit API",
                    Version = "1.0"
                });
            });
            services.AddLogging(options => options.SetMinimumLevel(LogLevel.Debug));

            services
            .AddControllers(options =>
            {
                    options.EnableEndpointRouting = false;
                    options.RespectBrowserAcceptHeader = true;
                    options.Filters.Add(new ExceptionFilter(Log.Logger));
                });

            services
                .AddCors(options => options.AddPolicy(nameof(CorsPolicy),
                         builder =>
                         {
                             builder.AllowAnyOrigin()
                             .AllowAnyMethod()
                             .AllowAnyHeader();
                         }));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services
                .AddApiVersioning(setup =>
                {
                    setup.AssumeDefaultVersionWhenUnspecified = true;
                    setup.DefaultApiVersion = new ApiVersion(1, 0);
                    setup.ErrorResponses = new ApiVersioningErrorResponseProvider();
                })
                .AddRouting(options => options.LowercaseUrls = true)
                .AddSettings(appSettings)
                .AddBusinessLayer()
                .AddDataAccessLayer()
                .AddHttpContextAccessor();
        }
    }
}
