using Microsoft.Extensions.Hosting;
using Vostok.Commons.Time;
using Vostok.Hosting.Abstractions;
using Vostok.Hosting.Helpers;
using Vostok.Logging.Abstractions;
using Vostok.ServiceDiscovery;

namespace WebApplicationApp.Setup.Application;

public class VostokApplicationLifeTimeService : IHostedService
{
    private readonly IHostApplicationLifetime _applicationLifetime;
    private readonly IVostokHostingEnvironment _environment;
    private readonly DisposableContainer _disposableContainer;

    private readonly ILog _log;

    public VostokApplicationLifeTimeService(
        IHostApplicationLifetime applicationLifetime,
        IVostokHostingEnvironment environment,
        DisposableContainer disposableContainer
    )
    {
        _applicationLifetime = applicationLifetime;
        _environment = environment;
        _disposableContainer = disposableContainer;

        _log = _environment.Log.ForContext<VostokApplicationLifeTimeService>();
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _environment.WarmUp(_log);

        _applicationLifetime.ApplicationStarted.Register(OnStartedAsync);
        _applicationLifetime.ApplicationStopping.Register(OnStopping);
        _applicationLifetime.ApplicationStopped.Register(OnStopped);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private async void OnStartedAsync()
    {
        _log.Info("Logger OnStarted");


        _environment.ServiceBeacon.Start();

        if (_environment.ServiceBeacon is ServiceBeacon convertedBeacon)
        {
            await convertedBeacon.WaitForInitialRegistrationAsync()
                .WaitAsync(10.Seconds())
                .ConfigureAwait(false);
        }
        

        // Perform post-startup activities here
    }

    private void OnStopping()
    {
        _log.Info("Logger OnStopping");

        _environment.ServiceBeacon.Stop();

        (_environment as IDisposable)?.Dispose();
        _disposableContainer.DoDispose();
    }

    private void OnStopped()
    {
        _log.Info("Logger OnStopped");
    }
}