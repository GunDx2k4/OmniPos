using System.Runtime.CompilerServices;

namespace OmniPos.Application.Common;

public class ApplicationExeption : Exception
{
    public ApplicationExeption()
    {
    }
    public ApplicationExeption(string message)
        : base(message)
    {
    }
    public ApplicationExeption(string message, Exception inner)
        : base(message, inner)
    {
    }

    public static void ThrowIfNull<T>(T? value, [CallerArgumentExpression(nameof(value))] string paramName = "") where T : class
    {
        if (value is null)
        {
            throw new ApplicationExeption($"{paramName} cannot be null.");
        }
    }

    public static void ThrowIfEntityNotFound<T>(T? value, [CallerArgumentExpression(nameof(value))] string paramName = "") where T : class
    {
        if (value is null)
        {
            throw new ApplicationExeption($"{paramName} not found.");
        }
    }
}
