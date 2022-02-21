using System.Runtime.Serialization;

namespace MoraviaIT.ConsoleApp.Exceptions;

[Serializable]
public sealed class MoraviaException : ApplicationException
{
    public MoraviaException()
    {
    }

    public MoraviaException(string? message) : base(message)
    {
    }

    public MoraviaException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    private MoraviaException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
