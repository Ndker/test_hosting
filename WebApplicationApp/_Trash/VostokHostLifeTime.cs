using Vostok.Hosting.Abstractions;
using Vostok.Hosting.Models;

namespace WebApplicationApp._Trash;

public class VostokHostLifeTime
{
    private readonly IVostokHostingEnvironment _environment;

    public VostokHostLifeTime(IVostokHostingEnvironment environment)
    {
        _environment = environment;
    }

    public Task WaitForStartAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
    public Task StopAsync(CancellationToken cancellationToken)
    {
        _environment.ServiceBeacon.Stop();
        return Task.CompletedTask;

    }
    
}