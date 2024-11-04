using BooksTogether.Domain.Common;
using BooksTogether.Domain.Errors;

namespace BooksTogether.Domain.ValueObjects;

public class Price : ValueObject
{
    private Price(decimal value)
    {
        Value = value;    
    }
    
    public decimal Value { get; private set; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<Price> Create(decimal value)
    {
        if (value < 0)
            return Result<Price>.Failure(PriceErrors.NegativeValue(value));
        
        return Result<Price>.Success(new Price(value));
    }
}