namespace RealEstate.Domain.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException()
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string message, Exception inner) : base(message, inner)
    {
    }

    public NotFoundException(string entityName, Guid entityId)
        : base($"Entity '{entityName}' with ID '{entityId}' not found.")
    {
    }
}
