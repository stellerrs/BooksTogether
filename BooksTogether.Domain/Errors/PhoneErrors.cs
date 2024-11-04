using BooksTogether.Domain.Common;
using BooksTogether.Domain.Enums;

namespace BooksTogether.Domain.Errors;

public static class PhoneErrors
{
    private const string Code = "Phone Errors";
    
    public static Error InvalidPhoneNumberFormat() => new Error(Code, "Invalid phone number", ErrorType.Validation);
}