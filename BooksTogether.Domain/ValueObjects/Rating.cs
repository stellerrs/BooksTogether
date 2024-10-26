using BooksTogether.Domain.Common;

namespace BooksTogether.Domain.ValueObjects;

public class Rating : ValueObject
{
    private Rating(double value)
    {
        Value = value;
    }

    public double Value { get; }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        throw new NotImplementedException();
    }

    public static Result<Rating> Create()
    {
        return Result<Rating>.Success(new Rating(0));
    }
}