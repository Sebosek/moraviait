namespace MoraviaIT.ConsoleApp.Interfaces;

public interface IReader<T>
    where T : class, new()
{
    Task<T> ReadAsync(IDeserializeConverter<T> converter);
}
