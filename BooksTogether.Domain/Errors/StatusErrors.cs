using BooksTogether.Domain.Common;
using BooksTogether.Domain.Enums;

namespace BooksTogether.Domain.Errors;

public class StatusErrors
{
    private const string Code = "Status Errors";
    
    public static Error EmptyStatus() => new Error(Code, "Status cannot be empty.", ErrorType.Validation);
}