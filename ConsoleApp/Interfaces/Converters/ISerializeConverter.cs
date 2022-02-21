namespace MoraviaIT.ConsoleApp.Interfaces.Converters;

public interface ISerializeConverter<in T>
    where T : class
{
    public string Serialize(T data);
}
