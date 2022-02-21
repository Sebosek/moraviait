using System.Text.Json;

using MoraviaIT.ConsoleApp.DTOs;
using MoraviaIT.ConsoleApp.Interfaces;
using MoraviaIT.ConsoleApp.Interfaces.Converters;

namespace MoraviaIT.ConsoleApp.Converters;

internal class JsonSerializeConverter : ISerializeConverter<Document>
{
    public string Serialize(Document data) => JsonSerializer.Serialize(data);
}
