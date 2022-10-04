using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GenericHostConsoleApp;

public class GenericHostApplication : IHostedService
{
    private readonly ILogger _logger;

    public GenericHostApplication(ILogger<GenericHostApplication> logger)
    {
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            _logger.Log(LogLevel.Information, "Doing my job...");
            await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.Log(LogLevel.Information, "Done my job");
        return Task.CompletedTask;
    }
}