using Vostok.Hosting;
using Vostok.Hosting.Kontur;
using Vostok.Hosting.Setup;

namespace VostokHostWebApp;

class EntryPoint
{
    static Task Main(string[] args)
    {
        var application = new VostokHostWebApplication();

        var hostSettings = new VostokHostSettings(application, EnvironmentSetup)
            .SetupForKontur();

        var host = new VostokHost(hostSettings);

        return host.WithConsoleCancellation().WithSigtermCancellation().RunAsync();
    }
    
    static void EnvironmentSetup(IVostokHostingEnvironmentBuilder builder)
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
            .SetBaseUrlPath("fedora");
    }
}