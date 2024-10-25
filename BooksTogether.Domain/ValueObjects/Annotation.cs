using BooksTogether.Domain.Common;
using BooksTogether.Domain.Errors;

namespace BooksTogether.Domain.ValueObjects;

public class Annotation : ValueObject
{
    private Annotation(string value) => Value = value;
    
    public string Value { get; }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<Annotation> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) 
            return Result<Annotation>.Failure(AnnotationErrors.EmptyAnnotation());
        
        return Result<Annotation>.Success(new Annotation(value));
    }
}