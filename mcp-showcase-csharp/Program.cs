using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Server;
using System.Collections.Concurrent;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((context, services) =>
{
    services.AddMcpServer()
        .WithStdioServerTransport()
        .WithToolsFromAssembly();

    services.AddSingleton<ITodoService, TodoService>();
});

var app = builder.Build();

await app.RunAsync();

public interface ITodoService
{
    void AddTodoItem(string item);
    string[] GetTodoItems();
}

public class TodoService : ITodoService
{
    private readonly ConcurrentBag<string> _todoItems = new();

    public void AddTodoItem(string item)
    {
        _todoItems.Add(item);
    }

    public string[] GetTodoItems()
    {
        return _todoItems.ToArray();
    }
}

[McpServerToolType]
public static class TodoTools
{
    [McpServerTool]
    public static string AddTodoItem(ITodoService todoService, string item)
    {
        todoService.AddTodoItem(item);
        return $"Added: {item}";
    }

    [McpServerTool]
    public static string[] GetTodoItems(ITodoService todoService)
    {
        return todoService.GetTodoItems();
    }
}
