using Microsoft.Extensions.Logging;
using Vostok.Applications.AspNetCore.Helpers;
using Vostok.Hosting.Abstractions;
using Vostok.Logging.Microsoft;

namespace WebApplicationApp.Setup.Builder;

public static class LoggingBuilderExtensions
{
    public static void SetupVostok(this ILoggingBuilder builder, IVostokHostingEnvironment environment)
    {
        builder.AddVostokLogging(environment, new VostokLoggerProviderSettings());
    }
}