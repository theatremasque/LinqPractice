namespace Tests.App.Extensions;

public interface ISource<T> where T : class
{
    protected IEnumerable<T>? Collection => GetSource();
    protected IEnumerable<T> GetSource();
}