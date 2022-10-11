using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Vostok.Commons.Time;
using Vostok.Hosting;
using Vostok.Hosting.Abstractions.Helpers;
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
        var disposables = new List<IDisposable>();
        var shutdownTokenSource = new CancellationTokenSource();

        var environment = VostokHostingEnvironmentFactory.Create(
            WrapSetupDelegate(setupEnvironment, shutdownTokenSource), settings);

        applicationBuilder.Logging.SetupVostok(environment);
        applicationBuilder.Configuration.SetupVostok(environment);
        applicationBuilder.SetupWebHost(environment, disposables);
        applicationBuilder.Services
            .SetupVostok(environment)
            .SetupVostokShutdown(environment, new VostokHostShutdown(shutdownTokenSource))
            .AddSingleton(new DisposableContainer(disposables));
    }

    private static VostokHostingEnvironmentSetup WrapSetupDelegate(VostokHostingEnvironmentSetup setup,
        CancellationTokenSource shutdownTokenSource)
    {
        return builder =>
        {
            builder.SetupShutdownToken(shutdownTokenSource.Token);
            builder.SetupShutdownTimeout(15.Seconds());
            // builder.SetupShutdownTimeout(ShutdownConstants.DefaultShutdownTimeout);
            builder.SetupHostExtensions(
                extensions =>
                {
                    var vostokHostShutdown = new VostokHostShutdown(shutdownTokenSource);
                    extensions.Add(vostokHostShutdown);
                    extensions.Add(typeof(IVostokHostShutdown), vostokHostShutdown);
                });

            setup(builder);
        };
    }
}