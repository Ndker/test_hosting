using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Vostok.Hosting.Abstractions;

namespace WebApplicationApp.Setup.Application;

public class VostokApplicationLifeTimeService : IHostedService
{
    private readonly IHostApplicationLifetime _applicationLifetime;
    private readonly IVostokHostingEnvironment _environment;
    private readonly DisposableContainer _disposableContainer;

    private readonly ILogger<VostokApplicationLifeTimeService> _logger;

    public VostokApplicationLifeTimeService(
        IHostApplicationLifetime applicationLifetime,
        IVostokHostingEnvironment environment,
        DisposableContainer disposableContainer,
        ILogger<VostokApplicationLifeTimeService> logger
    )
    {
        _applicationLifetime = applicationLifetime;
        _environment = environment;
        _logger = logger;
        _disposableContainer = disposableContainer;
        
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _applicationLifetime.ApplicationStarted.Register(OnStarted);
        _applicationLifetime.ApplicationStopping.Register(OnStopping);
        _applicationLifetime.ApplicationStopped.Register(OnStopped);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private void OnStarted()
    {
        _logger.LogInformation("Logger OnStarted");

        _environment.ServiceBeacon.Start();

        // Perform post-startup activities here
    }

    private void OnStopping()
    {
        _logger.LogInformation("Logger OnStopping");

        _environment.ServiceBeacon.Stop();

        (_environment as IDisposable)?.Dispose();
        _disposableContainer.DoDispose();

        // disposables.ForEach(disposable => disposable?.Dispose());
    }

    private void OnStopped()
    {
        _logger.LogInformation("Logger OnStopped");
    }
}