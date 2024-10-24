namespace BooksTogether.Domain.Enums;

public enum ErrorType
{
    Failure,
    InternalServerError,
    Validation,
    Conflict,
    NotFound,
    Unauthorized,
}