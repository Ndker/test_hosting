using Microsoft.AspNetCore.Builder;
using Vostok.Applications.AspNetCore;
using Vostok.Applications.AspNetCore.Builders;
using Vostok.Hosting.Abstractions;

namespace VostokHostWebApp;

public class VostokHostWebApplication : VostokAspNetCoreWebApplication
{
    public override Task SetupAsync(IVostokAspNetCoreWebApplicationBuilder builder,
        IVostokHostingEnvironment environment)
    {
        // builder.SetupWebApplication(webApplicationBuilder => webApplicationBuilder.Services.Add(...));
        builder.CustomizeWebApplication(webApplication => webApplication.MapGet("/", () => "Hello World!"));
        return Task.CompletedTask;
    }

    public override Task WarmupAsync(IVostokHostingEnvironment environment, WebApplication webApplication)
    {
        return Task.CompletedTask;
    }
}