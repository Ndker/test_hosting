using Microsoft.AspNetCore.Builder;
using Vostok.Hosting.Kontur;
using Vostok.Hosting.Setup;
using WebApplicationApp.Setup;

namespace WebApplicationApp;

public class EntryPoint
{
    static Task Main(string[] args)
    {
        var webApplicationBuilder = WebApplication.CreateBuilder(args);
        
        webApplicationBuilder.SetupVostok(EnvironmentSetup);

        // webApplicationBuilder.Services.Add();
        
        // webApplicationBuilder.Logging
        
        // webApplicationBuilder.Host.
        
        // webApplicationBuilder.WebHost
        

        var app = webApplicationBuilder.Build();
        

        app.MapGet("/", () => "Hello World!");

        // return app.Run();

        return app.RunAsync("http://fedora:3000");
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
            .SetupForKontur();
    }
}