namespace WebApplicationApp.Setup.Application;

public class DisposableContainer
{
    private readonly List<IDisposable> _disposables;

    public DisposableContainer(List<IDisposable> disposables)
    {
        _disposables = disposables;
    }

    public void DoDispose()
    {
        _disposables.ForEach(disposable => disposable?.Dispose());
    }
}