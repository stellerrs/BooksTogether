using BooksTogether.Domain.Common;
using BooksTogether.Domain.Errors;

namespace BooksTogether.Domain.ValueObjects;

public class PublishDate : ValueObject
{
    private PublishDate(DateOnly date)
    {
        Value = date;
    }
    
    public DateOnly Value { get; private set; }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    private Error Validate(DateOnly date)
    {
        var dateNow = DateOnly.FromDateTime(DateTime.Now);
        
        if (date > dateNow)
        {
            return PublishDateErrors.DateGreaterThanNow();
        }
        if (date < DateOnly.MinValue || date > DateOnly.MaxValue)
        {
            return PublishDateErrors.InvalidDate();
        }
        
        return Error.None;
    }
    
    public Result<PublishDate> Create(DateOnly date)
    {
        var error = Validate(date);

        if (error == Error.None)
        {
            return Result<PublishDate>.Success(new PublishDate(date));
        }
        return Result<PublishDate>.Failure(error);
    }
}