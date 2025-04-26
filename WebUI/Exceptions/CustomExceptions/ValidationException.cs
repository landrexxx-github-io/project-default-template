namespace Financev1.Exceptions.CustomExceptions;

public class ValidationException : Exception
{
    public ValidationException(string message) : base(message) {}
}