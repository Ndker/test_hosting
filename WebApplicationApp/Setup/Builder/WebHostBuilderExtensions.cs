using Microsoft.AspNetCore.Builder;
using Vostok.Applications.AspNetCore.Builders;
using Vostok.Applications.AspNetCore.Configuration;
using Vostok.Applications.AspNetCore.HostBuilders;
using Vostok.Hosting.Abstractions;

namespace WebApplicationApp.Setup.Builder;

public static class WebHostBuilderExtensions
{
    public static void SetupWebHost(this WebApplicationBuilder webApplicationBuilder,
        IVostokHostingEnvironment environment, List<IDisposable> disposables)
    {
        var kestrelBuilder = new VostokKestrelBuilder();
        var throttlingBuilder = new VostokThrottlingBuilder(environment, disposables);
        var middlewaresBuilder = new VostokMiddlewaresBuilder(environment, disposables, throttlingBuilder);
        middlewaresBuilder.Customize(PingApiSettingsSetup.Get(environment, webApplicationBuilder.GetType(), false));

        var vostokWebHostBuilder = new VostokWebHostBuilder(environment, kestrelBuilder, middlewaresBuilder,
            disposables, null);

        vostokWebHostBuilder.ConfigureWebHost(webApplicationBuilder);
    }
}