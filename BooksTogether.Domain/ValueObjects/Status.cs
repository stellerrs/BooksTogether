using BooksTogether.Domain.Common;
using BooksTogether.Domain.Errors;

namespace BooksTogether.Domain.ValueObjects;

public class Status : ValueObject
{
    private Status(string value)
    {
        Value = value;
    }

    public string Value { get; }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<Status> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result<Status>.Failure(StatusErrors.EmptyStatus());
        
        return Result<Status>.Success(new Status(value));
    }
}