using MoraviaIT.ConsoleApp.DTOs;
using MoraviaIT.ConsoleApp.Interfaces;
using MoraviaIT.ConsoleApp.Interfaces.Services;

namespace MoraviaIT.ConsoleApp.IO;

internal class FileReader : IReader<Document>
{
    private readonly IFiles _files;
    
    private readonly string _path;

    public FileReader(IFiles files, string path)
    {
        _files = files;
        _path = path;
    }

    public async Task<Document> ReadAsync(IDeserializeConverter<Document> converter)
    {
        var input = await _files.ReadAsync(_path);
        if (input is null) throw new ArgumentNullException(input);

        return converter.Deserialize(input);
    }
}
