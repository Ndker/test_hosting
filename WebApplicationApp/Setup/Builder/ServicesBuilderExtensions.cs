using Microsoft.Extensions.DependencyInjection;
using Vostok.Applications.AspNetCore.Helpers;
using Vostok.Hosting.Abstractions;
using Vostok.Hosting.Abstractions.Helpers;
using WebApplicationApp.Setup.Application;

namespace WebApplicationApp.Setup.Builder;

public static class ServicesBuilderExtensions
{
    public static IServiceCollection SetupVostok(this IServiceCollection services,
        IVostokHostingEnvironment environment)
    {
        services
            .AddVostokEnvironment(environment)
            .AddHostedService<VostokApplicationLifeTimeService>();
        return services;
    }

    public static IServiceCollection SetupVostokShutdown(this IServiceCollection services,
        IVostokHostingEnvironment environment,
        IVostokHostShutdown vostokHostShutdown)
    {
        services.AddSingleton(vostokHostShutdown);
        return services;
    }
}