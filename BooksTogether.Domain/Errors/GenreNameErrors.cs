using BooksTogether.Domain.Common;
using BooksTogether.Domain.Enums;

namespace BooksTogether.Domain.Errors;

public static class GenreNameErrors
{
    private const string Code = "Genre Name Errors";
    
    public static Error EmptyName() => new Error(Code, "Name cannot be empty.", ErrorType.Validation); 
}