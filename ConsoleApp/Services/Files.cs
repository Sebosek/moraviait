using MoraviaIT.ConsoleApp.Interfaces.Services;

namespace MoraviaIT.ConsoleApp.Services;

internal class Files : IFiles
{
    public Task<string> ReadAsync(string path)
    {
        using var sourceStream = File.Open(path, FileMode.Open);
        using var reader = new StreamReader(sourceStream);

        return reader.ReadToEndAsync();
    }

    public Task WriteAsync(string path, string content)
    {
        using var stream = File.Open(path, FileMode.Create, FileAccess.Write);
        using var sw = new StreamWriter(stream);

        return sw.WriteAsync(content);
    }
}