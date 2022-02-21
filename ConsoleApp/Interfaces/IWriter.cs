using MoraviaIT.ConsoleApp.Interfaces.Converters;

namespace MoraviaIT.ConsoleApp.Interfaces;

internal interface IWriter<T>
    where T : class
{
    Task WriteAsync(T data, ISerializeConverter<T> serializer);
}
