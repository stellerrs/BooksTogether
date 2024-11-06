using BooksTogether.Domain.Common;
using BooksTogether.Domain.Enums;

namespace BooksTogether.Domain.Errors;

public static class PublishDateErrors
{
    private const string Code = "PublishDate Errors";
    
    public static Error DateGreaterThanNow() => new Error(Code, "Date value cannot be greater than now", ErrorType.Validation);
    public static Error InvalidDate() => new Error(Code, "Invalid date value", ErrorType.Validation);
}