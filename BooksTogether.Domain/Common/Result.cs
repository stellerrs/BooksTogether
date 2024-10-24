namespace BooksTogether.Domain.Common;


public class Result : IResult
{
    private Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }
    
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }
    
    public static Result Success() => new Result(true, Error.None);
    public static Result Failure(Error error) => new Result(false, error);

    public static Result Combine(params Result[] results)
    {
        foreach (var result in results)
        {
            if (result.IsFailure) return Failure(result.Error);
        }
        return Success();
    }
}


public class Result<T>
{
    private Result(bool isSuccess, Error error, T? value = default)
    {
        IsSuccess = isSuccess;
        Error = error;
        Value = value;
    }
    
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }
    public T? Value { get; }
    
    public static Result<T> Success(T value) => new Result<T>(true, Error.None, value);
    public static Result<T> Failure(Error error) => new Result<T>(false, error);

    public static Result<T> Combine(params Result<T>[] results)
    {
        foreach (var result in results)
        {
            if (result.IsFailure) return Failure(result.Error);
        }
        return Success(results.Last().Value!);
    }
}