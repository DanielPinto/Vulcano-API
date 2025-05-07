using Vulcano.Domain.Enuns;

namespace Vulcano.Domain.Utils;
public class Result
{
    public bool IsSuccess { get; protected set; }
    public List<string> Errors { get; protected set; } = new();
    public int StatusCode { get; protected set; }
    public ErrorCode ErrorCode { get; protected set; }

    public bool IsFailure => !IsSuccess;

    public static Result Success(int statusCode = 200)
        => new()
        { IsSuccess = true, StatusCode = statusCode };

    public static Result Failure(string errorMessage, ErrorCode errorCode = ErrorCode.Unexpected, int statusCode = 400)
        => new()
        {
            IsSuccess = false,
            StatusCode = statusCode,
            ErrorCode = errorCode,
            Errors = new List<string> { errorMessage }
        };

    public static Result Failure(List<string> errorMessages, ErrorCode errorCode = ErrorCode.Validation, int statusCode = 400)
        => new()
        {
            IsSuccess = false,
            StatusCode = statusCode,
            ErrorCode = errorCode,
            Errors = errorMessages
        };
}

public class Result<T> : Result
{
    public T? Data { get; private set; }

    public static Result<T> Success(T data, int statusCode = 200)
        => new()
        { IsSuccess = true, StatusCode = statusCode, Data = data };

    public static new Result<T> Failure(string errorMessage, ErrorCode errorCode = ErrorCode.Unexpected, int statusCode = 400)
        => new()
        {
            IsSuccess = false,
            StatusCode = statusCode,
            ErrorCode = errorCode,
            Errors = new List<string> { errorMessage }
        };

    public static new Result<T> Failure(List<string> errorMessages, ErrorCode errorCode = ErrorCode.Validation, int statusCode = 400)
        => new()
        {
            IsSuccess = false,
            StatusCode = statusCode,
            ErrorCode = errorCode,
            Errors = errorMessages
        };
}