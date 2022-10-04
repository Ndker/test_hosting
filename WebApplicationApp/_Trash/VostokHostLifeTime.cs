using Vostok.Hosting.Models;

namespace WebApplicationApp._Trash;

public class VostokHostLifeTime
{
    private readonly VostokHostingEnvironment _environment;

    public VostokHostLifeTime(VostokHostingEnvironment environment)
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