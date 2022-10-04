using Vostok.Hosting.Abstractions;
using Vostok.Hosting.Components.SystemMetrics;
using Vostok.Hosting.Setup;

namespace WebApplicationApp._Trash;

public class VostokWebApplicationBuilder : IVostokHostingEnvironmentBuilder
{
    public static IVostokHostingEnvironment Build(VostokHostingEnvironmentSetup setupEnvironment)
    {
        var builder = new VostokWebApplicationBuilder();
        setupEnvironment(builder);
        return builder.Build();

    }

    private IVostokHostingEnvironment Build()
    {
        return null;
    }

    public IVostokHostingEnvironmentBuilder SetupShutdownToken(CancellationToken shutdownToken)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupShutdownTimeout(TimeSpan shutdownTimeout)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupClusterConfigClient(Action<IVostokClusterConfigClientBuilder> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupClusterConfigClient(Action<IVostokClusterConfigClientBuilder, IVostokConfigurationSetupContext> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupConfiguration(Action<IVostokConfigurationBuilder> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupConfiguration(Action<IVostokConfigurationBuilder, IVostokConfigurationSetupContext> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupLog(Action<IVostokCompositeLogBuilder> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupLog(Action<IVostokCompositeLogBuilder, IVostokHostingEnvironmentSetupContext> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupHerculesSink(Action<IVostokHerculesSinkBuilder> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupHerculesSink(Action<IVostokHerculesSinkBuilder, IVostokHostingEnvironmentSetupContext> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupApplicationIdentity(Action<IVostokApplicationIdentityBuilder> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupApplicationIdentity(Action<IVostokApplicationIdentityBuilder, IVostokHostingEnvironmentSetupContext> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupApplicationLimits(Action<IVostokApplicationLimitsBuilder> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupApplicationLimits(Action<IVostokApplicationLimitsBuilder, IVostokHostingEnvironmentSetupContext> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupApplicationReplicationInfo(Action<IVostokApplicationReplicationInfoBuilder> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupApplicationReplicationInfo(Action<IVostokApplicationReplicationInfoBuilder, IVostokHostingEnvironmentSetupContext> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupTracer(Action<IVostokTracerBuilder> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupTracer(Action<IVostokTracerBuilder, IVostokHostingEnvironmentSetupContext> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupMetrics(Action<IVostokMetricsBuilder> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupMetrics(Action<IVostokMetricsBuilder, IVostokHostingEnvironmentSetupContext> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupDiagnostics(Action<IVostokDiagnosticsBuilder> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupDiagnostics(Action<IVostokDiagnosticsBuilder, IVostokHostingEnvironmentSetupContext> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupDatacenters(Action<IVostokDatacentersBuilder> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupDatacenters(Action<IVostokDatacentersBuilder, IVostokHostingEnvironmentSetupContext> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupZooKeeperClient(Action<IVostokZooKeeperClientBuilder> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupZooKeeperClient(Action<IVostokZooKeeperClientBuilder, IVostokHostingEnvironmentSetupContext> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupServiceBeacon(Action<IVostokServiceBeaconBuilder> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupServiceBeacon(Action<IVostokServiceBeaconBuilder, IVostokHostingEnvironmentSetupContext> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupServiceDiscoveryEventsContext(Action<IVostokServiceDiscoveryEventsContextBuilder> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupServiceDiscoveryEventsContext(Action<IVostokServiceDiscoveryEventsContextBuilder, IVostokHostingEnvironmentSetupContext> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupServiceLocator(Action<IVostokServiceLocatorBuilder> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupServiceLocator(Action<IVostokServiceLocatorBuilder, IVostokHostingEnvironmentSetupContext> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupHostExtensions(Action<IVostokHostExtensionsBuilder> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupHostExtensions(Action<IVostokHostExtensionsBuilder, IVostokHostingEnvironment> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupSystemMetrics(Action<SystemMetricsSettings> setup)
    {
        throw new NotImplementedException();
    }

    public IVostokHostingEnvironmentBuilder SetupSystemMetrics(Action<SystemMetricsSettings, IVostokHostingEnvironment> setup)
    {
        throw new NotImplementedException();
    }

}