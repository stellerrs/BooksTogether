using BooksTogether.Domain.Common;
using BooksTogether.Domain.Enums;

namespace BooksTogether.Domain.Errors;

public static class EmailErrors
{
    private const string Code = "EmailErrors";
    
    public static Error InvalidEmail(string value) => new(Code, $"Invalid Email address: {value}", ErrorType.Validation);
    public static Error EmptyEmail() => new(Code, $"Empty Email address.", ErrorType.Validation);
}