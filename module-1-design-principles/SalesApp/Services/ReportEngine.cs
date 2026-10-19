namespace SalesApp.Services;

// A "future-proof" reporting framework written for the day the app needs it.
// Nothing in the app uses it yet.

public interface IReportPlugin<TInput, TOutput>
{
    string Name { get; }
    int Priority { get; }
    bool CanHandle(TInput input);
    Task<TOutput> ExecuteAsync(TInput input, IReportContext context);
}

public interface IReportContext
{
    IDictionary<string, object> Items { get; }
    IReportPipeline Pipeline { get; }
}

public interface IReportPipeline
{
    void Register<TInput, TOutput>(IReportPlugin<TInput, TOutput> plugin);
    Task<TOutput?> RunAsync<TInput, TOutput>(TInput input);
}

public class ReportPipeline : IReportPipeline, IReportContext
{
    private readonly List<object> _plugins = new();

    public IDictionary<string, object> Items { get; } = new Dictionary<string, object>();
    public IReportPipeline Pipeline => this;

    public void Register<TInput, TOutput>(IReportPlugin<TInput, TOutput> plugin) => _plugins.Add(plugin);

    public async Task<TOutput?> RunAsync<TInput, TOutput>(TInput input)
    {
        var plugin = _plugins
            .OfType<IReportPlugin<TInput, TOutput>>()
            .OrderBy(p => p.Priority)
            .FirstOrDefault(p => p.CanHandle(input));

        return plugin == null ? default : await plugin.ExecuteAsync(input, this);
    }
}

public class ReportPipelineFactory
{
    public IReportPipeline Create() => new ReportPipeline();
}
