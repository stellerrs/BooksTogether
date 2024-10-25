using BooksTogether.Domain.Common;
using BooksTogether.Domain.Errors;

namespace BooksTogether.Domain.ValueObjects;

public class GenreName : ValueObject
{
    private GenreName(string value)
    {
        Value = value;
    }
    
    public string Value { get; }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<GenreName> Create(string name)
    {
        if (string.IsNullOrEmpty(name))
            return Result<GenreName>.Failure(GenreNameErrors.EmptyName());

        return Result<GenreName>.Success(new GenreName(name));
    }
}