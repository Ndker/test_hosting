using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Vostok.Applications.AspNetCore.Builders;
using Vostok.Applications.AspNetCore.Kontur;
using Vostok.Hosting;
using Vostok.Hosting.Abstractions;
using Vostok.Hosting.Aspnetcore.Builder;
using Vostok.Hosting.Kontur;
using Vostok.Hosting.Setup;

namespace WebApplicationApp;

public static class EntryPoint
{
    static Task Main(string[] args)
    {
        var webApplicationBuilder = WebApplication.CreateBuilder(args);

        var settings = new VostokHostingEnvironmentFactorySettings();
        // {
        //     DiagnosticMetricsEnabled = true
        // };


        webApplicationBuilder.Services.AddMvcCore(options =>
            {
                options.ModelBinderProviders.Add(new DateTimeModelBinderProvider());
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
                options.EnableEndpointRouting = false;
            })
            .AddApplicationPart(Assembly.GetEntryAssembly())
            .AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                opt.SerializerSettings.Converters = new JsonConverter[]
                {
                    new StringEnumConverter()
                };
            })
            .SetCompatibilityVersion(CompatibilityVersion.Latest);

        webApplicationBuilder.WebHost.UseUrls("http://fedora:3001");

        webApplicationBuilder.SetupVostok(EnvironmentSetup, settings);
        webApplicationBuilder.SetupVostokWebApplication(WebApplicationSetup);

        var app = webApplicationBuilder.Build();

        app.UseMvc();

        app.MapGet("/", () => "Hello World!");

        // return app.Run();
        return app.RunAsync();

        // return app.RunAsync("http://fedora:3000");
    }

    private static void EnvironmentSetup(IVostokHostingEnvironmentBuilder builder)
    {
        builder
            .SetupApplicationIdentity(identityBuilder => identityBuilder
                //.SetProject("Vostok_Core_App_Kontur_Tests")
                .SetProject("vostok.core.app.kontur.tests")
                .SetEnvironment("dev")
                .SetApplication("teneneva_hosting_web_test"))
            .SetupLog(logBuilder => logBuilder
                .SetupConsoleLog())
            .SetPort(3001)
            .SetBaseUrlPath("fedora")
            .SetupForKontur()
            .SetupSystemMetrics(metrics =>
            {
                metrics.EnableHostMetricsLogging = true;
                metrics.EnableHostMetricsReporting = true;
            });
    }

    private static void WebApplicationSetup(IVostokAspNetCoreWebApplicationBuilder builder,
        IVostokHostingEnvironment environment)
    {
        builder.SetupForKontur();
    }
}