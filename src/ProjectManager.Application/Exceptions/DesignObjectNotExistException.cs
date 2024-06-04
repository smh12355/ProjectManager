using System.Runtime.Serialization;

namespace ProjectManager.Application.Exceptions;

[Serializable]
public class DesignObjectNotExistException : Exception
{
    public DesignObjectNotExistException()
    {
    }

    public DesignObjectNotExistException(string? message) : base(message)
    {
    }

    public DesignObjectNotExistException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected DesignObjectNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}