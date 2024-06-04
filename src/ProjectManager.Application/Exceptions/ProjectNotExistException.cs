using System.Runtime.Serialization;

namespace ProjectManager.Application.Exceptions;

[Serializable]
public class ProjectNotExistException : Exception
{
    public ProjectNotExistException()
    {
    }

    public ProjectNotExistException(string? message) : base(message)
    {
    }

    public ProjectNotExistException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ProjectNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}