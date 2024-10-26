using BooksTogether.Domain.Common;
using BooksTogether.Domain.Enums;

namespace BooksTogether.Domain.Errors;

public static class BookCoverErrors
{
    private const string Code = "Book Cover Errors";
    
    public static Error EmptyFormat() => new Error(Code, "Image format cannot be empty.", ErrorType.Validation);
}