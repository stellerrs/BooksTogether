using BooksTogether.Domain.Common;
using BooksTogether.Domain.Enums;

namespace BooksTogether.Domain.Errors;

public class UsernameErrors
{
    private const string Code = "Username Errors";
    
    public static Error EmptyUsername() => new(Code, $"Empty username.'", ErrorType.Validation);
}