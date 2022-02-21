namespace MoraviaIT.ConsoleApp.Interfaces;

public interface IDeserializeConverter<T>
    where T : class, new()
{
    public T Deserialize(string message);
}
