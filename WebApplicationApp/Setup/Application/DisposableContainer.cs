namespace WebApplicationApp.Setup.Application;

public class DisposableContainer
{
    private readonly List<IDisposable> disposables;

    public DisposableContainer(List<IDisposable> disposables)
    {
        this.disposables = disposables;
    }

    public void DoDispose()
    {
        disposables.ForEach(disposable => disposable?.Dispose());
    }
}