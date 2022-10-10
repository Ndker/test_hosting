using Microsoft.AspNetCore.Builder;
using Vostok.Hosting;
using Vostok.Hosting.Kontur;
using Vostok.Hosting.Setup;
using WebApplicationApp.Setup.Builder;

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

        webApplicationBuilder.SetupVostok(EnvironmentSetup, settings);
        
        var app = webApplicationBuilder.Build();

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
}