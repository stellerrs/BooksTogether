using BooksTogether.Domain.Common;
using BooksTogether.Domain.Enums;

namespace BooksTogether.Domain.Errors;

public static class UserImageErrors
{
    private const string Code = "User Image Errors";
    
    public static Error EmptyFormat() => new Error(Code, "Image format cannot be empty.", ErrorType.Validation);
}