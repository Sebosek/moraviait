using MoraviaIT.ConsoleApp.Interfaces.Services;

namespace MoraviaIT.ConsoleApp.Services;

internal class Files : IFiles
{
    public async Task<string> ReadAsync(string path)
    {
        await using var sourceStream = File.Open(path, FileMode.Open);
        using var reader = new StreamReader(sourceStream);

        return await reader.ReadToEndAsync();
    }

    public async Task WriteAsync(string path, string content)
    {
        await using var stream = File.Open(path, FileMode.Create, FileAccess.Write);
        await using var sw = new StreamWriter(stream);

        await sw.WriteAsync(content);
    }
}