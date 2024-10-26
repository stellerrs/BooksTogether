using BooksTogether.Domain.Common;
using BooksTogether.Domain.Enums;

namespace BooksTogether.Domain.Errors;

public static class PasswordErrors
{
    private const string Code = "PasswordErrors";
    
    public static Error InvalidPassword(string password) => 
        new(Code, $"Invalid password: '{password}'", ErrorType.Validation);
    
    public static Error ShortPassword(string password, int minLenght) =>
        new(Code, $"Password must be at least {minLenght} characters long: '{password}'", ErrorType.Validation);
}