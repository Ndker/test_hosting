using Vostok.Hosting;
using Vostok.Hosting.Kontur;
using Vostok.Hosting.Setup;

namespace VostokHostConsoleApp;

class EntryPoint
{
    static Task Main(string[] args)
    {
        var application = new VostokHostApplication();

        void EnvironmentSetup(IVostokHostingEnvironmentBuilder builder)
        {
            builder
                .SetupApplicationIdentity(identityBuilder => identityBuilder
                    //.SetProject("Vostok_Core_App_Kontur_Tests")
                    .SetProject("vostok.core.app.kontur.tests")
                    .SetEnvironment("dev")
                    .SetApplication("teneneva_hosting_test"))
                .SetupLog(logBuilder => logBuilder
                    .SetupConsoleLog())
                .SetPort(4455);
        }

        var hostSettings = new VostokHostSettings(application, EnvironmentSetup)
            .SetupForKontur();

        var host = new VostokHost(hostSettings);

        return host.WithConsoleCancellation().RunAsync();
    }
}