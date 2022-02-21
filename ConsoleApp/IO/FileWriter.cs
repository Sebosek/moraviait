using MoraviaIT.ConsoleApp.DTOs;
using MoraviaIT.ConsoleApp.Interfaces;
using MoraviaIT.ConsoleApp.Interfaces.Converters;
using MoraviaIT.ConsoleApp.Interfaces.Services;

namespace MoraviaIT.ConsoleApp.IO;

internal class FileWriter : IWriter<Document>
{
    private readonly IFiles _files;
    
    private readonly string _path;

    public FileWriter(IFiles files, string path)
    {
        _files = files;
        _path = path;
    }

    public Task WriteAsync(Document data, ISerializeConverter<Document> serializer)
    {
        var sanitized = serializer ?? throw new ArgumentNullException(nameof(serializer));
        var serialized = sanitized.Serialize(data);

        return _files.WriteAsync(_path, serialized);
    }
}
