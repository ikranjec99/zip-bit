﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace ZipBit.API.Extensions
{
    public static class WebHostBuilderExtensions
    {

        private static void HandleConfigureKestrel(KestrelServerOptions options)
        {
            options.AllowSynchronousIO = true;
        }

        public static IWebHostBuilder Configure(this IWebHostBuilder builder) =>
            builder.ConfigureKestrel(HandleConfigureKestrel)
                .ConfigureLogging((_, loggingBuilder) => loggingBuilder.ClearProviders());
    }
}
