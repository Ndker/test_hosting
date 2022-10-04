using Vostok.Hosting.Abstractions;
using Vostok.Logging.Abstractions;

namespace VostokHostConsoleApp;

public class VostokHostApplication : IVostokApplication
{
    public Task InitializeAsync(IVostokHostingEnvironment environment)
    {
        return Task.CompletedTask;
    }

    public async Task RunAsync(IVostokHostingEnvironment environment)
    {
        while (!environment.ShutdownToken.IsCancellationRequested)
        {
            environment.Log.Info("Doing my job...");
            await Task.Delay(1000, environment.ShutdownToken).ConfigureAwait(false);
        }
    }
}