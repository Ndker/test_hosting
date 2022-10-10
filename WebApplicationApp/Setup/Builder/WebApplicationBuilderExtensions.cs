using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Vostok.Hosting;
using Vostok.Hosting.Setup;
using WebApplicationApp.Setup.Application;

namespace WebApplicationApp.Setup.Builder;

public static class WebApplicationBuilderExtensions
{
    public static void SetupVostok([NotNull] this WebApplicationBuilder applicationBuilder,
        VostokHostingEnvironmentSetup setupEnvironment) =>
        SetupVostok(applicationBuilder, setupEnvironment, new VostokHostingEnvironmentFactorySettings());

    public static void SetupVostok(this WebApplicationBuilder applicationBuilder,
        VostokHostingEnvironmentSetup setupEnvironment,
        [NotNull] VostokHostingEnvironmentFactorySettings settings
    )
    {
        List<IDisposable> disposables = new List<IDisposable>();
        
        var environment = VostokHostingEnvironmentFactory.Create(
            setupEnvironment, settings);

        applicationBuilder.Logging.SetupVostok(environment);
        applicationBuilder.Configuration.SetupVostok(environment);
        applicationBuilder.SetupWebHost(environment, disposables);
        applicationBuilder.Services.SetupVostok(environment);

        applicationBuilder.Services.AddSingleton(new DisposableContainer(disposables));
    }
}