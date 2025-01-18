using System.Net;

namespace ResultT;

public partial class Result
{
    public bool Success { get; }
    public Error? Error { get; }
    public string? ErrorMessage => Error?.Message;
    public HttpStatusCode? StatusCodeError => Error?.StatusCode;

    public Result() => (Success, Error) = (true, null);
    public Result(Error error) => (Success, Error) = (false, error);
}

public partial class Result<T> : Result
{
    public T? Value { get; }

    public Result(T? value) : base() => Value = value;
    public Result(Error error) : base(error) => Value = default;
}

public record Error(string? Message, Exception? Exception = null, HttpStatusCode? StatusCode = null);