namespace Financev1.Exceptions.CustomExceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) {}
}