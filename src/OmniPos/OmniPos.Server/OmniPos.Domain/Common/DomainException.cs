using System.Numerics;
using System.Runtime.CompilerServices;

namespace OmniPos.Domain.Common;

public class DomainException : Exception
{
    public DomainException()
    {
    }

    public DomainException(string message)
        : base(message)
    {
    }

    public DomainException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public static void ThrowIfNull<T>(T? value, [CallerArgumentExpression(nameof(value))] string paramName = "") where T : class
    {
        if (value is null)
        {
            throw new DomainException($"{paramName} cannot be null.");
        }
    }

    public static void ThrowIfNullOrEmpty(string? value, [CallerArgumentExpression(nameof(value))] string paramName = "")
    {
        if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException($"{paramName} cannot be null or empty.");
        }
    }

    public static void ThrowIfPositive<T>(T value, [CallerArgumentExpression(nameof(value))] string paramName = "") where T : INumber<T>
    {
        if (value <= T.Zero)
        {
            throw new DomainException($"{paramName} must be a positive number.");
        }
    }

    public static void ThrowIfNegative<T>(T value, [CallerArgumentExpression(nameof(value))] string paramName = "") where T : INumber<T>
    {
        if (value < T.Zero)
        {
            throw new DomainException($"{paramName} cannot be negative.");
        }
    }
}
