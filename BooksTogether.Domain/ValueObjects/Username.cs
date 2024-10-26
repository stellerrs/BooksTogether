using BooksTogether.Domain.Common;
using BooksTogether.Domain.Errors;

namespace BooksTogether.Domain.ValueObjects;

public class Username : ValueObject
{
    private Username(string value)
    {
        Value = value;
    }

    public string Value { get; }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<Username> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result<Username>.Failure(UsernameErrors.EmptyUsername());

        return Result<Username>.Success(new Username(value));
    }
}