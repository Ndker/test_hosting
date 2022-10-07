using Microsoft.AspNetCore.Hosting;
using Vostok.Applications.AspNetCore.Builders;
using Vostok.Applications.AspNetCore.HostBuilders;
using Vostok.Hosting.Abstractions;

namespace WebApplicationApp.Setup.Builder;

public static class WebHostBuilderExtensions
{
    public static void SetupVostok(this IWebHostBuilder webHostBuilder, IVostokHostingEnvironment environment, List<IDisposable> disposables)
    {
        var kestrelBuilder = new VostokKestrelBuilder();
        var throttlingBuilder = new VostokThrottlingBuilder(environment, disposables);
        var middlewaresBuilder = new VostokMiddlewaresBuilder(environment, disposables, throttlingBuilder);
        var vostokWebHostBuilder = new VostokWebHostBuilder(environment, kestrelBuilder, middlewaresBuilder, disposables, null);
        
        vostokWebHostBuilder.ConfigureWebHost(webHostBuilder);
    }
}