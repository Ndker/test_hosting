using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Vostok.Hosting.Abstractions;
using Vostok.Logging.Abstractions;

namespace WebApplicationApp.Setup;

public class VostokApplicationLifeTimeService : IHostedService
{
    private readonly IHostApplicationLifetime _applicationLifetime;
    private readonly IVostokHostingEnvironment _environment;

    private readonly ILogger _logger;
    private readonly ILog _log; 

    public VostokApplicationLifeTimeService(
        IHostApplicationLifetime applicationLifetime,
        IVostokHostingEnvironment environment,
        ILogger logger)
    {
        _applicationLifetime = applicationLifetime;
        _environment = environment;
        _logger = logger;

        _log = environment.Log.ForContext<VostokApplicationLifeTimeService>();
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
    
    private void OnStarted() {
        _logger.LogInformation("Logger OnStarted");
        _log.Info("VostokLog OnStarted");
        
        _environment.ServiceBeacon.Start();

        // Perform post-startup activities here
    }

    private void OnStopping() {
        _logger.LogInformation("Logger OnStopping");
        _log.Info("VostokLog OnStopping");

        // Perform on-stopping activities here
    }

    private void OnStopped() {
        _logger.LogInformation("Logger OnStopped");
        _log.Info("VostokLog OnStopped");
        
        _environment.ServiceBeacon.Stop();

        // Perform post-stopped activities here
    }  
}