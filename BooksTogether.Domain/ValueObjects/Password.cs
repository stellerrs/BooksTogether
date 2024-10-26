using BooksTogether.Domain.Common;
using BooksTogether.Domain.Errors;

namespace BooksTogether.Domain.ValueObjects;

public class Password : ValueObject
{
    private const int MinLength = 6;

    private Password(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<Password> Create(string value)
    {
        var validationError = Validate(value);

        return validationError == Error.None
            ? Result<Password>.Success(new Password(value))
            : Result<Password>.Failure(validationError);
    }

    private static Error Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return PasswordErrors.InvalidPassword(value);
        }
        if (value.Length < MinLength)
        {
            return PasswordErrors.ShortPassword(value, MinLength);
        }
            
        return Error.None;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}