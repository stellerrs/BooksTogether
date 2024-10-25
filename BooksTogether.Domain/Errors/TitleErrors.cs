using BooksTogether.Domain.Common;
using BooksTogether.Domain.Enums;

namespace BooksTogether.Domain.Errors;

public static class TitleErrors
{
    private const string Code = "Title Errors";
    
    public static Error EmpyTitle() => new Error(Code, "Title cannot be empty.", ErrorType.Validation);
}