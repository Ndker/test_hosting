using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Vostok.Hosting;
using Vostok.Hosting.Components.Environment;
using Vostok.Hosting.Setup;
using Vostok.Logging.Microsoft;

namespace WebApplicationApp.Setup;

public static class WebApplicationBuilderExtensions
{
    public static void SetupVostok(this WebApplicationBuilder applicationBuilder,
        VostokHostingEnvironmentSetup setupEnvironment)
    {
        // var environment = VostokWebApplicationBuilder.Build(setupEnvironment);
        var environmentFactorySettings = new VostokHostingEnvironmentFactorySettings();
        var environment = EnvironmentBuilder.Build(setupEnvironment, environmentFactorySettings);

        // TODO Get environment log 

        applicationBuilder.Logging.ClearProviders();
        applicationBuilder.Logging.AddProvider(
            new VostokLoggerProvider(environment.Log, new VostokLoggerProviderSettings())
        );

        applicationBuilder.Services
            .AddVostokEnvironment(environment)
            .AddHostedService<VostokApplicationLifeTimeService>();


        // TODO add init step - run service beacon - before run - after listening port



        // applicationBuilder.Logging.Configure()
    }
}