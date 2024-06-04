using System.Runtime.Serialization;

namespace ProjectManager.Application.Exceptions;

[Serializable]
public class ProjectDontHaveDesignObjectsException : Exception
{
    public ProjectDontHaveDesignObjectsException()
    {
    }

    public ProjectDontHaveDesignObjectsException(string? message) : base(message)
    {
    }

    public ProjectDontHaveDesignObjectsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected ProjectDontHaveDesignObjectsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}