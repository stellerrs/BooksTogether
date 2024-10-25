using BooksTogether.Domain.Common;
using BooksTogether.Domain.Enums;

namespace BooksTogether.Domain.Errors;

public class PriceErrors
{
    private const string Code = "Price Errors";

    public static Error NegativeValue(decimal value) => new Error(Code, $"'{value}' is invalid price", ErrorType.Validation);
}