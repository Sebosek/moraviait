namespace MoraviaIT.ConsoleApp.Interfaces.Services;

public interface IFiles
{
    Task<string> ReadAsync(string path);
    Task WriteAsync(string path, string content);
}