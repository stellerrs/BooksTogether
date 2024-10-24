namespace BooksTogether.Domain.Common;

public interface IResult
{
    bool IsSuccess { get; }
    bool IsFailure => !IsSuccess;
    Error Error { get; }
}