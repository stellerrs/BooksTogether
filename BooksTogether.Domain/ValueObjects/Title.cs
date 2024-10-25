using BooksTogether.Domain.Common;
using BooksTogether.Domain.Errors;

namespace BooksTogether.Domain.ValueObjects;

public class Title : ValueObject
{
    private Title(string value)
    {
        Value = value;
    }

    public string Value { get; }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<Title> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result<Title>.Failure(TitleErrors.EmpyTitle());

        return Result<Title>.Success(new Title(value));
    }
}