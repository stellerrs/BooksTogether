using System.Text.RegularExpressions;
using BooksTogether.Domain.Common;
using BooksTogether.Domain.Errors;

namespace BooksTogether.Domain.ValueObjects;

public partial class Phone : ValueObject
{
    private const string PhonePattern = "^8\\d{10}$";

    private Phone(string value)
    {
        Value = value;
    }
    
    public string Value { get; private set; }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<Phone> Create(string value)
    {
        if (!PhoneRegex().IsMatch(value))
        {
            return Result<Phone>.Failure(PhoneErrors.InvalidPhoneNumberFormat());
        }

        return Result<Phone>.Success(new Phone(value));
    }

    [GeneratedRegex(PhonePattern)]
    private static partial Regex PhoneRegex();
}