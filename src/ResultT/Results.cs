namespace ResultT;

public class Result
{
    public bool Success { get; }
    public Error? Error { get; }
    public string? ErrorMessage => Error?.Message;

    internal Result() => (Success, Error) = (true, null);
    internal Result(Error error) => (Success, Error) = (false, error);

    public static implicit operator Result(Error error) => new Result(error);
}

public class Result<T> : Result
{
    public T? Value { get; private set; }

    internal Result(T? value) : base() => Value = value;
    internal Result(Error error) : base(error) => Value = default;

    public static implicit operator Result<T>(Error error) => new Result<T>(error);
}

public record Error(string? Message, Exception? Exception = null);

public class Results
{
    public static Result Ok() => new Result();
    public static Result<T> Ok<T>(T? value) => new Result<T>(value);

    public static Error Error(string? message = null, Exception? exception = null) => new Error(message, exception);
}
