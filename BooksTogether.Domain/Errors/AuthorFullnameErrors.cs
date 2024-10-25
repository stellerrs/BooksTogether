using BooksTogether.Domain.Common;
using BooksTogether.Domain.Enums;

namespace BooksTogether.Domain.Errors;

public static class AuthorFullnameErrors
{
    private const string Code = "Author Fullname Errors";
    
    public static Error EmptyFullname() => new Error(Code, "Fullname cannot be empty.", ErrorType.Validation);
}