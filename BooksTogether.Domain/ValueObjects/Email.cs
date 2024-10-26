using System.Text.RegularExpressions;
using BooksTogether.Domain.Common;
using BooksTogether.Domain.Errors;

namespace BooksTogether.Domain.ValueObjects;

public partial class Email : ValueObject
{
    private const string EmailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

    private Email(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<Email> Create(string email)
    {
        var validationError = Validate(email);

        return validationError == Error.None
            ? Result<Email>.Success(new Email(email))
            : Result<Email>.Failure(validationError);
    }

    private static Error Validate(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return EmailErrors.EmptyEmail();
        
        if (!EmailRegex().IsMatch(email))
            return EmailErrors.InvalidEmail(email);

        return Error.None;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    [GeneratedRegex(EmailPattern)]
    private static partial Regex EmailRegex();
}