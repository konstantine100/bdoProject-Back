namespace bdoProject.Domain.Common.Results;

public class Result
{
    public bool IsSuccess { get; }
    public ErrorResults? Error { get; }
    public bool IsFailure => !IsSuccess;

    protected Result(bool isSuccess, ErrorResults? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }
    
    public static Result Success() => new (true, null);
    public static Result Failure(ErrorResults error) => new (false, error);
}

public sealed class Result<T> : Result
{
    public T? Value { get; }

    public Result(bool isSuccess, T? value, ErrorResults? error) : base(isSuccess, error)
    {
        Value = value;
    }

    public static Result<T> Success(T value) => new(true, value, null);
    public static new Result<T> Failure(ErrorResults error) => new(false, default, error);
}